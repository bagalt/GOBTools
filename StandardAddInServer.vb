Imports Inventor
Imports System.Runtime.InteropServices
Imports Microsoft.Win32

Namespace GOBTools
    <ProgIdAttribute("GOBTools.StandardAddInServer"), _
    GuidAttribute("da7f705f-fbfa-45b4-ad7f-8398a2480c7c")> _
    Public Class StandardAddInServer
        Implements Inventor.ApplicationAddInServer

        'declare member variables
        Private g_ClientID As String
        Private WithEvents m_UIEvents As UserInterfaceEvents

        Private WithEvents m_StepperButtonDef As ButtonDefinition
        Private WithEvents m_HoleMakerButtonDef As ButtonDefinition

        Private WithEvents m_sampleButton As ButtonDefinition
        Private WithEvents m_featureCountButtonDef As ButtonDefinition


#Region "ApplicationAddInServer Members"

        ' This method is called by Inventor when it loads the AddIn. The AddInSiteObject provides access  
        ' to the Inventor Application object. The FirstTime flag indicates if the AddIn is loaded for
        ' the first time. However, with the introduction of the ribbon this argument is always true.

        Public Sub Activate(ByVal addInSiteObject As Inventor.ApplicationAddInSite, ByVal firstTime As Boolean) Implements Inventor.ApplicationAddInServer.Activate

            ' Initialize AddIn members.
            g_inventorApplication = addInSiteObject.Application

            'get the ClassID for this add-in and save it in a member variable to use where ever a clientID is needed
            g_ClientID = AddInClientID()

            ' Connect to the user-interface events to handle a ribbon reset.
            m_UIEvents = g_inventorApplication.UserInterfaceManager.UserInterfaceEvents

            'button defintions
            Dim controlDefs As ControlDefinitions
            controlDefs = g_inventorApplication.CommandManager.ControlDefinitions

            'Defining the icons for the stepper button
            Dim largeIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.Stepper32x32)
            Dim smallIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.Stepper16x16)

            'defining icons for the hole maker button
            Dim HMlargeIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.HoleMaker64x64)
            Dim HMsmallIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.HoleMaker16x16)

            'Button definition for the stepper program
            m_StepperButtonDef = controlDefs.AddButtonDefinition("Position Stepper", "GOBStepper", CommandTypesEnum.kNonShapeEditCmdType, AddInGuid(Me.GetType), "Automatically move P&P arm", "Position Stpper", smallIcon, largeIcon)

            'Button definition for the hole maker program
            m_HoleMakerButtonDef = controlDefs.AddButtonDefinition("Hole Maker", "GOBHoleMaker", CommandTypesEnum.kNonShapeEditCmdType, AddInGuid(Me.GetType), "Add Hole patterns to parts", "Hole Maker", HMsmallIcon, HMlargeIcon)

            ' Add to the user interface, if it's the first time.
            If firstTime Then
                'AddToUserInterface()
                AddToRibbon()
            End If
        End Sub

        ' This method is called by Inventor when the AddIn is unloaded. The AddIn will be
        ' unloaded either manually by the user or when the Inventor session is terminated.
        Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate

            ' TODO:  Add ApplicationAddInServer.Deactivate implementation

            ' Release objects.
            'these lines below may cause an error "COM object that has been separated from its underlying RCW cannot be used"
            'reference: https://forums.autodesk.com/t5/inventor-customization/com-object-that-has-been-separated-from-its-underlying-rcw/td-p/7404207
            'Marshal.FinalReleaseComObject(g_inventorApplication)
            g_inventorApplication = Nothing

            If Not m_StepperButtonDef Is Nothing Then
                Marshal.FinalReleaseComObject(m_StepperButtonDef)
            End If

            'this seem to generate the following error: "exception has been thrown by the target of an invocation"
            'I dont know what that means
            'If Not m_UIEvents Is Nothing Then
            'Marshal.FinalReleaseComObject(m_UIEvents)
            m_UIEvents = Nothing
            'End If

            System.GC.Collect()
            System.GC.WaitForPendingFinalizers()
        End Sub

        ' This property is provided to allow the AddIn to expose an API of its own to other 
        ' programs. Typically, this  would be done by implementing the AddIn's API
        ' interface in a class and returning that class object through this property.
        Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation
            Get
                Return Nothing
            End Get
        End Property

        ' Note:this method is now obsolete, you should use the 
        ' ControlDefinition functionality for implementing commands.
        Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand
        End Sub

