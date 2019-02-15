Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmLoadColumn

    'form should present user with the option to select the angle column of an excel sheet
    'and columns that can be selected for adding to columns
    'it should return a letter or value for the angle column
    'it should return a letter/value or list of letters/values for the data columns

    'Private mySelections

    Public Sub New(ParentForm As System.Windows.Forms.Form)

        ' This call is required by the designer.
        InitializeComponent()

        'set up combobox options
        With ComboBox1

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
            .Width = 45
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        LoadExcelFile()


    End Sub

    Private Sub LoadExcelFile()
        'populate the angle column dropdown and the column listview

        Dim filePath As String

        'get file to open
        filePath = StepperModule.BrowseForPath("Excel Files|*.xls;*.xlsx")

        Dim xlApp As Excel.Application = Nothing
        Dim xlWb As Excel.Workbook = Nothing
        Dim xlWs As Excel.Worksheet = Nothing
        Dim xlRange As Excel.Range
        Dim lastCol As Long
        Dim lastRow As Long

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

        'populate the listview with the letters of the columns minus the angle column


        xlRange = xlWs.Range("A1:" & "D" & lastRow)
        Dim angle As Integer

        Try
            'excel array starts at index 1
            Dim i As Integer

            'corrects angle wrap around output from VNM
            For i = 1 To lastRow
                'start filling datagrid view at row 1 (starts at 0) due to the offset row
                'get angle data and correct if greater than 360
                angle = xlWs.Range("A" & i).Value2
                If angle > 360 Then
                    angle -= 360
                End If

                'fill datagrid view based on angle value so it populates from 1-360 in decending order
                'DataGridView.Rows(angle).Cells(1).Value = angle
                'DataGridView.Rows(angle).Cells(2).Value = xlWs.Range("B" & i).Value2
                'DataGridView.Rows(angle).Cells(3).Value = xlWs.Range("C" & i).Value2

            Next

            'clean up to close everything
            xlWb.Close()
            xlApp.Quit()

        Catch ex As Exception
            MsgBox("Problem with the Excel File" & vbCrLf & vbCrLf & "Make sure file is copied from VNM VH Table")

        End Try


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