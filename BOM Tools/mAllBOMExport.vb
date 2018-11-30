
Imports Microsoft.Office.Interop
'Imports System.IO

Module mAllBOMExport

    '************************************
    'Module to export three collections for use in Proman
    'Part Creation, BOM Import, and BOM Compare
    '************************************


    Private mCollBomImport As Collection 'collection to hold all the parts with correct parents for BOM Import
    Private mCollPartCreate As Collection 'colection to hold all the new parts, manuf and purch and proman information, for Part Creation import
    Private mCollBomCompare As Collection 'collection to hold all the parts for the BOM compare listview

    Private mStartAssy As String 'holds the top level assembly name
    Private mYear As String 'variable to hold the current year as a string
    Private mParentAssy As String 'variable to hold the name of the parent assembly for a part
    Private mErrorStatus As Boolean 'variable to show if an error has occurred or not
    Private mIsAssembly As Boolean 'flag for indicating if current occurrence is an assembly (true)
    Private mAddToBomCompCollection As Boolean 'flag for indicating if current part should be added to BOM compare collection or not

    Private Structure ParentStatus
        Public ErrorStatus As Boolean
        Public ParentName As String
    End Structure

    Public Structure BomImportSettings
        Public bBomImportIncBassy As Boolean
    End Structure

    Public Structure PartCreateSettings
        Public bPartCreatIncBassy As Boolean
    End Structure

    Public Structure BomCompareSettings
        Public bBomCompAllowBAssyParent As Boolean 'Allow B49 Assemblies to be parents?
        Public bBomCompIncCAssy As Boolean 'include C49 Assy?
        Public bBomCompIncB39Children As Boolean 'include B39 children?
        Public bBomCompIncB45Children As Boolean 'include B45 children?
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
        Unknown = 10
    End Enum

    Public mResults As String = "" 'variable used for displaying the results
    Public PartsList As Collection 'collection for all unique parts in an assembly
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
        mCollBomImport = New Collection
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

            'check if occurrence is marked as reference or suppressed, dont do anything if it is reference or suppressed
            If Not ((oCompOcc.BOMStructure = Inventor.BOMStructureEnum.kReferenceBOMStructure) Or (oCompOcc.Suppressed = True)) Then  'if not reference or suppressed or phantom then continue
                'If (Not oCompOcc.BOMStructure = Inventor.BOMStructureEnum.kReferenceBOMStructure) And (Not oCompOcc.Suppressed = True) Then  'if not reference or suppressed then continue
                'Check if it's child occurrence (leaf node)
                If oCompOcc.SubOccurrences.Count = 0 Then
                    'not a sub assembly
                    If Not (oCompOcc.BOMStructure = Inventor.BOMStructureEnum.kPhantomBOMStructure) Then 'ignore phantom parts
                        mParentAssy = mStartAssy
                        mIsAssembly = False
                        SortPart(oCompOcc, colBreadCrumb)
                        iLeafNodes = iLeafNodes + 1
                    End If
                Else
                    'sub assembly found
                    mIsAssembly = True
                    iSubAssemblies = iSubAssemblies + 1
                    assyDoc = oCompOcc.Definition.Document
                    'add subassembly part number to breadcrumb
                    'colBreadCrumb.Add(assyDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                    sSubAssyName = BGENamePicker(oCompOcc.Name, mStartAssy)

                    'determine if assembly should be explored deeper or not
                    If DiveDeeper(oCompOcc) Then
                        'ok to go deeper into assembly
                        'add assembly part number to breadcrumb if going further into sub assembly                        
                        colBreadCrumb.Add(assyDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                        'sort the part
                        SortPart(oCompOcc, colBreadCrumb)
                        'subassembly
                        processAllSubOcc(oCompOcc, sMsg, iLeafNodes, iSubAssemblies, sSubAssyName, colBreadCrumb)
                    Else
                        'do not go deeper into assembly, treat as part
                        'occurrence is an assembly we do not want to go into further, treat as a part
                        mIsAssembly = False
                        SortPart(oCompOcc, colBreadCrumb)
                    End If

                    'dont go into the following sub assemblies, just the top level                    
                    'If DiveDeeper(oCompOcc) = False Then
                    '    'occurrence is an assembly we do not want to go into further, treat as a part
                    '    mIsAssembly = False
                    '    SortPart(oCompOcc, colBreadCrumb)
                    'Else
                    '    'add assembly part number to breadcrumb if going further into sub assembly                        
                    '    colBreadCrumb.Add(assyDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                    '    'sort the part
                    '    SortPart(oCompOcc, colBreadCrumb)
                    '    'subassembly
                    '    processAllSubOcc(oCompOcc, sMsg, iLeafNodes, iSubAssemblies, sSubAssyName, colBreadCrumb)
                    'End If

                End If
            End If
        Next

        'check the file path to see if it is valid
        sFilePath = sDirectoryPath & "\" & mStartAssy & "_PartsList.xlsx"

        mResults = "File created at: " & sFilePath

        'print the part list
        Debug.Print("")
        PrintColl(mCollBomImport)
        PartsList = mCollBomCompare

    End Sub

    Private Sub processAllSubOcc(ByVal oCompOcc As Inventor.ComponentOccurrence, ByRef sMsg As String,
                                 ByRef iLeafNodes As Long, ByRef iSubAssemblies As Long, ParentName As String,
                                 prevBreadCrumb As Collection)
        ' This function is called for processing sub assembly.  It is called recursively
        ' to iterate through the entire assembly tree.

        Dim oSubCompOcc As Inventor.ComponentOccurrence

        Dim sSubAssyName As String
        Dim subDoc As Inventor.Document

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

            If Not ((oSubCompOcc.BOMStructure = Inventor.BOMStructureEnum.kReferenceBOMStructure) Or (oSubCompOcc.Suppressed = True)) Then  'if not reference or suppressed or phantom then continue
                'If (Not oSubCompOcc.BOMStructure = Inventor.BOMStructureEnum.kReferenceBOMStructure) And (Not oSubCompOcc.Suppressed = True) Then  'if not reference or suppressed then continue
                ' Check if it's child occurrence (leaf node)
                If oSubCompOcc.SubOccurrences.Count = 0 Then
                    'Debug.Print oSubCompOcc.Name
                    If Not (oSubCompOcc.BOMStructure = Inventor.BOMStructureEnum.kPhantomBOMStructure) Then 'ignore phantom parts only
                        mIsAssembly = False
                        SortPart(oSubCompOcc, subBreadCrumb)
                        iLeafNodes = iLeafNodes + 1
                    End If
                Else 'it is a subassembly
                    mIsAssembly = True
                    sMsg = sMsg + oSubCompOcc.Name + vbCr
                    iSubAssemblies = iSubAssemblies + 1
                    'add subassembly to breadcrumb collection
                    subDoc = oSubCompOcc.Definition.Document
                    'check if  subassembly is a BGE
                    sSubAssyName = BGENamePicker(oSubCompOcc.Name, mParentAssy)

                    'determine if the sub assembly should be explored deeper or not
                    If DiveDeeper(oSubCompOcc) Then
                        'dive deeper into sub assembly
                        'Add oSubCompOcc.Name to breadcrumb if going further into a sub assembly
                        subBreadCrumb.Add(subDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                        SortPart(oSubCompOcc, subBreadCrumb)
                        'recursive call to this function to continue down the branch
                        processAllSubOcc(oSubCompOcc, sMsg, iLeafNodes, iSubAssemblies, sSubAssyName, subBreadCrumb)
                    Else
                        'do not dive into assembly, treat as part
                        mIsAssembly = False 'treating these assemblies as parts
                        SortPart(oSubCompOcc, subBreadCrumb)
                    End If

                    'dont go into the following sub assemblies, just the top level
                    'If DiveDeeper(oSubCompOcc) = False Then
                    '    mIsAssembly = False 'treating these assemblies as parts
                    '    SortPart(oSubCompOcc, subBreadCrumb)
                    'Else
                    '    'Add oSubCompOcc.Name to breadcrumb if going further into a sub assembly
                    '    subBreadCrumb.Add(subDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                    '    SortPart(oSubCompOcc, subBreadCrumb)
                    '    'recursive call to this function to continue down the branch
                    '    processAllSubOcc(oSubCompOcc, sMsg, iLeafNodes, iSubAssemblies, sSubAssyName, subBreadCrumb)
                    'End If
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

        sCurrentYear = "BY" & mYear

        'get first letter of occurrence name, may want to use part number property instead
        sFirstLetter = Left(oCompOcc.Name, 1)
        'get first two letters of occurrence name, may want to use part number property instead
        sFirstTwo = Left(oCompOcc.Name, 2)
        sPrefix = GetPrefix(oCompOcc.Name)

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
                                'go into B49 assemblies based on setting
                                If mBomCompSettings.bBomCompAllowBAssyParent Then 'true = dont go deeper, show no children
                                    'do not go deeper into assembly, no children
                                    '***********
                                    'want to go deeper, the filtering of what parts go onto what collections is handled in AddToCollection sub
                                    '**********
                                    Return True 'currently true to go into all B49 sub assemblies
                                Else
                                    'go deeper into assembly, children will be shown
                                    Return True
                                End If
                                ' True = Do not go into assy (no children), False = OK to go into sub assy
                                'Return Not mBomCompSettings.bBomCompIncBassy
                            Case "B47", "BGE", "BPH"
                                'Ok to go into assemblies
                                Return True
                            Case "B39"
                                'check if B39 children are included
                                Return mBomCompSettings.bBomCompIncB39Children 'return state of checkbox checked = true
                            Case "B45"
                                'check if B45 children are included
                                Return mBomCompSettings.bBomCompIncB45Children
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

    Private Sub SortPart(ByVal oCompOcc As Inventor.ComponentOccurrence, ByVal collBreadCrumb As Collection)
        'sub to filter out desired parts and take further action

        Dim partProps As Inventor.PropertySets  'variable for the property sets object of the occurrence
        Dim sFirstTwo As String 'variable for first two letters of part number/name
        Dim sFirstLetter As String 'variable for holding the first letter of the part number/name
        Dim docDef As Inventor.ComponentDefinition
        Dim sCurrentYear As String

        sCurrentYear = "BY" & mYear

        docDef = oCompOcc.Definition
        partProps = oCompOcc.Definition.Document.PropertySets

        'get first letter of occurrence name, may want to use part number property instead
        sFirstLetter = Left(oCompOcc.Name, 1)
        'get first two letters of occurrence name, may want to use part number property instead
        sFirstTwo = Left(oCompOcc.Name, 2)

        'check if occurrence is a virtual component
        If docDef.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
            'Get the properties of the virtual component
            GetProps(oCompOcc, PartType.VirtualPart, collBreadCrumb)
            Exit Sub
        End If

        Dim sPrefix As String
        sPrefix = GetPrefix(oCompOcc.Name)

        Select Case sFirstLetter
            Case "N", "S", "K", "D"
                'standard parts
                GetProps(oCompOcc, PartType.StandardPart, collBreadCrumb)
            Case "B"
                'MDE parts
                Select Case sFirstTwo
                    Case "BY"
                        'purchased part
                        If sPrefix = sCurrentYear Then
                            'current year purch part
                            GetProps(oCompOcc, PartType.PurchPart, collBreadCrumb)
                        Else
                            GetProps(oCompOcc, PartType.OldPurchPart, collBreadCrumb)
                        End If

                    Case Else
                        Select Case sPrefix
                            Case "B20", "B30", "B40", "B47", "B61", "B62", "B82", "B87", "B92", "B39", "B45"
                                GetProps(oCompOcc, PartType.ManufPart, collBreadCrumb)
                            Case "B0049", "B49"
                                'add the B49 assy to the parts list
                                GetProps(oCompOcc, PartType.BAssy, collBreadCrumb)
                            Case "BGE"
                                'BGE part generic
                                GetProps(oCompOcc, PartType.BGEPart, collBreadCrumb)
                            Case "BPH"
                                'BPH part, phantom part same as BGE
                                GetProps(oCompOcc, PartType.BPHPart, collBreadCrumb)
                            Case Else
                                'unknown part
                                GetProps(oCompOcc, PartType.Unknown, collBreadCrumb)
                        End Select
                End Select

            Case "C"
                'MBO parts
                Select Case sFirstTwo
                    Case "CY"
                        'purchased part
                        If sPrefix = sCurrentYear Then
                            'current year purch part
                            GetProps(oCompOcc, PartType.PurchPart, collBreadCrumb)
                        Else
                            GetProps(oCompOcc, PartType.OldPurchPart, collBreadCrumb)
                        End If
                    Case Else
                        Select Case sPrefix
                            Case "C20", "C30", "C40", "C47", "C61", "C62", "C82", "C87", "C92", "C39", "C45"
                                GetProps(oCompOcc, PartType.ManufPart, collBreadCrumb)
                            Case "C0049", "C49"
                                'case to allow C49 assemblies to be parts in the list
                                'add the C49 assy to the parts list
                                GetProps(oCompOcc, PartType.CAssy, collBreadCrumb)
                            Case "CGE"
                                'BGE part
                                GetProps(oCompOcc, PartType.BGEPart, collBreadCrumb)
                            Case "CPH"
                                'phantom part
                                GetProps(oCompOcc, PartType.BPHPart, collBreadCrumb)
                            Case Else
                                'unknown part
                                GetProps(oCompOcc, PartType.Unknown, collBreadCrumb)
                        End Select
                End Select
            Case Else
                'some unknown part
                GetProps(oCompOcc, PartType.Unknown, collBreadCrumb)
        End Select

    End Sub

    Private Sub GetProps(ByVal oCompOcc As Inventor.ComponentOccurrence, ByVal currentOccurrenceType As PartType, ByVal collBreadCrumb As Collection)
        'sub to get the desired properties from the occurrence
        'Proman Class Code, Part Number, Description English, Cust Serv Code

        'initialize variables
        Dim partProps As Inventor.PropertySets
        'Dim sPromanCode As String = ""
        'Dim sDescription As String = ""
        'Dim sServCode As String = ""
        'Dim sPartNum As String = ""
        'Dim sVendCode As String = ""
        'Dim sManufName As String = ""
        'Dim sManufNum As String = ""
        Dim bError As Boolean = False
        'Dim sErrorMsg As String = ""
        'Dim sBomCompareKey As String = "" 'used to store the key for the collection PartNum + ParentAssy
        Dim ParentInfo As ParentStatus
        Dim sBomImportKey As String = "" 'variable for key for all parts collection
        Dim sPartCreateKey As String = "" 'variable for key for new parts collection

        'define myPartInfo as class of cPartInfo
        Dim occurrenceInfo As New cPartInfo
        'Dim PartCreatePartInfo As cPartInfo
        'Dim BomImportPartInfo As cPartInfo
        'Dim BomCompPartInfo As cPartInfo

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

                'sPartNum = oCompOcc.Definition.PropertySets.item("Design Tracking Properties").item("Part Number").value
                'sPromanCode = "XXXXXX"
                'sDescription = "XXXX XXXX"
                'sServCode = "XX"
                bError = True
                'sErrorMsg = "Virtual Part: Missing Info"

            Case PartType.ManufPart, PartType.BAssy
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'some parts may not have these items, such as proman class code, probably older items
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    'sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.ServiceCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                    'sServCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(occurrenceInfo.ServiceCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'ServiceCodeErr(sServCode, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.CAssy
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'some parts may not have these items, such as proman class code, probably older items
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo.PromanCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    'sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.ServiceCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                    'sServCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(occurrenceInfo.ServiceCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'ServiceCodeErr(sServCode, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.PurchPart
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo.PromanCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    'sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.ServiceCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                    'sServCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(occurrenceInfo.ServiceCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'ServiceCodeErr(sServCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    'may need to check the vendor code for standard parts, should be the 6-digit alpha code 
                    occurrenceInfo.VendorCode = partProps.Item("User Defined Properties").Item("Supplier").Value
                    'sVendCode = partProps.Item("User Defined Properties").Item("Supplier").Value
                Catch
                    VendorCodeErr(occurrenceInfo.VendorCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'VendorCodeErr(sVendCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.ManufName = partProps.Item("User Defined Properties").Item("Manufacturer Name").Value
                    'sManufName = partProps.Item("User Defined Properties").Item("Manufacturer Name").Value
                Catch
                    ManufNameErr(occurrenceInfo.ManufName, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'ManufNameErr(sManufName, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.ManufNum = partProps.Item("User Defined Properties").Item("Supplier Part Nb").Value
                    'sManufNum = partProps.Item("User Defined Properties").Item("Supplier Part Nb").Value
                Catch
                    ManufNumErr(occurrenceInfo.ManufNum, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'ManufNumErr(sManufNum, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.OldPurchPart
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo.PromanCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                'some parts may not have these items, such as proman class code, probably older items
                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    'sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.ServiceCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                    'sServCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(occurrenceInfo.ServiceCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'ServiceCodeErr(sServCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.VendorCode = partProps.Item("User Defined Properties").Item("Supplier Mnem").Value
                    'sVendCode = partProps.Item("User Defined Properties").Item("Supplier Mnem").Value
                Catch
                    VendorCodeErr(occurrenceInfo.VendorCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'VendorCodeErr(sVendCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.ManufName = partProps.Item("User Defined Properties").Item("Supplier").Value
                    'sManufName = partProps.Item("User Defined Properties").Item("Supplier").Value
                Catch
                    ManufNameErr(occurrenceInfo.ManufName, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'ManufNameErr(sManufName, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.ManufNum = partProps.Item("User Defined Properties").Item("Supplier Part Nb").Value
                    'sManufNum = partProps.Item("User Defined Properties").Item("Supplier Part Nb").Value
                Catch
                    ManufNumErr(occurrenceInfo.ManufNum, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'ManufNumErr(sManufNum, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.StandardPart
                'Standard parts will not be in Part Create Collection, but will be in BOM Import Collection
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    occurrenceInfo.PromanCode = "STD"
                    'sPromanCode = "STD"
                Catch
                    PromanErr(occurrenceInfo.PromanCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    'sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.BGEPart 'BGE Parts should not appear in the BOM Import Collection, or the Part Create Collection, just keeping it as an option just in case
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    occurrenceInfo.PromanCode = "BGE"
                    'sPromanCode = "BGE"
                Catch
                    PromanErr(occurrenceInfo.PromanCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    'sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.BPHPart 'BPH Parts should not appear in the BOM Import Collection, or the Part Create Collection, or BOM Compare just keeping it as an option just in case
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    occurrenceInfo.PromanCode = "BPH"
                    'sPromanCode = "BPH"
                Catch
                    PromanErr(occurrenceInfo.PromanCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    'sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.Unknown
                'Get the part number from the status tab of the iProperties
                occurrenceInfo.PartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                'sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    occurrenceInfo.PromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                    'sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(occurrenceInfo.PromanCode, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    occurrenceInfo.Description = partProps.Item("User Defined Properties").Item("Description English").Value
                    'sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(occurrenceInfo.Description, bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                    'DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

                'General error for unknown part, check for missing information
                UnknownPartErr(bError, mErrorStatus, occurrenceInfo.ErrorMsg)
                'UnknownPartErr(bError, mErrorStatus, sErrorMsg)

        End Select

        'define the key for the item in the collection, PartNumber + Parent Part

        '*************will need parent info for each part collection, currently it is in all parts
        ParentInfo = BomImportFindParent(collBreadCrumb, occurrenceInfo.PartNum) 'sPartNum)

        'sBomImportKey = occurrenceInfo.PartNum & ParentInfo.ParentName 'sPartNum & ParentInfo.ParentName
        sPartCreateKey = occurrenceInfo.PartNum
        'sBomCompareKey = occurrenceInfo.PartNum 'sPartNum

#Region "Create parts collection commented out"
        'Build Create Parts collection
        If Not KeyExists(mCollPartCreate, spartcreatekey) Then

            'if include b49 is true and part is a b49 then do all this
            If (mPartCreateSettings.bPartCreatIncBassy = False) And (currentOccurrenceType = PartType.BAssy) Then
                'do nothing, b49 assemblies not added to part create collection if option is not checked
            ElseIf (currentOccurrenceType = PartType.BGEPart) Then
                'do nothing, bge parts should never be created
            ElseIf (currentOccurrenceType = PartType.OldPurchPart) Then
                'do nothing, prior year purchased parts should never be created
            ElseIf currentOccurrenceType = PartType.StandardPart Then
                'do nothing, standard parts not added to part create collection
            Else
                'create instance of partinfo class for new parts
                'partcreatepartinfo = New cPartInfo
                'add properties to partcreatepartinfo
                'partcreatepartinfo.partnum = spartnum
                'partcreatepartinfo.description = CommaReplacer(sdescription)
                'partcreatepartinfo.servicecode = sservcode
                'partcreatepartinfo.promancode = spromancode
                'partcreatepartinfo.vendorcode = svendcode
                'partcreatepartinfo.manufname = CommaReplacer(smanufname)
                'partcreatepartinfo.manufnum = smanufnum
                If ParentInfo.ErrorStatus = True Then
                    occurrenceInfo.ParentAssy = ParentInfo.ParentName
                    occurrenceInfo.PartError = True
                    occurrenceInfo.ErrorMsg = "invalid parent assy"
                    'partcreatepartinfo.parentassy = ParentInfo.ParentName
                    'partcreatepartinfo.parterror = True
                    'partcreatepartinfo.errormsg = "invalid parent assy"
                Else
                    occurrenceInfo.ParentAssy = ParentInfo.ParentName
                    occurrenceInfo.PartError = False
                    occurrenceInfo.ErrorMsg = "Some Error here?"
                    'partcreatepartinfo.parentassy = ParentInfo.ParentName
                    'partcreatepartinfo.parterror = bError
                    'partcreatepartinfo.errormsg = serrormsg
                End If
                occurrenceInfo.ParentAssy = FindParent(collBreadCrumb).ParentName
                occurrenceInfo.Breadcrumb = collBreadCrumb
                'partcreatepartinfo.parentassy = FindParent(collBreadCrumb).ParentName
                'partcreatepartinfo.breadcrumb = collBreadCrumb
                'bump the quantity of the part (starts at 0)
                occurrenceInfo.IncrementQty(1)
                'partcreatepartinfo.incrementqty(1)
                'add the newly created mypartinfo to the myparts collection with the part number as the key
                mCollPartCreate.Add(occurrenceInfo, sPartCreateKey) 'partcreatepartinfo, (spartcreatekey))
            End If
        Else
            'key already exists, bump the quantity of the part
            mCollPartCreate.Item(spartcreatekey).incrementqty(1)
        End If
#End Region

        'build BOM Collections
        AddToCollection(collBreadCrumb, occurrenceInfo, currentOccurrenceType)

    End Sub

    Private Sub AddToCollection(ByRef collBreadCrumb As Collection, ByVal occurrenceInfo As cPartInfo, ByRef occurrenceType As PartType)
        'sub to add occurrences to collections
        'BOM Import collection, holds all parts and correct hierarchy with part information for proman
        'BOM Compare collection, holds all the parts for the BOM compare listview, no part information required
        'occurrences should be added to collections based on user settings

        Dim sBomImportKey As String
        Dim sBomCompareKey As String
        Dim ParentInfo As ParentStatus

        ParentInfo = BomImportFindParent(collBreadCrumb, occurrenceInfo.PartNum)
        sBomImportKey = occurrenceInfo.PartNum & ParentInfo.ParentName
        sBomCompareKey = occurrenceInfo.PartNum

        'Build the BOM Compare collection of parts
        If Not KeyExists(mCollBomCompare, sBomCompareKey) Then
            'if include B49 is true and part is a B49 then add the B49's information to the collection
            If (mBomCompSettings.bBomCompAllowBAssyParent = False) And (occurrenceType = PartType.BAssy) Then
                'do nothing, B49s are not included (children promoted) and part is an assembly
            ElseIf (mBomCompSettings.bBomCompIncCAssy = False) And (occurrenceType = PartType.CAssy) Then
                'do nothing
            ElseIf occurrenceType = PartType.BGEPart Then
                'do nothing
            ElseIf occurrenceType = PartType.BPHPart Then
                'do nothing
            ElseIf (IsBFourtyNine(BOMCompareFindParent(collBreadCrumb, occurrenceInfo.PartNum).ParentName)) And mBomCompSettings.bBomCompAllowBAssyParent Then
                'parent is a B49 and setting says to show only B49 parents so do not add child
            Else
                'create instance of the partinfo class for all parts
                occurrenceInfo.Description = CommaReplacer(occurrenceInfo.Description)
                'bump the quantity of the part (starts at 0)
                occurrenceInfo.IncrementQty(1)
                'add the newly created BomCompPartInfo to the mCollBomCompare collection with the part number as the key
                mCollBomCompare.Add(occurrenceInfo, sBomCompareKey)
            End If
        Else
            'key already exists, bump the quantity of the part
            mCollBomCompare.Item(sBomCompareKey).IncrementQty(1)
        End If

        'Build the BOM Import collection of parts
        If Not KeyExists(mCollBomImport, sBomImportKey) Then
            ParentInfo = BomImportFindParent(collBreadCrumb, occurrenceInfo.PartNum) 'sPartNum)
            'if include B49 is true and part is a B49 then do all this
            If (mBomImportSettings.bBomImportIncBassy = False) And (occurrenceType = PartType.BAssy) Then
                'do nothing
            ElseIf (occurrenceType = PartType.BGEPart) Then
                'do nothing, BGE parts should never be added to collection
            ElseIf (IsBFourtyNine(BomImportFindParent(collBreadCrumb, occurrenceInfo.PartNum).ParentName)) And mBomImportSettings.bBomImportIncBassy Then
                'parent is a B49 and setting says to show only B49 parents so do not add child
            Else
                'if include BGE or B49 is checked, how to give the propper parent to the sub components
                If ParentInfo.ErrorStatus = True Then
                    occurrenceInfo.ParentAssy = ParentInfo.ParentName
                    occurrenceInfo.PartError = True
                    occurrenceInfo.ErrorMsg = "Invalid Parent Assy"
                Else
                    occurrenceInfo.ParentAssy = ParentInfo.ParentName
                End If
                'AllPartInfo.ParentAssy = FindParent(coll, False).Result
                occurrenceInfo.Breadcrumb = collBreadCrumb

                'bump the quantity of the part (starts at 0)
                occurrenceInfo.IncrementQty(1)
                'add the newly created AllPartInfo to the mAllParts collection with the part number + parent as the key
                mCollBomImport.Add(occurrenceInfo, sBomImportKey) 'BomImportPartInfo, (sBomImportKey))
            End If
        Else
            'key already exists, bump the quantity of the part
            mCollBomImport.Item(sBomImportKey).IncrementQty(1)
        End If

    End Sub

#Region "Error handler sub routines"

    Private Sub PromanErr(ByRef PromanCode As String, ByRef MyError As Boolean, ByRef ErrorStatus As Boolean, ByRef ErrorMsg As String)
        'sub to handle changing the values if there is no proman code in the part

        PromanCode = "XXXX"
        MyError = True
        ErrorStatus = True
        ErrorMsg = ErrorMsg & "Missing Proman Class Code"

    End Sub

    Private Sub DescriptionErr(ByRef Description As String, ByRef MyError As Boolean, ByRef ErrorStatus As Boolean, ByRef ErrorMsg As String)
        'sub to handle changing the values if there is no english description in the part

        Description = "XXXX XXXX"
        MyError = True
        ErrorStatus = True
        ErrorMsg = ErrorMsg & ", " & "Missing Description"

    End Sub

    Private Sub ServiceCodeErr(ByRef ServCode As String, ByRef MyError As Boolean, ByRef ErrorStatus As Boolean, ByRef ErrorMsg As String)
        'sub to handle changing the values if there is no Customer Service Code in the part

        ServCode = "XX"
        MyError = True
        ErrorStatus = True
        ErrorMsg = ErrorMsg & ", " & "Missing Customer Service Code"

    End Sub

    Private Sub VendorCodeErr(ByRef VendCode As String, ByRef MyError As Boolean, ByRef ErrorStatus As Boolean, ByRef ErrorMsg As String)
        'sub to handle changing the values if there is no Vendor Code in the part

        VendCode = "XXXXXX"
        MyError = True
        ErrorStatus = True
        ErrorMsg = ErrorMsg & ", " & "Missing Vendor Code"

    End Sub

    Private Sub ManufNameErr(ByRef ManufName As String, ByRef MyError As Boolean, ByRef ErrorStatus As Boolean, ByRef ErrorMsg As String)
        'sub to handle changing the values if there is no Manufacturer Name in the part

        ManufName = "XXXXXX"
        MyError = True
        ErrorStatus = True
        ErrorMsg = ErrorMsg & ", " & "Missing Manufacturer Name"

    End Sub

    Private Sub ManufNumErr(ByRef ManufNum As String, ByRef MyError As Boolean, ByRef ErrorStatus As Boolean, ByRef ErrorMsg As String)
        'sub to handle changing the values if there is no Manufacturer Name in the part

        ManufNum = "XXXXXX"
        MyError = True
        ErrorStatus = True
        ErrorMsg = ErrorMsg & ", " & "Missing Manufacturer Number"

    End Sub

    Private Sub UnknownPartErr(ByRef MyError As Boolean, ByRef ErrorStatus As Boolean, ByRef ErrorMsg As String)
        'sub to handle error information for unknown parts
        MyError = True
        ErrorStatus = True
        ErrorMsg = ErrorMsg & "," & "Unknown Type: Verify Info"

    End Sub

#End Region

    Public Function CreateExcelDoc(FilePath As String) As Boolean
        'sub to create an excel document from the parts list that was created from the assembly

        Dim XLApp As Excel.Application
        Dim wb As Excel.Workbook
        Dim ws1 As Excel.Worksheet 'for Part Create info
        Dim ws2 As Excel.Worksheet 'for BOM Import info
        'Dim ws3 As Excel.Worksheet 'for BOM Compare info
        Dim sFilePath As String = ""

        'Check if mNewParts contains items
        If IsNothing(mCollPartCreate) Then
            'Empty parts list
            MsgBox("Parts List Empty, try loading Inventor BOM")
            CreateExcelDoc = False
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
            mResults = mResults & "File Path: " & FilePath & vbNewLine & vbNewLine & "Num Unique Parts: " & CStr(PartsList.Count)
        Else
            'File Path not valid
            If mErrorStatus = True Then
                mResults = "**** ERRORS Found Some Parts Missing Info ****" & vbNewLine & vbNewLine
            End If
            mResults = mResults & "Excel file NOT created" & vbNewLine & vbNewLine & "Num Unique Parts: " & CStr(PartsList.Count)
            'dont try to create excel document
            CreateExcelDoc = False
            Exit Function
        End If

        'create the excel application, workbook and worksheet
        XLApp = CreateObject("Excel.Application")
        XLApp.DisplayAlerts = False 'dont display alert for overwriting file on save
        wb = XLApp.Workbooks.Add
        ws1 = wb.Sheets(1) 'wb.Worksheets.Item(1)
        ws2 = wb.Sheets.Add(, ws1)
        'ws3 = wb.Sheets.Add(, ws2)

        ws1.Name = "Part Create"
        ws2.Name = "EXPERIMENTAL"
        'ws3.Name = "BOM Compare"
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
            '.Range("H1").Value = "Parent Assy"
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

        'create column headings for ws3
        'With ws3
        '    .Range("A1").Value = "Part Number"
        '    .Range("B1").Value = "Description"
        '    .Range("C1").Value = "QPA"
        '    'color heading row gray
        '    .Range("A1:C1").Interior.Color = mikronBlue 'RGB(178, 178, 178)
        '    'color heading text
        '    .Range("A1:C1").Font.Color = headingTextColor
        '    'bold heading row column headings
        '    .Range("A1:C1").Font.Bold = True
        'End With

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
                '.Range("H" & row).Value = part.ParentAssy
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
        For Each part In mCollBomImport
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

        'start filling in table on row 2
        row = 2

        'populate the remaining cells for ws3
        'For Each part In mCollBomCompare
        '    With ws3
        '        .Range("A" & row).Value = part.PartNum
        '        .Range("B" & row).Value = part.Description
        '        .Range("C" & row).Value = part.Qty
        '        If part.PartError = True Then
        '            'color error rows
        '            .Range("A" & row & ":" & "C" & row).Interior.Color = errorColor
        '        End If
        '    End With
        '    row = row + 1
        'Next

        'autosize columns
        ws1.Columns("A:J").AutoFit
        ws2.Columns("A:K").Autofit
        'ws3.Columns("A:D").Autofit

        'autosort by part number on ws3
        'ws3.Columns("A:C").Sort(Key1:=ws3.Range("A2"), Order1:=Excel.XlSortOrder.xlAscending, Header:=Excel.XlYesNoGuess.xlYes)

        Try
            wb.SaveAs(Filename:=FilePath, AccessMode:=Excel.XlSaveAsAccessMode.xlExclusive, ConflictResolution:=Excel.XlSaveConflictResolution.xlLocalSessionChanges)
            CreateExcelDoc = True
            wb.Close()
            XLApp.Quit()
        Catch ex As Exception
            CreateExcelDoc = False
            wb.Close()
            XLApp.Quit()
        End Try

    End Function

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
        Dim parent As String

        For i = 0 To collBreadcrumb.Count
            Try
                parent = collBreadcrumb.Item(collBreadcrumb.Count - i)
                If sChild = parent Then
                    'cant have a child part have itself as a parent 
                Else
                    If IsBGE(parent) Then
                        'cant have BGE as parent
                    ElseIf IsBFourtyNine(parent) Then
                        'are B49s allowed to be parents??
                        If mBomCompSettings.bBomCompAllowBAssyParent Then
                            'B49s allowed to be parents
                            BOMCompareFindParent.ParentName = parent
                            Exit Function
                        End If
                    Else
                        'parent is not a B49 or a BGE so it is OK
                        BOMCompareFindParent.ParentName = parent
                        Exit Function
                    End If
                End If

            Catch ex As Exception
                BOMCompareFindParent.ParentName = "INVALID Parent"
                BOMCompareFindParent.ErrorStatus = True
                mErrorStatus = True
            End Try
        Next

    End Function

    Private Function BomImportFindParent(collBreadCrumb As Collection, sChild As String) As ParentStatus
        'function to find the parent assembly by going backwards through the breadcrumb collection
        'coll is the breadcrumb collection 
        'depending on settings, BGE and B49 parts will or will not be parents

        Dim i As Integer
        Dim parent As String

        For i = 0 To collBreadCrumb.Count
            Try
                parent = collBreadCrumb.Item(collBreadCrumb.Count - i)
                If sChild = parent Then
                    'cant have a child part have itself as a parent 
                Else
                    If IsBGE(parent) Then
                        'cant have BGE as parent
                    ElseIf IsBFourtyNine(parent) Then
                        'are B49s allowed to be parents??
                        If mBomImportSettings.bBomImportIncBassy = True Then
                            'B49s allowed to be parents
                            BomImportFindParent.ParentName = parent
                            Exit Function
                        End If
                    Else
                        'parent is not a B49 or a BGE so it is OK
                        BomImportFindParent.ParentName = parent
                        Exit Function
                    End If
                End If

            Catch ex As Exception
                BomImportFindParent.ParentName = "INVALID Parent"
                BomImportFindParent.ErrorStatus = True
                mErrorStatus = True
            End Try
        Next

        'AllPartsFindParent.ParentName = "****"
        'AllPartsFindParent.ErrorStatus = True

    End Function

    Private Function FindParent(coll As Collection) As ParentStatus
        'function to find the parent assembly by going backwards through the breadcrumb collection
        'coll is the breadcrumb collection 
        'depending on settings, BGE and B49 parts will or will not be parents
        'This only really affects the mAllParts collection since that is the only collection that needs the parents.

        Dim i As Integer
        Dim parent As String

        For i = 0 To coll.Count
            Try
                parent = coll.Item(coll.Count - i)
                If mIsAssembly = False Then
                    'occurrence is a part, OK to have BGE or B49 as parent if setting is included
                    If IsBGE(parent) = True Then
                        'parent is a BGE part, check if BGEs are included
                    ElseIf IsBFourtyNine(parent) = True Then
                        'parent is B49, check if B49s are included
                        If mBomImportSettings.bBomImportIncBassy = True Then
                            'OK to have B49 parent
                            FindParent.ParentName = parent
                            Exit Function
                        End If
                    Else
                        'not a B49 or BGE parent
                        FindParent.ParentName = parent
                        Exit Function
                    End If

                Else
                    'occurrence is an assembly, NOT OK to have BGE or B49 as parent
                    If Not (IsBGE(parent) Or IsBFourtyNine(parent)) Then
                        'parent is NOT a BGE or B49
                        FindParent.ParentName = parent
                        Exit Function
                    End If
                End If
            Catch ex As Exception
                FindParent.ParentName = "INVALID BGE Parent"
                FindParent.ErrorStatus = True
                mErrorStatus = True
            End Try
        Next

        FindParent.ParentName = "****"
        FindParent.ErrorStatus = True

    End Function

    Private Function IsBGE(Name As String) As Boolean
        'determine if Name is a BGE part number and return TRUE if it is

        Dim iPeriodLoc As Integer
        Dim sPrefix As String = ""

        'identify where the period is in the Parent part
        iPeriodLoc = InStr(Name, ".")
        If iPeriodLoc <> 0 Then
            sPrefix = Left(Name, iPeriodLoc - 1)
        End If

        If sPrefix = "BGE" Then
            IsBGE = True
        Else
            IsBGE = False
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
