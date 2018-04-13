<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lblFilePath
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.chkIgnorePriorYr = New System.Windows.Forms.CheckBox()
        Me.chkBAssy = New System.Windows.Forms.CheckBox()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File Path"
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(15, 26)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(334, 20)
        Me.txtFilePath.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(355, 26)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'chkIgnorePriorYr
        '
        Me.chkIgnorePriorYr.AutoSize = True
        Me.chkIgnorePriorYr.Checked = True
        Me.chkIgnorePriorYr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIgnorePriorYr.Location = New System.Drawing.Point(15, 53)
        Me.chkIgnorePriorYr.Name = "chkIgnorePriorYr"
        Me.chkIgnorePriorYr.Size = New System.Drawing.Size(169, 17)
        Me.chkIgnorePriorYr.TabIndex = 3
        Me.chkIgnorePriorYr.Text = "Ignore Prior Year Purch Parts?"
        Me.chkIgnorePriorYr.UseVisualStyleBackColor = True
        '
        'chkBAssy
        '
        Me.chkBAssy.AutoSize = True
        Me.chkBAssy.Checked = True
        Me.chkBAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBAssy.Location = New System.Drawing.Point(190, 53)
        Me.chkBAssy.Name = "chkBAssy"
        Me.chkBAssy.Size = New System.Drawing.Size(159, 17)
        Me.chkBAssy.TabIndex = 4
        Me.chkBAssy.Text = "Separate B49, B0049 Assy?"
        Me.chkBAssy.UseVisualStyleBackColor = True
        '
        'btnRunReport
        '
        Me.btnRunReport.Location = New System.Drawing.Point(15, 77)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(415, 35)
        Me.btnRunReport.TabIndex = 5
        Me.btnRunReport.Text = "Run Report"
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'lblResults
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Location = New System.Drawing.Point(12, 115)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(42, 13)
        Me.lblResults.TabIndex = 6
        Me.lblResults.Text = "Results"
        '
        'txtResults
        '
        Me.txtResults.Location = New System.Drawing.Point(13, 132)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.Size = New System.Drawing.Size(417, 98)
        Me.txtResults.TabIndex = 7
        '
        'lblFilePath
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 242)
        Me.Controls.Add(Me.txtResults)
        Me.Controls.Add(Me.lblResults)
        Me.Controls.Add(Me.btnRunReport)
        Me.Controls.Add(Me.chkBAssy)
        Me.Controls.Add(Me.chkIgnorePriorYr)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.Label1)
        Me.Name = "lblFilePath"
        Me.Text = "BOM Export Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtFilePath As Windows.Forms.TextBox
    Friend WithEvents btnBrowse As Windows.Forms.Button
    Friend WithEvents chkIgnorePriorYr As Windows.Forms.CheckBox
    Friend WithEvents chkBAssy As Windows.Forms.CheckBox
    Friend WithEvents btnRunReport As Windows.Forms.Button
    Friend WithEvents lblResults As Windows.Forms.Label
    Friend WithEvents txtResults As Windows.Forms.TextBox
End Class
