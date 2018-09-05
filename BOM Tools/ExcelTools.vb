Imports Excel = Microsoft.Office.Interop.Excel

Module ExcelTools
    '*****************************
    'Module to load an excel file into a collection
    '*****************************

    Private mLastRowLetter As String
    Private mLastColLetter As String

    Public Function GetPath() As String
        'function to get the path to the desired file

        'open dialog to browse to file
        Dim myFileDlog As New System.Windows.Forms.OpenFileDialog

        'look for files starting at desktop, doesnt quite work correctly now        
        'myFileDlog.InitialDirectory = 'this is set in the properties of the included FolderBrowser1 component I think

        'specifies what type of data files to look for
        myFileDlog.Filter = "(*.xls; *.xlsx)|*.xls; *.xlsx|All Files (*.*)|*.*"

        'specifies which data type is focused on start up
        myFileDlog.FilterIndex = 1

        'Gets or sets a value indicating whether the dialog box restores the current directory before closing.
        myFileDlog.RestoreDirectory = False

        'seperates message outputs for files found or not found
        If (myFileDlog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            If Dir(myFileDlog.FileName) <> "" Then
                'MsgBox("File Exists: " & myFileDlog.FileName, MsgBoxStyle.Information)
            Else
                MsgBox("File Not Found", MsgBoxStyle.Critical)
                GetPath = ""
            End If
        End If

        'Adds the file directory to the text box
        GetPath = myFileDlog.FileName

    End Function

    Public Function ExcelToPartCollection(ByVal Path As String, ByRef PartCollection As Collection) As Collection
        'sub to load an excel document into a collection of PartInfo items

        'check if file path points to an excel document
        Dim extension As String
        extension = System.IO.Path.GetExtension(Path)

        If (extension = ".xlsx") Or (extension = ".xls") Then
            'everything good
        ElseIf (extension = "") Then
            'dialog was cancled
            Return Nothing
            Exit Function
        Else
            MsgBox("Need to open Excel Document .xlsx or .xls")
            Return Nothing
            Exit Function
        End If

        Dim xlApp As Excel.Application = Nothing
        Dim xlWb As Excel.Workbook = Nothing
        Dim xlWs As Excel.Worksheet = Nothing
        Dim myPart As cPartInfo
        Dim lastRowNum As Long
        Dim lastColNum As Long

        'load the excel application, workbook and worksheet
        xlApp = New Excel.Application
        xlWb = xlApp.Workbooks.Open(Path)
        xlWs = xlWb.Worksheets(1)

        'get the last used row and column
        lastRowNum = LastRowInOneColumn(xlWb, "L") 'last row used in row L
        lastColNum = LastColumnInOneRow(xlWb, 1) 'last column used in first row

        'Read each row in the document and assign info to the collection
        Dim i As Integer
        Dim sPartNum As String
        Dim rngPartNum As Excel.Range   'range where the part number is
        Dim rngPartQty As Excel.Range   'range where the part quantity is
        Dim intPartQty As Integer       'part quantity 
        Dim lnQBOMColNum As Long        'holds the column number of "Q BOM"
        Dim lnPartNbrColNum As Long     'holds the column number of "Part Nbr"
        Dim rngHeader As Excel.Range    'holds the range for the colum headers

        'get the column number for "Q BOM"
        rngHeader = xlWs.Range("A1:Z1")
        lnQBOMColNum = ColumnNumberByHeader("Q BOM", rngHeader)
        'get the column number for "Part Nbr"
        lnPartNbrColNum = ColumnNumberByHeader("Part Nbr", rngHeader)

        sPartNum = ""
        For i = 2 To lastRowNum 'start at row 2 to avoid header row

            'pick out the part number to use as the key in the collection
            rngPartNum = xlWs.Cells(i, lnPartNbrColNum)
            sPartNum = rngPartNum.Value

            'pick out the part quantity to use in the part info
            rngPartQty = xlWs.Cells(i, lnQBOMColNum) 'column "Q BOM"
            intPartQty = rngPartQty.Value
            'check if there is a quantity in the Q BOM column, if it is nothing don't add the part to the collection
            If Not rngPartQty.Value Is Nothing Then
                'see if part exists in the collection
                If Not KeyExists(PartCollection, sPartNum) Then
                    'Key not found, add part to collection

                    'create new instance of part info
                    myPart = New cPartInfo

                    'add part information
                    myPart.PartNum = sPartNum
                    myPart.Qty = intPartQty

                    'add the newly created myPart to the PartCollection collection using the part number as the key
                    PartCollection.Add(myPart, sPartNum)
                Else
                    'I dont think this will happen with the expedite all report for a station, I think the parts roll up to one list
                    'key already exists, need to increment the quantiy
                    PartCollection.Item(sPartNum).incrementQty(intPartQty)
                End If
            End If
        Next

        Try
            xlWb.Close()
        Catch ex As Exception
            MsgBox("ExcelTools: Problem Closing the Workbook")
        End Try

        Return PartCollection
        PrintColl(PartCollection)

    End Function

    Function LastRowInOneColumn(ByVal WB As Excel.Workbook, ByVal SearchCol As String) As Long
        'Find the last used row in a Column, SearchCol
        With WB.ActiveSheet
            LastRowInOneColumn = .Cells(.Rows.Count, SearchCol).End(Excel.XlDirection.xlUp).Row
        End With
    End Function

    Function LastColumnInOneRow(ByVal WB As Excel.Workbook, ByVal SearchRow As Integer) As Long
        'Find the last used column in a Row, SearchRow
        With WB.ActiveSheet
            LastColumnInOneRow = .Cells(SearchRow, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
        End With
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

    Private Sub PrintColl(PartCollection As Collection)
        'sub to debug print the parts collection

        Dim item As cPartInfo

        For Each item In PartCollection

            'for printing new parts collection
            'Debug.Print(item.PartNum & vbTab & item.PromanCode & vbTab & item.Description & vbTab & item.ServiceCode &
            'vbTab & item.VendorCode & vbTab & item.ManufName & vbTab &
            'item.ManufNum & vbTab & item.ParentAssy & vbTab & item.PrintBreadCrumb & vbTab & item.Qty)
            Debug.Print(item.PartNum & vbTab & vbTab & "Qty: " & item.Qty)

            'for printing all parts collection
            'Debug.Print(item.PartNum & vbTab "Qty: " & item.Qty)

            'for printing compare parts collection
            'Debug.Print(item.PartNum & vbTab & vbTab & "Qty: " & vbTab & item.Qty)
        Next
    End Sub

    Private Function ColumnNumberByHeader(text As String, headerRange As Excel.Range) As Long
        'function to get the column number by searching for the text string
        Dim foundRange As Excel.Range

        foundRange = headerRange.Find(text)
        If foundRange Is Nothing Then
            MsgBox("Q BOM Column not found")
            ColumnNumberByHeader = 0
        Else
            ColumnNumberByHeader = foundRange.Column
        End If

    End Function







End Module