#End Region

#Region "Sub to add items to the Ribbon"

        Private Sub m_UIEvents_OnResetRibbonInterface(Context As NameValueMap) Handles m_UIEvents.OnResetRibbonInterface
            ' The ribbon was reset, so add back the add-ins user-interface.
            ' AddToUserInterface()
            AddToRibbon()
        End Sub

        Public Sub AddToRibbon()
            Try
                'create a panel on the tools tab in the part and assembly ribbons
                For Each ribbon As Inventor.Ribbon In g_inventorApplication.UserInterfaceManager.Ribbons
                    Select Case ribbon.InternalName
                        Case "Part", "Assembly"
                            Dim tab As RibbonTab = ribbon.RibbonTabs.Item("id_TabTools")

                            Dim newpanel As RibbonPanel = tab.RibbonPanels.Add("GOB Tools", "gombarTools", AddInGuid(Me.GetType))

                            Call newpanel.CommandControls.AddButton(m_StepperButtonDef, True, True)
                            Call newpanel.CommandControls.AddButton(m_HoleMakerButtonDef, True, True)

                    End Select
                Next
            Catch ex As Exception
                MsgBox("Error adding GOB Tools to the Ribbon")
            End Try
        End Sub

#End Region

        Private Sub m_StepperButtonDef_OnExecute(Context As NameValueMap) Handles m_StepperButtonDef.OnExecute

            Dim PosStepper As New frmStepper(g_inventorApplication)
            'show form and tie it to the inventor window
            PosStepper.Show(New WindowWrapper(g_inventorApplication.MainFrameHWND))

        End Sub

        Private Sub m_HoleMakerButtonDef_OnExecute(Context As NameValueMap) Handles m_HoleMakerButtonDef.OnExecute

            'define new form and pass application 
            Dim HoleMaker As New frmHoleMaker(g_inventorApplication)
            'show the form and tie it to inventor window, 
            HoleMaker.Show(New WindowWrapper(g_inventorApplication.MainFrameHWND))

        End Sub

#Region "User interface definition"
        ' Sub where the user-interface creation is done.  This is called when
        ' the add-in loaded and also if the user interface is reset.
        Private Sub AddToUserInterface()
            ' This is where you'll add code to add buttons to the ribbon.

            '** Sample to illustrate creating a button on a new panel of the Tools tab of the Part ribbon.

            'Get the ribbon associated with the part document.
            'Dim partRibbon As Ribbon = g_inventorApplication.UserInterfaceManager.Ribbons.Item("Part")
            'get the ribbon associated with the Assembly document
            Dim partRibbon As Ribbon = g_inventorApplication.UserInterfaceManager.Ribbons.Item("Assembly")

            '' Get the "Tools" tab.
            'Dim toolsTab As RibbonTab = partRibbon.RibbonTabs.Item("id_TabTools")
            'get the Add-Ins tab from the assembly document ribbon
            Dim toolsTab As RibbonTab = partRibbon.RibbonTabs.Item("id_AddInsTab")


            '' Create a new panel.
            'Dim customPanel As RibbonPanel = toolsTab.RibbonPanels.Add("Sample", "MysSample", AddInClientID)
            Dim customPanel As RibbonPanel = toolsTab.RibbonPanels.Add("GOB Tools", "GOBTools", AddInClientID)

            '' Add a button, set to true to use the large icon (64x64)
            customPanel.CommandControls.AddButton(m_sampleButton, True)

        End Sub

        ' Sample handler for the button.
        ' Private Sub m_sampleButton_OnExecute(Context As NameValueMap) Handles m_sampleButton.OnExecute

        'Dim PosStepper As New frmStepper(g_inventorApplication)
        'show form and tie it to the inventor window
        'PosStepper.Show(New WindowWrapper(g_inventorApplication.MainFrameHWND))

        'End Sub
#End Region

    End Class
End Namespace


Public Module Globals
    ' Inventor application object.
    Public g_inventorApplication As Inventor.Application

#Region "Function to get the add-in client ID."
    ' This function uses reflection to get the GuidAttribute associated with the add-in.
    Public Function AddInClientID() As String
        Dim guid As String = ""
        Try
            Dim t As Type = GetType(GOBTools.StandardAddInServer)
            Dim customAttributes() As Object = t.GetCustomAttributes(GetType(GuidAttribute), False)
            Dim guidAttribute As GuidAttribute = CType(customAttributes(0), GuidAttribute)
            guid = "{" + guidAttribute.Value.ToString() + "}"
        Catch
        End Try

        Return guid
    End Function
