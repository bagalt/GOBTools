Imports System.ComponentModel

Public Class frmParameterHelp

    'enable events and interaction/select objects

    'Private WithEvents oInteraction As Inventor.InteractionEvents
    'Private mySelectEvents As Inventor.SelectEvents

    Private mySelection As clsInteract
    Private InvApp As Inventor.Application
    Private ParameterName As String
    Private ConstraintName As String
    Private ColumnName As String

    Private donePicking As Boolean

    Public Sub New(App As Inventor.Application, myColumns As System.Windows.Forms.DataGridViewColumnCollection)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InvApp = App
        columnsComboBox.Items.Clear()

        'fill in the drop down menu
        Dim item As System.Windows.Forms.DataGridViewColumn
        For Each item In myColumns
            columnsComboBox.Items.Add(item.Name)
        Next

        mySelection = New clsInteract(InvApp)
        donePicking = False

    End Sub

    ReadOnly Property GetColumnName As String
        Get
            donePicking = True
            Return ColumnName
        End Get
    End Property

    ReadOnly Property GetParameterName() As String
        Get
            donePicking = True
            Return ParameterName
        End Get

    End Property

    ReadOnly Property GetConstraintName() As String
        Get
            donePicking = True
            Return ConstraintName
        End Get
    End Property

    ReadOnly Property PickingStatus() As Boolean
        Get
            Return donePicking
        End Get
    End Property

    Private Sub frmParameterHelp_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked
        'Show the help message box
        MsgBox("1. Select the desired constraint in the model tree" & vbCrLf &
                    "2. Click Apply to Vert or Apply to Horiz",, "Parameter Name Help")
    End Sub

    Private Sub btnNameHelpCancel_Click(sender As Object, e As EventArgs) Handles btnNameHelpCancel.Click
        'canceled name helper, close form
        donePicking = True
        mySelection.CancelInteract()
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        'sub to apply the selected parameter to the horizontal parameter
        ParameterName = txtParamName.Text
        ConstraintName = txtConstraintName.Text
        ColumnName = columnsComboBox.SelectedItem.ToString
        donePicking = True
    End Sub

    Public Sub PickConsraint()
        'sub to handle selecting the constraint from the browser tree

        'define the type of object that will be selected, if not this type of object it will thrown an error
        Dim assyConstraint As Inventor.AssemblyConstraint = Nothing
        'Inventor.AssemblyConstraint
        Dim param As Inventor.ModelParameter

        'keep form on top of other windows
        Me.TopMost = True

        'assign assy constraint to assyConstraint, handle error if not correct selection
        Try
            'set focus back to inventor for these steps so tool tips show up 
            BringWindowToTop(InvApp.MainFrameHWND)

            assyConstraint = mySelection.PickConstraint(Inventor.SelectionFilterEnum.kAllEntitiesFilter, "Pick Constraint from Tree")

            'if assyConstraint is a flush or mate constraint then continue to get information
            If (assyConstraint.Type = Inventor.ObjectTypeEnum.kMateConstraintObject) Or (assyConstraint.Type = Inventor.ObjectTypeEnum.kFlushConstraintObject) Then

                'assign the correspoding parameter to param
                param = assyConstraint.offset

                'populate text boxes with names from selected item
                txtConstraintName.Text = assyConstraint.Name
                txtParamName.Text = param.Name

            Else
                MsgBox("Must be a Flush or Mate Constraint, select again", MsgBoxStyle.SystemModal)
                Call PickConsraint()
            End If
        Catch
            If (assyConstraint IsNot Nothing) Then
                'something was picked, but it was not correct so present the message and pick again
                MsgBox("Must select a flush or mate constraint from Browser Tree", MsgBoxStyle.SystemModal)
                Call PickConsraint()
            ElseIf (donePicking = True And assyConstraint Is Nothing) Then
                'cancled operation so close the form
                Exit Sub
            ElseIf (mySelection.bTerminated = True) Then
                Exit Sub
            Else
                'if assyConstraint is nothing then close the form, 
                MsgBox("Invalid selection, must pick flush/mate constraint", MsgBoxStyle.SystemModal)
                Call PickConsraint()
                'Exit Sub
            End If

        End Try

        'set focus back to the form
        Me.Activate()

        'loop until selection is made
        Do While donePicking = False
            'InvApp.UserInterfaceManager.DoEvents()
            System.Windows.Forms.Application.DoEvents()
        Loop

    End Sub

    'function to bring the window to the top
    Private Declare Function BringWindowToTop Lib "user32.dll" (ByVal hwnd As Integer) As Long

    Private Sub btnPickAgain_Click(sender As Object, e As EventArgs) Handles btnPickAgain.Click
        'Rerun the PickConstraint routine when PickAgain was clicked
        Call PickConsraint()
    End Sub


    Public Function StopNameHelp() As Object

        mySelection.CancelInteract()
        Me.Close()
        Me.Finalize()
        Return Nothing
    End Function

    Private Sub frmParameterHelp_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'handle closing of the form by the X button
        mySelection.CancelInteract()
        donePicking = True
    End Sub
End Class