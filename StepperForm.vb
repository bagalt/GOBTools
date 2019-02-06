Imports Inventor
Imports System.ComponentModel
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmStepper

    Dim gAssyCompDef As Inventor.AssemblyComponentDefinition
    Dim gdblPosArray As Object(,) 'array from VNM has 361 elements, arrays start at zero
    Dim gintCurrentIndex As Integer = 1 'holds current index for traversing through position array
    Dim gintPrevIndex As Integer = 1 'holds previous index for traversing through position array
    Public gInvApp As Inventor.Application 'global for inventor application object
    Dim gVertParam As Inventor.Parameter 'global for vertical parameter
    Dim gHorizParam As Inventor.Parameter 'global for horizontal parameter
    Dim gboolLoop As Boolean
    Dim gOrigVert As Double 'holds the original value of the vertical parameter for reset purposes
    Dim gOrigHoriz As Double 'holds the original value of the horizontal parameter for reset purposes
    Dim gAssyDoc As Inventor.AssemblyDocument
    Dim gVertNameValidated As Boolean
    Dim gHorizNameValidated As Boolean

    Public Sub New(ThisApplication As Inventor.Application)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gInvApp = ThisApplication

        'get the assembly component definition and assign to global
        Try
            'Dim assyDoc As Inventor.AssemblyDocument
            gAssyDoc = g_inventorApplication.ActiveDocument
            gAssyCompDef = gAssyDoc.ComponentDefinition
            txtNumConstraints.Text = gAssyDoc.ComponentDefinition.Constraints.Count
            'add label for information
            lblVersion.Text = "v1.3"
            'set default values
            gVertNameValidated = False
            gHorizNameValidated = False
        Catch
            MsgBox("Assembly document must be active")
            Me.Close()
        End Try

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
            ExcelToArray(txtFilePath.Text)
        End If



    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        'sub to handle reloading the excel document, updating the global array, and repopulating the listview

        'if file path is not empty, then call excel to array
        If (txtFilePath.Text <> "") Then
            If System.IO.File.Exists(txtFilePath.Text) Then
                ExcelToArray(txtFilePath.Text)
            Else
                MsgBox("File does not exist, check file path", MsgBoxStyle.OkOnly, "File not Found")
            End If

        End If

    End Sub

    Private Sub ExcelToArray(Path As String)
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
        lastCol = 4 'lastCol = 4 due to the fact that we only care about the first 4 columns of the vnm output
        lastRow = xlWs.UsedRange.Rows.Count

        xlRange = xlWs.Range("A1:" & "D" & lastRow)

        Try
            'excel array starts at index 1
            'converts the excel range into the object type
            gdblPosArray = CType(xlRange.Value2, Object(,))
            Dim i As Integer

            'corrects angle wrap around output from VNM
            For i = 1 To lastRow
                If gdblPosArray(i, 1) > 360 Then
                    gdblPosArray(i, 1) = gdblPosArray(i, 1) - 360
                End If
            Next

            'clean up to close everything
            xlWb.Close()
            xlApp.Quit()

            'call populateListView to populate the listview
            'PrintArray(gdblPosArray, 361, 4)
            PopulateListView(gdblPosArray)

        Catch ex As Exception
            MsgBox("Problem with the Excel File" & vbCrLf & vbCrLf & "Make sure file is copied from VNM VH Table")

        End Try
    End Sub

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

    Private Sub PopulateListView(MyArray As Object)
        'populate the listview  based on the global position array 
        'also sets listview options

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

        '************************************
        'would like to have bold column headers for listview or grey background, also maybe
        'programatically assign column header text?
        'ref: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listview.columnheadercollection?view=netframework-4.7.1
        '************************************

        'define column headers and define properties for each column
        Dim col1Header As New System.Windows.Forms.ColumnHeader
        Dim col2Header As New System.Windows.Forms.ColumnHeader
        Dim col3Header As New System.Windows.Forms.ColumnHeader
        Dim col4Header As New System.Windows.Forms.ColumnHeader
        Dim colWidth As Integer = 60

        With col1Header
            .Text = "Angle"
            .Width = 45
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With
        With col2Header
            .Text = "Vert"
            .Width = colWidth
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With
        With col3Header
            .Text = "Horiz"
            .Width = colWidth
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With
        With col4Header
            .Text = "Accel"
            .Width = colWidth
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        'add column headers to listview 
        lstData.Columns.Add(col1Header)
        lstData.Columns.Add(col2Header)
        lstData.Columns.Add(col3Header)
        lstData.Columns.Add(col4Header)

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim myItem As System.Windows.Forms.ListViewItem

        For i = 1 To 361
            myItem = lstData.Items.Add(gdblPosArray(i, 1))
            For j = 2 To 4
                'add array values to listview 
                myItem.SubItems.Add(gdblPosArray(i, j))
            Next
        Next

        ColorRows(CDbl(txtAccelThreshold.Text))
    End Sub

    Private Sub ColorRows(AccelThreshold As Double)
        'sub to handle updating the accel threshold
        'highlight rows in the list view that equal or exceed this threshold
        Dim i As Integer

        For i = 1 To lstData.Items.Count - 1
            'if accel value is >= threshold color red, if not color white
            If (CDbl(lstData.Items(i).SubItems(3).Text) >= AccelThreshold) Then
                lstData.Items(i).BackColor = Drawing.Color.Red
            Else
                lstData.Items(i).BackColor = Drawing.Color.White
            End If

        Next
    End Sub

    Private Sub UpdateListView()
        'sub to update the listview and highlight the current index row
        Dim myItem As System.Windows.Forms.ListViewItem

        'array starts at 1, listview starts at 0 so need currentIndex - 1
        myItem = lstData.Items(gintCurrentIndex - 1)

        lstData.Focus()
        myItem.Selected = True
        myItem.EnsureVisible()

    End Sub

    Private Sub UpdateModel(ByRef VertName As Inventor.Parameter, ByRef HorizName As Inventor.Parameter)
        'sub to update the inventor assembly parameters based on VertName and HorizName and the index
        'in the gdblPosArray

        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        gInvApp.ScreenUpdating = False
        Try
            'check if ignore horiz is checked
            If (chkIgnoreHoriz.Checked = True) Then
                'for passing values to inventor, inventor uses internal units of cm and radians
                'use the expression to have the display only show 3 decimal places and add the mm to use the correct units
                VertName.Expression = FormatNumber(gdblPosArray(gintCurrentIndex, 2) + CDbl(txtVertOffset.Text), 3) & "mm"
                'VertName.Value = CDbl((gdblPosArray(gintCurrentIndex, 2) + CDbl(txtVertOffset.Text)) / 10)
                'update model and ignore errors
                gInvApp.ScreenUpdating = True
                gAssyDoc.Update2(True)
            Else
                'use the expression to have the display only show 3 decimal places and add the mm to use the correct units               
                VertName.Expression = FormatNumber(gdblPosArray(gintCurrentIndex, 2) + CDbl(txtVertOffset.Text), 3) & "mm"
                HorizName.Expression = FormatNumber(gdblPosArray(gintCurrentIndex, 3) + CDbl(txtHorizOffset.Text), 3) & "mm"
                'VertName.Value = CDbl((gdblPosArray(gintCurrentIndex, 2) + CDbl(txtVertOffset.Text)) / 10)
                'HorizName.Value = CDbl((gdblPosArray(gintCurrentIndex, 3) + CDbl(txtHorizOffset.Text)) / 10)
                'update model and ignore errors
                gInvApp.ScreenUpdating = True
                gAssyDoc.Update2(True)
            End If

            txtStopwatch.Text = stopwatch.ElapsedMilliseconds
            txtVertPos.Text = VertName.Value * 10
            txtHorizPos.Text = HorizName.Value * 10

        Catch ex As Exception
            gInvApp.UserInterfaceManager.UserInteractionDisabled = False
            gInvApp.AssemblyOptions.DeferUpdate = False
            Exit Sub

        End Try
    End Sub

    Private Sub NextAngle()
        'sub to index to the next angle

        'check if an array is loaded, end if there is none loaded
        If (gdblPosArray.GetUpperBound(0) = 0) Then
            MsgBox("No Array Loaded")
            Exit Sub
        End If

        'check that the index value is still within the array bounds
        If ((gintCurrentIndex + txtStepSize.Text) <= gdblPosArray.GetUpperBound(0)) Then
            'update index holders
            gintPrevIndex = gintCurrentIndex
            gintCurrentIndex += txtStepSize.Text
        Else
            'new index value is out of range, stop at last index value (may want to wrap around)
            gintPrevIndex = gintCurrentIndex
            'gintCurrentIndex = gdblPosArray.GetUpperBound(0)

            'new index is outside bounds, wrap back around to first angle
            gintCurrentIndex = 1
        End If

        'update the model
        UpdateModel(gVertParam, gHorizParam)
        UpdateListView()

    End Sub

    Private Sub PrevAngle()
        'sub to index to the previous angle

        'check if an array is loaded, end if there is none loaded
        If (gdblPosArray.GetUpperBound(0) = 0) Then
            MsgBox("No Array Loaded")
            Exit Sub
        End If

        'check to see if new index will be within range
        If ((gintCurrentIndex - txtStepSize.Text) >= 1) Then
            'update index values
            gintPrevIndex = gintCurrentIndex
            gintCurrentIndex -= txtStepSize.Text
        Else
            'new index is less than one, stop at first index (may want to wrap around)
            gintPrevIndex = gintCurrentIndex
            gintCurrentIndex = 361
        End If

        'update model
        UpdateModel(gVertParam, gHorizParam)
        UpdateListView()

    End Sub

    Private Function CheckSuppressed(ParameterName As String) As Boolean
        'function to take the parameter name and search through all the constraints to find the constraint name 
        'and suppression status

        Dim assyConstraint As AssemblyConstraint
        Dim myFlushConstraint As FlushConstraint
        Dim myMateConstraint As MateConstraint
        Dim constraintFound As Boolean
        constraintFound = False

        For Each assyConstraint In gAssyCompDef.Constraints
            Select Case assyConstraint.Type
                Case ObjectTypeEnum.kFlushConstraintObject
                    myFlushConstraint = assyConstraint
                    If myFlushConstraint.Offset.Name = ParameterName Then
                        'found the constraint, check suppressed status  
                        constraintFound = True
                        Return myFlushConstraint.Suppressed
                    End If
                Case ObjectTypeEnum.kMateConstraintObject
                    myMateConstraint = assyConstraint
                    If myMateConstraint.Offset.Name = ParameterName Then
                        'found the constraint
                        constraintFound = True
                        Return myMateConstraint.Suppressed
                    End If

            End Select
        Next

        If constraintFound = False Then
            Return False
        End If

    End Function

    Private Function CheckHorizName(HorizName As String) As Boolean
        'sub to check horizontal name in text box to see if the parameter exists
        'and assign it to the horizparam global

        Try
            gHorizParam = gAssyCompDef.Parameters(txtHorizName.Text)
            'check parameter suppressed status
            If CheckSuppressed(gHorizParam.Name) Then
                MsgBox("Horizontal Parameter is Suppressed, please unsuppress", MsgBoxStyle.OkOnly, "Horiz Param Suppressed")
                Return False
            Else
                'set validated flag
                gHorizNameValidated = True
                Return True
            End If

        Catch ex As Exception
            MsgBox("Problem with the Horiz Parameter Name")
            Return False
        End Try

    End Function

    Private Function CheckVertName(VertName As String) As Boolean
        'sub to check and assign the parameter name when the value has been updated
        'and assign it to the vert param global
        Try
            gVertParam = gAssyCompDef.Parameters(txtVertName.Text)
            'check to see if parameter is supressed
            If CheckSuppressed(gVertParam.Name) Then
                MsgBox("Vertical Parameter is Suppressed, please unsuppress", MsgBoxStyle.OkOnly, "Vert Param Suppressed")
                Return False
            Else
                'set validated flag
                gVertNameValidated = True
                Return True
            End If


        Catch ex As Exception
            MsgBox("Problem with the Vert Parameter Name")
            Return False
        End Try

    End Function

    Private Sub txtHorizName_Validated(sender As Object, e As EventArgs) Handles txtHorizName.Validated
        'sub to handle text entered in the vert name text box
        'check the vert name (it is bad practice to call other event handlers from other parts of code
        'that is why there is a separate check horiz name sub)        
        If (CheckHorizName(txtHorizName.Text)) Then
            'parameter name OK, assign to origian variable for reset purposes
            gOrigHoriz = gHorizParam.Value
        End If
    End Sub

    Private Sub txtVertName_Validated(sender As Object, e As EventArgs) Handles txtVertName.Validated
        'sub to handle text entered in the vert name text box
        'check the vert name (it is bad practice to call other event handlers from other parts of code
        'that is why there is a separate check vert name sub)
        If (CheckVertName(txtVertName.Text)) Then
            'parameter name valid assign to original variable
            gOrigVert = gVertParam.Value
        End If
    End Sub

    Private Sub btnNextAngle_Click(sender As Object, e As EventArgs) Handles btnNextAngle.Click
        'make sure parameter names are valid
        If chkIgnoreHoriz.Checked = True Then
            'check only the vert name
            If gVertNameValidated = True Then
                'vert name is valid
                NextAngle()
            Else
                MsgBox("Vert Name not valid")
            End If
        Else
            If gVertNameValidated = True And gHorizNameValidated = True Then
                'both names valid
                NextAngle()
            Else
                MsgBox("Vert Name or Horiz Name not valid")
            End If
        End If
    End Sub

    Private Sub btnPrevAngle_Click(sender As Object, e As EventArgs) Handles btnPrevAngle.Click
        'make sure parameter names are valid
        If chkIgnoreHoriz.Checked = True Then
            'check only the vert name
            If gVertNameValidated = True Then
                'vert name is valid
                PrevAngle()
            Else
                MsgBox("Vert Name not valid")
            End If
        Else
            If gVertNameValidated = True And gHorizNameValidated = True Then
                'both names valid
                PrevAngle()
            Else
                MsgBox("Vert Name or Horiz Name not valid")
            End If
        End If
    End Sub

    Private Sub lstData_DoubleClick(sender As Object, e As EventArgs) Handles lstData.DoubleClick
        'sub to handle double clicking on the listview control
        'should highlight double clicked row, update the position index, and update the model
        Dim selectedItems As System.Windows.Forms.ListView.SelectedListViewItemCollection
        selectedItems = lstData.SelectedItems

        'index will be +1 from current index
        'pos array index starts at 1, lstview index starts at 0


        gintPrevIndex = gintCurrentIndex
        gintCurrentIndex = selectedItems.Item(0).Index + 1
        UpdateModel(gVertParam, gHorizParam)




    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        'sub to handle the automatic incrementing of the positions

        'disable user interface interaction to speed things up
        gInvApp.UserInterfaceManager.UserInteractionDisabled = True
        'gInvApp.AssemblyOptions.DeferUpdate = True 'Not sure If this will make a difference

        Try
            gboolLoop = True

            Do While gboolLoop = True
                'allows stop button event to be caught
                gInvApp.UserInterfaceManager.DoEvents()
                NextAngle()

                If gintCurrentIndex >= gdblPosArray.GetUpperBound(0) Then
                    gintPrevIndex = gintCurrentIndex
                    gintCurrentIndex = 1
                End If
            Loop

        Catch ex As Exception
            MsgBox("Something went wrong with the Play function. Check Parameter names.")

        End Try

        'enable user interface again
        gInvApp.UserInterfaceManager.UserInteractionDisabled = False

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        'sub to stop the Play loop
        gboolLoop = False
    End Sub

    Private Sub txtAccelThreshold_Validated(sender As Object, e As EventArgs) Handles txtAccelThreshold.Validated
        'sub handles entering text into the AccelThreshold text box
        ColorRows(CDbl(txtAccelThreshold.Text))
    End Sub

    Private Sub chkShowDebug_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowDebug.CheckedChanged

        'will extend the form width to show or hide some additional information
        If (chkShowDebug.Checked = True) Then
            Me.Width = 600
        Else
            Me.Width = 510
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'handles the exit button click event
        'should terminate play options and return everything back to normal

        'stop play loop if running
        gboolLoop = False
        'enable user interaction 
        gInvApp.UserInterfaceManager.UserInteractionDisabled = False
        Try
            'reset vert and horizontal parameters to the original values
            gVertParam.Value = gOrigVert
            gHorizParam.Value = gOrigHoriz
            gInvApp.ActiveDocument.Update2(True)
        Catch ex As Exception

        End Try

        'close form
        Me.Close()

    End Sub

    Private Sub frmPosStepper_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'stop play loop if running
        gboolLoop = False
        'enable user interaction 
        gInvApp.UserInterfaceManager.UserInteractionDisabled = False
        Try
            'reset vert and horizontal parameters to the original values
            gVertParam.Value = gOrigVert
            gHorizParam.Value = gOrigHoriz
            gInvApp.ActiveDocument.Update2(True)
            gintCurrentIndex = 1
        Catch ex As Exception

        End Try

        'Save settings
        My.Settings.StepperFilePath = txtFilePath.Text
        My.Settings.StepperVertName = txtVertName.Text
        My.Settings.StepperHorizName = txtHorizName.Text
        My.Settings.StepperAccelThresh = CDbl(txtAccelThreshold.Text)
        My.Settings.StepperStepSize = CInt(txtStepSize.Text)
        My.Settings.StepperIgnoreHoriz = chkIgnoreHoriz.Checked

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        'reset the horizontal and vertical position using the original values
        'values are defined after the text boxes with the names are validated
        'if they have not been validated this will throw an error

        Try
            'reset vert and horizontal parameters to the original values
            gVertParam.Value = gOrigVert
            gHorizParam.Value = gOrigHoriz
            gInvApp.ActiveDocument.Update2(True)
        Catch ex As Exception
            MsgBox("Problem resetting values, check Vert and Horiz Parameter Names")
        End Try
    End Sub

    Private Sub frmStepper_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'set window width
        Me.Width = 510 'debug controls hidden

        'check for master representation, and activate it if selected
        If (Not gAssyCompDef.RepresentationsManager.ActivePositionalRepresentation.Master) Then
            Dim result As System.Windows.Forms.DialogResult = System.Windows.Forms.MessageBox.Show("Master Positional Representation must be active.  Do you want to activate it?", "Activate Master Pos Rep", System.Windows.Forms.MessageBoxButtons.YesNo)
            If (result = System.Windows.Forms.DialogResult.Yes) Then
                Dim masterRep As Inventor.PositionalRepresentation
                masterRep = gAssyCompDef.RepresentationsManager.PositionalRepresentations.Item("Master")
                masterRep.Activate()
            Else
                Me.Close()
            End If
        End If

        'load settings
        txtFilePath.Text = My.Settings.StepperFilePath
        txtAccelThreshold.Text = My.Settings.StepperAccelThresh
        txtStepSize.Text = My.Settings.StepperStepSize
        chkIgnoreHoriz.Checked = My.Settings.StepperIgnoreHoriz

        'load vertical and horizontal names
        txtVertName.Text = My.Settings.StepperVertName

        'check vert name that was loaded
        If CheckVertName(txtVertName.Text) Then
            gOrigVert = gVertParam.Value
        End If

        'see if we're using the horizontal parameter
        If chkIgnoreHoriz.Checked Then
            'not using the horizontal parameter
        Else
            'checkbox not checked, using horizontal parameter
            txtHorizName.Text = My.Settings.StepperHorizName
            If CheckHorizName(txtHorizName.Text) Then
                gOrigHoriz = gHorizParam.Value
            End If
        End If


    End Sub

    Private Sub btnNameHelp_Click(sender As Object, e As EventArgs) Handles btnNameHelp.Click

        'create new instance of the class frmNameHelp and pass inventor application object
        Dim NameHelp = New frmNameHelp(gInvApp)

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
        If (NameHelp.GetVertParamName <> "") Then
            'apply the selected param name to the vert name text box
            txtVertName.Text = NameHelp.GetVertParamName
            If (CheckVertName(txtVertName.Text)) Then
                gOrigVert = gVertParam.Value
            End If
        ElseIf (NameHelp.GetHorizParamName <> "") Then
            'apply the selected param name to the horiz name text box
            txtHorizName.Text = NameHelp.GetHorizParamName
            If (CheckHorizName(txtHorizName.Text)) Then
                gOrigHoriz = gHorizParam.Value
            End If
        End If

        'Stop  NameHelp form And clear up memory
        NameHelp.Close()
        'make sure selection is terminated
        gInvApp.CommandManager.StopActiveCommand()
        'Show form again
        Me.Show()

    End Sub

    Private Function LocateInCenter(ByVal parent As Form, ByVal child As Form) As System.Drawing.Point
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
End Class