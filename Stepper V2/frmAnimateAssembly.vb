Imports Inventor
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class frmAnimateAssembly

    Private InvApp As Inventor.Application 'global for inventor application object
    Private AssyDoc As Inventor.AssemblyDocument
    Private AssyCompDef As Inventor.AssemblyComponentDefinition

    Private CurrentIndex As Integer = 1 'holds current index for traversing through position array
    Private PrevIndex As Integer = 1 'holds previous index for traversing through position array

    Private gboolLoop As Boolean = True
    Private gOrigVert As Double 'holds the original value of the vertical parameter for reset purposes
    Private gOrigHoriz As Double 'holds the original value of the horizontal parameter for reset purposes
    Private columnCounter As Integer
    Private highlightColor As Drawing.Color = Drawing.Color.PaleGoldenrod
    Private parameterList As List(Of Inventor.Parameter)
    Private WithEvents bgWorker As System.ComponentModel.BackgroundWorker = Nothing

    Public Sub New(ThisApplication As Inventor.Application)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InvApp = ThisApplication
        'start column counter at 3, because there will always be an index column, angle and param 1 and param 2
        columnCounter = 3
        parameterList = New List(Of Parameter)

        'disable stop button for now
        btnStop.Enabled = False

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
        Dim columnHeaderStyle As New DataGridViewCellStyle

        columnHeaderStyle.BackColor = Drawing.Color.LightSkyBlue
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

        Dim path As String
        path = StepperModule.BrowseForPath("Excel Files|*.xls;*.xlsx")

        If path IsNot "" Then
            LoadExcelValues(path)
        End If

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

                'fill datagrid view based on angle value so it populates from 1-360 in decending order
                DataGridView.Rows(angle).Cells(1).Value = angle
                DataGridView.Rows(angle).Cells(2).Value = xlWs.Range("B" & i).Value2
                DataGridView.Rows(angle).Cells(3).Value = xlWs.Range("C" & i).Value2
                'DataGridView.Rows(i).Cells(1).Value = angle
                'DataGridView.Rows(i).Cells(2).Value = xlWs.Range("B" & i).Value2
                'DataGridView.Rows(i).Cells(3).Value = xlWs.Range("C" & i).Value2
            Next

            'clean up to close everything
            xlWb.Close()
            xlApp.Quit()

        Catch ex As Exception
            MsgBox("Problem with the Excel File" & vbCrLf & vbCrLf & "Make sure file is copied from VNM VH Table")

        End Try
    End Sub

    Private Sub btnNameHelp_Click(sender As Object, e As EventArgs) Handles btnAssignParam.Click

        'create new instance of the class frmNameHelp and pass inventor application object
        Dim parameterHelp = New frmParameterHelp(InvApp, DataGridView.Columns)
        Dim newColumnName As String
        Dim newColHeader As String

        'show NameHelp form
        parameterHelp.Show()
        'set the namehelp form owner
        parameterHelp.Owner = Me
        'set the location
        parameterHelp.Location = LocateInCenter(Me, parameterHelp)
        'hide the form
        Me.Hide()

        parameterHelp.PickConsraint()

        'Assign the parameter name to the column name
        'Assign the constraint description to the header text
        If (parameterHelp.GetParameterName <> "") Then
            newColumnName = parameterHelp.GetParameterName
            newColHeader = parameterHelp.GetConstraintName
            parameterList.Add(parameterHelp.GetSelectedParameter)
            'give the column the new name
            DataGridView.Columns(parameterHelp.GetColumnName).Name = newColumnName
            'give the column header the new name
            DataGridView.Columns(newColumnName).HeaderCell.Value = newColHeader

        End If

        'Stop  NameHelp form And clear up memory
        parameterHelp.Close()
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
        GoToNextAngle(True)
    End Sub

    Private Sub btnPrevAngle_Click(sender As Object, e As EventArgs) Handles btnPrevAngle.Click
        GoToPreviousAngle()
    End Sub

    Private Sub GoToNextAngle(updateGridView As Boolean)
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
        UpdateModel(updateGridView)
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
        UpdateModel(True)
    End Sub

    Private Sub UpdateModel(highlightGridView As Boolean)
        'sub to update the inventor assembly parameters based on VertName and HorizName and the index
        'in the gdblPosArray

        Dim stopwatch As New System.Diagnostics.Stopwatch

        Try

            Dim dataColumn As Windows.Forms.DataGridViewColumn
            Dim dataParam As Inventor.Parameter
            'Dim i As Integer
            Dim i As Integer
            Dim value As Double
            Dim findParam As Parameter

            stopwatch.Start()
            For i = 2 To DataGridView.Columns.Count - 1
                'skip the first two columns
                'get the column we're currently looking at
                dataColumn = DataGridView.Columns.Item(i)
                dataParam = Nothing
                Try
                    'see if the parameter can be assigned

                    'This is done to reduce API calls to inventor
                    'at the mapping of the parameters the parameters are added to the parameterList
                    'now we need to find the parameter in the list based on the datacolumn name which is the 
                    'name of the parameter when it was mapped.
                    'Replaces: dataParam = AssyCompDef.Parameters(dataColumn.Name)
                    For Each findParam In parameterList
                        If findParam.Name = dataColumn.Name Then
                            dataParam = findParam
                            Exit For
                        End If
                    Next

                    'if it was ok, then get the value from the DataGridView
                    If highlightGridView Then
                        'highlight and unhighlight rows
                        DataGridView.Rows(PrevIndex).DefaultCellStyle.BackColor = Drawing.Color.White
                        DataGridView.Rows(CurrentIndex).DefaultCellStyle.BackColor = highlightColor
                        'keep highlighted row visible
                        DataGridView.FirstDisplayedScrollingRowIndex = CurrentIndex
                    End If


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
            'update the assembly for each row
            AssyDoc.Update2(True)
            txtStopwatch.Text = stopwatch.ElapsedMilliseconds

        Catch ex As Exception
            InvApp.UserInterfaceManager.UserInteractionDisabled = False
            InvApp.AssemblyOptions.DeferUpdate = False
            Exit Sub

        End Try
    End Sub

    Private Sub DataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseDoubleClick

        'will not handle double clicks on the column headers or the first row where the offsets are listed
        If e.RowIndex >= 1 AndAlso e.ColumnIndex >= 0 Then
            'Update the index trackers
            PrevIndex = CurrentIndex
            CurrentIndex = e.RowIndex
            'Update the model to new index
            UpdateModel(True)
        End If

    End Sub

