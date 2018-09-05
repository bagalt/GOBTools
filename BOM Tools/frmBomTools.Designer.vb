<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBomTools
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkBomImportIncludeBAssy = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkPartCreateIncludeBAssy = New System.Windows.Forms.CheckBox()
        Me.chkBomCompIncludeBAssy = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnExportBOM = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvInventorBom = New System.Windows.Forms.ListView()
        Me.txtNumInventorParts = New System.Windows.Forms.TextBox()
        Me.btnRunCompare = New System.Windows.Forms.Button()
        Me.btnLoadInventorBom = New System.Windows.Forms.Button()
        Me.lblNumInvParts = New System.Windows.Forms.Label()
        Me.btnLoadPromanBom = New System.Windows.Forms.Button()
        Me.lblNumPromanParts = New System.Windows.Forms.Label()
        Me.lblPromanBom = New System.Windows.Forms.Label()
        Me.lblInventorBom = New System.Windows.Forms.Label()
        Me.txtNumPromanParts = New System.Windows.Forms.TextBox()
        Me.lvPromanBom = New System.Windows.Forms.ListView()
        Me.PromanMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PromanLVMenuIsolateItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PromanLVMenuDeleteItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PromanMenuStrip.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkBomImportIncludeBAssy)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 60)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "BOM Import Options"
        '
        'chkBomImportIncludeBAssy
        '
        Me.chkBomImportIncludeBAssy.AutoSize = True
        Me.chkBomImportIncludeBAssy.Checked = True
        Me.chkBomImportIncludeBAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomImportIncludeBAssy.Location = New System.Drawing.Point(6, 28)
        Me.chkBomImportIncludeBAssy.Name = "chkBomImportIncludeBAssy"
        Me.chkBomImportIncludeBAssy.Size = New System.Drawing.Size(144, 17)
        Me.chkBomImportIncludeBAssy.TabIndex = 13
        Me.chkBomImportIncludeBAssy.Text = "Include B49 Assemblies?"
        Me.chkBomImportIncludeBAssy.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkPartCreateIncludeBAssy)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 60)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Part Create Options"
        '
        'chkPartCreateIncludeBAssy
        '
        Me.chkPartCreateIncludeBAssy.AutoSize = True
        Me.chkPartCreateIncludeBAssy.Checked = True
        Me.chkPartCreateIncludeBAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPartCreateIncludeBAssy.Location = New System.Drawing.Point(6, 28)
        Me.chkPartCreateIncludeBAssy.Name = "chkPartCreateIncludeBAssy"
        Me.chkPartCreateIncludeBAssy.Size = New System.Drawing.Size(144, 17)
        Me.chkPartCreateIncludeBAssy.TabIndex = 15
        Me.chkPartCreateIncludeBAssy.Text = "Include B49 Assemblies?"
        Me.chkPartCreateIncludeBAssy.UseVisualStyleBackColor = True
        '
        'chkBomCompIncludeBAssy
        '
        Me.chkBomCompIncludeBAssy.AutoSize = True
        Me.chkBomCompIncludeBAssy.Checked = True
        Me.chkBomCompIncludeBAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompIncludeBAssy.Location = New System.Drawing.Point(6, 28)
        Me.chkBomCompIncludeBAssy.Name = "chkBomCompIncludeBAssy"
        Me.chkBomCompIncludeBAssy.Size = New System.Drawing.Size(144, 17)
        Me.chkBomCompIncludeBAssy.TabIndex = 15
        Me.chkBomCompIncludeBAssy.Text = "Include B49 Assemblies?"
        Me.chkBomCompIncludeBAssy.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkBomCompIncludeBAssy)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 151)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 60)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "BOM Compare Options"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblVersion)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(447, 477)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(360, 443)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(39, 13)
        Me.lblVersion.TabIndex = 18
        Me.lblVersion.Text = "Label1"
        '
        'btnExportBOM
        '
        Me.btnExportBOM.Location = New System.Drawing.Point(186, 273)
        Me.btnExportBOM.Name = "btnExportBOM"
        Me.btnExportBOM.Size = New System.Drawing.Size(75, 60)
        Me.btnExportBOM.TabIndex = 13
        Me.btnExportBOM.Text = "Export Inventor BOM <--"
        Me.btnExportBOM.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnExportBOM)
        Me.TabPage1.Controls.Add(Me.lvInventorBom)
        Me.TabPage1.Controls.Add(Me.txtNumInventorParts)
        Me.TabPage1.Controls.Add(Me.btnRunCompare)
        Me.TabPage1.Controls.Add(Me.btnLoadInventorBom)
        Me.TabPage1.Controls.Add(Me.lblNumInvParts)
        Me.TabPage1.Controls.Add(Me.btnLoadPromanBom)
        Me.TabPage1.Controls.Add(Me.lblNumPromanParts)
        Me.TabPage1.Controls.Add(Me.lblPromanBom)
        Me.TabPage1.Controls.Add(Me.lblInventorBom)
        Me.TabPage1.Controls.Add(Me.txtNumPromanParts)
        Me.TabPage1.Controls.Add(Me.lvPromanBom)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(447, 477)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "BOM Compare"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvInventorBom
        '
        Me.lvInventorBom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvInventorBom.FullRowSelect = True
        Me.lvInventorBom.GridLines = True
        Me.lvInventorBom.Location = New System.Drawing.Point(8, 28)
        Me.lvInventorBom.MultiSelect = False
        Me.lvInventorBom.Name = "lvInventorBom"
        Me.lvInventorBom.Size = New System.Drawing.Size(172, 402)
        Me.lvInventorBom.TabIndex = 0
        Me.lvInventorBom.UseCompatibleStateImageBehavior = False
        Me.lvInventorBom.View = System.Windows.Forms.View.Details
        '
        'txtNumInventorParts
        '
        Me.txtNumInventorParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumInventorParts.Location = New System.Drawing.Point(9, 451)
        Me.txtNumInventorParts.Name = "txtNumInventorParts"
        Me.txtNumInventorParts.Size = New System.Drawing.Size(98, 20)
        Me.txtNumInventorParts.TabIndex = 7
        '
        'btnRunCompare
        '
        Me.btnRunCompare.Location = New System.Drawing.Point(186, 207)
        Me.btnRunCompare.Name = "btnRunCompare"
        Me.btnRunCompare.Size = New System.Drawing.Size(75, 60)
        Me.btnRunCompare.TabIndex = 6
        Me.btnRunCompare.Text = "Run Compare"
        Me.btnRunCompare.UseVisualStyleBackColor = True
        '
        'btnLoadInventorBom
        '
        Me.btnLoadInventorBom.Location = New System.Drawing.Point(186, 27)
        Me.btnLoadInventorBom.Name = "btnLoadInventorBom"
        Me.btnLoadInventorBom.Size = New System.Drawing.Size(75, 60)
        Me.btnLoadInventorBom.TabIndex = 5
        Me.btnLoadInventorBom.Text = "Load Inventor BOM <--"
        Me.btnLoadInventorBom.UseVisualStyleBackColor = True
        '
        'lblNumInvParts
        '
        Me.lblNumInvParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumInvParts.AutoSize = True
        Me.lblNumInvParts.Location = New System.Drawing.Point(6, 434)
        Me.lblNumInvParts.Name = "lblNumInvParts"
        Me.lblNumInvParts.Size = New System.Drawing.Size(98, 13)
        Me.lblNumInvParts.TabIndex = 8
        Me.lblNumInvParts.Text = "Num Inventor Parts"
        '
        'btnLoadPromanBom
        '
        Me.btnLoadPromanBom.Location = New System.Drawing.Point(186, 93)
        Me.btnLoadPromanBom.Name = "btnLoadPromanBom"
        Me.btnLoadPromanBom.Size = New System.Drawing.Size(75, 60)
        Me.btnLoadPromanBom.TabIndex = 4
        Me.btnLoadPromanBom.Text = "Load Proman BOM -->"
        Me.btnLoadPromanBom.UseVisualStyleBackColor = True
        '
        'lblNumPromanParts
        '
        Me.lblNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumPromanParts.AutoSize = True
        Me.lblNumPromanParts.Location = New System.Drawing.Point(264, 433)
        Me.lblNumPromanParts.Name = "lblNumPromanParts"
        Me.lblNumPromanParts.Size = New System.Drawing.Size(95, 13)
        Me.lblNumPromanParts.TabIndex = 10
        Me.lblNumPromanParts.Text = "Num Proman Parts"
        '
        'lblPromanBom
        '
        Me.lblPromanBom.AutoSize = True
        Me.lblPromanBom.Location = New System.Drawing.Point(264, 10)
        Me.lblPromanBom.Name = "lblPromanBom"
        Me.lblPromanBom.Size = New System.Drawing.Size(70, 13)
        Me.lblPromanBom.TabIndex = 3
        Me.lblPromanBom.Text = "Proman BOM"
        '
        'lblInventorBom
        '
        Me.lblInventorBom.AutoSize = True
        Me.lblInventorBom.Location = New System.Drawing.Point(3, 11)
        Me.lblInventorBom.Name = "lblInventorBom"
        Me.lblInventorBom.Size = New System.Drawing.Size(73, 13)
        Me.lblInventorBom.TabIndex = 2
        Me.lblInventorBom.Text = "Inventor BOM"
        '
        'txtNumPromanParts
        '
        Me.txtNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumPromanParts.Location = New System.Drawing.Point(267, 451)
        Me.txtNumPromanParts.Name = "txtNumPromanParts"
        Me.txtNumPromanParts.Size = New System.Drawing.Size(98, 20)
        Me.txtNumPromanParts.TabIndex = 9
        '
        'lvPromanBom
        '
        Me.lvPromanBom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvPromanBom.ContextMenuStrip = Me.PromanMenuStrip
        Me.lvPromanBom.FullRowSelect = True
        Me.lvPromanBom.GridLines = True
        Me.lvPromanBom.Location = New System.Drawing.Point(267, 27)
        Me.lvPromanBom.MultiSelect = False
        Me.lvPromanBom.Name = "lvPromanBom"
        Me.lvPromanBom.Size = New System.Drawing.Size(172, 402)
        Me.lvPromanBom.TabIndex = 1
        Me.lvPromanBom.UseCompatibleStateImageBehavior = False
        Me.lvPromanBom.View = System.Windows.Forms.View.Details
        '
        'PromanMenuStrip
        '
        Me.PromanMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PromanLVMenuIsolateItem, Me.PromanLVMenuDeleteItem})
        Me.PromanMenuStrip.Name = "PromanMenuStrip"
        Me.PromanMenuStrip.Size = New System.Drawing.Size(136, 48)
        '
        'PromanLVMenuIsolateItem
        '
        Me.PromanLVMenuIsolateItem.Name = "PromanLVMenuIsolateItem"
        Me.PromanLVMenuIsolateItem.Size = New System.Drawing.Size(135, 22)
        Me.PromanLVMenuIsolateItem.Text = "Isolate Item"
        '
        'PromanLVMenuDeleteItem
        '
        Me.PromanLVMenuDeleteItem.Name = "PromanLVMenuDeleteItem"
        Me.PromanLVMenuDeleteItem.Size = New System.Drawing.Size(135, 22)
        Me.PromanLVMenuDeleteItem.Text = "Delete Item"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(455, 503)
        Me.TabControl1.TabIndex = 15
        '
        'frmBomTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 521)
        Me.Controls.Add(Me.TabControl1)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(480, 900)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(480, 39)
        Me.Name = "frmBomTools"
        Me.Text = "BOM Tools"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PromanMenuStrip.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents chkBomImportIncludeBAssy As Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents chkPartCreateIncludeBAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompIncludeBAssy As Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents btnExportBOM As Windows.Forms.Button
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents lvInventorBom As Windows.Forms.ListView
    Friend WithEvents txtNumInventorParts As Windows.Forms.TextBox
    Friend WithEvents btnRunCompare As Windows.Forms.Button
    Friend WithEvents btnLoadInventorBom As Windows.Forms.Button
    Friend WithEvents lblNumInvParts As Windows.Forms.Label
    Friend WithEvents btnLoadPromanBom As Windows.Forms.Button
    Friend WithEvents lblNumPromanParts As Windows.Forms.Label
    Friend WithEvents lblPromanBom As Windows.Forms.Label
    Friend WithEvents lblInventorBom As Windows.Forms.Label
    Friend WithEvents txtNumPromanParts As Windows.Forms.TextBox
    Friend WithEvents lvPromanBom As Windows.Forms.ListView
    Friend WithEvents PromanMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents PromanLVMenuIsolateItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PromanLVMenuDeleteItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As Windows.Forms.SaveFileDialog
End Class