#End Region

    'this property uses reflection to get the value fo rthe GuidAttribute attached to the class
    Public ReadOnly Property AddInGuid(ByVal t As Type) As String
        Get
            Dim guid As String = ""
            Try
                Dim customAttributes() As Object = t.GetCustomAttributes(GetType(GuidAttribute), False)
                Dim guidAttribute As GuidAttribute = CType(customAttributes(0), GuidAttribute)
                guid = "{" + guidAttribute.Value.ToString() + "}"
            Finally
                AddInGuid = guid
            End Try
        End Get
    End Property

#Region "hWnd Wrapper Class"
    ' This class is used to wrap a Win32 hWnd as a .Net IWind32Window class.
    ' This is primarily used for parenting a dialog to the Inventor window.
    '
    ' For example:
    ' myForm.Show(New WindowWrapper(g_inventorApplication.MainFrameHWND))
    '
    Public Class WindowWrapper
        Implements System.Windows.Forms.IWin32Window
        Public Sub New(ByVal handle As IntPtr)
            _hwnd = handle
        End Sub

        Public ReadOnly Property Handle() As IntPtr _
          Implements System.Windows.Forms.IWin32Window.Handle
            Get
                Return _hwnd
            End Get
        End Property

        Private _hwnd As IntPtr
    End Class
#End Region

#Region "Image Converter"
    ' Class used to convert bitmaps and icons from their .Net native types into
    ' an IPictureDisp object which is what the Inventor API requires. A typical
    ' usage is shown below where MyIcon is a bitmap or icon that's available
    ' as a resource of the project.
    '
    ' Dim smallIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.MyIcon)

    Public NotInheritable Class PictureDispConverter
        <DllImport("OleAut32.dll", EntryPoint:="OleCreatePictureIndirect", ExactSpelling:=True, PreserveSig:=False)> _
        Private Shared Function OleCreatePictureIndirect( _
            <MarshalAs(UnmanagedType.AsAny)> ByVal picdesc As Object, _
            ByRef iid As Guid, _
            <MarshalAs(UnmanagedType.Bool)> ByVal fOwn As Boolean) As stdole.IPictureDisp
        End Function

        Shared iPictureDispGuid As Guid = GetType(stdole.IPictureDisp).GUID

        Private NotInheritable Class PICTDESC
            Private Sub New()
            End Sub

            'Picture Types
            Public Const PICTYPE_BITMAP As Short = 1
            Public Const PICTYPE_ICON As Short = 3

            <StructLayout(LayoutKind.Sequential)> _
            Public Class Icon
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Icon))
                Friend picType As Integer = PICTDESC.PICTYPE_ICON
                Friend hicon As IntPtr = IntPtr.Zero
                Friend unused1 As Integer
                Friend unused2 As Integer

                Friend Sub New(ByVal icon As System.Drawing.Icon)
                    Me.hicon = icon.ToBitmap().GetHicon()
                End Sub
            End Class

            <StructLayout(LayoutKind.Sequential)> _
            Public Class Bitmap
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Bitmap))
                Friend picType As Integer = PICTDESC.PICTYPE_BITMAP
                Friend hbitmap As IntPtr = IntPtr.Zero
                Friend hpal As IntPtr = IntPtr.Zero
                Friend unused As Integer

                Friend Sub New(ByVal bitmap As System.Drawing.Bitmap)
                    Me.hbitmap = bitmap.GetHbitmap()
                End Sub
            End Class
        End Class

        Public Shared Function ToIPictureDisp(ByVal icon As System.Drawing.Icon) As stdole.IPictureDisp
            Dim pictIcon As New PICTDESC.Icon(icon)
            Return OleCreatePictureIndirect(pictIcon, iPictureDispGuid, True)
        End Function

        Public Shared Function ToIPictureDisp(ByVal bmp As System.Drawing.Bitmap) As stdole.IPictureDisp
            Dim pictBmp As New PICTDESC.Bitmap(bmp)
            Return OleCreatePictureIndirect(pictBmp, iPictureDispGuid, True)
        End Function
    End Class
#End Region

End Module
