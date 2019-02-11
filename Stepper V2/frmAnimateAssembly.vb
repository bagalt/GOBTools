Imports Inventor
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmAnimateAssembly

    Dim InvApp As Inventor.Application 'global for inventor application object
    Dim AssyDoc As Inventor.AssemblyDocument
    Dim AssyCompDef As Inventor.AssemblyComponentDefinition

    Dim CurrentIndex As Integer = 1 'holds current index for traversing through position array
    Dim PrevIndex As Integer = 1 'holds previous index for traversing through position array

    Dim gboolLoop As Boolean
    Dim gOrigVert As Double 'holds the original value of the vertical parameter for reset purposes
    Dim gOrigHoriz As Double 'holds the original value of the horizontal parameter for reset purposes

    Public Sub New(ThisApplication As Inventor.Application)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InvApp = ThisApplication

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

        InitializeListView()
        InitializeDataGridView()
    End Sub

    Private Sub InitializeListView()
        'Initialize the listview  with column headings and options

        'clear all items and columns from control
        lstData.Clear()

        'setup listview options
        With lstData
            .GridLines = True
            .View = System.Windows.Forms.View.Details
            .Sorting = False
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable 'ColumnHeaderStyle.Nonclickable
            .LabelEdit = False
            .FullRowSelect = True
            .HoverSelection = False
            .MultiSelect = False
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable 'ColumnHeaderStyle.Nonclickable
        End With

        'define column headers and define properties for each column
        Dim col1Header As New System.Windows.Forms.ColumnHeader
        Dim col2Header As New System.Windows.Forms.ColumnHeader
        Dim col3Header As New System.Windows.Forms.ColumnHeader
        Dim colWidth As Integer = 60

        With col1Header
            .Text = "Angle"
            .Width = 40
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With
        With col2Header
            .Text = "Param1"
            .Width = colWidth
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With
        With col3Header
            .Text = "Param2"
            .Width = colWidth
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        'add column headers to listview 
        lstData.Columns.Add(col1Header)
        lstData.Columns.Add(col2Header)
        lstData.Columns.Add(col3Header)

        'load numbers into the Angle column
        Dim i As Integer
        i = 1
        For i = 1 To 361
            lstData.Items.Add(i)
        Next

    End Sub

    Private Sub InitializeDataGridView()
        'sub to initialize and define options for the datagridview

        Dim i As Integer

        AngleDataGrid.Rows.Add(360)
        For i = 0 To 360
            AngleDataGrid.Rows(i).Cells(0).Value = i + 1
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

        Try
            'excel array starts at index 1
            Dim i As Integer

            'corrects angle wrap around output from VNM
            For i = 1 To lastRow
                AngleDataGrid.Rows(i - 1).Cells(1).Value = xlWs.Range("B" & i).Value2
                AngleDataGrid.Rows(i - 1).Cells(2).Value = xlWs.Range("C" & i).Value2
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
        Dim NameHelp = New frmParameterHelp(InvApp, AngleDataGrid.Columns)

        'show NameHelp form
        NameHelp.Show()
        'set the namehelp form owner
        NameHelp.Owner = Me
        'set the location
        NameHelp.Location = LocateInCenter(Me, NameHelp)
        'hide the form
        Me.Hide()

        NameHelp.PickConsraint()

        'if either the vert or horiz params have a name, then update the text box on PosStepper
        If (NameHelp.GetParameterName <> "") Then
            'apply the selected param name to the vert name text box
            AngleDataGrid.Columns(NameHelp.GetColumnName).HeaderCell.Value = NameHelp.GetParameterName
            'AngleDataGrid.Columns(1).HeaderCell.Value = NameHelp.GetParameterName

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

End Class