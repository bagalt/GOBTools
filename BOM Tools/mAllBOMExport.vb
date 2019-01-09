
Imports Microsoft.Office.Interop
'Imports System.IO

Module mAllBOMExport

    '************************************
    'Module to export three collections for use in Proman
    'Part Creation, BOM Import, and BOM Compare
    '************************************


    Private mCollFullBOM As Collection 'collection to hold all the parts with correct parents for BOM Import
    Private mCollBOMInstances As Collection 'collection to hold all of the parts with instances of parent, used for full bom creation
    Private mCollPartCreate As Collection 'colection to hold all the new parts, manuf and purch and proman information, for Part Creation import
    Private mCollBomCompare As Collection 'collection to hold all the parts for the BOM compare listview

    Private mStartAssy As String 'holds the top level assembly name
    Private mYear As String 'variable to hold the current year as a string
    Private mParentAssy As String 'variable to hold the name of the parent assembly for a part
    Private mErrorStatus As Boolean 'variable to show if an error has occurred in any of the part info, used to display message about excel file
    Private mIsAssembly As Boolean 'flag for indicating if current occurrence is an assembly (true)
    Private mAddToBomCompCollection As Boolean 'flag for indicating if current part should be added to BOM compare collection or not

    Private Structure ParentStatus
        Public ErrorStatus As Boolean
        Public ParentName As String
    End Structure

    Public Structure BomImportSettings
        Public bBomImportIncBassy As Boolean
        Public bBomImportShowFasteners As Boolean
    End Structure

    Public Structure PartCreateSettings
        Public bPartCreatIncBassy As Boolean
    End Structure

    Public Structure BomCompareSettings
        Public bBomCompIncludeBAssy As Boolean 'Allow B49 Assemblies to be parents?
        Public bBomCompIncCAssy As Boolean 'include C49 Assy?
        Public bBomCompIncB39Children As Boolean 'include B39 children?
        Public bBomCompIncB45Children As Boolean 'include B45 children?
        Public bBomCompShowFasteners As Boolean 'toggle for showing fasteners, M900 parts
    End Structure

    Private mBomImportSettings As BomImportSettings
    Private mPartCreateSettings As PartCreateSettings
    Private mBomCompSettings As BomCompareSettings


    'enum to characterize the type of part that is identified
    'this helps with handling the different types of parts
    Private Enum PartType As Integer
        ManufPart = 1
        PurchPart = 2
        VirtualPart = 3
        OldPurchPart = 4
        BAssy = 5 'for B49, B0049 assemblies
        CAssy = 6 'for C49, C0049 assemblies
        StandardPart = 7
        BGEPart = 8
        BPHPart = 9
        M900Part = 10
        B39 = 11
        Unknown = 12
        Toplevel = 13
    End Enum

    Public mResults As String = "" 'variable used for displaying the results
    Public bomCompareList As Collection 'collection for all unique parts in an assembly
    Public partExportList As Collection
    Public bomImportList As Collection
    Public collAllParts As Collection 'public collection to show all parts


    Public Sub AssemblyCount(ThisApplication As Inventor.Application, BomImportConfig As BomImportSettings, PartCreateConfig As PartCreateSettings, BomCompConfig As BomCompareSettings, sDirectoryPath As String)
        ' Set reference to active document.
        ' This assumes the active document is an assembly
        Dim oDoc As Inventor.AssemblyDocument

        If ThisApplication.ActiveDocumentType <> Inventor.DocumentTypeEnum.kAssemblyDocumentObject Then
            MsgBox("Assembly document must be active")
            mResults = "No Report Created, Assembly must be active"
            Exit Sub
        End If

        oDoc = ThisApplication.ActiveDocument
        mCollFullBOM = New Collection
        mCollBOMInstances = New Collection
        mCollPartCreate = New Collection
        mCollBomCompare = New Collection

        ' Get assembly component definition
        Dim oCompDef As Inventor.ComponentDefinition
        oCompDef = oDoc.ComponentDefinition

        Dim sMsg As String
        Dim iLeafNodes As Long
        Dim iSubAssemblies As Long
        Dim sSubAssyName As String
        Dim assyDoc As Inventor.AssemblyDocument
        Dim colBreadCrumb As Collection
        Dim sFilePath As String
        'variables to hold information for each occurrence
        Dim occDoc As Inventor.Document
        Dim occProps As Inventor.PropertySets
        Dim occPartNum As String

        'Assign All parts and New Parts settings
        mBomImportSettings = BomImportConfig
        mPartCreateSettings = PartCreateConfig
        mBomCompSettings = BomCompConfig

        sMsg = ""
        mParentAssy = ""
        mErrorStatus = False
        mResults = ""

        'Get the current year,  then get the last two characters to get the year string
        mYear = Right(CStr(System.DateTime.Today.Year), 2)

        'get the starting assembly name, for display and excel file naming purposes
        mStartAssy = oDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value
        If mStartAssy = "" Then
            mStartAssy = oDoc.DisplayName
        End If

        ' Get all occurrences from component definition for Assembly document
        Dim oCompOcc As Inventor.ComponentOccurrence
        For Each oCompOcc In oCompDef.Occurrences
            'clear out breadcrumb collection, and add the starting assembly
            colBreadCrumb = Nothing
            colBreadCrumb = New Collection
            colBreadCrumb.Add(mStartAssy)

            Try
                occDoc = oCompOcc.Definition.Document
                occProps = occDoc.PropertySets
                If oCompOcc.Definition.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
                    'virtual parts have the part number in a different location for some reason
                    occPartNum = oCompOcc.Definition.propertysets.item("Design Tracking Properties").item("Part Number").value
                Else
                    'get occurrence part number
                    occPartNum = occProps.Item("Design Tracking Properties").Item("Part Number").Value
                End If

            Catch ex As Exception
                occPartNum = oCompOcc.Name
            End Try

            'check if occurrence is marked as reference or suppressed, dont do anything if it is reference or suppressed
            If Not ((oCompOcc.BOMStructure = Inventor.BOMStructureEnum.kReferenceBOMStructure) Or (oCompOcc.Suppressed = True)) Then  'if not reference or suppressed or phantom then continue
                'Check if it's child occurrence (leaf node)
                If oCompOcc.SubOccurrences.Count = 0 Then
                    'not a sub assembly
                    If oCompOcc.Definition.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
                        mParentAssy = mStartAssy
                        mIsAssembly = False
                        GetProps(oCompOcc, PartType.VirtualPart, colBreadCrumb)
                    ElseIf Not (oCompOcc.BOMStructure = Inventor.BOMStructureEnum.kPhantomBOMStructure) Then 'ignore phantom parts
                        mParentAssy = mStartAssy
                        mIsAssembly = False
                        GetProps(oCompOcc, GetOccType(occPartNum), colBreadCrumb)
                        iLeafNodes = iLeafNodes + 1
                    End If
                Else
                    'sub assembly found
                    mIsAssembly = True
                    iSubAssemblies = iSubAssemblies + 1
                    assyDoc = oCompOcc.Definition.Document
                    'add subassembly part number to breadcrumb
                    sSubAssyName = BGENamePicker(occPartNum, mStartAssy)

                    'determine if assembly should be explored deeper or not
                    If DiveDeeper(oCompOcc) Then
                        'ok to go deeper into assembly
                        'add assembly part number to breadcrumb if going further into sub assembly                        
                        colBreadCrumb.Add(assyDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                        'sort the part
                        GetProps(oCompOcc, GetOccType(occPartNum), colBreadCrumb)
                        'subassembly
                        processAllSubOcc(oCompOcc, sMsg, iLeafNodes, iSubAssemblies, sSubAssyName, colBreadCrumb)
                    Else
                        'do not go deeper into assembly, treat as part
                        'occurrence is an assembly we do not want to go into further, treat as a part
                        mIsAssembly = False
                        If oCompOcc.Definition.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
                            GetProps(oCompOcc, PartType.VirtualPart, colBreadCrumb)
                        Else
                            GetProps(oCompOcc, GetOccType(occPartNum), colBreadCrumb) 'how to detect virtual parts?
                        End If
                    End If
                End If
            End If
        Next

        'check the file path to see if it is valid
        sFilePath = sDirectoryPath & "\" & mStartAssy & "_PartsList.xlsx"

        mResults = "File created at: " & sFilePath

        'print the part list
        Debug.Print("")
        PrintColl(mCollFullBOM)
        bomCompareList = mCollBomCompare
        partExportList = mCollPartCreate
        bomImportList = mCollFullBOM

    End Sub

    Private Sub processAllSubOcc(ByVal oCompOcc As Inventor.ComponentOccurrence, ByRef sMsg As String,
                                 ByRef iLeafNodes As Long, ByRef iSubAssemblies As Long, ParentName As String,
                                 prevBreadCrumb As Collection)
        ' This function is called for processing sub assembly.  It is called recursively
        ' to iterate through the entire assembly tree.

        Dim oSubCompOcc As Inventor.ComponentOccurrence
        Dim sSubAssyName As String
        Dim subDoc As Inventor.Document
        'variables for sub occurrence properties
        Dim subCompOccDoc As Inventor.Document
        Dim subCompOccProps As Inventor.PropertySets
        Dim subCompOccPartNum As String

        'make a new breadcrumb collection for each time this sub is run
        Dim subBreadCrumb As Collection

        'check if ParentName is BGE
        mParentAssy = BGENamePicker(ParentName, mParentAssy)

        For Each oSubCompOcc In oCompOcc.SubOccurrences
            'clear out breadcrumb collection and start at beginning
            subBreadCrumb = Nothing
            subBreadCrumb = New Collection
            'append prevBreadCrumb to the newly created breadcrumb
            AppendColl(subBreadCrumb, prevBreadCrumb)

            Try
                subCompOccDoc = oSubCompOcc.Definition.Document
                subCompOccProps = subCompOccDoc.PropertySets

                If oSubCompOcc.Definition.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
                    'virtual parts have the part number in a different location for some reason
                    subCompOccPartNum = oSubCompOcc.Definition.propertysets.item("Design Tracking Properties").item("Part Number").value
                Else
                    'get part number
                    subCompOccPartNum = subCompOccProps.Item("Design Tracking Properties").Item("Part Number").Value
                End If
            Catch ex As Exception
                subCompOccPartNum = oSubCompOcc.Name
            End Try

            If Not ((oSubCompOcc.BOMStructure = Inventor.BOMStructureEnum.kReferenceBOMStructure) Or (oSubCompOcc.Suppressed = True)) Then  'if not reference or suppressed or phantom then continue
                ' Check if it's child occurrence (leaf node)
                If oSubCompOcc.SubOccurrences.Count = 0 Then
                    'Debug.Print oSubCompOcc.Name
                    If oSubCompOcc.Definition.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
                        mParentAssy = mStartAssy
                        mIsAssembly = False
                        GetProps(oSubCompOcc, PartType.VirtualPart, subBreadCrumb)
                    ElseIf Not (oSubCompOcc.BOMStructure = Inventor.BOMStructureEnum.kPhantomBOMStructure) Then 'ignore phantom parts only
                        mIsAssembly = False
                        GetProps(oSubCompOcc, GetOccType(subCompOccPartNum), subBreadCrumb)
                        iLeafNodes = iLeafNodes + 1
                    End If
                Else 'it is a subassembly
                    mIsAssembly = True
                    sMsg = sMsg + subCompOccPartNum + vbCr
                    iSubAssemblies = iSubAssemblies + 1
                    'add subassembly to breadcrumb collection
                    subDoc = oSubCompOcc.Definition.Document
                    'check if  subassembly is a BGE
                    sSubAssyName = BGENamePicker(subCompOccPartNum, mParentAssy)

                    'determine if the sub assembly should be explored deeper or not
                    If DiveDeeper(oSubCompOcc) Then
                        'dive deeper into sub assembly
                        'Add oSubCompOcc.Name to breadcrumb if going further into a sub assembly
                        subBreadCrumb.Add(subDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                        GetProps(oSubCompOcc, GetOccType(subCompOccPartNum), subBreadCrumb)

                        'recursive call to this function to continue down the branch
                        processAllSubOcc(oSubCompOcc, sMsg, iLeafNodes, iSubAssemblies, sSubAssyName, subBreadCrumb)
                    Else
                        'do not dive into assembly, treat as part
                        mIsAssembly = False 'treating these assemblies as parts

                        If oSubCompOcc.Definition.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
                            GetProps(oSubCompOcc, PartType.VirtualPart, subBreadCrumb)
                        Else
                            GetProps(oSubCompOcc, GetOccType(subCompOccPartNum), subBreadCrumb) 'how to detect virtual parts?
                        End If
                    End If
                End If
            End If
        Next

    End Sub

    Private Function AppendColl(FirstColl As Collection, SecondColl As Collection) As Collection
        'sub to append the second collection to the first collection

        'Dim item As Variant
        Dim item As Object

        For Each item In SecondColl
            FirstColl.Add(item)
        Next

        AppendColl = FirstColl

    End Function

    Private Function DiveDeeper(ByVal oCompOcc As Inventor.ComponentOccurrence) As Boolean
        'function to presort items and determine if assemblies should be explored deeper or not
        'standard assemblies and unknown assemblies should not be explored deeper
        'True = OK to go into assembly
        'False = do NOT go into assembly further

        Dim sFirstLetter As String
        Dim sFirstTwo As String
        Dim sCurrentYear As String
        Dim sPrefix As String
        Dim assyDoc As Inventor.AssemblyDocument
        Dim partNumber As String

        sCurrentYear = "BY" & mYear
        assyDoc = oCompOcc.Definition.Document

        Try
            partNumber = assyDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value
        Catch
            partNumber = oCompOcc.Name
        End Try

        'get first letter of occurrence name, may want to use part number property instead
        sFirstLetter = Left(partNumber, 1) 'Left(oCompOcc.Name, 1)
        'get first two letters of occurrence name, may want to use part number property instead
        sFirstTwo = Left(partNumber, 2) 'Left(oCompOcc.Name, 2)
        sPrefix = GetPrefix(partNumber)

        Select Case sFirstLetter
            Case "N", "S", "K", "D"
                'do not go into these assemblies
                Return False
            Case "B"
                Select Case sFirstTwo
                    Case "BY"
                        'do not go further into assembly
                        Return False
                    Case Else
                        Select Case sPrefix
                            Case "B49", "B0049"
                                'need to go into B49s for BOM Export functionality
                                Return True
                            Case "B47", "BGE", "BPH"
                                'Ok to go into assemblies
                                Return True
                            Case "B39"
                                'need to go into B39 assemblies for BOM Export functionality
                                Return True
                            Case "B45"
                                'check if B45 children are included
                                Return True
                            Case Else
                                Return False
                        End Select
                End Select
            Case "C"
                Select Case sFirstTwo
                    Case "CY"
                        'do not go further into assembly
                        Return False
                    Case Else
                        Select Case sPrefix
                            Case "C49", "C0049"
                                'go into B49 assemblies based on setting
                                'True = Do not go into assy (no children), False = OK to go into sub assy   
                                '*****************
                                'may need to go into all C assemblies as well and handle the filtering onto the collections
                                'in AddToCollection sub, similar to how B49s are handled.                                
                                '*****************
                                Return Not mBomCompSettings.bBomCompIncCAssy
                            Case "CPH", "CGE"
                                'ok to go into sub assemblies
                                Return True
                            Case "C39"
                                'check setting
                            Case "C45"
                                'check setting
                            Case Else
                                Return False
                        End Select
                End Select
            Case Else
                Return False
        End Select


    End Function

    'Private Sub SortPart(ByVal oCompOcc As Inventor.ComponentOccurrence, ByVal collBreadCrumb As Collection)
    '    'sub to filter out desired parts and take further action

    '    Dim partProps As Inventor.PropertySets  'variable for the property sets object of the occurrence
    '    Dim sFirstTwo As String 'variable for first two letters of part number/name
    '    Dim sFirstLetter As String 'variable for holding the first letter of the part number/name
    '    Dim docDef As Inventor.ComponentDefinition
    '    Dim sCurrentYear As String

    '    sCurrentYear = "BY" & mYear

    '    docDef = oCompOcc.Definition
    '    partProps = oCompOcc.Definition.Document.PropertySets

    '    'get first letter of occurrence name, may want to use part number property instead
    '    sFirstLetter = Left(oCompOcc.Name, 1)
    '    'get first two letters of occurrence name, may want to use part number property instead
    '    sFirstTwo = Left(oCompOcc.Name, 2)

    '    'check if occurrence is a virtual component
    '    If docDef.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
    '        'Get the properties of the virtual component
    '        GetProps(oCompOcc, PartType.VirtualPart, collBreadCrumb)
    '        Exit Sub
    '    End If

    '    Dim sPrefix As String
    '    sPrefix = GetPrefix(oCompOcc.Name)

    '    Select Case sFirstLetter
    '        Case "N", "S", "K", "D"
    '            'standard parts
    '            GetProps(oCompOcc, PartType.StandardPart, collBreadCrumb)
    '        Case "B"
    '            'MDE parts
    '            Select Case sFirstTwo
    '                Case "BY"
    '                    'purchased part
    '                    If sPrefix = sCurrentYear Then
    '                        'current year purch part
    '                        GetProps(oCompOcc, PartType.PurchPart, collBreadCrumb)
    '                    Else
    '                        GetProps(oCompOcc, PartType.OldPurchPart, collBreadCrumb)
    '                    End If

    '                Case Else
    '                    Select Case sPrefix
    '                        Case "B20", "B30", "B40", "B47", "B61", "B62", "B82", "B87", "B92", "B39", "B45"
    '                            GetProps(oCompOcc, PartType.ManufPart, collBreadCrumb)
    '                        Case "B0049", "B49"
    '                            'add the B49 assy to the parts list
    '                            GetProps(oCompOcc, PartType.BAssy, collBreadCrumb)
    '                        Case "BGE"
    '                            'BGE part generic
    '                            GetProps(oCompOcc, PartType.BGEPart, collBreadCrumb)
    '                        Case "BPH"
    '                            'BPH part, phantom part same as BGE
    '                            GetProps(oCompOcc, PartType.BPHPart, collBreadCrumb)
    '                        Case Else
    '                            'unknown part
    '                            GetProps(oCompOcc, PartType.Unknown, collBreadCrumb)
    '                    End Select
    '            End Select

    '        Case "C"
    '            'MBO parts
    '            Select Case sFirstTwo
    '                Case "CY"
    '                    'purchased part
    '                    If sPrefix = sCurrentYear Then
    '                        'current year purch part
    '                        GetProps(oCompOcc, PartType.PurchPart, collBreadCrumb)
    '                    Else
    '                        GetProps(oCompOcc, PartType.OldPurchPart, collBreadCrumb)
    '                    End If
    '                Case Else
    '                    Select Case sPrefix
    '                        Case "C20", "C30", "C40", "C47", "C61", "C62", "C82", "C87", "C92", "C39", "C45"
    '                            GetProps(oCompOcc, PartType.ManufPart, collBreadCrumb)
    '                        Case "C0049", "C49"
    '                            'case to allow C49 assemblies to be parts in the list
    '                            'add the C49 assy to the parts list
    '                            GetProps(oCompOcc, PartType.CAssy, collBreadCrumb)
    '                        Case "CGE"
    '                            'BGE part
    '                            GetProps(oCompOcc, PartType.BGEPart, collBreadCrumb)
    '                        Case "CPH"
    '                            'phantom part
    '                            GetProps(oCompOcc, PartType.BPHPart, collBreadCrumb)
    '                        Case Else
    '                            'unknown part
    '                            GetProps(oCompOcc, PartType.Unknown, collBreadCrumb)
    '                    End Select
    '            End Select
    '        Case "M"
    '            If sPrefix = "M900" Then 'fasteners
    '                GetProps(oCompOcc, PartType.M900Part, collBreadCrumb)
    '            Else
    '                GetProps(oCompOcc, PartType.Unknown, collBreadCrumb)
    '            End If
    '        Case Else
    '            'some unknown part
    '            GetProps(oCompOcc, PartType.Unknown, collBreadCrumb)
    '    End Select

    'End Sub

    Private Function GetOccType(ByVal sOcccName As String) As PartType
        'function to get the type of the part based on the occurrence name as a string

        Dim sFirstTwo As String 'variable for first two letters of part number/name
        Dim sFirstLetter As String 'variable for holding the first letter of the part number/name
        Dim sCurrentYear As String

        If sOcccName = "-TL" Then
            Return PartType.Toplevel
        End If

        sCurrentYear = "BY" & mYear

        'get first letter of occurrence name, may want to use part number property instead
        sFirstLetter = Left(sOcccName, 1)
        'get first two letters of occurrence name, may want to use part number property instead
        sFirstTwo = Left(sOcccName, 2)

        Dim sPrefix As String
        sPrefix = GetPrefix(sOcccName)

        Select Case sFirstLetter
            Case "N", "S", "K", "D"
                'check the length of the prefix to see if it is a standard part
                'and not just S.
                If Len(sPrefix) > 1 Then
                    GetOccType = PartType.StandardPart
                Else
                    GetOccType = PartType.Unknown
                End If
            Case "B"
                'MDE parts
                Select Case sFirstTwo
                    Case "BY"
                        'purchased part
                        If sPrefix = sCurrentYear Then
                            'current year purch part
                            GetOccType = PartType.PurchPart
                        Else
                            GetOccType = PartType.OldPurchPart
                        End If

                    Case Else
                        Select Case sPrefix
                            Case "B20", "B30", "B40", "B47", "B61", "B62", "B82", "B87", "B92", "B39", "B45"
                                GetOccType = PartType.ManufPart
                            Case "B0049", "B49"
                                'add the B49 assy to the parts list
                                GetOccType = PartType.BAssy
                            Case "BGE"
                                'BGE part generic
                                GetOccType = PartType.BGEPart
                            Case "BPH"
                                'BPH part, phantom part same as BGE
                                GetOccType = PartType.BPHPart
                            Case Else
                                'unknown part
                                GetOccType = PartType.Unknown
                        End Select
                End Select

            Case "C"
                'MBO parts
                Select Case sFirstTwo
                    Case "CY"
                        'purchased part
                        If sPrefix = sCurrentYear Then
                            'current year purch part
                            GetOccType = PartType.PurchPart
                        Else
                            GetOccType = PartType.OldPurchPart
                        End If
                    Case Else
                        Select Case sPrefix
                            Case "C20", "C30", "C40", "C47", "C61", "C62", "C82", "C87", "C92", "C39", "C45"
                                GetOccType = PartType.ManufPart
                            Case "C0049", "C49"
                                'case to allow C49 assemblies to be parts in the list
                                'add the C49 assy to the parts list
                                GetOccType = PartType.CAssy
                            Case "CGE"
                                'BGE part
                                GetOccType = PartType.BGEPart
                            Case "CPH"
                                'phantom part
                                GetOccType = PartType.BPHPart
                            Case Else
                                'unknown part
                                GetOccType = PartType.Unknown
                        End Select
                End Select
            Case "M"
                If sPrefix = "M900" Then 'fasteners
                    GetOccType = PartType.M900Part
                Else
                    GetOccType = PartType.Unknown
                End If
            Case Else
                'some unknown part
                GetOccType = PartType.Unknown
        End Select

    End Function

    Private Sub GetProps(ByVal oCompOcc As Inventor.ComponentOccurrence, ByVal currentOccurrenceType As PartType, ByVal collBreadCrumb As Collection)
        'sub to get the desired properties from the occurrence
        'Proman Class Code, Part Number, Description English, Cust Serv Code

        'initialize variables
        Dim partProps As Inventor.PropertySets

        'define myPartInfo as class of cPartInfo
        Dim occurrenceInfo As New cPartInfo

        'assign part properties object
        partProps = oCompOcc.Definition.Document.PropertySets


        'get the occurrence properties based on the current occurrence type, unfortunately locations for info change based on type
        Select Case currentOccurrenceType
            Case PartType.VirtualPart
                'virtual parts have a different location to get the part number
                'assign the other fields manually
                occurrenceInfo.PartNum = oCompOcc.Definition.PropertySets.item("Design Tracking Properties").item("Part Number").value
                occurrenceInfo.PromanCode = "XXXXX"
                occurrenceInfo.Description = "XXXX XXXX"
                occurrenceInfo.ServiceCode = "XX"
                occurrenceInfo.PartError = True
                occurrenceInfo.ErrorMsg = "Virtual Part: Missing Info"

            Case PartType.ManufPart, PartType.BAssy
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'some parts may not have these items, such as proman class code, probably older items
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    'need to raise error if proman code is empty
                    If occurrenceInfo.PromanCode = "" Then
                        PromanErr(occurrenceInfo)
                    End If
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper()
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.ServiceCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(occurrenceInfo)
                End Try

            Case PartType.CAssy
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'some parts may not have these items, such as proman class code, probably older items
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.ServiceCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(occurrenceInfo)
                End Try

            Case PartType.PurchPart
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.ServiceCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(occurrenceInfo)
                End Try

                Try
                    'may need to check the vendor code for standard parts, should be the 6-digit alpha code 
                    occurrenceInfo.VendorCode = partProps.Item("User Defined Properties").Item("Supplier").Value
                    occurrenceInfo.VendorCode = occurrenceInfo.VendorCode.ToUpper
                Catch
                    VendorCodeErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.ManufName = partProps.Item("User Defined Properties").Item("Manufacturer Name").Value
                    occurrenceInfo.ManufName = occurrenceInfo.ManufName.ToUpper
                Catch
                    ManufNameErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.ManufNum = partProps.Item("User Defined Properties").Item("Supplier Part Nb").Value
                    occurrenceInfo.ManufNum = occurrenceInfo.ManufNum.ToUpper
                Catch
                    ManufNumErr(occurrenceInfo)
                End Try

            Case PartType.OldPurchPart
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                'some parts may not have these items, such as proman class code, probably older items
                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.ServiceCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.VendorCode = partProps.Item("User Defined Properties").Item("Supplier Mnem").Value
                    occurrenceInfo.VendorCode = occurrenceInfo.VendorCode.ToUpper
                Catch
                    VendorCodeErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.ManufName = partProps.Item("User Defined Properties").Item("Supplier").Value
                    occurrenceInfo.ManufName = occurrenceInfo.ManufName.ToUpper
                Catch
                    ManufNameErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.ManufNum = partProps.Item("User Defined Properties").Item("Supplier Part Nb").Value
                    occurrenceInfo.ManufNum = occurrenceInfo.ManufNum.ToUpper
                Catch
                    ManufNumErr(occurrenceInfo)
                End Try

            Case PartType.StandardPart
                'Standard parts will not be in Part Create Collection, but will be in BOM Import Collection
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    occurrenceInfo.PromanCode = "STD"
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

            Case PartType.BGEPart 'BGE Parts should not appear in the BOM Import Collection, or the Part Create Collection, just keeping it as an option just in case
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    occurrenceInfo.PromanCode = "BGE"
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

            Case PartType.BPHPart 'BPH Parts should not appear in the BOM Import Collection, or the Part Create Collection, or BOM Compare just keeping it as an option just in case
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    occurrenceInfo.PromanCode = "BPH"
                    occurrenceInfo.PartError = True
                    occurrenceInfo.ErrorMsg = "Invalid Part Type"
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

            Case PartType.M900Part
                'fastener part
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    occurrenceInfo.PromanCode = "M900"
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

            Case PartType.Unknown
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    occurrenceInfo.Description = occurrenceInfo.Description.ToUpper
                Catch
                    DescriptionError(occurrenceInfo)
                End Try

                'General error for unknown part, check for missing information
                UnknownPartErr(occurrenceInfo)

        End Select

        'build BOM Collections
        AddToCollection(collBreadCrumb, occurrenceInfo, currentOccurrenceType, oCompOcc)

    End Sub

    Private Sub AddToCollection(ByRef collBreadCrumb As Collection, ByVal occurrenceInfo As cPartInfo, ByRef occurrenceType As PartType, ByVal occurrence As Inventor.ComponentOccurrence)
        'sub to add occurrences to collections
        'BOM Import collection, holds all parts and correct hierarchy with part information for proman
        'BOM Compare collection, holds all the parts for the BOM compare listview, no part information required
        'occurrences should be added to collections based on user settings

        Dim addPart As Boolean
        Dim sBomImportKey As String
        Dim sBomInstanceKey As String
        Dim sParentInstance As String
        Dim sBomCompareKey As String
        Dim sPartCreateKey As String
        Dim ParentInfo As ParentStatus
        Dim createOccurence As cPartInfo
        Dim compOccurrence As cPartInfo
        Dim importOccurrence As cPartInfo
        Dim parentType As PartType
        Dim parentOccType As PartType

        'find parent for occurrence
        Try
            sParentInstance = FindParentOccurrence(occurrence)
            parentOccType = GetOccType(sParentInstance)
        Catch ex As Exception
            'occurrence is on the top level, no parent occurrence
            sParentInstance = "TopLevel"
            parentOccType = PartType.Toplevel
        End Try

        ParentInfo = BomExportFindParent(collBreadCrumb, occurrenceInfo.PartNum)
        parentType = GetOccType(ParentInfo.ParentName)

        'build the keys for the collections
        sBomImportKey = occurrenceInfo.PartNum & "-" & ParentInfo.ParentName
        sBomInstanceKey = occurrenceInfo.PartNum & "-" & sParentInstance
        sBomCompareKey = occurrenceInfo.PartNum
        sPartCreateKey = occurrenceInfo.PartNum

        'Build the BOM Compare collection of parts
        If Not KeyExists(mCollBomCompare, sBomCompareKey) Then
            'if the part does not exist in collection then add the part
            addPart = True
            Select Case parentType
                Case PartType.BAssy
                    'check settings for B49 parents
                    If mBomCompSettings.bBomCompIncludeBAssy Then
                        'B49s are shown, no children
                        addPart = False
                    Else
                        addPart = CheckPartSettings(occurrenceType) 'need to check part level settings like for M900s
                    End If
                Case PartType.CAssy
                    'check settings for C assemblies
                    If mBomCompSettings.bBomCompIncCAssy Then
                        'C49s are shown, no children
                        addPart = False
                    Else
                        addPart = CheckPartSettings(occurrenceType)
                    End If
                Case PartType.M900Part
                    addPart = mBomCompSettings.bBomCompShowFasteners
                Case Else
                    'check other settings
                    If IsB39(ParentInfo.ParentName) Then
                        'check settings for B39 children
                        addPart = mBomCompSettings.bBomCompIncB39Children
                    ElseIf GetPrefix(ParentInfo.ParentName) = "B45" Then
                        addPart = mBomCompSettings.bBomCompIncB45Children
                    Else
                        addPart = CheckPartSettings(occurrenceType)
                    End If
            End Select

            If addPart Then
                'create instance of the partinfo class for all parts
                compOccurrence = New cPartInfo
                MakeEqual(compOccurrence, occurrenceInfo)
                compOccurrence.Description = CommaReplacer(occurrenceInfo.Description)
                'bump the quantity of the part (starts at 0)
                compOccurrence.IncrementQty(1)
                'add the newly created BomCompPartInfo to the mCollBomCompare collection with the part number as the key
                mCollBomCompare.Add(compOccurrence, sBomCompareKey)
            End If
        Else
            'part already exists in list, increment qty
            mCollBomCompare.Item(sBomCompareKey).IncrementQty(1)
        End If


        Dim addToBOMColl As Boolean
        addToBOMColl = True

        'build the Bom Export list
        If Not KeyExists(mCollBOMInstances, sBomInstanceKey) Then
            'part does not exist in the collection
            If Not KeyExists(mCollFullBOM, sBomImportKey) Then
                'part does not exist in the collection
                Select Case occurrenceType
                    Case PartType.BAssy
                        'add assembly based on settings
                        addToBOMColl = mBomImportSettings.bBomImportIncBassy
                    Case PartType.M900Part
                        addToBOMColl = mBomImportSettings.bBomImportShowFasteners
                    Case PartType.BPHPart, PartType.BGEPart
                        addToBOMColl = False
                    Case Else
                        addToBOMColl = True
                End Select
                'add to collection
                If addToBOMColl Then
                    importOccurrence = New cPartInfo
                    MakeEqual(importOccurrence, occurrenceInfo)
                    If ParentInfo.ErrorStatus = True Then
                        importOccurrence.ParentAssy = ParentInfo.ParentName
                        importOccurrence.PartError = True
                        importOccurrence.ErrorMsg = "Invalid Parent Assy"
                    Else
                        importOccurrence.ParentAssy = ParentInfo.ParentName
                    End If
                    importOccurrence.Breadcrumb = collBreadCrumb
                    'bump the quantity of the part (starts at 0)
                    importOccurrence.IncrementQty(1)
                    'add the newly created partinfo to the full bom collection and bom instances collection 
                    mCollFullBOM.Add(importOccurrence, sBomImportKey)
                    mCollBOMInstances.Add(importOccurrence, sBomInstanceKey)
                End If
            Else
                'key already exists, bump the quantity of the part
            End If
        Else
            mCollFullBOM.Item(sBomImportKey).incrementqty(1)
        End If

        'Build the Parts collection
        If Not KeyExists(mCollPartCreate, sPartCreateKey) Then
            'if include b49 is true and part is a b49 then do all this
            If (mPartCreateSettings.bPartCreatIncBassy = False) And (occurrenceType = PartType.BAssy) Then
                'do nothing, b49 assemblies not added to part create collection if option is not checked
            ElseIf (occurrenceType = PartType.BGEPart) Then
                'do nothing, bge parts should never be created
            ElseIf (occurrenceType = PartType.BPHPart) Then
                'do nothing, BPH parts should never be created
            ElseIf occurrenceType = PartType.StandardPart Then
                'do nothing, standard parts not added to part create collection
            Else
                'create instance of partinfo class for new parts
                createOccurence = New cPartInfo
                MakeEqual(createOccurence, occurrenceInfo)

                'bump the quantity of the part (starts at 0)
                createOccurence.IncrementQty(1)

                'add the newly created mypartinfo to the myparts collection with the part number as the key
                mCollPartCreate.Add(createOccurence, sPartCreateKey) 'partcreatepartinfo, (spartcreatekey))
            End If
        Else
            'key already exists, bump the quantity of the part
            mCollPartCreate.Item(sPartCreateKey).incrementqty(1)
        End If

    End Sub

    Private Function FindParentOccurrence(ByVal occ As Inventor.ComponentOccurrence) As String
        'finds the name of the parent occurrence and if the parent meets certain conditions it 
        'recursively calls itself until it gets to a valid parent

        Dim parentOccType As PartType

        If occ Is Nothing Then
            Return "-TL"
        Else
            'find parent type
            parentOccType = GetOccType(occ.ParentOccurrence.Name)

            Select Case parentOccType
                Case PartType.BPHPart, PartType.BGEPart
                    'part types cannot be parents, keep looking
                    Return FindParentOccurrence(occ.ParentOccurrence)
                Case PartType.BAssy
                    'check setting
                    If mBomImportSettings.bBomImportIncBassy Then
                        'b49s allowed to be parents
                        Return occ.ParentOccurrence.Name
                    Else
                        Return FindParentOccurrence(occ.ParentOccurrence)
                    End If
                Case Else
                    'found valid parent, return the name
                    Return occ.ParentOccurrence.Name
            End Select
        End If

    End Function

    Private Function CheckPartSettings(occurrenceType As PartType) As Boolean
        'function to check the settings as they relate to the occurrence and return a boolean value to 
        'add or not add the occurrence to a collection

        Select Case occurrenceType
            'add parts based on part level settings settings
            Case PartType.BAssy
                'part occurrence is a B49 assembly, are these included?
                CheckPartSettings = mBomCompSettings.bBomCompIncludeBAssy
            Case PartType.CAssy
                CheckPartSettings = mBomCompSettings.bBomCompIncCAssy
            Case PartType.BGEPart
                'never add BGE parts
                CheckPartSettings = False
            Case PartType.BPHPart
                'never add BPH parts
                CheckPartSettings = False
            Case PartType.M900Part
                CheckPartSettings = mBomCompSettings.bBomCompShowFasteners
            Case Else
                CheckPartSettings = True
        End Select

    End Function

    Private Function MakeEqual(ByRef part1 As cPartInfo, ByVal part2 As cPartInfo) As cPartInfo
        'sub for copying information from one PartInfo to another

        part1.Breadcrumb = part2.Breadcrumb
        part1.Description = CommaReplacer(part2.Description)
        part1.ErrorMsg = part2.ErrorMsg
        part1.ManufName = CommaReplacer(part2.ManufName)
        part1.ManufNum = part2.ManufNum
        part1.ParentAssy = part2.ParentAssy
        part1.PartError = part2.PartError
        part1.PartNum = part2.PartNum
        part1.PromanCode = part2.PromanCode
        part1.Qty = part2.Qty
        part1.ServiceCode = part2.ServiceCode
        part1.VendorCode = part2.VendorCode

        Return part1
    End Function

#Region "Error handler sub routines"

    Private Sub PromanErr(ByVal occurrence As cPartInfo)
        'sub to handle proman errors

        occurrence.PromanCode = "XXXX"
        occurrence.PartError = True
        occurrence.ErrorMsg = occurrence.ErrorMsg & "Missing Proman Class Code"
        mErrorStatus = True

    End Sub

    Private Sub DescriptionError(ByVal occurrence As cPartInfo)
        'sub to handle changing the values if there is no english description in the part
        occurrence.Description = "XXXX XXXX"
        occurrence.PartError = True
        occurrence.ErrorMsg = occurrence.ErrorMsg & "," & "Missing Description"
        mErrorStatus = True
    End Sub

    Private Sub ServiceCodeErr(ByVal occurrence As cPartInfo)
        'sub to handle changing values if there is no Customer Service Code in the occurrence

        occurrence.ServiceCode = "XX"
        occurrence.PartError = True
        occurrence.ErrorMsg = occurrence.ErrorMsg & "," & "Missing Customer Service Code"
        mErrorStatus = True

    End Sub

    Private Sub VendorCodeErr(ByVal occurrence As cPartInfo)
        'sub to handle changing the values if there is no Vendor Code in the part

        occurrence.VendorCode = "XXXXXX"
        occurrence.PartError = True
        occurrence.ErrorMsg = occurrence.ErrorMsg & "," & "Missing Vendor Code"
        mErrorStatus = True

    End Sub

    Private Sub ManufNameErr(ByVal occurrence As cPartInfo)
        'sub to handle changing the values if there is no Manufacturer Name in the part

        occurrence.ManufName = "XXXXXX"
        occurrence.PartError = True
        occurrence.ErrorMsg = occurrence.ErrorMsg & ", " & "Missing Manufacturer Name"
        mErrorStatus = True

    End Sub

    Private Sub ManufNumErr(ByVal occurrence As cPartInfo)
        'sub to handle changing the values if there is no Manufacturer Name in the part

        occurrence.ManufNum = "XXXXXX"
        occurrence.PartError = True
        occurrence.ErrorMsg = occurrence.ErrorMsg & ", " & "Missing Manufacturer Number"
        mErrorStatus = True

    End Sub

    Private Sub UnknownPartErr(ByVal occurrence As cPartInfo)
        'sub to handle error information for unknown parts
        occurrence.PartError = True
        occurrence.ErrorMsg = occurrence.ErrorMsg & "," & "Unknown Type: Verify Info"
        mErrorStatus = True
    End Sub

#End Region

#Region "Export Functions - Create Excel documents"

    Public Function BOMExportExcel(FilePath As String) As Boolean
        'function to create an excel document from the BOM list that was created from the assembly
        Dim XLApp As Excel.Application
        Dim wb As Excel.Workbook
        Dim ws1 As Excel.Worksheet 'for BOM export
        Dim sFilePath As String = ""

        'Check if mNewParts contains items
        If IsNothing(mCollPartCreate) Then
            'Empty parts list
            MsgBox("Parts List Empty, try loading Inventor BOM")
            BOMExportExcel = False
            Exit Function
        End If

        'Check the file path and directory
        If IsValidFileNameOrPath(FilePath) Then
            'valid file path
            'valid file path
            If mErrorStatus = True Then
                Debug.Print("***** ERRORS Found See Excel Document *****")
                mResults = "**** ERRORS Found See Excel Document ****" & vbNewLine & vbNewLine
            End If
            'Add results to Results String
            mResults = mResults & "File Path: " & FilePath & vbNewLine & vbNewLine & "Num Unique Parts: " & CStr(bomImportList.Count)
        Else
            'File Path not valid
            If mErrorStatus = True Then
                mResults = "**** ERRORS Found Some Parts Missing Info ****" & vbNewLine & vbNewLine
            End If
            mResults = mResults & "Excel file NOT created" & vbNewLine & vbNewLine & "Num Unique Parts: " & CStr(bomImportList.Count)
            'dont try to create excel document
            BOMExportExcel = False
            Exit Function
        End If

        'create the excel application, workbook and worksheet
        XLApp = CreateObject("Excel.Application")
        XLApp.DisplayAlerts = False 'dont display alert for overwriting file on save
        wb = XLApp.Workbooks.Add
        ws1 = wb.Sheets(1) 'wb.Worksheets.Item(1)

        'name sheets
        ws1.Name = "BOM Export-EXPERIMENTAL"
        ws1.Activate()

        'add items to the worksheet
        Dim part As cPartInfo
        Dim row As Integer
        Dim mikronBlue As Integer
        Dim headingTextColor As Integer
        Dim errorColor As Integer

        'define mikron blue color
        mikronBlue = RGB(0, 51, 153)
        'define heading text color
        headingTextColor = RGB(255, 255, 255)
        'define error color
        errorColor = RGB(255, 97, 161)

        'create column headings for ws2
        With ws1
            .Range("A1").Value = "Part Number"
            .Range("B1").Value = "Class Code"
            .Range("C1").Value = "Description"
            .Range("D1").Value = "Serv Code"
            .Range("E1").Value = "Vend Code"
            .Range("F1").Value = "Manuf Name"
            .Range("G1").Value = "Manuf Num"
            .Range("H1").Value = "QPA"
            .Range("I1").Value = "Parent Assy"
            .Range("J1").Value = "Plan Type"
            .Range("K1").Value = "Item Nbr"
            .Range("L1").Value = "Errors"
            'color heading row gray
            .Range("A1:L1").Interior.Color = mikronBlue 'RGB(178, 178, 178)
            'color heading text
            .Range("A1:L1").Font.Color = headingTextColor
            'bold heading row column headings
            .Range("A1:L1").Font.Bold = True
        End With

        'start filling in table on row 2
        row = 2

        'populate the remaining cells for ws2
        For Each part In mCollFullBOM
            With ws1
                .Range("A" & row).Value = part.PartNum
                .Range("B" & row).Value = part.PromanCode
                .Range("C" & row).Value = part.Description
                .Range("D" & row).Value = part.ServiceCode
                .Range("E" & row).Value = part.VendorCode
                .Range("F" & row).Value = part.ManufName
                .Range("G" & row).Value = part.ManufNum
                .Range("H" & row).Value = part.Qty
                .Range("I" & row).Value = part.ParentAssy
                .Range("J" & row).Value = 1 'default plan type will always be 1
                .Range("K" & row).Value = "" 'default to a blank cell
                .Range("L" & row).Value = part.ErrorMsg
                If part.PartError = True Then
                    'color error rows
                    .Range("A" & row & ":" & "L" & row).Interior.Color = errorColor
                End If
            End With
            row = row + 1
        Next

        'autosize columns
        ws1.Columns("A:L").Autofit

        Try
            wb.SaveAs(Filename:=FilePath, AccessMode:=Excel.XlSaveAsAccessMode.xlExclusive, ConflictResolution:=Excel.XlSaveConflictResolution.xlLocalSessionChanges)
            BOMExportExcel = True
            wb.Close()
            XLApp.Quit()
        Catch ex As Exception
            BOMExportExcel = False
            wb.Close()
            XLApp.Quit()
        End Try

    End Function

    Public Function PartExportExcel(FilePath As String) As Boolean
        'sub to create an excel document from the parts list that was created from the assembly

        Dim XLApp As Excel.Application
        Dim wb As Excel.Workbook
        Dim ws1 As Excel.Worksheet 'for Part Create info
        Dim ws2 As Excel.Worksheet 'for BOM Import info
        Dim sFilePath As String = ""

        'Check if mNewParts contains items
        If IsNothing(mCollPartCreate) Then
            'Empty parts list
            MsgBox("Parts List Empty, try loading Inventor BOM")
            PartExportExcel = False
            Exit Function
        End If

        'Check the file path and directory
        If IsValidFileNameOrPath(FilePath) Then
            'valid file path
            'valid file path
            If mErrorStatus = True Then
                Debug.Print("***** ERRORS Found See Excel Document *****")
                mResults = "**** ERRORS Found See Excel Document ****" & vbNewLine & vbNewLine
            End If
            'Add results to Results String
            mResults = mResults & "File Path: " & FilePath & vbNewLine & vbNewLine & "Num Unique Parts: " & CStr(partExportList.Count)
        Else
            'File Path not valid
            If mErrorStatus = True Then
                mResults = "**** ERRORS Found Some Parts Missing Info ****" & vbNewLine & vbNewLine
            End If
            mResults = mResults & "Excel file NOT created" & vbNewLine & vbNewLine & "Num Unique Parts: " & CStr(partExportList.Count)
            'dont try to create excel document
            PartExportExcel = False
            Exit Function
        End If

        'create the excel application, workbook and worksheet
        XLApp = CreateObject("Excel.Application")
        XLApp.DisplayAlerts = False 'dont display alert for overwriting file on save
        wb = XLApp.Workbooks.Add
        ws1 = wb.Sheets(1) 'wb.Worksheets.Item(1)
        ws2 = wb.Sheets.Add(, ws1)

        'name sheets
        ws1.Name = "Part Create"
        ws2.Name = "EXPERIMENTAL"
        ws1.Activate()

        'add items to the worksheet
        Dim part As cPartInfo
        Dim row As Integer
        Dim mikronBlue As Integer
        Dim headingTextColor As Integer
        Dim errorColor As Integer

        'define mikron blue color
        mikronBlue = RGB(0, 51, 153)
        'define heading text color
        headingTextColor = RGB(255, 255, 255)
        'define error color
        errorColor = RGB(255, 97, 161)

        'start filling in table on row 2
        row = 2

        'create column headings for ws1
        With ws1
            .Range("A1").Value = "Part Number"
            .Range("B1").Value = "Class Code"
            .Range("C1").Value = "Description"
            .Range("D1").Value = "Serv Code"
            .Range("E1").Value = "Vend Code"
            .Range("F1").Value = "Manuf Name"
            .Range("G1").Value = "Manuf Num"
            .Range("H1").Value = "QPA"
            .Range("I1").Value = "Errors"
            'color heading row gray
            .Range("A1:I1").Interior.Color = mikronBlue
            'Color heading text white
            .Range("A1:I1").Font.Color = headingTextColor
            'bold heading row column headings
            .Range("A1:I1").Font.Bold = True
        End With

        'create column headings for ws2
        With ws2
            .Range("A1").Value = "Part Number"
            .Range("B1").Value = "Class Code"
            .Range("C1").Value = "Description"
            .Range("D1").Value = "Serv Code"
            .Range("E1").Value = "Vend Code"
            .Range("F1").Value = "Manuf Name"
            .Range("G1").Value = "Manuf Num"
            .Range("H1").Value = "QPA"
            .Range("I1").Value = "Parent Assy"
            .Range("J1").Value = "Plan Type"
            .Range("K1").Value = "Errors"
            'color heading row gray
            .Range("A1:K1").Interior.Color = mikronBlue 'RGB(178, 178, 178)
            'color heading text
            .Range("A1:K1").Font.Color = headingTextColor
            'bold heading row column headings
            .Range("A1:K1").Font.Bold = True
        End With

        'populate the remaining cells for WS1
        For Each part In mCollPartCreate
            With ws1
                .Range("A" & row).Value = part.PartNum
                .Range("B" & row).Value = part.PromanCode
                .Range("C" & row).Value = part.Description
                .Range("D" & row).Value = part.ServiceCode
                .Range("E" & row).Value = part.VendorCode
                .Range("F" & row).Value = part.ManufName
                .Range("G" & row).Value = part.ManufNum
                .Range("H" & row).Value = part.Qty
                .Range("I" & row).Value = part.ErrorMsg
                If part.PartError = True Then
                    'color error rows
                    .Range("A" & row & ":" & "I" & row).Interior.Color = errorColor
                End If
            End With
            row = row + 1
        Next

        'start filling in table on row 2
        row = 2

        'populate the remaining cells for ws2
        For Each part In mCollFullBOM
            With ws2
                .Range("A" & row).Value = part.PartNum
                .Range("B" & row).Value = part.PromanCode
                .Range("C" & row).Value = part.Description
                .Range("D" & row).Value = part.ServiceCode
                .Range("E" & row).Value = part.VendorCode
                .Range("F" & row).Value = part.ManufName
                .Range("G" & row).Value = part.ManufNum
                .Range("H" & row).Value = part.Qty
                .Range("I" & row).Value = part.ParentAssy
                .Range("J" & row).Value = 1 'default plan type will always be 1
                .Range("K" & row).Value = part.ErrorMsg
                If part.PartError = True Then
                    'color error rows
                    .Range("A" & row & ":" & "K" & row).Interior.Color = errorColor
                End If
            End With
            row = row + 1
        Next

        'autosize columns
        ws1.Columns("A:J").AutoFit
        ws2.Columns("A:K").Autofit

        'autosort by part number on ws3
        'ws3.Columns("A:C").Sort(Key1:=ws3.Range("A2"), Order1:=Excel.XlSortOrder.xlAscending, Header:=Excel.XlYesNoGuess.xlYes)

        Try
            wb.SaveAs(Filename:=FilePath, AccessMode:=Excel.XlSaveAsAccessMode.xlExclusive, ConflictResolution:=Excel.XlSaveConflictResolution.xlLocalSessionChanges)
            PartExportExcel = True
            wb.Close()
            XLApp.Quit()
        Catch ex As Exception
            PartExportExcel = False
            wb.Close()
            XLApp.Quit()
        End Try

    End Function

    Public Function BomCompExportExcel(FilePath As String) As Boolean
        'sub to create BOM Compare excel document from the parts list that was created from the assembly
        'uses the bom compare collection mCollBomCompare

        Dim XLApp As Excel.Application
        Dim wb As Excel.Workbook
        Dim ws1 As Excel.Worksheet 'for Part Create info
        Dim sFilePath As String = ""

        'Check if mNewParts contains items
        If IsNothing(mCollPartCreate) Then
            'Empty parts list
            MsgBox("Parts List Empty, try loading Inventor BOM")
            BomCompExportExcel = False
            Exit Function
        End If

        'Check the file path and directory
        If IsValidFileNameOrPath(FilePath) Then
            'valid file path
            'valid file path
            If mErrorStatus = True Then
                Debug.Print("***** ERRORS Found See Excel Document *****")
                mResults = "**** ERRORS Found See Excel Document ****" & vbNewLine & vbNewLine
            End If
            'Add results to Results String
            mResults = mResults & "File Path: " & FilePath & vbNewLine & vbNewLine & "Num Unique Parts: " & CStr(bomCompareList.Count)
        Else
            'File Path not valid
            If mErrorStatus = True Then
                mResults = "**** ERRORS Found Some Parts Missing Info ****" & vbNewLine & vbNewLine
            End If
            mResults = mResults & "Excel file NOT created" & vbNewLine & vbNewLine & "Num Unique Parts: " & CStr(bomCompareList.Count)
            'dont try to create excel document
            BomCompExportExcel = False
            Exit Function
        End If

        'create the excel application, workbook and worksheet
        XLApp = CreateObject("Excel.Application")
        XLApp.DisplayAlerts = False 'dont display alert for overwriting file on save
        wb = XLApp.Workbooks.Add
        ws1 = wb.Sheets(1)

        'name sheets
        ws1.Name = "BOM Compare"
        ws1.Activate()

        'add items to the worksheet
        Dim part As cPartInfo
        Dim row As Integer
        Dim mikronBlue As Integer
        Dim headingTextColor As Integer
        Dim errorColor As Integer

        'define mikron blue color
        mikronBlue = RGB(0, 51, 153)
        'define heading text color
        headingTextColor = RGB(255, 255, 255)
        'define error color
        errorColor = RGB(255, 97, 161)

        'start filling in table on row 2
        row = 2

        'create column headings for ws1
        With ws1
            .Range("A1").Value = "Part Number"
            .Range("B1").Value = "Description"
            .Range("C1").Value = "QPA"
            'color heading row gray
            .Range("A1:C1").Interior.Color = mikronBlue
            'Color heading text white
            .Range("A1:C1").Font.Color = headingTextColor
            'bold heading row column headings
            .Range("A1:C1").Font.Bold = True
        End With

        'populate the remaining cells for WS1
        For Each part In mCollPartCreate
            With ws1
                .Range("A" & row).Value = part.PartNum
                .Range("B" & row).Value = part.Description
                .Range("C" & row).Value = part.Qty
                If part.PartError = True Then
                    'color error rows
                    .Range("A" & row & ":" & "C" & row).Interior.Color = errorColor
                End If
            End With
            row = row + 1
        Next

        'autosize columns
        ws1.Columns("A:C").AutoFit

        Try
            wb.SaveAs(Filename:=FilePath, AccessMode:=Excel.XlSaveAsAccessMode.xlExclusive, ConflictResolution:=Excel.XlSaveConflictResolution.xlLocalSessionChanges)
            BomCompExportExcel = True
            wb.Close()
            XLApp.Quit()
        Catch ex As Exception
            BomCompExportExcel = False
            wb.Close()
            XLApp.Quit()
        End Try

    End Function

#End Region


    Private Sub PrintColl(PartCollection As Collection)
        'sub to debug print the parts collection

        Dim item As cPartInfo

        For Each item In PartCollection

            'for printing new parts collection
            'Debug.Print(item.PartNum & vbTab & item.PromanCode & vbTab & item.Description & vbTab & item.ServiceCode &
            'vbTab & item.VendorCode & vbTab & item.ManufName & vbTab &
            'item.ManufNum & vbTab & item.ParentAssy & vbTab & item.PrintBreadCrumb & vbTab & item.Qty)
            Debug.Print(item.PartNum & vbTab & vbTab & item.PromanCode & vbTab & vbTab & "Parent: " & item.ParentAssy & vbTab & vbTab & "Qty: " & item.Qty & vbTab & vbTab & item.PrintBreadCrumb)

            'for printing all parts collection
            'Debug.Print(item.PartNum & vbTab "Qty: " & item.Qty)

            'for printing compare parts collection
            'Debug.Print(item.PartNum & vbTab & vbTab & "Qty: " & vbTab & item.Qty)
        Next
    End Sub

    Private Function CommaReplacer(origString As String) As String
        'function to parse a string, look for commas and replace them with semicolons
        'this is needed because when you export a tab delimited file from excel, cells with commas in them
        'are surrounded by quotes.  This makes things ugly when importing into proman.

        Dim modString As String 'modified string with commas removed

        modString = Replace(origString, ",", ";")
        'return value
        CommaReplacer = modString

    End Function

    Private Function BGENamePicker(Name As String, PrevName As String) As String
        'sub to determine if Name is a BGE part number
        'if it is BGE it returns the PrevName else it returns the Name

        Dim iPeriodLoc As Integer
        Dim sPrefix As String = ""

        'identify where the period is in the Parent part
        iPeriodLoc = InStr(Name, ".")
        If iPeriodLoc <> 0 Then
            sPrefix = Left(Name, iPeriodLoc - 1)
        End If

        If sPrefix = "BGE" Then
            BGENamePicker = PrevName
        Else
            BGENamePicker = Name
        End If

    End Function

    Private Function BOMCompareFindParent(collBreadcrumb As Collection, sChild As String) As ParentStatus
        'function to find the parent assembly by going backwards through the breadcrumb collection 
        'settings are specific to the BOM Compare Settings

        Dim i As Integer
        Dim parent As String = "Empty"

        For i = 0 To collBreadcrumb.Count
            Try
                parent = collBreadcrumb.Item(collBreadcrumb.Count - i)
                If sChild = parent Then
                    'cant have a child part have itself as a parent 
                Else
                    If IsPrefixMatch(parent, "BGE") Then
                        'cant have BGE as parent
                    ElseIf IsBFourtyNine(parent) Then
                        'are B49s allowed to be parents??
                        If mBomCompSettings.bBomCompIncludeBAssy Then
                            'B49s allowed to be parents
                            Exit For
                        End If
                    Else
                        'parent is not a B49 or a BGE so it is OK
                        Exit For
                    End If
                End If

            Catch ex As Exception
                BOMCompareFindParent.ParentName = "INVALID Parent"
                BOMCompareFindParent.ErrorStatus = True
                'exit the function and assign invalid parent error
                Exit Function
            End Try
        Next

        'for loop was finished or exited, assign parent
        BOMCompareFindParent.ParentName = parent
        BOMCompareFindParent.ErrorStatus = False

    End Function

    Private Function BomExportFindParent(collBreadCrumb As Collection, sChild As String) As ParentStatus
        'function to find the parent assembly by going backwards through the breadcrumb collection
        'coll is the breadcrumb collection 
        'depending on settings, BGE and B49 parts will or will not be parents

        Dim i As Integer
        Dim parent As String = "Empty Parent"

        For i = 0 To collBreadCrumb.Count
            Try
                parent = collBreadCrumb.Item(collBreadCrumb.Count - i)
                If sChild = parent Then
                    'cant have a child part have itself as a parent 
                Else
                    If IsPrefixMatch(parent, "BGE") Then
                        'cant have BGE as parent
                    ElseIf IsPrefixMatch(parent, "BPH") Then
                        'cant have BPH as parent
                    ElseIf IsBFourtyNine(parent) Then
                        'are B49s allowed to be parents??
                        If mBomImportSettings.bBomImportIncBassy = True Then
                            'B49s allowed to be parents
                            Exit For
                        End If
                    Else
                        'parent is not a B49, BPH or a BGE so it is OK
                        Exit For
                    End If
                End If

            Catch ex As Exception
                BomExportFindParent.ParentName = "INVALID Parent"
                BomExportFindParent.ErrorStatus = True
                mErrorStatus = True
                'exit the function and assign invalid parent error
                Exit Function
            End Try
        Next

        'for loop was finished or exited, assign values
        BomExportFindParent.ParentName = parent
        BomExportFindParent.ErrorStatus = False

    End Function

    Private Function IsPrefixMatch(Name As String, MatchString As String) As Boolean
        'function to determine if the prefix of Name matches MatchString
        Dim periodLoc As Integer
        Dim prefix As String = ""

        'identify where the period is located in Name
        periodLoc = InStr(Name, ".")
        If periodLoc <> 0 Then
            prefix = Left(Name, periodLoc - 1)
        End If

        If prefix = MatchString Then
            IsPrefixMatch = True
        Else
            IsPrefixMatch = False
        End If

    End Function

    Private Function IsBFourtyNine(name As String) As Boolean
        'determine if Name is a B49 or B0049 part number and return TRUE if it is

        Dim iPeriodLoc As Integer
        Dim sPrefix As String = ""

        'identify where the period is in the Parent part
        iPeriodLoc = InStr(name, ".")
        If iPeriodLoc <> 0 Then
            sPrefix = Left(name, iPeriodLoc - 1)
        End If

        If sPrefix = "B49" Or sPrefix = "B0049" Then
            IsBFourtyNine = True
        Else
            IsBFourtyNine = False
        End If
    End Function

    Private Function IsB39(name As String) As Boolean
        'determine if Name is a B39 part number and return TRUE if it is

        Dim iPeriodLoc As Integer
        Dim sPrefix As String = ""

        'identify where the period is in the Parent part
        iPeriodLoc = InStr(name, ".")
        If iPeriodLoc <> 0 Then
            sPrefix = Left(name, iPeriodLoc - 1)
        End If

        If sPrefix = "B39" Then
            IsB39 = True
        Else
            IsB39 = False
        End If
    End Function

    Private Function KeyExists(coll As Collection, key As String) As Boolean
        'determines if the key in the collection exists or not
        'if it does it returns true

        If coll.Contains(key) Then
            KeyExists = True
        Else
            KeyExists = False
        End If

    End Function

    Private Function IsValidFileNameOrPath(ByVal name As String) As Boolean
        'determines if the name is nothing
        If name Is Nothing Then
            Return False
        End If

        'determines if there are bad characters in the name
        For Each badchar As Char In System.IO.Path.GetInvalidPathChars
            If InStr(name, badchar) > 0 Then
                Return False
            End If
        Next

        'check if file exists, will return false if it does exist
        'If Not System.IO.File.Exists(name) Then
        'Return False
        'End If

        'the name passes basic validation
        Return True
    End Function

    Private Function IsDirectoryValid(sDirectoryPath As String) As Boolean
        'function to determine if the directory is valid

        If System.IO.Directory.Exists(sDirectoryPath) Then
            Return True
        End If

        Return False
    End Function

    Private Function GetPrefix(Name As String) As String
        'function to return the desired prefix of a file name, the letters before the period
        Dim iPeriodLoc As Integer

        'identify where the period is in the Parent part
        iPeriodLoc = InStr(Name, ".")
        If iPeriodLoc <> 0 Then
            GetPrefix = Left(Name, iPeriodLoc - 1)
        Else
            GetPrefix = ""
        End If

    End Function

    'Private Sub HighlightPart(PartNum As String)
    'sub to highlight the part based on the part number

    'Dim oCompOcc As ComponentOccurrence
    'Dim PartProps As Inventor.PropertySets
    'Dim oDoc As Inventor.Document

    'clear the highlight set
    'oSet.Clear()

    'need to have recursive function here
    'For Each oCompOcc In oCompDef.Occurrences
    'If oCompOcc.SubOccurrences.Count = 0 Then
    'oDoc = oCompOcc.Definition.Document
    'PartProps = oDoc.PropertySets
    'If PartProps.Item("Design Tracking Properties").Item("Part Number").Value = PartNum Then
    'Add occurrence to highlight set
    'oSet.AddItem(oCompOcc)
    'End If
    'Else
    'sub assembly found
    'ProcessSubAssys(oCompOcc)
    'End If
    'Next

    'For Each oCompOcc In oCompDef.Occurrences
    'If PartProps.Item("Design Tracking Properties").Item("Part Number").Value = PartNum Then
    'oSet.AddItem(oCompOcc)
    'End If
    'Next



    'End Sub

End Module
