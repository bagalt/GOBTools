Imports Inventor

Public Class clsInteract
    'class to interact with user

    'Private WithEvents clsInteraction As Inventor.InteractionEvents
    Private WithEvents oInteractEvents As Inventor.InteractionEvents
    Private WithEvents oSelectEvents As Inventor.SelectEvents
    Private WithEvents oKeyboardEvents As Inventor.KeyboardEvents

    Private bStillSelecting As Boolean
    Private bToolTipEnabled As Boolean 'used to remember the general option for tool tips
    Private oInvApp As Inventor.Application
    Public bTerminated As Boolean

    Public Sub New(App As Inventor.Application)
        'on creation of class set the app value to the inventor app private variable
        oInvApp = App

    End Sub

    Public Function PickConstraint(filter As Inventor.SelectionFilterEnum, message As String) As Object
        'function for selecting an entity, copied from example code

        'flag for determining if selection is still ongoing
        bStillSelecting = True

        'create interaction object
        oInteractEvents = oInvApp.CommandManager.CreateInteractionEvents

        'ensure interaction is enables
        oInteractEvents.InteractionDisabled = False

        'set reference to select events
        oSelectEvents = oInteractEvents.SelectEvents

        'set filter using the value passed to the function
        oSelectEvents.AddSelectionFilter(filter)

        'only allow selection of one item
        oSelectEvents.SingleSelectEnabled = True

        'start interact events 
        oInteractEvents.Start()

        'show flying tool tip next to cursor with status bar text message
        bToolTipEnabled = oInvApp.GeneralOptions.ShowCommandPromptTooltips
        oInvApp.GeneralOptions.ShowCommandPromptTooltips = True

        'if message is not empty, then add the status bar text
        If message <> "" Then
            oInteractEvents.StatusBarText = message
        End If

        'loop until selection is made
        Do While bStillSelecting
            'allows interaction with the form
            'System.Windows.Forms.Application.DoEvents()
            oInvApp.UserInterfaceManager.DoEvents()
        Loop

        'get the selected item, if more than one thing selected usee only the first one
        Dim oSelectedEnts As Inventor.ObjectsEnumerator
        oSelectedEnts = oSelectEvents.SelectedEntities
        If oSelectedEnts.Count > 0 Then
            PickConstraint = oSelectedEnts.Item(1)
        Else
            PickConstraint = Nothing
        End If

        'stop interaction events object
        oInteractEvents.Stop()

        'cleanup
        oSelectEvents = Nothing
        oInteractEvents = Nothing

    End Function

    Private Sub oSelectEvents_OnSelect(JustSelectedEntities As ObjectsEnumerator, SelectionDevice As SelectionDeviceEnum, ModelPosition As Point, ViewPosition As Point2d, View As View) Handles oSelectEvents.OnSelect
        'set the flag to indicate done selecting
        bStillSelecting = False

    End Sub

    Private Sub oInteractEvents_OnTerminate() Handles oInteractEvents.OnTerminate
        'reset tooltip optino back to original option
        oInvApp.GeneralOptions.ShowCommandPromptTooltips = bToolTipEnabled

        'set select flag to indicate done selecting
        bStillSelecting = False
        bTerminated = True
    End Sub

    Public Function CancelInteract() As Object
        'reset tooltip optino back to original option
        oInvApp.GeneralOptions.ShowCommandPromptTooltips = bToolTipEnabled

        bStillSelecting = False
        bTerminated = True
        Return Nothing
    End Function

End Class