#Region "Background worker and Play Stop buttons"

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'enable user interaction just in case it was disabled
        InvApp.UserInterfaceManager.UserInteractionDisabled = False

        'close form
        Me.Close()

    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click

        'disable play button
        btnPlay.Enabled = False
        'enable stop button
        btnStop.Enabled = True

        '' these properties should be set to True (at design-time or runtime) before calling the RunWorkerAsync
        '' to ensure that it supports Cancellation and reporting Progress

        If IsNothing(bgWorker) Then
            bgWorker = New System.ComponentModel.BackgroundWorker
            'set background worker options
            bgWorker.WorkerSupportsCancellation = True
            bgWorker.WorkerReportsProgress = True
            'start the background worker
            bgWorker.RunWorkerAsync()
        Else
            bgWorker.CancelAsync()
            bgWorker = Nothing
        End If

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        '' to cancel the task, just call the BackgroundWorker1.CancelAsync method.

        'disable the stop button
        btnStop.Enabled = False
        'Enable the play button
        btnPlay.Enabled = True
        'stop background worker
        bgWorker.CancelAsync()

    End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker.DoWork
        Dim bgw As System.ComponentModel.BackgroundWorker = sender

        'Do While gboolLoop = True
        While Not bgw.CancellationPending
            GoToNextAngle(False)
            bgw.ReportProgress(CurrentIndex, "Working...")
        End While

        If bgw.CancellationPending Then
            e.Cancel = True
            bgw.ReportProgress(100, "Stopped")
        End If
    End Sub

    Private Sub bgWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        '' This event is fired when you call the ReportProgress method from inside your DoWork.
        '' Any visual indicators about the progress should go here.

        'highlight and unhighlight rows
        DataGridView.Rows(PrevIndex).DefaultCellStyle.BackColor = Drawing.Color.White
        DataGridView.Rows(CurrentIndex).DefaultCellStyle.BackColor = highlightColor
        'keep highlighted row visible
        DataGridView.FirstDisplayedScrollingRowIndex = CurrentIndex
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        '' This event is fired when your BackgroundWorker exits.
        '' It may have exitted Normally after completing its task, 
        '' or because of Cancellation, or due to any Error.

        If e.Error IsNot Nothing Then
            '' if BackgroundWorker terminated due to error
            'MessageBox.Show(e.Error.Message)

        ElseIf e.Cancelled Then
            '' otherwise if it was cancelled
            'MessageBox.Show("Task cancelled!")

        Else
            '' otherwise it completed normally
            'MessageBox.Show("Task completed!")
        End If

        'set worker back to nothing so it can be started again
        bgWorker = Nothing
    End Sub


#End Region

    Private Sub btnLoadColumn_Click(sender As Object, e As EventArgs) Handles btnLoadColumn.Click
        'handles loading a column into the datagrid from an excel file

        Dim loadColumnFromExcel As DialogResult

        If loadColumnFromExcel = DialogResult.OK Then
            MsgBox("Loaded OK")
        End If




    End Sub
End Class