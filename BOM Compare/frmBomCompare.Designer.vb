<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBomCompare
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
        Me.lvInventorBom = New System.Windows.Forms.ListView()
        Me.lvPromanBom = New System.Windows.Forms.ListView()
        Me.lblInventorBom = New System.Windows.Forms.Label()
        Me.lblPromanBom = New System.Windows.Forms.Label()
        Me.btnLoadPromanBom = New System.Windows.Forms.Button()
        Me.btnLoadInventorBom = New System.Windows.Forms.Button()
        Me.btnRunCompare = New System.Windows.Forms.Button()
        Me.txtNumInventorParts = New System.Windows.Forms.TextBox()
        Me.lblNumInvParts = New System.Windows.Forms.Label()
        Me.lblNumPromanParts = New System.Windows.Forms.Label()
        Me.txtNumPromanParts = New System.Windows.Forms.TextBox()
        Me.btnInventorColor = New System.Windows.Forms.Button()
        Me.btnPromanColor = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvInventorBom
        '
        Me.lvInventorBom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvInventorBom.Location = New System.Drawing.Point(12, 30)
        Me.lvInventorBom.Name = "lvInventorBom"
        Me.lvInventorBom.Size = New System.Drawing.Size(194, 515)
        Me.lvInventorBom.TabIndex = 0
        Me.lvInventorBom.UseCompatibleStateImageBehavior = False
        '
        'lvPromanBom
        '
        Me.lvPromanBom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvPromanBom.Location = New System.Drawing.Point(293, 30)
        Me.lvPromanBom.Name = "lvPromanBom"
        Me.lvPromanBom.Size = New System.Drawing.Size(194, 515)
        Me.lvPromanBom.TabIndex = 1
        Me.lvPromanBom.UseCompatibleStateImageBehavior = False
        '
        'lblInventorBom
        '
        Me.lblInventorBom.AutoSize = True
        Me.lblInventorBom.Location = New System.Drawing.Point(13, 12)
        Me.lblInventorBom.Name = "lblInventorBom"
        Me.lblInventorBom.Size = New System.Drawing.Size(73, 13)
        Me.lblInventorBom.TabIndex = 2
        Me.lblInventorBom.Text = "Inventor BOM"
        '
        'lblPromanBom
        '
        Me.lblPromanBom.AutoSize = True
        Me.lblPromanBom.Location = New System.Drawing.Point(290, 12)
        Me.lblPromanBom.Name = "lblPromanBom"
        Me.lblPromanBom.Size = New System.Drawing.Size(70, 13)
        Me.lblPromanBom.TabIndex = 3
        Me.lblPromanBom.Text = "Proman BOM"
        '
        'btnLoadPromanBom
        '
        Me.btnLoadPromanBom.Location = New System.Drawing.Point(212, 30)
        Me.btnLoadPromanBom.Name = "btnLoadPromanBom"
        Me.btnLoadPromanBom.Size = New System.Drawing.Size(75, 60)
        Me.btnLoadPromanBom.TabIndex = 4
        Me.btnLoadPromanBom.Text = "Load Proman BOM"
        Me.btnLoadPromanBom.UseVisualStyleBackColor = True
        '
        'btnLoadInventorBom
        '
        Me.btnLoadInventorBom.Location = New System.Drawing.Point(212, 96)
        Me.btnLoadInventorBom.Name = "btnLoadInventorBom"
        Me.btnLoadInventorBom.Size = New System.Drawing.Size(75, 60)
        Me.btnLoadInventorBom.TabIndex = 5
        Me.btnLoadInventorBom.Text = "Load Inventor BOM"
        Me.btnLoadInventorBom.UseVisualStyleBackColor = True
        '
        'btnRunCompare
        '
        Me.btnRunCompare.Location = New System.Drawing.Point(212, 162)
        Me.btnRunCompare.Name = "btnRunCompare"
        Me.btnRunCompare.Size = New System.Drawing.Size(75, 60)
        Me.btnRunCompare.TabIndex = 6
        Me.btnRunCompare.Text = "Run Compare"
        Me.btnRunCompare.UseVisualStyleBackColor = True
        '
        'txtNumInventorParts
        '
        Me.txtNumInventorParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumInventorParts.Location = New System.Drawing.Point(12, 564)
        Me.txtNumInventorParts.Name = "txtNumInventorParts"
        Me.txtNumInventorParts.Size = New System.Drawing.Size(98, 20)
        Me.txtNumInventorParts.TabIndex = 7
        '
        'lblNumInvParts
        '
        Me.lblNumInvParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumInvParts.AutoSize = True
        Me.lblNumInvParts.Location = New System.Drawing.Point(9, 548)
        Me.lblNumInvParts.Name = "lblNumInvParts"
        Me.lblNumInvParts.Size = New System.Drawing.Size(98, 13)
        Me.lblNumInvParts.TabIndex = 8
        Me.lblNumInvParts.Text = "Num Inventor Parts"
        '
        'lblNumPromanParts
        '
        Me.lblNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumPromanParts.AutoSize = True
        Me.lblNumPromanParts.Location = New System.Drawing.Point(290, 548)
        Me.lblNumPromanParts.Name = "lblNumPromanParts"
        Me.lblNumPromanParts.Size = New System.Drawing.Size(95, 13)
        Me.lblNumPromanParts.TabIndex = 10
        Me.lblNumPromanParts.Text = "Num Proman Parts"
        '
        'txtNumPromanParts
        '
        Me.txtNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumPromanParts.Location = New System.Drawing.Point(293, 564)
        Me.txtNumPromanParts.Name = "txtNumPromanParts"
        Me.txtNumPromanParts.Size = New System.Drawing.Size(98, 20)
        Me.txtNumPromanParts.TabIndex = 9
        '
        'btnInventorColor
        '
        Me.btnInventorColor.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnInventorColor.Location = New System.Drawing.Point(161, 551)
        Me.btnInventorColor.Name = "btnInventorColor"
        Me.btnInventorColor.Size = New System.Drawing.Size(45, 33)
        Me.btnInventorColor.TabIndex = 11
        Me.btnInventorColor.Text = "Color"
        Me.btnInventorColor.UseVisualStyleBackColor = True
        '
        'btnPromanColor
        '
        Me.btnPromanColor.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnPromanColor.Location = New System.Drawing.Point(442, 551)
        Me.btnPromanColor.Name = "btnPromanColor"
        Me.btnPromanColor.Size = New System.Drawing.Size(45, 34)
        Me.btnPromanColor.TabIndex = 12
        Me.btnPromanColor.Text = "Color"
        Me.btnPromanColor.UseVisualStyleBackColor = True
        '
        'frmBomCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 606)
        Me.Controls.Add(Me.btnPromanColor)
        Me.Controls.Add(Me.btnInventorColor)
        Me.Controls.Add(Me.lblNumPromanParts)
        Me.Controls.Add(Me.txtNumPromanParts)
        Me.Controls.Add(Me.lblNumInvParts)
        Me.Controls.Add(Me.txtNumInventorParts)
        Me.Controls.Add(Me.btnRunCompare)
        Me.Controls.Add(Me.btnLoadInventorBom)
        Me.Controls.Add(Me.btnLoadPromanBom)
        Me.Controls.Add(Me.lblPromanBom)
        Me.Controls.Add(Me.lblInventorBom)
        Me.Controls.Add(Me.lvPromanBom)
        Me.Controls.Add(Me.lvInventorBom)
        Me.Name = "frmBomCompare"
        Me.Text = "frmBomCompare"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvInventorBom As Windows.Forms.ListView
    Friend WithEvents lvPromanBom As Windows.Forms.ListView
    Friend WithEvents lblInventorBom As Windows.Forms.Label
    Friend WithEvents lblPromanBom As Windows.Forms.Label
    Friend WithEvents btnLoadPromanBom As Windows.Forms.Button
    Friend WithEvents btnLoadInventorBom As Windows.Forms.Button
    Friend WithEvents btnRunCompare As Windows.Forms.Button
    Friend WithEvents txtNumInventorParts As Windows.Forms.TextBox
    Friend WithEvents lblNumInvParts As Windows.Forms.Label
    Friend WithEvents lblNumPromanParts As Windows.Forms.Label
    Friend WithEvents txtNumPromanParts As Windows.Forms.TextBox
    Friend WithEvents btnInventorColor As Windows.Forms.Button
    Friend WithEvents btnPromanColor As Windows.Forms.Button
End Class
