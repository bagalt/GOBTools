Imports Inventor
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.Office.Core

Public Class frmBOMExport

    Private ThisApplication As Inventor.Application

    Public Sub New(InvApp As Inventor.Application)

        ' This call is required by the designer.
        InitializeComponent()

        ThisApplication = InvApp
        txtResults.Clear()

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'browse for a file path to save the excel document

        FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        FolderBrowserDialog1.ShowNewFolderButton = True
        FolderBrowserDialog1.Description = "Select the folder where the Excel file will be saved"

        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtDirectoryPath.Text = FolderBrowserDialog1.SelectedPath
        End If

    End Sub

    Private Sub btnRunReport_Click(sender As Object, e As EventArgs) Handles btnRunReport.Click
        'Export the part list has been clicked, run the program
        txtResults.Text = ""
        txtResults.Text = "Processing..."
        BOMExport.AssemblyCount(ThisApplication, chkIgnorePriorYr.Checked, txtDirectoryPath.Text, chkBAssy.Checked)
        txtResults.Text = BOMExport.Results
    End Sub

    Private Sub frmBOMExport_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked
        'display help  information
        Dim sHelpString As String

        sHelpString = "This tool will generate an Excel file of all the unique non standard parts in an assembly." _
            & vbNewLine & vbNewLine & "1. Click the Browse button to browse to a directory to save the excel file." _
            & vbNewLine & "     If no path is defined the Excel file will not be created" _
            & vbNewLine & vbNewLine & "2. Checking 'Ignore Prior Year Purch Parts' will not include purchase parts from earlier years" _
            & vbNewLine & vbNewLine & "3. Checking 'Separate B49, B0049 Assy?' will treat B49 assemblies as parts and they will be included in the file" _
            & vbNewLine & vbNewLine & "4. Click Run Report to start the process.  Information will be displayed in the Results section"

        MsgBox(sHelpString, MsgBoxStyle.Information, "Help for BOM Export")
        e.Cancel = True

    End Sub

    Private Sub frmBOMExport_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'handles closing tasks

        'clear the information in txtResults
        txtResults.Clear()

    End Sub
End Class