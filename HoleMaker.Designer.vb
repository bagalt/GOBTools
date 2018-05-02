<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoleMaker
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
        Me.gboxTemplate = New System.Windows.Forms.GroupBox()
        Me.cmbTemplate = New System.Windows.Forms.ComboBox()
        Me.gboxTolerance = New System.Windows.Forms.GroupBox()
        Me.cmbTolerance = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkShowThumb = New System.Windows.Forms.CheckBox()
        Me.numRotationAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblRotationAngle = New System.Windows.Forms.Label()
        Me.chkThreaded = New System.Windows.Forms.CheckBox()
        Me.chkFlip = New System.Windows.Forms.CheckBox()
        Me.picThumbnail = New System.Windows.Forms.PictureBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.gboxTemplate.SuspendLayout()
        Me.gboxTolerance.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numRotationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gboxTemplate
        '
        Me.gboxTemplate.Controls.Add(Me.cmbTemplate)
        Me.gboxTemplate.Location = New System.Drawing.Point(3, 12)
        Me.gboxTemplate.Name = "gboxTemplate"
        Me.gboxTemplate.Size = New System.Drawing.Size(163, 49)
        Me.gboxTemplate.TabIndex = 0
        Me.gboxTemplate.TabStop = False
        Me.gboxTemplate.Text = "Template"
        '
        'cmbTemplate
        '
        Me.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemplate.FormattingEnabled = True
        Me.cmbTemplate.Location = New System.Drawing.Point(6, 19)
        Me.cmbTemplate.Name = "cmbTemplate"
        Me.cmbTemplate.Size = New System.Drawing.Size(151, 21)
        Me.cmbTemplate.TabIndex = 0
        '
        'gboxTolerance
        '
        Me.gboxTolerance.Controls.Add(Me.cmbTolerance)
        Me.gboxTolerance.Location = New System.Drawing.Point(3, 67)
        Me.gboxTolerance.Name = "gboxTolerance"
        Me.gboxTolerance.Size = New System.Drawing.Size(163, 54)
        Me.gboxTolerance.TabIndex = 1
        Me.gboxTolerance.TabStop = False
        Me.gboxTolerance.Text = "Tolerance"
        '
        'cmbTolerance
        '
        Me.cmbTolerance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTolerance.FormattingEnabled = True
        Me.cmbTolerance.Location = New System.Drawing.Point(6, 19)
        Me.cmbTolerance.Name = "cmbTolerance"
        Me.cmbTolerance.Size = New System.Drawing.Size(151, 21)
        Me.cmbTolerance.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkShowThumb)
        Me.GroupBox1.Controls.Add(Me.numRotationAngle)
        Me.GroupBox1.Controls.Add(Me.lblRotationAngle)
        Me.GroupBox1.Controls.Add(Me.chkThreaded)
        Me.GroupBox1.Controls.Add(Me.chkFlip)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 106)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'chkShowThumb
        '
        Me.chkShowThumb.AutoSize = True
        Me.chkShowThumb.Checked = True
        Me.chkShowThumb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowThumb.Location = New System.Drawing.Point(9, 83)
        Me.chkShowThumb.Name = "chkShowThumb"
        Me.chkShowThumb.Size = New System.Drawing.Size(95, 17)
        Me.chkShowThumb.TabIndex = 4
        Me.chkShowThumb.Text = "Show Thumb?"
        Me.chkShowThumb.UseVisualStyleBackColor = True
        '
        'numRotationAngle
        '
        Me.numRotationAngle.Location = New System.Drawing.Point(9, 36)
        Me.numRotationAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.numRotationAngle.Name = "numRotationAngle"
        Me.numRotationAngle.Size = New System.Drawing.Size(70, 20)
        Me.numRotationAngle.TabIndex = 3
        '
        'lblRotationAngle
        '
        Me.lblRotationAngle.AutoSize = True
        Me.lblRotationAngle.Location = New System.Drawing.Point(6, 20)
        Me.lblRotationAngle.Name = "lblRotationAngle"
        Me.lblRotationAngle.Size = New System.Drawing.Size(73, 13)
        Me.lblRotationAngle.TabIndex = 3
        Me.lblRotationAngle.Text = "Rot Ang (deg)"
        '
        'chkThreaded
        '
        Me.chkThreaded.AutoSize = True
        Me.chkThreaded.Location = New System.Drawing.Point(9, 60)
        Me.chkThreaded.Name = "chkThreaded"
        Me.chkThreaded.Size = New System.Drawing.Size(78, 17)
        Me.chkThreaded.TabIndex = 1
        Me.chkThreaded.Text = "Threaded?"
        Me.chkThreaded.UseVisualStyleBackColor = True
        '
        'chkFlip
        '
        Me.chkFlip.AutoSize = True
        Me.chkFlip.Location = New System.Drawing.Point(93, 60)
        Me.chkFlip.Name = "chkFlip"
        Me.chkFlip.Size = New System.Drawing.Size(48, 17)
        Me.chkFlip.TabIndex = 0
        Me.chkFlip.Text = "Flip?"
        Me.chkFlip.UseVisualStyleBackColor = True
        '
        'picThumbnail
        '
        Me.picThumbnail.Location = New System.Drawing.Point(172, 12)
        Me.picThumbnail.Name = "picThumbnail"
        Me.picThumbnail.Size = New System.Drawing.Size(150, 150)
        Me.picThumbnail.TabIndex = 3
        Me.picThumbnail.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(294, 219)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(30, 13)
        Me.lblVersion.TabIndex = 4
        Me.lblVersion.Text = "vX.X"
        '
        'frmHoleMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 241)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.picThumbnail)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gboxTolerance)
        Me.Controls.Add(Me.gboxTemplate)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(350, 280)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(185, 250)
        Me.Name = "frmHoleMaker"
        Me.Text = "Hole Maker"
        Me.gboxTemplate.ResumeLayout(False)
        Me.gboxTolerance.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numRotationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gboxTemplate As Windows.Forms.GroupBox
    Friend WithEvents cmbTemplate As Windows.Forms.ComboBox
    Friend WithEvents gboxTolerance As Windows.Forms.GroupBox
    Friend WithEvents cmbTolerance As Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents lblRotationAngle As Windows.Forms.Label
    Friend WithEvents chkThreaded As Windows.Forms.CheckBox
    Friend WithEvents chkFlip As Windows.Forms.CheckBox
    Friend WithEvents numRotationAngle As Windows.Forms.NumericUpDown
    Friend WithEvents picThumbnail As Windows.Forms.PictureBox
    Friend WithEvents chkShowThumb As Windows.Forms.CheckBox
    Friend WithEvents lblVersion As Windows.Forms.Label
End Class
