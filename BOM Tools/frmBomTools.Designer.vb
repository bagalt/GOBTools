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
        Me.chkBomImportShowFasteners = New System.Windows.Forms.CheckBox()
        Me.chkBomImportAllowBAssyParent = New System.Windows.Forms.CheckBox()
        Me.chkBomCompIncludeBAssy = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkBomCompShowFasteners = New System.Windows.Forms.CheckBox()
        Me.chkBomCompIncludeCAssy = New System.Windows.Forms.CheckBox()
        Me.chkBOMCompIncB45Children = New System.Windows.Forms.CheckBox()
        Me.chkBOMCompIncB39Children = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnBCExportInventorBOM = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvBomCompInventor = New System.Windows.Forms.ListView()
        Me.InventorMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InventorMenuStripCOPY = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtNumInventorParts = New System.Windows.Forms.TextBox()
        Me.btnRunCompare = New System.Windows.Forms.Button()
        Me.lblNumInvParts = New System.Windows.Forms.Label()
        Me.btnLoadPromanBom = New System.Windows.Forms.Button()
        Me.lblNumPromanParts = New System.Windows.Forms.Label()
        Me.lblPromanBom = New System.Windows.Forms.Label()
        Me.lblInventorBom = New System.Windows.Forms.Label()
        Me.txtNumPromanParts = New System.Windows.Forms.TextBox()
        Me.lvPromanBom = New System.Windows.Forms.ListView()
        Me.PromanMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PromanLVMenuCopyItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoadInventorBOM = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtPCNumInventorParts = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvPartCreate = New System.Windows.Forms.ListView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtBomImportNumParts = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lvBomImport = New System.Windows.Forms.ListView()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnPartCreateExport = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkPartCreateIncludeBAssy = New System.Windows.Forms.CheckBox()
        Me.btnBomImportExport = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.InventorMenuStrip.SuspendLayout()
        Me.PromanMenuStrip.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkBomImportShowFasteners)
        Me.GroupBox2.Controls.Add(Me.chkBomImportAllowBAssyParent)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 281)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 100)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "BOM Import Options (Experimental)"
        '
        'chkBomImportShowFasteners
        '
        Me.chkBomImportShowFasteners.AutoSize = True
        Me.chkBomImportShowFasteners.Checked = True
        Me.chkBomImportShowFasteners.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomImportShowFasteners.Location = New System.Drawing.Point(6, 51)
        Me.chkBomImportShowFasteners.Name = "chkBomImportShowFasteners"
        Me.chkBomImportShowFasteners.Size = New System.Drawing.Size(165, 17)
        Me.chkBomImportShowFasteners.TabIndex = 20
        Me.chkBomImportShowFasteners.Text = "Show Fasteners (M900 Parts)"
        Me.chkBomImportShowFasteners.UseVisualStyleBackColor = True
        '
        'chkBomImportAllowBAssyParent
        '
        Me.chkBomImportAllowBAssyParent.AutoSize = True
        Me.chkBomImportAllowBAssyParent.Checked = True
        Me.chkBomImportAllowBAssyParent.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomImportAllowBAssyParent.Location = New System.Drawing.Point(6, 28)
        Me.chkBomImportAllowBAssyParent.Name = "chkBomImportAllowBAssyParent"
        Me.chkBomImportAllowBAssyParent.Size = New System.Drawing.Size(137, 17)
        Me.chkBomImportAllowBAssyParent.TabIndex = 13
        Me.chkBomImportAllowBAssyParent.Text = "Allow B49s as Parents?"
        Me.chkBomImportAllowBAssyParent.UseVisualStyleBackColor = True
        '
        'chkBomCompIncludeBAssy
        '
        Me.chkBomCompIncludeBAssy.AutoSize = True
        Me.chkBomCompIncludeBAssy.Checked = True
        Me.chkBomCompIncludeBAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompIncludeBAssy.Location = New System.Drawing.Point(6, 52)
        Me.chkBomCompIncludeBAssy.Name = "chkBomCompIncludeBAssy"
        Me.chkBomCompIncludeBAssy.Size = New System.Drawing.Size(238, 17)
        Me.chkBomCompIncludeBAssy.TabIndex = 15
        Me.chkBomCompIncludeBAssy.Text = "Show B49 Assemblies as Parts (no children)?"
        Me.chkBomCompIncludeBAssy.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkBomCompShowFasteners)
        Me.GroupBox3.Controls.Add(Me.chkBomCompIncludeCAssy)
        Me.GroupBox3.Controls.Add(Me.chkBOMCompIncB45Children)
        Me.GroupBox3.Controls.Add(Me.chkBOMCompIncB39Children)
        Me.GroupBox3.Controls.Add(Me.chkBomCompIncludeBAssy)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 15)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 151)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "BOM Compare Options"
        '
        'chkBomCompShowFasteners
        '
        Me.chkBomCompShowFasteners.AutoSize = True
        Me.chkBomCompShowFasteners.Checked = True
        Me.chkBomCompShowFasteners.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompShowFasteners.Location = New System.Drawing.Point(6, 29)
        Me.chkBomCompShowFasteners.Name = "chkBomCompShowFasteners"
        Me.chkBomCompShowFasteners.Size = New System.Drawing.Size(165, 17)
        Me.chkBomCompShowFasteners.TabIndex = 19
        Me.chkBomCompShowFasteners.Text = "Show Fasteners (M900 Parts)"
        Me.chkBomCompShowFasteners.UseVisualStyleBackColor = True
        '
        'chkBomCompIncludeCAssy
        '
        Me.chkBomCompIncludeCAssy.AutoSize = True
        Me.chkBomCompIncludeCAssy.Checked = True
        Me.chkBomCompIncludeCAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompIncludeCAssy.Location = New System.Drawing.Point(6, 74)
        Me.chkBomCompIncludeCAssy.Name = "chkBomCompIncludeCAssy"
        Me.chkBomCompIncludeCAssy.Size = New System.Drawing.Size(238, 17)
        Me.chkBomCompIncludeCAssy.TabIndex = 16
        Me.chkBomCompIncludeCAssy.Text = "Show C49 Assemblies as Parts (no children)?"
        Me.chkBomCompIncludeCAssy.UseVisualStyleBackColor = True
        '
        'chkBOMCompIncB45Children
        '
        Me.chkBOMCompIncB45Children.AutoSize = True
        Me.chkBOMCompIncB45Children.Location = New System.Drawing.Point(6, 120)
        Me.chkBOMCompIncB45Children.Name = "chkBOMCompIncB45Children"
        Me.chkBOMCompIncB45Children.Size = New System.Drawing.Size(130, 17)
        Me.chkBOMCompIncB45Children.TabIndex = 15
        Me.chkBOMCompIncB45Children.Text = "Include B45 Children?"
        Me.chkBOMCompIncB45Children.UseVisualStyleBackColor = True
        '
        'chkBOMCompIncB39Children
        '
        Me.chkBOMCompIncB39Children.AutoSize = True
        Me.chkBOMCompIncB39Children.Checked = True
        Me.chkBOMCompIncB39Children.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBOMCompIncB39Children.Location = New System.Drawing.Point(6, 97)
        Me.chkBOMCompIncB39Children.Name = "chkBOMCompIncB39Children"
        Me.chkBOMCompIncB39Children.Size = New System.Drawing.Size(130, 17)
        Me.chkBOMCompIncB39Children.TabIndex = 15
        Me.chkBOMCompIncB39Children.Text = "Include B39 Children?"
        Me.chkBOMCompIncB39Children.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.lblVersion)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(447, 460)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(399, 444)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(39, 13)
        Me.lblVersion.TabIndex = 18
        Me.lblVersion.Text = "Label1"
        '
        'btnBCExportInventorBOM
        '
        Me.btnBCExportInventorBOM.Location = New System.Drawing.Point(186, 353)
        Me.btnBCExportInventorBOM.Name = "btnBCExportInventorBOM"
        Me.btnBCExportInventorBOM.Size = New System.Drawing.Size(75, 60)
        Me.btnBCExportInventorBOM.TabIndex = 13
        Me.btnBCExportInventorBOM.Text = "Export Inventor BOM <--"
        Me.btnBCExportInventorBOM.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnBCExportInventorBOM)
        Me.TabPage1.Controls.Add(Me.lvBomCompInventor)
        Me.TabPage1.Controls.Add(Me.txtNumInventorParts)
        Me.TabPage1.Controls.Add(Me.btnRunCompare)
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
        Me.TabPage1.Size = New System.Drawing.Size(447, 460)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "BOM Compare"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvBomCompInventor
        '
        Me.lvBomCompInventor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvBomCompInventor.ContextMenuStrip = Me.InventorMenuStrip
        Me.lvBomCompInventor.FullRowSelect = True
        Me.lvBomCompInventor.GridLines = True
        Me.lvBomCompInventor.Location = New System.Drawing.Point(8, 28)
        Me.lvBomCompInventor.MultiSelect = False
        Me.lvBomCompInventor.Name = "lvBomCompInventor"
        Me.lvBomCompInventor.Size = New System.Drawing.Size(170, 385)
        Me.lvBomCompInventor.TabIndex = 0
        Me.lvBomCompInventor.UseCompatibleStateImageBehavior = False
        Me.lvBomCompInventor.View = System.Windows.Forms.View.Details
        '
        'InventorMenuStrip
        '
        Me.InventorMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventorMenuStripCOPY})
        Me.InventorMenuStrip.Name = "InventorMenuStrip"
        Me.InventorMenuStrip.Size = New System.Drawing.Size(103, 26)
        '
        'InventorMenuStripCOPY
        '
        Me.InventorMenuStripCOPY.Name = "InventorMenuStripCOPY"
        Me.InventorMenuStripCOPY.Size = New System.Drawing.Size(102, 22)
        Me.InventorMenuStripCOPY.Text = "Copy"
        '
        'txtNumInventorParts
        '
        Me.txtNumInventorParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumInventorParts.Location = New System.Drawing.Point(9, 433)
        Me.txtNumInventorParts.Name = "txtNumInventorParts"
        Me.txtNumInventorParts.Size = New System.Drawing.Size(98, 20)
        Me.txtNumInventorParts.TabIndex = 7
        '
        'btnRunCompare
        '
        Me.btnRunCompare.Location = New System.Drawing.Point(186, 174)
        Me.btnRunCompare.Name = "btnRunCompare"
        Me.btnRunCompare.Size = New System.Drawing.Size(75, 60)
        Me.btnRunCompare.TabIndex = 6
        Me.btnRunCompare.Text = "Run Compare"
        Me.btnRunCompare.UseVisualStyleBackColor = True
        '
        'lblNumInvParts
        '
        Me.lblNumInvParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumInvParts.AutoSize = True
        Me.lblNumInvParts.Location = New System.Drawing.Point(6, 416)
        Me.lblNumInvParts.Name = "lblNumInvParts"
        Me.lblNumInvParts.Size = New System.Drawing.Size(98, 13)
        Me.lblNumInvParts.TabIndex = 8
        Me.lblNumInvParts.Text = "Num Inventor Parts"
        '
        'btnLoadPromanBom
        '
        Me.btnLoadPromanBom.Location = New System.Drawing.Point(186, 27)
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
        Me.lblNumPromanParts.Location = New System.Drawing.Point(264, 416)
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
        Me.lblInventorBom.Location = New System.Drawing.Point(6, 10)
        Me.lblInventorBom.Name = "lblInventorBom"
        Me.lblInventorBom.Size = New System.Drawing.Size(73, 13)
        Me.lblInventorBom.TabIndex = 2
        Me.lblInventorBom.Text = "Inventor BOM"
        '
        'txtNumPromanParts
        '
        Me.txtNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumPromanParts.Location = New System.Drawing.Point(267, 434)
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
        Me.lvPromanBom.Size = New System.Drawing.Size(170, 386)
        Me.lvPromanBom.TabIndex = 1
        Me.lvPromanBom.UseCompatibleStateImageBehavior = False
        Me.lvPromanBom.View = System.Windows.Forms.View.Details
        '
        'PromanMenuStrip
        '
        Me.PromanMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PromanLVMenuCopyItem})
        Me.PromanMenuStrip.Name = "PromanMenuStrip"
        Me.PromanMenuStrip.Size = New System.Drawing.Size(103, 26)
        '
        'PromanLVMenuCopyItem
        '
        Me.PromanLVMenuCopyItem.Name = "PromanLVMenuCopyItem"
        Me.PromanLVMenuCopyItem.Size = New System.Drawing.Size(102, 22)
        Me.PromanLVMenuCopyItem.Text = "Copy"
        '
        'btnLoadInventorBOM
        '
        Me.btnLoadInventorBOM.Location = New System.Drawing.Point(7, 3)
        Me.btnLoadInventorBOM.Name = "btnLoadInventorBOM"
        Me.btnLoadInventorBOM.Size = New System.Drawing.Size(451, 39)
        Me.btnLoadInventorBOM.TabIndex = 5
        Me.btnLoadInventorBOM.Text = "Load Inventor BOM"
        Me.btnLoadInventorBOM.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 45)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(455, 486)
        Me.TabControl1.TabIndex = 15
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnPartCreateExport)
        Me.TabPage3.Controls.Add(Me.txtPCNumInventorParts)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.lvPartCreate)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(447, 460)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Part Create"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtPCNumInventorParts
        '
        Me.txtPCNumInventorParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtPCNumInventorParts.Location = New System.Drawing.Point(9, 434)
        Me.txtPCNumInventorParts.Name = "txtPCNumInventorParts"
        Me.txtPCNumInventorParts.Size = New System.Drawing.Size(98, 20)
        Me.txtPCNumInventorParts.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 417)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Num Inventor Parts"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Inventor BOM"
        '
        'lvPartCreate
        '
        Me.lvPartCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvPartCreate.ContextMenuStrip = Me.InventorMenuStrip
        Me.lvPartCreate.FullRowSelect = True
        Me.lvPartCreate.GridLines = True
        Me.lvPartCreate.Location = New System.Drawing.Point(8, 28)
        Me.lvPartCreate.MultiSelect = False
        Me.lvPartCreate.Name = "lvPartCreate"
        Me.lvPartCreate.Size = New System.Drawing.Size(355, 385)
        Me.lvPartCreate.TabIndex = 6
        Me.lvPartCreate.UseCompatibleStateImageBehavior = False
        Me.lvPartCreate.View = System.Windows.Forms.View.Details
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnBomImportExport)
        Me.TabPage4.Controls.Add(Me.txtBomImportNumParts)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.lvBomImport)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(447, 460)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "BOM Import"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtBomImportNumParts
        '
        Me.txtBomImportNumParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtBomImportNumParts.Location = New System.Drawing.Point(12, 429)
        Me.txtBomImportNumParts.Name = "txtBomImportNumParts"
        Me.txtBomImportNumParts.Size = New System.Drawing.Size(98, 20)
        Me.txtBomImportNumParts.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 412)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Num Inventor Parts"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Inventor BOM"
        '
        'lvBomImport
        '
        Me.lvBomImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvBomImport.ContextMenuStrip = Me.InventorMenuStrip
        Me.lvBomImport.FullRowSelect = True
        Me.lvBomImport.GridLines = True
        Me.lvBomImport.Location = New System.Drawing.Point(8, 28)
        Me.lvBomImport.MultiSelect = False
        Me.lvBomImport.Name = "lvBomImport"
        Me.lvBomImport.Size = New System.Drawing.Size(290, 380)
        Me.lvBomImport.TabIndex = 17
        Me.lvBomImport.UseCompatibleStateImageBehavior = False
        Me.lvBomImport.View = System.Windows.Forms.View.Details
        '
        'btnPartCreateExport
        '
        Me.btnPartCreateExport.Location = New System.Drawing.Point(219, 416)
        Me.btnPartCreateExport.Name = "btnPartCreateExport"
        Me.btnPartCreateExport.Size = New System.Drawing.Size(144, 41)
        Me.btnPartCreateExport.TabIndex = 18
        Me.btnPartCreateExport.Text = "Export Part Create BOM"
        Me.btnPartCreateExport.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkPartCreateIncludeBAssy)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 196)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 52)
        Me.GroupBox1.TabIndex = 19
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
        'btnBomImportExport
        '
        Me.btnBomImportExport.Location = New System.Drawing.Point(154, 416)
        Me.btnBomImportExport.Name = "btnBomImportExport"
        Me.btnBomImportExport.Size = New System.Drawing.Size(144, 41)
        Me.btnBomImportExport.TabIndex = 21
        Me.btnBomImportExport.Text = "Export BOM Import"
        Me.btnBomImportExport.UseVisualStyleBackColor = True
        '
        'frmBomTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 536)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnLoadInventorBOM)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(480, 900)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(480, 39)
        Me.Name = "frmBomTools"
        Me.Text = "BOM Tools"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.InventorMenuStrip.ResumeLayout(False)
        Me.PromanMenuStrip.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents chkBomImportAllowBAssyParent As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompIncludeBAssy As Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents btnBCExportInventorBOM As Windows.Forms.Button
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents lvBomCompInventor As Windows.Forms.ListView
    Friend WithEvents txtNumInventorParts As Windows.Forms.TextBox
    Friend WithEvents btnRunCompare As Windows.Forms.Button
    Friend WithEvents btnLoadInventorBOM As Windows.Forms.Button
    Friend WithEvents lblNumInvParts As Windows.Forms.Label
    Friend WithEvents btnLoadPromanBom As Windows.Forms.Button
    Friend WithEvents lblNumPromanParts As Windows.Forms.Label
    Friend WithEvents lblPromanBom As Windows.Forms.Label
    Friend WithEvents lblInventorBom As Windows.Forms.Label
    Friend WithEvents txtNumPromanParts As Windows.Forms.TextBox
    Friend WithEvents lvPromanBom As Windows.Forms.ListView
    Friend WithEvents PromanMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As Windows.Forms.SaveFileDialog
    Friend WithEvents chkBOMCompIncB39Children As Windows.Forms.CheckBox
    Friend WithEvents chkBOMCompIncB45Children As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompIncludeCAssy As Windows.Forms.CheckBox
    Friend WithEvents PromanLVMenuCopyItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventorMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents InventorMenuStripCOPY As Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkBomCompShowFasteners As Windows.Forms.CheckBox
    Friend WithEvents chkBomImportShowFasteners As Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lvPartCreate As Windows.Forms.ListView
    Friend WithEvents txtPCNumInventorParts As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents TabPage4 As Windows.Forms.TabPage
    Friend WithEvents txtBomImportNumParts As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents lvBomImport As Windows.Forms.ListView
    Friend WithEvents btnPartCreateExport As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents chkPartCreateIncludeBAssy As Windows.Forms.CheckBox
    Friend WithEvents btnBomImportExport As Windows.Forms.Button
End Class
