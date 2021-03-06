﻿Imports System.ComponentModel

Public Class frmNameHelp
    'enable events and interaction/select objects

    'Private WithEvents oInteraction As Inventor.InteractionEvents
    'Private mySelectEvents As Inventor.SelectEvents

    Private mySelection As clsInteract
    Private InvApp As Inventor.Application
    Private HorizParamName As String
    Private HorizConstraintName As String
    Private VertParamName As String
    Private VertConstraintName As String
    Private AngleParamName As String
    Private AngleConstraintName As String
    Private angleConstraint As Inventor.AngleConstraint
    Private mateConstraint As Inventor.MateConstraint
    Private flushConstraint As Inventor.FlushConstraint
    Private donePicking As Boolean

    Public Sub New(App As Inventor.Application)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InvApp = App
        mySelection = New clsInteract(InvApp)
        donePicking = False

    End Sub

    ReadOnly Property GetHorizParamName() As String
        Get
            donePicking = True
            Return HorizParamName
        End Get

    End Property

    ReadOnly Property GetHorizConstraintName() As String
        Get
            donePicking = True
            Return HorizConstraintName
        End Get
    End Property

    ReadOnly Property GetVertParamName() As String
        Get
            donePicking = True
            Return VertParamName
        End Get
    End Property

    ReadOnly Property GetVertConstraintName() As String

        Get
            donePicking = True
            Return VertConstraintName
        End Get
    End Property

    ReadOnly Property GetAngleParamName() As String
        Get
            donePicking = True
            Return AngleParamName
        End Get
    End Property

    ReadOnly Property GetAngleConstraintName() As String
        Get
            donePicking = True
            Return AngleConstraintName
        End Get
    End Property

    ReadOnly Property PickingStatus() As Boolean
        Get
            Return donePicking
        End Get
    End Property

    Private Sub frmNameHelp_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked
        'Show the help message box
        MsgBox("1. Select the desired constraint in the model tree" & vbCrLf &
                "2. Click Apply to Vert, Apply to Horiz, or Apply to Angle",, "Parameter Name Help")
    End Sub

    Private Sub btnNameHelpCancel_Click(sender As Object, e As EventArgs) Handles btnNameHelpCancel.Click
        'canceled name helper, close form
        donePicking = True
        mySelection.CancelInteract()
    End Sub

    Private Sub btnApplyToVert_Click(sender As Object, e As EventArgs) Handles btnApplyToVert.Click
        'sub to apply the chosen parameter to the vertical parameter
        VertParamName = txtParamName.Text
        VertConstraintName = txtConstraintName.Text
        donePicking = True
    End Sub

    Private Sub btnApplyToHoriz_Click(sender As Object, e As EventArgs) Handles btnApplyToHoriz.Click
        'sub to apply the selected parameter to the horizontal parameter
        HorizParamName = txtParamName.Text
        HorizConstraintName = txtConstraintName.Text
        donePicking = True
    End Sub

    Private Sub btnApplyToAngle_Click(sender As Object, e As EventArgs) Handles btnApplyToAngle.Click
        'sub to apply the selected parameter to the angle parameter
        AngleParamName = txtParamName.Text
        AngleConstraintName = txtConstraintName.Text
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

            'if assyConstraint is a flush, mate, or angle constraint then continue to get information
            If (assyConstraint.Type = Inventor.ObjectTypeEnum.kMateConstraintObject) Or (assyConstraint.Type = Inventor.ObjectTypeEnum.kFlushConstraintObject Or (assyConstraint.Type = Inventor.ObjectTypeEnum.kAngleConstraintObject)) Then

                Select Case assyConstraint.Type
                    Case Inventor.ObjectTypeEnum.kMateConstraintObject
                        'assign the correspoding parameter to param
                        mateConstraint = assyConstraint
                        param = mateConstraint.Offset
                        'populate text boxes with names from selected item
                        txtConstraintName.Text = mateConstraint.Name
                        txtParamName.Text = param.Name

                    Case Inventor.ObjectTypeEnum.kFlushConstraintObject
                        'assign the correspoding parameter to param
                        flushConstraint = assyConstraint
                        param = flushConstraint.Offset
                        'populate text boxes with names from selected item
                        txtConstraintName.Text = flushConstraint.Name
                        txtParamName.Text = param.Name

                    Case Inventor.ObjectTypeEnum.kAngleConstraintObject
                        'Angle constraints do not have an "Offset". 
                        angleConstraint = assyConstraint
                        param = angleConstraint.Angle
                        'populate text boxes with names from selected item
                        txtConstraintName.Text = angleConstraint.Name
                        txtParamName.Text = param.Name
                    Case Else
                        param = Nothing
                End Select

            Else
                MsgBox("Must be a Flush, Mate, or Angle Constraint, select again", MsgBoxStyle.SystemModal)
                Call PickConsraint()
            End If
        Catch
            If (assyConstraint IsNot Nothing) Then
                'something was picked, but it was not correct so present the message and pick again
                MsgBox("Must select a flush, mate, or angle constraint from Browser Tree", MsgBoxStyle.SystemModal)
                Call PickConsraint()
            ElseIf (donePicking = True And assyConstraint Is Nothing) Then
                'cancled operation so close the form
                Exit Sub
            ElseIf (mySelection.bTerminated = True) Then
                Exit Sub
            Else
                'if assyConstraint is nothing then close the form, 
                MsgBox("Invalid selection, must pick flush, mate, or angle constraint", MsgBoxStyle.SystemModal)
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

    Private Sub frmNameHelp_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'handle closing of the form by the X button
        mySelection.CancelInteract()
        donePicking = True
    End Sub


End Class