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
        Me.SuspendLayout()
        '
        'btnPickAgain
        '
        Me.btnPickAgain.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPickAgain.Location = New System.Drawing.Point(195, 51)
        Me.btnPickAgain.Name = "btnPickAgain"
        Me.btnPickAgain.Size = New System.Drawing.Size(80, 35)
        Me.btnPickAgain.TabIndex = 15
        Me.btnPickAgain.Text = "Pick Again"
        Me.btnPickAgain.UseVisualStyleBackColor = True
        '
        'btnNameHelpCancel
        '
        Me.btnNameHelpCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNameHelpCancel.Location = New System.Drawing.Point(276, 51)
        Me.btnNameHelpCancel.Name = "btnNameHelpCancel"
        Me.btnNameHelpCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnNameHelpCancel.TabIndex = 14
        Me.btnNameHelpCancel.Text = "Cancel"
        Me.btnNameHelpCancel.UseVisualStyleBackColor = True
        '
        'btnApplyToHoriz
        '
        Me.btnApplyToHoriz.Location = New System.Drawing.Point(96, 51)
        Me.btnApplyToHoriz.Name = "btnApplyToHoriz"
        Me.btnApplyToHoriz.Size = New System.Drawing.Size(80, 35)
        Me.btnApplyToHoriz.TabIndex = 13
        Me.btnApplyToHoriz.Text = "Apply to Horiz"
        Me.btnApplyToHoriz.UseVisualStyleBackColor = True
        '
        'btnApplyToVert
        '
        Me.btnApplyToVert.Location = New System.Drawing.Point(15, 51)
        Me.btnApplyToVert.Name = "btnApplyToVert"
        Me.btnApplyToVert.Size = New System.Drawing.Size(80, 35)
        Me.btnApplyToVert.TabIndex = 12
        Me.btnApplyToVert.Text = "Apply to Vert"
        Me.btnApplyToVert.UseVisualStyleBackColor = True
        '
        'lblParamName
        '
        Me.lblParamName.AutoSize = True
        Me.lblParamName.Location = New System.Drawing.Point(270, 7)
        Me.lblParamName.Name = "lblParamName"
        Me.lblParamName.Size = New System.Drawing.Size(86, 13)
        Me.lblParamName.TabIndex = 11
        Me.lblParamName.Text = "Parameter Name"
        '
        'txtParamName
        '
        Me.txtParamName.Location = New System.Drawing.Point(273, 25)
        Me.txtParamName.Name = "txtParamName"
        Me.txtParamName.Size = New System.Drawing.Size(83, 20)
        Me.txtParamName.TabIndex = 10
        '
        'lblConstraintName
        '
        Me.lblConstraintName.AutoSize = True
        Me.lblConstraintName.Location = New System.Drawing.Point(12, 7)
        Me.lblConstraintName.Name = "lblConstraintName"
        Me.lblConstraintName.Size = New System.Drawing.Size(85, 13)
        Me.lblConstraintName.TabIndex = 9
        Me.lblConstraintName.Text = "Constraint Name"
        '
        'txtConstraintName
        '
        Me.txtConstraintName.Location = New System.Drawing.Point(15, 25)
        Me.txtConstraintName.Name = "txtConstraintName"
        Me.txtConstraintName.Size = New System.Drawing.Size(248, 20)
        Me.txtConstraintName.TabIndex = 8
        '
        'frmNameHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 96)
        Me.Controls.Add(Me.btnPickAgain)
        Me.Controls.Add(Me.btnNameHelpCancel)
        Me.Controls.Add(Me.btnApplyToHoriz)
        Me.Controls.Add(Me.btnApplyToVert)
        Me.Controls.Add(Me.lblParamName)
        Me.Controls.Add(Me.txtParamName)
        Me.Controls.Add(Me.lblConstraintName)
        Me.Controls.Add(Me.txtConstraintName)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(385, 135)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 135)
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
End Class
