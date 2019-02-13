Imports Inventor
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Drawing


Public Class frmAnimateAssembly

    Private InvApp As Inventor.Application 'global for inventor application object
    Private AssyDoc As Inventor.AssemblyDocument
    Private AssyCompDef As Inventor.AssemblyComponentDefinition

    Private CurrentIndex As Integer = 1 'holds current index for traversing through position array
    Private PrevIndex As Integer = 1 'holds previous index for traversing through position array

    Private gboolLoop As Boolean
    Private gOrigVert As Double 'holds the original value of the vertical parameter for reset purposes
    Private gOrigHoriz As Double 'holds the original value of the horizontal parameter for reset purposes
    Private columnCounter As Integer
    Private highlightColor As Drawing.Color = Drawing.Color.PaleGoldenrod

    Public Sub New(ThisApplication As Inventor.Application)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InvApp = ThisApplication
        'start column counter at 3, because there will always be an index column, angle and param 1 and param 2
        columnCounter = 3

        'get the assembly component definition and assign to global
        Try
            'Dim assyDoc As Inventor.AssemblyDocument
            AssyDoc = g_inventorApplication.ActiveDocument
            AssyCompDef = AssyDoc.ComponentDefinition
            txtNumConstraints.Text = AssyDoc.ComponentDefinition.Constraints.Count
            'add label for information
            lblVersion.Text = "v0.0"

        Catch
            MsgBox("Assembly document must be active")
            Me.Close()
        End Try

    End Sub

    Private Sub frmAnimateAssembly_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'form has been shown
        InitializeDataGridView()
        RichTextBox1.Rtf = My.Resources.StepperHelp
    End Sub

    Private Sub InitializeDataGridView()
        'sub to initialize and define options for the datagridview
        Dim columnHeaderStyle As New Windows.Forms.DataGridViewCellStyle

        columnHeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle

        Dim i As Integer

        DataGridView.Rows.Add(361)
        DataGridView.Rows(0).Cells(0).Value = "Offset"
        DataGridView.Rows(0).Frozen = True
        DataGridView.Rows(0).DefaultCellStyle.BackColor = Drawing.Color.LightSkyBlue

        For i = 1 To 361
            DataGridView.Rows(i).Cells(0).Value = i
        Next
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'sub to open a browse dialog starting at the user's desktop
        'selects a document and displays the path to the file in the txtFilePath textbox
        'finishes by calling the ExcelToArray sub to load the excel file

        Dim myFileDlog As New System.Windows.Forms.OpenFileDialog 'OpenFileDialog()

        'look for files starting at desktop, doesnt quite work correctly now        
        myFileDlog.InitialDirectory = System.Environment.SpecialFolder.MyComputer

        'specifies what type of data files to look for
        myFileDlog.Filter = "All Files (*.*)|*.*"

        'specifies which data type is focused on start up
        myFileDlog.FilterIndex = 1

        'Gets or sets a value indicating whether the dialog box restores the current directory before closing.
        myFileDlog.RestoreDirectory = True

        'seperates message outputs for files found or not found
        If (myFileDlog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            'Adds the file directory to the text box
            txtFilePath.Text = myFileDlog.FileName
        End If

        LoadExcelValues(myFileDlog.FileName)

    End Sub

    Private Sub LoadExcelValues(Path As String)
        'sub to load excel range into an array directly

        'check if file path points to an excel document
        Dim extension As String
        extension = System.IO.Path.GetExtension(Path)

        If (extension = ".xlsx") Or (extension = ".xls") Then
            'everything good
        ElseIf (extension = "") Then
            'dialog was cancled
            Exit Sub
        Else
            MsgBox("Need to open Excel Document .xlsx or .xls")
            Exit Sub
        End If

        Dim xlApp As Excel.Application = Nothing
        Dim xlWb As Excel.Workbook = Nothing
        Dim xlWs As Excel.Worksheet = Nothing
        Dim xlRange As Excel.Range
        Dim lastCol As Integer
        Dim lastRow As Integer

        'load the excel application, workbook and worksheet
        xlApp = New Excel.Application
        xlWb = xlApp.Workbooks.Open(Path)
        xlWs = xlWb.Worksheets(1)

        'get the last used row and column
        lastCol = 3 'lastCol = 4 due to the fact that we only care about the first 3 columns of the vnm output
        lastRow = xlWs.UsedRange.Rows.Count

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
                DataGridView.Rows(i).Cells(1).Value = angle
                DataGridView.Rows(i).Cells(2).Value = xlWs.Range("B" & i).Value2
                DataGridView.Rows(i).Cells(3).Value = xlWs.Range("C" & i).Value2
            Next

            'clean up to close everything
            xlWb.Close()
            xlApp.Quit()

        Catch ex As Exception
            MsgBox("Problem with the Excel File" & vbCrLf & vbCrLf & "Make sure file is copied from VNM VH Table")

        End Try
    End Sub

    Private Sub btnNameHelp_Click(sender As Object, e As EventArgs) Handles btnNameHelp.Click

        'create new instance of the class frmNameHelp and pass inventor application object
        Dim NameHelp = New frmParameterHelp(InvApp, DataGridView.Columns)
        Dim newColumnName As String
        Dim newColHeader As String

        'show NameHelp form
        NameHelp.Show()
        'set the namehelp form owner
        NameHelp.Owner = Me
        'set the location
        NameHelp.Location = LocateInCenter(Me, NameHelp)
        'hide the form
        Me.Hide()

        NameHelp.PickConsraint()

        'Assign the parameter name to the column name
        'Assign the constraint description to the header text
        If (NameHelp.GetParameterName <> "") Then
            newColumnName = NameHelp.GetParameterName
            newColHeader = NameHelp.GetConstraintName
            'give the column the new name
            DataGridView.Columns(NameHelp.GetColumnName).Name = newColumnName
            'give the column header the new name
            DataGridView.Columns(newColumnName).HeaderCell.Value = newColHeader
        End If

        'Stop  NameHelp form And clear up memory
        NameHelp.Close()
        'make sure selection is terminated
        InvApp.CommandManager.StopActiveCommand()
        'Show form again
        Me.Show()

    End Sub

    Private Function LocateInCenter(ByVal parent As System.Windows.Forms.Form, ByVal child As System.Windows.Forms.Form) As System.Drawing.Point
        'function to find the center point of the parent form 
        'and locate the child form in the center of the parent
        'returns the top left location the child should be on the parent

        Dim parentCenter As System.Drawing.Point

        'calculate the center locaton of the parent form
        parentCenter.X = Me.Location.X + (Me.Width / 2)
        parentCenter.Y = Me.Location.Y + (Me.Height / 2)
        'calculate the top left point of the child form
        LocateInCenter.X = parentCenter.X - (child.Width / 2)
        LocateInCenter.Y = parentCenter.Y - (child.Height / 2)

        Return LocateInCenter

    End Function

    Private Sub PrintArray(myArray As Object(,), row As Integer, col As Integer)

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim rowString As String = ""

        For i = 1 To row
            rowString = myArray(i, 1)
            For j = 2 To col
                rowString = rowString & "," & myArray(i, j)
            Next
            Debug.Print(rowString)
        Next
    End Sub

    Private Sub btnAddColumn_Click(sender As Object, e As EventArgs) Handles btnAddColumn.Click

        Dim newCol As New System.Windows.Forms.DataGridViewTextBoxColumn

        'set column properties
        With newCol
            .HeaderText = "Param" & columnCounter
            .Resizable = True
            .MinimumWidth = 65
            .Width = 100
            .Name = "Param" & columnCounter
            .SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        End With

        columnCounter += 1
        'add new column
        DataGridView.Columns.Add(newCol)

    End Sub

    Private Sub btnDeleteColumn_Click(sender As Object, e As EventArgs) Handles btnDeleteColumn.Click
        Dim dialog As New ColumnManager(DataGridView.Columns, Me)

        Dim result As Windows.Forms.DialogResult = dialog.ShowDialog()
        dialog.Location = LocateInCenter(Me, dialog)
        If result = Windows.Forms.DialogResult.OK Then
            'delete the column
            DataGridView.Columns.Remove(dialog.ColumnToDelete)
        End If

    End Sub

    Private Sub btnNextAngle_Click(sender As Object, e As EventArgs) Handles btnNextAngle.Click
        GoToNextAngle()
    End Sub

    Private Sub btnPrevAngle_Click(sender As Object, e As EventArgs) Handles btnPrevAngle.Click
        GoToPreviousAngle()
    End Sub

    Private Sub GoToNextAngle()
        'sub to index to the next angle

        Dim numRows As Integer
        numRows = DataGridView.RowCount - 1

        'check that the index value is still within the array bounds
        If ((CurrentIndex + txtStepSize.Text) <= numRows) Then
            'update index holders
            PrevIndex = CurrentIndex
            CurrentIndex += txtStepSize.Text
        Else
            'new index value is out of range, stop at last index value (may want to wrap around)
            PrevIndex = CurrentIndex
            'new index is outside bounds, wrap back around to first Index row
            CurrentIndex = 1
        End If

        'update the model
        UpdateModel()
    End Sub

    Private Sub GoToPreviousAngle()

        'check that the index value is still within the array bounds
        If ((CurrentIndex - txtStepSize.Text) > 0) Then
            'update index holders
            PrevIndex = CurrentIndex
            CurrentIndex -= txtStepSize.Text
        Else
            'new index value is out of range, stop at last index value (may want to wrap around)
            PrevIndex = CurrentIndex
            'new index is outside bounds, wrap back around to first Index row
            CurrentIndex = 361
        End If

        'update the model
        UpdateModel()
    End Sub

    Private Sub UpdateModel()
        'sub to update the inventor assembly parameters based on VertName and HorizName and the index
        'in the gdblPosArray

        Dim stopwatch As New System.Diagnostics.Stopwatch

        ' InvApp.ScreenUpdating = False
        Try

            Dim dataColumn As Windows.Forms.DataGridViewColumn
            Dim dataParam As Inventor.Parameter
            'Dim i As Integer
            Dim i As Integer
            Dim value As Double

            stopwatch.Start()
            For i = 2 To DataGridView.Columns.Count - 1
                'skip the first two columns
                'get the column we're currently looking at
                dataColumn = DataGridView.Columns.Item(i)
                Try
                    'see if the parameter can be assigned
                    dataParam = AssyCompDef.Parameters(dataColumn.Name)
                    'if ti was ok, then get the value from the DataGridView

                    '************************************************
                    'currently dont have offsets worked into program
                    '************************************************

                    'highlight and unhighlight rows
                    DataGridView.Rows(PrevIndex).DefaultCellStyle.BackColor = Drawing.Color.White
                    DataGridView.Rows(CurrentIndex).DefaultCellStyle.BackColor = highlightColor
                    'keep highlighted row visible
                    DataGridView.FirstDisplayedScrollingRowIndex = CurrentIndex

                    'Build the expression for the parameter (used expression in order to maintain 3 decimal places)
                    If Not DataGridView.Rows.Item(CurrentIndex).Cells(i).Value Is Nothing Then
                        value = CDbl(DataGridView.Rows.Item(CurrentIndex).Cells(i).Value) + CDbl(DataGridView.Rows.Item(0).Cells(i).Value)
                        dataParam.Expression = FormatNumber(value, 3) & "mm"
                    End If

                Catch ex As Exception
                    MsgBox("Invalid Parameter: " & dataColumn.Name & vbNewLine & "Used for Column: " & dataColumn.HeaderText.ToString)
                End Try
            Next
            'turn screen updating back on
            'InvApp.ScreenUpdating = True
            'update the assembly for each row
            AssyDoc.Update2(True)
            txtStopwatch.Text = stopwatch.ElapsedMilliseconds

        Catch ex As Exception
            InvApp.UserInterfaceManager.UserInteractionDisabled = False
            InvApp.AssemblyOptions.DeferUpdate = False
            Exit Sub

        End Try
    End Sub


End Class