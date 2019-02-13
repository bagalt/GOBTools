<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParameterHelp
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
        Me.btnApply = New System.Windows.Forms.Button()
        Me.lblParamName = New System.Windows.Forms.Label()
        Me.txtParamName = New System.Windows.Forms.TextBox()
        Me.lblConstraintName = New System.Windows.Forms.Label()
        Me.txtConstraintName = New System.Windows.Forms.TextBox()
        Me.columnsComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnPickAgain
        '
        Me.btnPickAgain.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPickAgain.Location = New System.Drawing.Point(96, 103)
        Me.btnPickAgain.Name = "btnPickAgain"
        Me.btnPickAgain.Size = New System.Drawing.Size(80, 35)
        Me.btnPickAgain.TabIndex = 23
        Me.btnPickAgain.Text = "Pick Again"
        Me.btnPickAgain.UseVisualStyleBackColor = True
        '
        'btnNameHelpCancel
        '
        Me.btnNameHelpCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNameHelpCancel.Location = New System.Drawing.Point(182, 103)
        Me.btnNameHelpCancel.Name = "btnNameHelpCancel"
        Me.btnNameHelpCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnNameHelpCancel.TabIndex = 22
        Me.btnNameHelpCancel.Text = "Cancel"
        Me.btnNameHelpCancel.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(10, 103)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(80, 35)
        Me.btnApply.TabIndex = 21
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'lblParamName
        '
        Me.lblParamName.AutoSize = True
        Me.lblParamName.Location = New System.Drawing.Point(179, 54)
        Me.lblParamName.Name = "lblParamName"
        Me.lblParamName.Size = New System.Drawing.Size(86, 13)
        Me.lblParamName.TabIndex = 19
        Me.lblParamName.Text = "Parameter Name"
        '
        'txtParamName
        '
        Me.txtParamName.Location = New System.Drawing.Point(182, 72)
        Me.txtParamName.Name = "txtParamName"
        Me.txtParamName.Size = New System.Drawing.Size(80, 20)
        Me.txtParamName.TabIndex = 18
        '
        'lblConstraintName
        '
        Me.lblConstraintName.AutoSize = True
        Me.lblConstraintName.Location = New System.Drawing.Point(7, 54)
        Me.lblConstraintName.Name = "lblConstraintName"
        Me.lblConstraintName.Size = New System.Drawing.Size(85, 13)
        Me.lblConstraintName.TabIndex = 17
        Me.lblConstraintName.Text = "Constraint Name"
        '
        'txtConstraintName
        '
        Me.txtConstraintName.Location = New System.Drawing.Point(10, 72)
        Me.txtConstraintName.Name = "txtConstraintName"
        Me.txtConstraintName.Size = New System.Drawing.Size(166, 20)
        Me.txtConstraintName.TabIndex = 16
        '
        'columnsComboBox
        '
        Me.columnsComboBox.FormattingEnabled = True
        Me.columnsComboBox.Location = New System.Drawing.Point(10, 25)
        Me.columnsComboBox.Name = "columnsComboBox"
        Me.columnsComboBox.Size = New System.Drawing.Size(252, 21)
        Me.columnsComboBox.TabIndex = 24
        Me.columnsComboBox.Text = "Select Column..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Apply to Column"
        '
        'frmParameterHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 148)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.columnsComboBox)
        Me.Controls.Add(Me.btnPickAgain)
        Me.Controls.Add(Me.btnNameHelpCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lblParamName)
        Me.Controls.Add(Me.txtParamName)
        Me.Controls.Add(Me.lblConstraintName)
        Me.Controls.Add(Me.txtConstraintName)
        Me.Name = "frmParameterHelp"
        Me.Text = "Parameter Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPickAgain As Windows.Forms.Button
    Friend WithEvents btnNameHelpCancel As Windows.Forms.Button
    Friend WithEvents btnApply As Windows.Forms.Button
    Friend WithEvents lblParamName As Windows.Forms.Label
    Friend WithEvents txtParamName As Windows.Forms.TextBox
    Friend WithEvents lblConstraintName As Windows.Forms.Label
    Friend WithEvents txtConstraintName As Windows.Forms.TextBox
    Friend WithEvents columnsComboBox As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
End Class
