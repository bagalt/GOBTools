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
        Me.btnBCExportInventorBOM = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkBomCompViewImmediatly = New System.Windows.Forms.CheckBox()
        Me.chkBomCompShowTLAssy = New System.Windows.Forms.CheckBox()
        Me.chkBOMCompIncB45Children = New System.Windows.Forms.CheckBox()
        Me.chkBOMCompIncB39Children = New System.Windows.Forms.CheckBox()
        Me.chkBomCompIncludeCAssy = New System.Windows.Forms.CheckBox()
        Me.chkBomCompIncludeBAssy = New System.Windows.Forms.CheckBox()
        Me.chkBomCompShowFasteners = New System.Windows.Forms.CheckBox()
        Me.lvBomCompInventor = New System.Windows.Forms.ListView()
        Me.InventorMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InventorMenuStripCOPY = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventorMenuStripFIND = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.PromanMenuStripCOPY = New System.Windows.Forms.ToolStripMenuItem()
        Me.PromanMenuStripFIND = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoadInventorBOM = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chkPartExportViewImmediately = New System.Windows.Forms.CheckBox()
        Me.chkPartExportShowFasteners = New System.Windows.Forms.CheckBox()
        Me.chkPartExportShowTLAssy = New System.Windows.Forms.CheckBox()
        Me.chkPartExportShowB49 = New System.Windows.Forms.CheckBox()
        Me.btnExportPartList = New System.Windows.Forms.Button()
        Me.txtPCNumInventorParts = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvPartCreate = New System.Windows.Forms.ListView()
        Me.PartMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PartMenuStripCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartMenuStripFIND = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.chkBomExportViewImmediately = New System.Windows.Forms.CheckBox()
        Me.chkBOMExportShowTLAssy = New System.Windows.Forms.CheckBox()
        Me.chkBomExportShowFasteners = New System.Windows.Forms.CheckBox()
        Me.chkBomExportAllowB49Parents = New System.Windows.Forms.CheckBox()
        Me.btnBOMExport = New System.Windows.Forms.Button()
        Me.txtBomImportNumParts = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lvFullBOM = New System.Windows.Forms.ListView()
        Me.BomMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BomMenuStripCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.BomMenuStripFIND = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.TabPage1.SuspendLayout()
        Me.InventorMenuStrip.SuspendLayout()
        Me.PromanMenuStrip.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.PartMenuStrip.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.BomMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBCExportInventorBOM
        '
        Me.btnBCExportInventorBOM.Location = New System.Drawing.Point(184, 371)
        Me.btnBCExportInventorBOM.Name = "btnBCExportInventorBOM"
        Me.btnBCExportInventorBOM.Size = New System.Drawing.Size(120, 45)
        Me.btnBCExportInventorBOM.TabIndex = 13
        Me.btnBCExportInventorBOM.Text = "Export Inventor BOM <--"
        Me.btnBCExportInventorBOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBCExportInventorBOM.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkBomCompViewImmediatly)
        Me.TabPage1.Controls.Add(Me.chkBomCompShowTLAssy)
        Me.TabPage1.Controls.Add(Me.chkBOMCompIncB45Children)
        Me.TabPage1.Controls.Add(Me.chkBOMCompIncB39Children)
        Me.TabPage1.Controls.Add(Me.chkBomCompIncludeCAssy)
        Me.TabPage1.Controls.Add(Me.chkBomCompIncludeBAssy)
        Me.TabPage1.Controls.Add(Me.chkBomCompShowFasteners)
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
        Me.TabPage1.Size = New System.Drawing.Size(488, 461)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "BOM Compare"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkBomCompViewImmediatly
        '
        Me.chkBomCompViewImmediatly.AutoSize = True
        Me.chkBomCompViewImmediatly.Checked = True
        Me.chkBomCompViewImmediatly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompViewImmediatly.Location = New System.Drawing.Point(184, 422)
        Me.chkBomCompViewImmediatly.Name = "chkBomCompViewImmediatly"
        Me.chkBomCompViewImmediatly.Size = New System.Drawing.Size(107, 17)
        Me.chkBomCompViewImmediatly.TabIndex = 27
        Me.chkBomCompViewImmediatly.Text = "View Immediately"
        Me.chkBomCompViewImmediatly.UseVisualStyleBackColor = True
        '
        'chkBomCompShowTLAssy
        '
        Me.chkBomCompShowTLAssy.AutoSize = True
        Me.chkBomCompShowTLAssy.Location = New System.Drawing.Point(182, 88)
        Me.chkBomCompShowTLAssy.Name = "chkBomCompShowTLAssy"
        Me.chkBomCompShowTLAssy.Size = New System.Drawing.Size(78, 30)
        Me.chkBomCompShowTLAssy.TabIndex = 26
        Me.chkBomCompShowTLAssy.Text = "Show Top " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Level Assy"
        Me.chkBomCompShowTLAssy.UseVisualStyleBackColor = True
        '
        'chkBOMCompIncB45Children
        '
        Me.chkBOMCompIncB45Children.AutoSize = True
        Me.chkBOMCompIncB45Children.Location = New System.Drawing.Point(183, 255)
        Me.chkBOMCompIncB45Children.Name = "chkBOMCompIncB45Children"
        Me.chkBOMCompIncB45Children.Size = New System.Drawing.Size(116, 17)
        Me.chkBOMCompIncB45Children.TabIndex = 24
        Me.chkBOMCompIncB45Children.Text = "Show B45 Children"
        Me.chkBOMCompIncB45Children.UseVisualStyleBackColor = True
        '
        'chkBOMCompIncB39Children
        '
        Me.chkBOMCompIncB39Children.AutoSize = True
        Me.chkBOMCompIncB39Children.Checked = True
        Me.chkBOMCompIncB39Children.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBOMCompIncB39Children.Location = New System.Drawing.Point(183, 232)
        Me.chkBOMCompIncB39Children.Name = "chkBOMCompIncB39Children"
        Me.chkBOMCompIncB39Children.Size = New System.Drawing.Size(116, 17)
        Me.chkBOMCompIncB39Children.TabIndex = 23
        Me.chkBOMCompIncB39Children.Text = "Show B39 Children"
        Me.chkBOMCompIncB39Children.UseVisualStyleBackColor = True
        '
        'chkBomCompIncludeCAssy
        '
        Me.chkBomCompIncludeCAssy.AutoSize = True
        Me.chkBomCompIncludeCAssy.Checked = True
        Me.chkBomCompIncludeCAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompIncludeCAssy.Location = New System.Drawing.Point(183, 196)
        Me.chkBomCompIncludeCAssy.Name = "chkBomCompIncludeCAssy"
        Me.chkBomCompIncludeCAssy.Size = New System.Drawing.Size(84, 30)
        Me.chkBomCompIncludeCAssy.TabIndex = 22
        Me.chkBomCompIncludeCAssy.Text = "Show C49s " & Global.Microsoft.VisualBasic.ChrW(10) & "(no children)"
        Me.chkBomCompIncludeCAssy.UseVisualStyleBackColor = True
        '
        'chkBomCompIncludeBAssy
        '
        Me.chkBomCompIncludeBAssy.AutoSize = True
        Me.chkBomCompIncludeBAssy.Checked = True
        Me.chkBomCompIncludeBAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompIncludeBAssy.Location = New System.Drawing.Point(183, 160)
        Me.chkBomCompIncludeBAssy.Name = "chkBomCompIncludeBAssy"
        Me.chkBomCompIncludeBAssy.Size = New System.Drawing.Size(84, 30)
        Me.chkBomCompIncludeBAssy.TabIndex = 21
        Me.chkBomCompIncludeBAssy.Text = "Show B49s " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(no children)"
        Me.chkBomCompIncludeBAssy.UseVisualStyleBackColor = True
        '
        'chkBomCompShowFasteners
        '
        Me.chkBomCompShowFasteners.AutoSize = True
        Me.chkBomCompShowFasteners.Checked = True
        Me.chkBomCompShowFasteners.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompShowFasteners.Location = New System.Drawing.Point(183, 124)
        Me.chkBomCompShowFasteners.Name = "chkBomCompShowFasteners"
        Me.chkBomCompShowFasteners.Size = New System.Drawing.Size(102, 30)
        Me.chkBomCompShowFasteners.TabIndex = 20
        Me.chkBomCompShowFasteners.Text = "Show Fasteners" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(M900)"
        Me.chkBomCompShowFasteners.UseVisualStyleBackColor = True
        '
        'lvBomCompInventor
        '
        Me.lvBomCompInventor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvBomCompInventor.ContextMenuStrip = Me.InventorMenuStrip
        Me.lvBomCompInventor.FullRowSelect = True
        Me.lvBomCompInventor.GridLines = True
        Me.lvBomCompInventor.Location = New System.Drawing.Point(6, 28)
        Me.lvBomCompInventor.MultiSelect = False
        Me.lvBomCompInventor.Name = "lvBomCompInventor"
        Me.lvBomCompInventor.Size = New System.Drawing.Size(170, 386)
        Me.lvBomCompInventor.TabIndex = 0
        Me.lvBomCompInventor.UseCompatibleStateImageBehavior = False
        Me.lvBomCompInventor.View = System.Windows.Forms.View.Details
        '
        'InventorMenuStrip
        '
        Me.InventorMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventorMenuStripCOPY, Me.InventorMenuStripFIND})
        Me.InventorMenuStrip.Name = "InventorMenuStrip"
        Me.InventorMenuStrip.Size = New System.Drawing.Size(122, 48)
        '
        'InventorMenuStripCOPY
        '
        Me.InventorMenuStripCOPY.Name = "InventorMenuStripCOPY"
        Me.InventorMenuStripCOPY.Size = New System.Drawing.Size(121, 22)
        Me.InventorMenuStripCOPY.Text = "Copy"
        '
        'InventorMenuStripFIND
        '
        Me.InventorMenuStripFIND.Name = "InventorMenuStripFIND"
        Me.InventorMenuStripFIND.Size = New System.Drawing.Size(121, 22)
        Me.InventorMenuStripFIND.Text = "Find Part"
        '
        'txtNumInventorParts
        '
        Me.txtNumInventorParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumInventorParts.Location = New System.Drawing.Point(9, 434)
        Me.txtNumInventorParts.Name = "txtNumInventorParts"
        Me.txtNumInventorParts.Size = New System.Drawing.Size(98, 20)
        Me.txtNumInventorParts.TabIndex = 7
        '
        'btnRunCompare
        '
        Me.btnRunCompare.Location = New System.Drawing.Point(183, 291)
        Me.btnRunCompare.Name = "btnRunCompare"
        Me.btnRunCompare.Size = New System.Drawing.Size(120, 50)
        Me.btnRunCompare.TabIndex = 6
        Me.btnRunCompare.Text = "Run Compare"
        Me.btnRunCompare.UseVisualStyleBackColor = True
        '
        'lblNumInvParts
        '
        Me.lblNumInvParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumInvParts.AutoSize = True
        Me.lblNumInvParts.Location = New System.Drawing.Point(6, 417)
        Me.lblNumInvParts.Name = "lblNumInvParts"
        Me.lblNumInvParts.Size = New System.Drawing.Size(98, 13)
        Me.lblNumInvParts.TabIndex = 8
        Me.lblNumInvParts.Text = "Num Inventor Parts"
        '
        'btnLoadPromanBom
        '
        Me.btnLoadPromanBom.Location = New System.Drawing.Point(184, 27)
        Me.btnLoadPromanBom.Name = "btnLoadPromanBom"
        Me.btnLoadPromanBom.Size = New System.Drawing.Size(120, 45)
        Me.btnLoadPromanBom.TabIndex = 4
        Me.btnLoadPromanBom.Text = "Load Proman BOM -->"
        Me.btnLoadPromanBom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLoadPromanBom.UseVisualStyleBackColor = True
        '
        'lblNumPromanParts
        '
        Me.lblNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumPromanParts.AutoSize = True
        Me.lblNumPromanParts.Location = New System.Drawing.Point(309, 417)
        Me.lblNumPromanParts.Name = "lblNumPromanParts"
        Me.lblNumPromanParts.Size = New System.Drawing.Size(95, 13)
        Me.lblNumPromanParts.TabIndex = 10
        Me.lblNumPromanParts.Text = "Num Proman Parts"
        '
        'lblPromanBom
        '
        Me.lblPromanBom.AutoSize = True
        Me.lblPromanBom.Location = New System.Drawing.Point(309, 10)
        Me.lblPromanBom.Name = "lblPromanBom"
        Me.lblPromanBom.Size = New System.Drawing.Size(70, 13)
        Me.lblPromanBom.TabIndex = 3
        Me.lblPromanBom.Text = "Proman BOM"
        '
        'lblInventorBom
        '
        Me.lblInventorBom.AutoSize = True
        Me.lblInventorBom.Location = New System.Drawing.Point(4, 10)
        Me.lblInventorBom.Name = "lblInventorBom"
        Me.lblInventorBom.Size = New System.Drawing.Size(73, 13)
        Me.lblInventorBom.TabIndex = 2
        Me.lblInventorBom.Text = "Inventor BOM"
        '
        'txtNumPromanParts
        '
        Me.txtNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumPromanParts.Location = New System.Drawing.Point(312, 435)
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
        Me.lvPromanBom.Location = New System.Drawing.Point(312, 27)
        Me.lvPromanBom.MultiSelect = False
        Me.lvPromanBom.Name = "lvPromanBom"
        Me.lvPromanBom.Size = New System.Drawing.Size(170, 387)
        Me.lvPromanBom.TabIndex = 1
        Me.lvPromanBom.UseCompatibleStateImageBehavior = False
        Me.lvPromanBom.View = System.Windows.Forms.View.Details
        '
        'PromanMenuStrip
        '
        Me.PromanMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PromanMenuStripCOPY, Me.PromanMenuStripFIND})
        Me.PromanMenuStrip.Name = "PromanMenuStrip"
        Me.PromanMenuStrip.Size = New System.Drawing.Size(125, 48)
        '
        'PromanMenuStripCOPY
        '
        Me.PromanMenuStripCOPY.Name = "PromanMenuStripCOPY"
        Me.PromanMenuStripCOPY.Size = New System.Drawing.Size(124, 22)
        Me.PromanMenuStripCOPY.Text = "Copy"
        '
        'PromanMenuStripFIND
        '
        Me.PromanMenuStripFIND.Name = "PromanMenuStripFIND"
        Me.PromanMenuStripFIND.Size = New System.Drawing.Size(124, 22)
        Me.PromanMenuStripFIND.Text = "Find Item"
        '
        'btnLoadInventorBOM
        '
        Me.btnLoadInventorBOM.Location = New System.Drawing.Point(3, 3)
        Me.btnLoadInventorBOM.Name = "btnLoadInventorBOM"
        Me.btnLoadInventorBOM.Size = New System.Drawing.Size(492, 39)
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
        Me.TabControl1.Location = New System.Drawing.Point(4, 45)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(496, 487)
        Me.TabControl1.TabIndex = 15
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.chkPartExportViewImmediately)
        Me.TabPage3.Controls.Add(Me.chkPartExportShowFasteners)
        Me.TabPage3.Controls.Add(Me.chkPartExportShowTLAssy)
        Me.TabPage3.Controls.Add(Me.chkPartExportShowB49)
        Me.TabPage3.Controls.Add(Me.btnExportPartList)
        Me.TabPage3.Controls.Add(Me.txtPCNumInventorParts)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.lvPartCreate)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(488, 461)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Part Export"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'chkPartExportViewImmediately
        '
        Me.chkPartExportViewImmediately.AutoSize = True
        Me.chkPartExportViewImmediately.Checked = True
        Me.chkPartExportViewImmediately.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPartExportViewImmediately.Location = New System.Drawing.Point(400, 378)
        Me.chkPartExportViewImmediately.Name = "chkPartExportViewImmediately"
        Me.chkPartExportViewImmediately.Size = New System.Drawing.Size(81, 30)
        Me.chkPartExportViewImmediately.TabIndex = 28
        Me.chkPartExportViewImmediately.Text = "View" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Immediately"
        Me.chkPartExportViewImmediately.UseVisualStyleBackColor = True
        '
        'chkPartExportShowFasteners
        '
        Me.chkPartExportShowFasteners.AutoSize = True
        Me.chkPartExportShowFasteners.Checked = True
        Me.chkPartExportShowFasteners.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPartExportShowFasteners.Location = New System.Drawing.Point(379, 87)
        Me.chkPartExportShowFasteners.Name = "chkPartExportShowFasteners"
        Me.chkPartExportShowFasteners.Size = New System.Drawing.Size(102, 30)
        Me.chkPartExportShowFasteners.TabIndex = 26
        Me.chkPartExportShowFasteners.Text = "Show Fasteners" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(M900)"
        Me.chkPartExportShowFasteners.UseVisualStyleBackColor = True
        '
        'chkPartExportShowTLAssy
        '
        Me.chkPartExportShowTLAssy.AutoSize = True
        Me.chkPartExportShowTLAssy.Location = New System.Drawing.Point(379, 28)
        Me.chkPartExportShowTLAssy.Name = "chkPartExportShowTLAssy"
        Me.chkPartExportShowTLAssy.Size = New System.Drawing.Size(78, 30)
        Me.chkPartExportShowTLAssy.TabIndex = 25
        Me.chkPartExportShowTLAssy.Text = "Show Top " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Level Assy"
        Me.chkPartExportShowTLAssy.UseVisualStyleBackColor = True
        '
        'chkPartExportShowB49
        '
        Me.chkPartExportShowB49.AutoSize = True
        Me.chkPartExportShowB49.Checked = True
        Me.chkPartExportShowB49.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPartExportShowB49.Location = New System.Drawing.Point(379, 64)
        Me.chkPartExportShowB49.Name = "chkPartExportShowB49"
        Me.chkPartExportShowB49.Size = New System.Drawing.Size(80, 17)
        Me.chkPartExportShowB49.TabIndex = 19
        Me.chkPartExportShowB49.Text = "Show B49s"
        Me.chkPartExportShowB49.UseVisualStyleBackColor = True
        '
        'btnExportPartList
        '
        Me.btnExportPartList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportPartList.Location = New System.Drawing.Point(337, 413)
        Me.btnExportPartList.Name = "btnExportPartList"
        Me.btnExportPartList.Size = New System.Drawing.Size(144, 41)
        Me.btnExportPartList.TabIndex = 18
        Me.btnExportPartList.Text = "Export Part List"
        Me.btnExportPartList.UseVisualStyleBackColor = True
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
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Inventor BOM"
        '
        'lvPartCreate
        '
        Me.lvPartCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvPartCreate.ContextMenuStrip = Me.PartMenuStrip
        Me.lvPartCreate.FullRowSelect = True
        Me.lvPartCreate.GridLines = True
        Me.lvPartCreate.Location = New System.Drawing.Point(6, 28)
        Me.lvPartCreate.MultiSelect = False
        Me.lvPartCreate.Name = "lvPartCreate"
        Me.lvPartCreate.Size = New System.Drawing.Size(367, 380)
        Me.lvPartCreate.TabIndex = 6
        Me.lvPartCreate.UseCompatibleStateImageBehavior = False
        Me.lvPartCreate.View = System.Windows.Forms.View.Details
        '
        'PartMenuStrip
        '
        Me.PartMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartMenuStripCopy, Me.PartMenuStripFIND})
        Me.PartMenuStrip.Name = "PartMenuStrip"
        Me.PartMenuStrip.Size = New System.Drawing.Size(125, 48)
        '
        'PartMenuStripCopy
        '
        Me.PartMenuStripCopy.Name = "PartMenuStripCopy"
        Me.PartMenuStripCopy.Size = New System.Drawing.Size(124, 22)
        Me.PartMenuStripCopy.Text = "Copy"
        '
        'PartMenuStripFIND
        '
        Me.PartMenuStripFIND.Name = "PartMenuStripFIND"
        Me.PartMenuStripFIND.Size = New System.Drawing.Size(124, 22)
        Me.PartMenuStripFIND.Text = "Find Item"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.chkBomExportViewImmediately)
        Me.TabPage4.Controls.Add(Me.chkBOMExportShowTLAssy)
        Me.TabPage4.Controls.Add(Me.chkBomExportShowFasteners)
        Me.TabPage4.Controls.Add(Me.chkBomExportAllowB49Parents)
        Me.TabPage4.Controls.Add(Me.btnBOMExport)
        Me.TabPage4.Controls.Add(Me.txtBomImportNumParts)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.lvFullBOM)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(488, 461)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "BOM Export"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'chkBomExportViewImmediately
        '
        Me.chkBomExportViewImmediately.AutoSize = True
        Me.chkBomExportViewImmediately.Checked = True
        Me.chkBomExportViewImmediately.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomExportViewImmediately.Location = New System.Drawing.Point(374, 392)
        Me.chkBomExportViewImmediately.Name = "chkBomExportViewImmediately"
        Me.chkBomExportViewImmediately.Size = New System.Drawing.Size(107, 17)
        Me.chkBomExportViewImmediately.TabIndex = 28
        Me.chkBomExportViewImmediately.Text = "View Immediately"
        Me.chkBomExportViewImmediately.UseVisualStyleBackColor = True
        '
        'chkBOMExportShowTLAssy
        '
        Me.chkBOMExportShowTLAssy.AutoSize = True
        Me.chkBOMExportShowTLAssy.Location = New System.Drawing.Point(332, 28)
        Me.chkBOMExportShowTLAssy.Name = "chkBOMExportShowTLAssy"
        Me.chkBOMExportShowTLAssy.Size = New System.Drawing.Size(129, 17)
        Me.chkBOMExportShowTLAssy.TabIndex = 24
        Me.chkBOMExportShowTLAssy.Text = "Show Top Level Assy"
        Me.chkBOMExportShowTLAssy.UseVisualStyleBackColor = True
        '
        'chkBomExportShowFasteners
        '
        Me.chkBomExportShowFasteners.AutoSize = True
        Me.chkBomExportShowFasteners.Checked = True
        Me.chkBomExportShowFasteners.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomExportShowFasteners.Location = New System.Drawing.Point(332, 73)
        Me.chkBomExportShowFasteners.Name = "chkBomExportShowFasteners"
        Me.chkBomExportShowFasteners.Size = New System.Drawing.Size(138, 17)
        Me.chkBomExportShowFasteners.TabIndex = 23
        Me.chkBomExportShowFasteners.Text = "Show Fasteners (M900)"
        Me.chkBomExportShowFasteners.UseVisualStyleBackColor = True
        '
        'chkBomExportAllowB49Parents
        '
        Me.chkBomExportAllowB49Parents.AutoSize = True
        Me.chkBomExportAllowB49Parents.Checked = True
        Me.chkBomExportAllowB49Parents.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomExportAllowB49Parents.Location = New System.Drawing.Point(332, 50)
        Me.chkBomExportAllowB49Parents.Name = "chkBomExportAllowB49Parents"
        Me.chkBomExportAllowB49Parents.Size = New System.Drawing.Size(112, 17)
        Me.chkBomExportAllowB49Parents.TabIndex = 22
        Me.chkBomExportAllowB49Parents.Text = "Allow B49 Parents"
        Me.chkBomExportAllowB49Parents.UseVisualStyleBackColor = True
        '
        'btnBOMExport
        '
        Me.btnBOMExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnBOMExport.Location = New System.Drawing.Point(337, 413)
        Me.btnBOMExport.Name = "btnBOMExport"
        Me.btnBOMExport.Size = New System.Drawing.Size(144, 41)
        Me.btnBOMExport.TabIndex = 21
        Me.btnBOMExport.Text = "Export BOM"
        Me.btnBOMExport.UseVisualStyleBackColor = True
        '
        'txtBomImportNumParts
        '
        Me.txtBomImportNumParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtBomImportNumParts.Location = New System.Drawing.Point(9, 434)
        Me.txtBomImportNumParts.Name = "txtBomImportNumParts"
        Me.txtBomImportNumParts.Size = New System.Drawing.Size(98, 20)
        Me.txtBomImportNumParts.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 417)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Num Inventor Parts"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Inventor BOM"
        '
        'lvFullBOM
        '
        Me.lvFullBOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvFullBOM.ContextMenuStrip = Me.BomMenuStrip
        Me.lvFullBOM.FullRowSelect = True
        Me.lvFullBOM.GridLines = True
        Me.lvFullBOM.Location = New System.Drawing.Point(6, 28)
        Me.lvFullBOM.MultiSelect = False
        Me.lvFullBOM.Name = "lvFullBOM"
        Me.lvFullBOM.Size = New System.Drawing.Size(320, 381)
        Me.lvFullBOM.TabIndex = 17
        Me.lvFullBOM.UseCompatibleStateImageBehavior = False
        Me.lvFullBOM.View = System.Windows.Forms.View.Details
        '
        'BomMenuStrip
        '
        Me.BomMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BomMenuStripCopy, Me.BomMenuStripFIND})
        Me.BomMenuStrip.Name = "FullBomMenuStrip"
        Me.BomMenuStrip.Size = New System.Drawing.Size(125, 48)
        '
        'BomMenuStripCopy
        '
        Me.BomMenuStripCopy.Name = "BomMenuStripCopy"
        Me.BomMenuStripCopy.Size = New System.Drawing.Size(124, 22)
        Me.BomMenuStripCopy.Text = "Copy"
        '
        'BomMenuStripFIND
        '
        Me.BomMenuStripFIND.Name = "BomMenuStripFIND"
        Me.BomMenuStripFIND.Size = New System.Drawing.Size(124, 22)
        Me.BomMenuStripFIND.Text = "Find Item"
        '
        'lblVersion
        '
        Me.lblVersion.Location = New System.Drawing.Point(453, 48)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 25
        Me.lblVersion.Text = "Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmBomTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 537)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnLoadInventorBOM)
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(520, 1100)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(520, 300)
        Me.Name = "frmBomTools"
        Me.Text = "BOM Tools"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.InventorMenuStrip.ResumeLayout(False)
        Me.PromanMenuStrip.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.PartMenuStrip.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.BomMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents SaveFileDialog1 As Windows.Forms.SaveFileDialog
    Friend WithEvents PromanMenuStripCOPY As Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventorMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents InventorMenuStripCOPY As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lvPartCreate As Windows.Forms.ListView
    Friend WithEvents txtPCNumInventorParts As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents TabPage4 As Windows.Forms.TabPage
    Friend WithEvents txtBomImportNumParts As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents lvFullBOM As Windows.Forms.ListView
    Friend WithEvents btnExportPartList As Windows.Forms.Button
    Friend WithEvents btnBOMExport As Windows.Forms.Button
    Friend WithEvents chkBomExportAllowB49Parents As Windows.Forms.CheckBox
    Friend WithEvents chkBomExportShowFasteners As Windows.Forms.CheckBox
    Friend WithEvents chkPartExportShowB49 As Windows.Forms.CheckBox
    Friend WithEvents PartMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents PartMenuStripCopy As Windows.Forms.ToolStripMenuItem
    Friend WithEvents BomMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents BomMenuStripCopy As Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkBOMCompIncB45Children As Windows.Forms.CheckBox
    Friend WithEvents chkBOMCompIncB39Children As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompIncludeCAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompIncludeBAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompShowFasteners As Windows.Forms.CheckBox
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents InventorMenuStripFIND As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PromanMenuStripFIND As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PartMenuStripFIND As Windows.Forms.ToolStripMenuItem
    Friend WithEvents BomMenuStripFIND As Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkPartExportShowTLAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBOMExportShowTLAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompShowTLAssy As Windows.Forms.CheckBox
    Friend WithEvents chkPartExportShowFasteners As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompViewImmediatly As Windows.Forms.CheckBox
    Friend WithEvents chkPartExportViewImmediately As Windows.Forms.CheckBox
    Friend WithEvents chkBomExportViewImmediately As Windows.Forms.CheckBox
End Class
