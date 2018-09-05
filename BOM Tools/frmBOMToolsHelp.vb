Imports System.IO

Public Class frmBOMToolsHelp
    Private Sub frmBOMToolsHelp_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        RichTextBox1.Rtf = My.Resources.BOMComparison_Help

    End Sub


End Class