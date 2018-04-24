Imports Inventor
Imports Microsoft.Office.Interop
Imports System.IO

Module BOMExport

    Private mMyParts As Collection 'variable to hold the collection of parts
    Private mStartAssy As String 'holds the top level assembly name
    Private mIgnoreYr As Boolean 'checkbox to include prior year purch parts or not
    Private mYear As String 'variable to hold the current year as a string
    Private mParentAssy As String 'variable to hold the name of the parent assembly for a part
    Private mAddBAssy As Boolean 'variable to hold flag for adding B49 assemblies to part list
    Private mErrorStatus As Boolean 'variable to show if an error has occurred or not

    Private Structure ParentStatus
        Public ErrorStatus As Boolean
        Public Result As String
    End Structure

    'enum to characterize the type of part that is identified
    'this helps with handling the different types of parts
    Private Enum PartType As Integer
        ManufPart = 1
        PurchPart = 2
        VirtualPart = 3
        OldPurchPart = 4
        BAssy = 5 'for B049, B0049 assemblies
    End Enum

    Public Results As String = "" 'variable used for displaying the results

    Public Sub AssemblyCount(ThisApplication As Inventor.Application, bIgnorePriorYr As Boolean, sDirectoryPath As String, AddBAssy As Boolean)
        ' Set reference to active document.
        ' This assumes the active document is an assembly
        Dim oDoc As Inventor.AssemblyDocument

        If ThisApplication.ActiveDocumentType <> Inventor.DocumentTypeEnum.kAssemblyDocumentObject Then
            MsgBox("Assembly document must be active")
            Results = "No Report Created, Assembly must be active"
            Exit Sub
        End If

        oDoc = ThisApplication.ActiveDocument
        mMyParts = New Collection

        ' Get assembly component definition
        Dim oCompDef As Inventor.ComponentDefinition
        oCompDef = oDoc.ComponentDefinition

        Dim sMsg As String
        Dim iLeafNodes As Long
        Dim iSubAssemblies As Long
        Dim sSubAssyName As String
        Dim assyDoc As Inventor.AssemblyDocument
        Dim colBreadCrumb As Collection
        Dim thisDate As Date
        Dim sFilePath As String

        sMsg = ""
        mIgnoreYr = bIgnorePriorYr
        mParentAssy = ""
        mAddBAssy = AddBAssy
        mErrorStatus = False
        Results = ""

        'Get the current year,  then get the last two characters to get the year string
        mYear = Right(CStr(thisDate.Year), 2)

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
            If (Not oCompOcc.BOMStructure = Inventor.BOMStructureEnum.kReferenceBOMStructure) And (Not oCompOcc.Suppressed = True) Then  'if not reference or suppressed then continue
                'Check if it's child occurrence (leaf node)
                If oCompOcc.SubOccurrences.Count = 0 Then
                    'not a sub assembly
                    mParentAssy = mStartAssy
                    SortPart(oCompOcc, colBreadCrumb)
                    iLeafNodes = iLeafNodes + 1
                Else
                    'sub assembly found
                    SortPart(oCompOcc, colBreadCrumb)
                    iSubAssemblies = iSubAssemblies + 1
                    assyDoc = oCompOcc.Definition.Document
                    'add subassembly part number to breadcrumb
                    colBreadCrumb.Add(assyDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                    sSubAssyName = BGENamePicker(oCompOcc.Name, mStartAssy)
                    'subassembly
                    processAllSubOcc(oCompOcc, sMsg, iLeafNodes, iSubAssemblies, sSubAssyName, colBreadCrumb)
                End If
            End If
        Next

        'check the file path to see if it is valid
        sFilePath = sDirectoryPath & "\" & mStartAssy & "_PartsList.xlsx"

        If IsValidFileNameOrPath(sFilePath) And IsDirectoryValid(sDirectoryPath) Then
            'file name is valid and directory path is valid
            Debug.Print("")
            If mErrorStatus = True Then
                Debug.Print("**** ERRORS FOUND See Excel Document ****")
                Results = "**** ERRORS FOUND Check Excel Document ****" & vbNewLine
            End If
            Debug.Print("Num unique Parts: " & mMyParts.Count)
            Debug.Print("No of sub assemblies: " + CStr(iSubAssemblies))
            Results = Results & "File Path: " & sFilePath & vbNewLine &
            "Num Unique Parts: " & CStr(mMyParts.Count) & vbNewLine & "Num Sub Assemblies: " & CStr(iSubAssemblies)
            If CreateExcelDoc(mMyParts, mStartAssy, sFilePath) = False Then
                Results = Results & vbNewLine & "**** No Excel File Created ****" & vbNewLine
            End If
        Else
            Debug.Print("")
            If mErrorStatus = True Then
                Debug.Print("**** ERRORS FOUND Parts Missing Info ****")
                Results = "**** ERRORS FOUND Some Parts Missing Info ****" & vbNewLine
            End If
            Debug.Print("Excel Document NOT created")
            Debug.Print("Num unique Parts: " & mMyParts.Count)
            Debug.Print("No of sub assemblies: " + CStr(iSubAssemblies))
            Results = Results & "Excel file NOT created" & vbNewLine &
            "Num Unique Parts: " & CStr(mMyParts.Count) & vbNewLine & "Num Sub Assemblies: " & CStr(iSubAssemblies)
        End If


        'if file path is not selected, then do not create an excel file
        'If sFilePath <> "Choose a Folder" Then
        'Debug.Print("")
        'If mErrorStatus = True Then
        'Debug.Print("**** ERRORS FOUND Check Excel ****")
        'Results = "**** ERRORS FOUND Check Excel ****" & vbNewLine
        'End If
        'Debug.Print("Num unique Parts: " & mMyParts.Count)
        'Debug.Print("No of sub assemblies: " + CStr(iSubAssemblies))
        'Results = Results & "File Path: " & sFilePath & "\" & mStartAssy & "_PartsList.xlsx" & vbNewLine &
        '"Num Unique Parts: " & CStr(mMyParts.Count) & vbNewLine & "Num Sub Assemblies: " & CStr(iSubAssemblies)
        'Call CreateExcelDoc(mMyParts, mStartAssy, sFilePath)
        'Else
        'Debug.Print("")
        'If mErrorStatus = True Then
        'Debug.Print("**** ERRORS FOUND Check Excel ****")
        'Results = "**** ERRORS FOUND Check Excel ****" & vbNewLine
        'End If
        'Debug.Print("Excel Document NOT created")
        'Debug.Print("Num unique Parts: " & mMyParts.Count)
        'Debug.Print("No of sub assemblies: " + CStr(iSubAssemblies))
        'Results = Results & "Excel file NOT created" & vbNewLine &
        '"Num Unique Parts: " & CStr(mMyParts.Count) & vbNewLine & "Num Sub Assemblies: " & CStr(iSubAssemblies)
        'End If

        'print the part list
        Debug.Print("")
        PrintColl(mMyParts)

    End Sub

    Private Sub processAllSubOcc(ByVal oCompOcc As Inventor.ComponentOccurrence, ByRef sMsg As String, ByRef iLeafNodes As Long, ByRef iSubAssemblies As Long, ParentName As String, prevBreadCrumb As Collection)
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

            ' Check if it's child occurrence (leaf node)
            If oSubCompOcc.SubOccurrences.Count = 0 Then
                'Debug.Print oSubCompOcc.Name
                SortPart(oSubCompOcc, subBreadCrumb)
                iLeafNodes = iLeafNodes + 1
            Else 'it is a subassembly
                sMsg = sMsg + oSubCompOcc.Name + vbCr
                iSubAssemblies = iSubAssemblies + 1
                'add subassembly to breadcrumb collection
                subDoc = oSubCompOcc.Definition.Document
                'subBreadCrumb.Add oSubCompOcc.Name
                subBreadCrumb.Add(subDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value)
                'check if  subassembly is a BGE
                sSubAssyName = BGENamePicker(oSubCompOcc.Name, mParentAssy)
                'recursive call to this function to continue down the branch
                processAllSubOcc(oSubCompOcc, sMsg, iLeafNodes, iSubAssemblies, sSubAssyName, subBreadCrumb)
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

    Private Sub SortPart(ByVal oCompOcc As Inventor.ComponentOccurrence, ByVal coll As Collection)
        'sub to filter out desired parts and take further action

        Dim PeriodLoc As Integer 'variable to hold the location of the period in the name
        Dim partProps As Inventor.PropertySets  'variable for the property sets object of the occurrence
        Dim sFirstTwo As String 'variable for first two letters of part number/name
        Dim docDef As Inventor.ComponentDefinition
        Dim sCurrentYear As String

        sCurrentYear = "BY" & mYear

        docDef = oCompOcc.Definition
        partProps = oCompOcc.Definition.Document.PropertySets

        'get first two letters of occurrence name, may want to use part number property instead
        sFirstTwo = Left(oCompOcc.Name, 2)

        'check if occurrence is a virtual component
        If docDef.Type = Inventor.ObjectTypeEnum.kVirtualComponentDefinitionObject Then
            'Get the properties of the virtual component
            GetProps(oCompOcc, PartType.VirtualPart, coll)
            Exit Sub
        End If

        'search for the period in the occurrence name, if it doesnt have one, skip the occurrence
        PeriodLoc = InStr(oCompOcc.Name, ".")
        If PeriodLoc <> 0 Then 'InStr returns 0 if the string is not found

            Dim prefix As String
            prefix = Left(oCompOcc.Name, PeriodLoc - 1)

            Select Case prefix
        'pick out desired parts
        'may want to expand this search to get all the characters to the first period, it may be more robust that way for other parts
                Case "B20", "B30", "B39", "B40", "B45", "B47", "B61", "B62", "B82", "B87", "B92"
                    GetProps(oCompOcc, PartType.ManufPart, coll)
                    Exit Sub
                Case "B0049", "B49"
                    'case to allow B49 assemblies to be parts in the list
                    If mAddBAssy = True Then
                        'add the B49 assy to the parts list
                        GetProps(oCompOcc, PartType.BAssy, coll)
                    End If
                    Exit Sub
            End Select

            'needed a second select case for the BY part numbers, this avoids having to list all the years of BY part numbers
            'in the case expression
            'also need to distinguish between old and new purchased parts since some information is in different iProperties
            Select Case sFirstTwo
                Case "BY"
                    'ignoring old purch parts?
                    If mIgnoreYr = False Then 'not ignoring old purch parts
                        'check if part is a prior year part
                        If prefix <> sCurrentYear Then
                            'prefix does not match current year parts, it is an old purch part
                            GetProps(oCompOcc, PartType.OldPurchPart, coll)
                        End If
                        'prefix matches current year prefix so it is a current purch part
                        GetProps(oCompOcc, PartType.PurchPart, coll)
                        'if ignore year is selected and part is not BY+current year then it is an old purch part, do nothing
                    ElseIf mIgnoreYr = True And prefix <> sCurrentYear Then
                        'Prior year part, do nothing
                    Else
                        GetProps(oCompOcc, PartType.PurchPart, coll)
                    End If
            End Select

        End If
    End Sub

    Private Sub GetProps(ByVal oCompOcc As Inventor.ComponentOccurrence, ByVal desiredPart As PartType, ByVal coll As Collection)
        'sub to get the desired properties from the occurrence
        'Proman Class Code, Part Number, Description English, Cust Serv Code

        'initialize variables
        Dim partProps As Inventor.PropertySets
        Dim sPromanCode As String = ""
        Dim sDescription As String = ""
        Dim sServCode As String = ""
        Dim sPartNum As String = ""
        Dim sVendCode As String = ""
        Dim sManufName As String = ""
        Dim sManufNum As String = ""
        Dim bError As Boolean = False
        Dim sErrorMsg As String = ""
        Dim sKey As String = "" 'used to store the key for the collection PartNum + ParentAssy
        Dim myParts As New Collection
        Dim ParentInfo As ParentStatus

        'define myPartInfo as class of cPartInfo
        Dim myPartInfo As cPartInfo
        'assign part properties object
        partProps = oCompOcc.Definition.Document.PropertySets

        Select Case desiredPart
            Case PartType.VirtualPart
                'virtual parts have a different location to get the part number
                'assign the other fields manually
                sPartNum = oCompOcc.Definition.PropertySets.item("Design Tracking Properties").item("Part Number").value
                sPromanCode = "XXXXXX"
                sDescription = "XXXX XXXX"
                sServCode = "XX"

            Case PartType.ManufPart, PartType.BAssy
                'Get the part number from the status tab of the iProperties
                sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    'some parts may not have these items, such as proman class code, probably older items
                    sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sServCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(sServCode, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.PurchPart
                'Get the part number from the status tab of the iProperties
                sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                'some parts may not have these items, such as proman class code, probably older items
                Try
                    sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sServCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(sServCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sVendCode = partProps.Item("User Defined Properties").Item("Supplier").Value
                Catch
                    VendorCodeErr(sVendCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sManufName = partProps.Item("User Defined Properties").Item("Manufacturer Name").Value
                Catch
                    ManufNameErr(sManufName, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sManufNum = partProps.Item("User Defined Properties").Item("Supplier Part Nb").Value
                Catch
                    ManufNumErr(sManufNum, bError, mErrorStatus, sErrorMsg)
                End Try

            Case PartType.OldPurchPart
                'Get the part number from the status tab of the iProperties
                sPartNum = partProps.Item("Design Tracking Properties").Item("Part Number").Value
                Try
                    sPromanCode = partProps.Item("User Defined Properties").Item("Proman Class Code").Value
                Catch
                    PromanErr(sPromanCode, bError, mErrorStatus, sErrorMsg)
                End Try

                'some parts may not have these items, such as proman class code, probably older items
                Try
                    sDescription = partProps.Item("User Defined Properties").Item("Description English").Value
                Catch
                    DescriptionErr(sDescription, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sServCode = partProps.Item("User Defined Properties").Item("Cust Serv Code").Value
                Catch
                    ServiceCodeErr(sServCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sVendCode = partProps.Item("User Defined Properties").Item("Supplier Mnem").Value
                Catch
                    VendorCodeErr(sVendCode, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sManufName = partProps.Item("User Defined Properties").Item("Supplier").Value
                Catch
                    ManufNameErr(sManufName, bError, mErrorStatus, sErrorMsg)
                End Try

                Try
                    sManufNum = partProps.Item("User Defined Properties").Item("Supplier Part Nb").Value
                Catch
                    ManufNumErr(sManufNum, bError, mErrorStatus, sErrorMsg)
                End Try

        End Select

        'define the key for the item in the collection, PartNumber + Parent Part
        ParentInfo = FindParent(coll)
        sKey = sPartNum & ParentInfo.Result

        'add parts to collection if they are not already there
        'keys must be unique strings
        If KeyExists(mMyParts, sKey) = False Then
            'create a new instance of the PartInfo class
            myPartInfo = New cPartInfo
            'add properties to myPartInfo
            myPartInfo.PartNum = sPartNum
            myPartInfo.Description = CommaReplacer(sDescription)
            myPartInfo.ServiceCode = sServCode
            myPartInfo.PromanCode = sPromanCode
            myPartInfo.VendorCode = sVendCode
            myPartInfo.ManufName = CommaReplacer(sManufName)
            myPartInfo.ManufNum = sManufNum

            If ParentInfo.ErrorStatus = True Then
                myPartInfo.ParentAssy = ParentInfo.Result
                myPartInfo.PartError = True
                myPartInfo.ErrorMsg = "Invalid Parent Assy"
            Else
                myPartInfo.ParentAssy = ParentInfo.Result
                myPartInfo.PartError = bError
                myPartInfo.ErrorMsg = sErrorMsg
            End If
            myPartInfo.ParentAssy = FindParent(coll).Result
            myPartInfo.Breadcrumb = coll
            'myPartInfo.PartError = bError
            'myPartInfo.ErrorMsg = sErrorMsg

            'bump the quantity of the part (starts at 0)
            myPartInfo.IncrementQty(1)
            'add the newly created myPartInfo to the myParts collection with the part number as the key
            mMyParts.Add(myPartInfo, (sPartNum & myPartInfo.ParentAssy))
        Else
            'key already exists, bump the quantity of the part
            mMyParts.Item(sKey).IncrementQty(1)
        End If

        Exit Sub

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
#End Region

    Private Function CreateExcelDoc(PartsList As Collection, AssyName As String, FilePath As String) As Boolean
        'sub to create an excel document from the parts list that was created from the assembly

        Dim XLApp As Excel.Application
        Dim wb As Excel.Workbook
        Dim ws As Excel.Worksheet

        'create the excel application, workbook and worksheet
        XLApp = CreateObject("Excel.Application")
        wb = XLApp.Workbooks.Add
        ws = wb.Worksheets.Item(1)

        'add items to the worksheet
        Dim part As cPartInfo
        Dim row As Integer

        'start filling in table on row 2
        row = 2

        'create column headings
        With ws
            .Range("A1").Value = "Part Number"
            .Range("B1").Value = "Class Code"
            .Range("C1").Value = "Description"
            .Range("D1").Value = "Serv Code"
            .Range("E1").Value = "Vend Code"
            .Range("F1").Value = "Manuf Name"
            .Range("G1").Value = "Manuf Num"
            .Range("H1").Value = "Parent Assy"
            .Range("I1").Value = "QPA"
            .Range("J1").Value = "Errors"
            'color heading row gray
            .Range("A1").EntireRow.Interior.Color = RGB(178, 178, 178)
            'bold heading row column headings
            .Range("A1:J1").Font.Bold = True

        End With

        'populate the remaining cells
        For Each part In mMyParts
            With ws
                .Range("A" & row).Value = part.PartNum
                .Range("B" & row).Value = part.PromanCode
                .Range("C" & row).Value = part.Description
                .Range("D" & row).Value = part.ServiceCode
                .Range("E" & row).Value = part.VendorCode
                .Range("F" & row).Value = part.ManufName
                .Range("G" & row).Value = part.ManufNum
                .Range("H" & row).Value = part.ParentAssy
                .Range("I" & row).Value = part.Qty
                .Range("J" & row).Value = part.ErrorMsg
                If part.PartError = True Then
                    .Range("A" & row).EntireRow.Interior.Color = RGB(255, 97, 161)
                End If
            End With
            row = row + 1
        Next

        'autosize columns
        ws.Columns("A:J").AutoFit

        Try
            wb.SaveAs(FilePath)
            CreateExcelDoc = True
            wb.Close()
        Catch ex As Exception
            MsgBox("No Excel Document will be Created")
            CreateExcelDoc = False
        End Try


    End Function

    Private Sub PrintColl(PartCollection As Collection)
        'sub to debug print the parts collection

        Dim item As cPartInfo

        For Each item In PartCollection
            Debug.Print(item.PartNum & vbTab & item.PromanCode & vbTab & item.Description & vbTab & item.ServiceCode &
                vbTab & item.VendorCode & vbTab & item.ManufName & vbTab &
                item.ManufNum & vbTab & item.ParentAssy & vbTab & item.PrintBreadCrumb & vbTab & item.Qty)
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

    Private Function FindParent(coll As Collection) As ParentStatus
        'function to find the parent assembly by going backwards through the breadcrumb collection
        'this will skip over BGE assemblies and get the next parent

        Dim i As Integer

        For i = 0 To coll.Count
            Try
                'if it is not a BGE then
                If Not IsBGE(coll.Item(coll.Count - i)) Then
                    FindParent.Result = coll.Item(coll.Count - i)
                    FindParent.ErrorStatus = False
                    Exit Function
                End If
            Catch ex As Exception
                FindParent.Result = "INVALID"
                FindParent.ErrorStatus = True
                mErrorStatus = True
            End Try
        Next
        FindParent.Result = "****"
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

End Module
