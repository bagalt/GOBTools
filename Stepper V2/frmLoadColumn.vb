Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmLoadColumn

    'form should present user with the option to select the angle column of an excel sheet
    'and columns that can be selected for adding to columns
    'it should return a letter or value for the angle column
    'it should return a letter/value or list of letters/values for the data columns

    Private angleArray(360) As String  '361 elements because that is what VNM spits out, zero based
    Private angleList As New Generic.List(Of String)(360) 'zero based?
    'Private values As Generic.List(Of String)
    Private valuesCollection As Collection 'Collection to hold all the value lists if multiple are selected

    Private xlApp As Excel.Application
    Private xlWb As Excel.Workbook
    Private xlWs As Excel.Worksheet
    Private lastCol As Long
    Private lastRow As Long

    Public Sub New(ParentForm As System.Windows.Forms.Form)

        ' This call is required by the designer.
        InitializeComponent()

        'set up combobox options
        With ComboBox1
            .Text = "Select Column..."
        End With

        'setup listview options
        With ListView1
            .CheckBoxes = True
            .GridLines = True
            .View = System.Windows.Forms.View.Details
            .Sorting = False
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable 'ColumnHeaderStyle.Nonclickable
            .LabelEdit = False
            .FullRowSelect = True
            .HoverSelection = False
            .MultiSelect = True
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable 'ColumnHeaderStyle.Nonclickable
        End With

        'define column headers and define properties for each column
        Dim col1Header As New System.Windows.Forms.ColumnHeader

        With col1Header
            .Text = "Column Letter"
            .Width = 100
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        'add column header to the listview
        ListView1.Columns.Add(col1Header)

        'enable the dropdown menu and disable the listview
        ComboBox1.Enabled = True
        ListView1.Enabled = False

        Dim i As Integer
        For i = 0 To angleList.Capacity
            angleList.Add("")
        Next

        LoadExcelFile()

    End Sub

    Private Sub LoadExcelFile()
        'populate the angle column dropdown and the column listview

        Dim filePath As String

        'get file to open
        filePath = StepperModule.BrowseForPath("Excel Files|*.xls;*.xlsx")

        'Dim xlApp As Excel.Application = Nothing
        'Dim xlWb As Excel.Workbook = Nothing
        'Dim xlWs As Excel.Worksheet = Nothing
        Dim xlRange As Excel.Range
        'Dim lastCol As Long
        'Dim lastRow As Long

        'load the excel application, workbook and worksheet
        xlApp = New Excel.Application
        xlWb = xlApp.Workbooks.Open(filePath)
        xlWs = xlWb.Worksheets(1)

        'get the last used row and column
        lastCol = xlWs.UsedRange.Columns.Count
        lastRow = xlWs.UsedRange.Rows.Count

        'populate the dropdown with the letters of the columns
        Dim j As Long
        Dim letter As String

        For j = 1 To lastCol
            letter = GetExcelColumnName(j)
            ComboBox1.Items.Add(letter)
            ListView1.Items.Add(letter)
        Next

        xlRange = xlWs.Range("A1:" & "D" & lastRow)
        'Dim angle As Integer

        Try
            'excel array starts at index 1

            'For i = 1 To lastRow
            '    'start filling datagrid view at row 1 (starts at 0) due to the offset row
            '    'get angle data and correct if greater than 360
            '    angle = xlWs.Range("A" & i).Value2
            '    If angle > 360 Then
            '        angle -= 360
            '    End If

            '    'fill datagrid view based on angle value so it populates from 1-360 in decending order
            '    'DataGridView.Rows(angle).Cells(1).Value = angle
            '    'DataGridView.Rows(angle).Cells(2).Value = xlWs.Range("B" & i).Value2
            '    'DataGridView.Rows(angle).Cells(3).Value = xlWs.Range("C" & i).Value2

            'Next

            'clean up to close everything
            'xlWb.Close()
            'xlApp.Quit()

        Catch ex As Exception
            MsgBox("Problem with the Excel File" & vbCrLf & vbCrLf & "Make sure file is copied from VNM VH Table")

        End Try

    End Sub

    Private Sub frmLoadColumn_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'when a selection is made in the combobox repopulate the listview
        ListView1.Items.Clear()
        Dim item As Object

        For Each item In ComboBox1.Items
            'if the item matches the selected item dont add it to the list
            If Not ComboBox1.SelectedItem = item Then
                ListView1.Items.Add(item.ToString)
            End If
        Next
        'enable the list view so selections can be made
        ListView1.Enabled = True

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'when the OK button is clicked, it should 

        'populate the angle array based on the desired column in the combo box
        Dim col As String
        Dim angle As Integer
        col = ComboBox1.SelectedItem.ToString

        Dim i As Integer
        For i = 1 To lastRow 'probably want a check to not try and load more than 361 elements
            angle = xlWs.Range(col & i).Value2
            If angle > 360 Then
                angle -= 360
            End If
            angleArray(angle) = angle
            angleList(angle) = CStr(angle)
        Next
        PrintArray(angleArray)
        printList(angleList)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'clean up to close everything
        xlWb.Close()
        xlApp.Quit()

    End Sub

    Private Sub PrintArray(myArray() As String)

        Dim i As Integer = 0
        Dim rowString As String = ""

        For i = 0 To myArray.Length - 1
            rowString = myArray(i)
            Debug.Print(rowString)
        Next
    End Sub

    Private Sub printList(myList As Generic.List(Of String))

        Dim i As Integer
        Debug.Print("****LIST****")
        For i = 0 To myList.Count - 1
            Debug.Print(myList.Item(i))
        Next

    End Sub

    Private Function GetExcelColumnName(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function

End Class