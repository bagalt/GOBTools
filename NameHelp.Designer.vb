<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNameHelp
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
        Me.btnPickAgain = New System.Windows.Forms.Button()
        Me.btnNameHelpCancel = New System.Windows.Forms.Button()
        Me.btnApplyToHoriz = New System.Windows.Forms.Button()
        Me.btnApplyToVert = New System.Windows.Forms.Button()
        Me.lblParamName = New System.Windows.Forms.Label()
        Me.txtParamName = New System.Windows.Forms.TextBox()
        Me.lblConstraintName = New System.Windows.Forms.Label()
        Me.txtConstraintName = New System.Windows.Forms.TextBox()
        Me.btnApplyToAngle = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPickAgain
        '
        Me.btnPickAgain.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPickAgain.Location = New System.Drawing.Point(380, 63)
        Me.btnPickAgain.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPickAgain.Name = "btnPickAgain"
        Me.btnPickAgain.Size = New System.Drawing.Size(107, 43)
        Me.btnPickAgain.TabIndex = 15
        Me.btnPickAgain.Text = "Pick Again"
        Me.btnPickAgain.UseVisualStyleBackColor = True
        '
        'btnNameHelpCancel
        '
        Me.btnNameHelpCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNameHelpCancel.Location = New System.Drawing.Point(492, 63)
        Me.btnNameHelpCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNameHelpCancel.Name = "btnNameHelpCancel"
        Me.btnNameHelpCancel.Size = New System.Drawing.Size(107, 43)
        Me.btnNameHelpCancel.TabIndex = 14
        Me.btnNameHelpCancel.Text = "Cancel"
        Me.btnNameHelpCancel.UseVisualStyleBackColor = True
        '
        'btnApplyToHoriz
        '
        Me.btnApplyToHoriz.Location = New System.Drawing.Point(135, 63)
        Me.btnApplyToHoriz.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnApplyToHoriz.Name = "btnApplyToHoriz"
        Me.btnApplyToHoriz.Size = New System.Drawing.Size(107, 43)
        Me.btnApplyToHoriz.TabIndex = 13
        Me.btnApplyToHoriz.Text = "Apply to Horiz"
        Me.btnApplyToHoriz.UseVisualStyleBackColor = True
        '
        'btnApplyToVert
        '
        Me.btnApplyToVert.Location = New System.Drawing.Point(20, 63)
        Me.btnApplyToVert.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnApplyToVert.Name = "btnApplyToVert"
        Me.btnApplyToVert.Size = New System.Drawing.Size(107, 43)
        Me.btnApplyToVert.TabIndex = 12
        Me.btnApplyToVert.Text = "Apply to Vert"
        Me.btnApplyToVert.UseVisualStyleBackColor = True
        '
        'lblParamName
        '
        Me.lblParamName.AutoSize = True
        Me.lblParamName.Location = New System.Drawing.Point(484, 9)
        Me.lblParamName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblParamName.Name = "lblParamName"
        Me.lblParamName.Size = New System.Drawing.Size(115, 17)
        Me.lblParamName.TabIndex = 11
        Me.lblParamName.Text = "Parameter Name"
        '
        'txtParamName
        '
        Me.txtParamName.Location = New System.Drawing.Point(488, 31)
        Me.txtParamName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtParamName.Name = "txtParamName"
        Me.txtParamName.Size = New System.Drawing.Size(109, 22)
        Me.txtParamName.TabIndex = 10
        '
        'lblConstraintName
        '
        Me.lblConstraintName.AutoSize = True
        Me.lblConstraintName.Location = New System.Drawing.Point(16, 9)
        Me.lblConstraintName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConstraintName.Name = "lblConstraintName"
        Me.lblConstraintName.Size = New System.Drawing.Size(113, 17)
        Me.lblConstraintName.TabIndex = 9
        Me.lblConstraintName.Text = "Constraint Name"
        '
        'txtConstraintName
        '
        Me.txtConstraintName.Location = New System.Drawing.Point(20, 31)
        Me.txtConstraintName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtConstraintName.Name = "txtConstraintName"
        Me.txtConstraintName.Size = New System.Drawing.Size(460, 22)
        Me.txtConstraintName.TabIndex = 8
        '
        'btnApplyToAngle
        '
        Me.btnApplyToAngle.Location = New System.Drawing.Point(251, 63)
        Me.btnApplyToAngle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApplyToAngle.Name = "btnApplyToAngle"
        Me.btnApplyToAngle.Size = New System.Drawing.Size(107, 43)
        Me.btnApplyToAngle.TabIndex = 16
        Me.btnApplyToAngle.Text = "Apply to Angle"
        Me.btnApplyToAngle.UseVisualStyleBackColor = True
        '
        'frmNameHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 108)
        Me.Controls.Add(Me.btnApplyToAngle)
        Me.Controls.Add(Me.btnPickAgain)
        Me.Controls.Add(Me.btnNameHelpCancel)
        Me.Controls.Add(Me.btnApplyToHoriz)
        Me.Controls.Add(Me.btnApplyToVert)
        Me.Controls.Add(Me.lblParamName)
        Me.Controls.Add(Me.txtParamName)
        Me.Controls.Add(Me.lblConstraintName)
        Me.Controls.Add(Me.txtConstraintName)
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(630, 155)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(507, 155)
        Me.Name = "frmNameHelp"
        Me.Text = "Parameter Name Helper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPickAgain As Windows.Forms.Button
    Friend WithEvents btnNameHelpCancel As Windows.Forms.Button
    Friend WithEvents btnApplyToHoriz As Windows.Forms.Button
    Friend WithEvents btnApplyToVert As Windows.Forms.Button
    Friend WithEvents lblParamName As Windows.Forms.Label
    Friend WithEvents txtParamName As Windows.Forms.TextBox
    Friend WithEvents lblConstraintName As Windows.Forms.Label
    Friend WithEvents txtConstraintName As Windows.Forms.TextBox
    Friend WithEvents btnApplyToAngle As Windows.Forms.Button
End Class
