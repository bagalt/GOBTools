﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
 Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0"),  _
 Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
Partial Friend NotInheritable Class Settings
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared defaultInstance As Settings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()),Settings)
    
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
    
    Public Shared ReadOnly Property [Default]() As Settings
        Get
            
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
            Return defaultInstance
        End Get
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property BomToolsBomImportAllowBAssyParent() As Boolean
        Get
            Return CType(Me("BomToolsBomImportAllowBAssyParent"),Boolean)
        End Get
        Set
            Me("BomToolsBomImportAllowBAssyParent") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property BomToolsPartCreateIncludeB49Assemblies() As Boolean
        Get
            Return CType(Me("BomToolsPartCreateIncludeB49Assemblies"),Boolean)
        End Get
        Set
            Me("BomToolsPartCreateIncludeB49Assemblies") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property BomToolsBomCompIncludeB49Assemblies() As Boolean
        Get
            Return CType(Me("BomToolsBomCompIncludeB49Assemblies"),Boolean)
        End Get
        Set
            Me("BomToolsBomCompIncludeB49Assemblies") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property BOMToolsBomCompIncludeB39Children() As Boolean
        Get
            Return CType(Me("BOMToolsBomCompIncludeB39Children"),Boolean)
        End Get
        Set
            Me("BOMToolsBomCompIncludeB39Children") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property BOMToolsBomCompIncludeB45Children() As Boolean
        Get
            Return CType(Me("BOMToolsBomCompIncludeB45Children"),Boolean)
        End Get
        Set
            Me("BOMToolsBomCompIncludeB45Children") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Browse for Path")>  _
    Public Property StepperFilePath() As String
        Get
            Return CType(Me("StepperFilePath"),String)
        End Get
        Set
            Me("StepperFilePath") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Vert Name")>  _
    Public Property StepperVertName() As String
        Get
            Return CType(Me("StepperVertName"),String)
        End Get
        Set
            Me("StepperVertName") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Horiz Name")>  _
    Public Property StepperHorizName() As String
        Get
            Return CType(Me("StepperHorizName"),String)
        End Get
        Set
            Me("StepperHorizName") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("9")>  _
    Public Property StepperAccelThresh() As Double
        Get
            Return CType(Me("StepperAccelThresh"),Double)
        End Get
        Set
            Me("StepperAccelThresh") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("2")>  _
    Public Property StepperStepSize() As Integer
        Get
            Return CType(Me("StepperStepSize"),Integer)
        End Get
        Set
            Me("StepperStepSize") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property StepperIgnoreHoriz() As Boolean
        Get
            Return CType(Me("StepperIgnoreHoriz"),Boolean)
        End Get
        Set
            Me("StepperIgnoreHoriz") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property BomToolsBomCompIncludeC49Assemblies() As Boolean
        Get
            Return CType(Me("BomToolsBomCompIncludeC49Assemblies"),Boolean)
        End Get
        Set
            Me("BomToolsBomCompIncludeC49Assemblies") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
    Public Property BomToolsFormLocation() As Global.System.Drawing.Point
        Get
            Return CType(Me("BomToolsFormLocation"),Global.System.Drawing.Point)
        End Get
        Set
            Me("BomToolsFormLocation") = value
        End Set
    End Property
End Class

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.GOBTools.Settings
            Get
                Return Global.GOBTools.Settings.Default
            End Get
        End Property
    End Module
End Namespace
