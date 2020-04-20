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
        Me.InventorMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InventorMenuStripCOPY = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventorMenuStripFIND = New System.Windows.Forms.ToolStripMenuItem()
        Me.PromanMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PromanMenuStripCOPY = New System.Windows.Forms.ToolStripMenuItem()
        Me.PromanMenuStripFIND = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoadInventorBOM = New System.Windows.Forms.Button()
        Me.BomMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BomMenuStripCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.BomMenuStripFIND = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.lblVersion = New System.Windows.Forms.Label()
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
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkBomCompViewImmediatly = New System.Windows.Forms.CheckBox()
        Me.chkBomCompShowTLAssy = New System.Windows.Forms.CheckBox()
        Me.chkBOMCompIncB45Children = New System.Windows.Forms.CheckBox()
        Me.chkBOMCompIncB39Children = New System.Windows.Forms.CheckBox()
        Me.chkBomCompIncludeCAssy = New System.Windows.Forms.CheckBox()
        Me.chkBomCompIncludeBAssy = New System.Windows.Forms.CheckBox()
        Me.chkBomCompShowFasteners = New System.Windows.Forms.CheckBox()
        Me.btnBCExportInventorBOM = New System.Windows.Forms.Button()
        Me.lvBomCompInventor = New System.Windows.Forms.ListView()
        Me.txtNumInventorParts = New System.Windows.Forms.TextBox()
        Me.txtNumPromanParts = New System.Windows.Forms.TextBox()
        Me.btnRunCompare = New System.Windows.Forms.Button()
        Me.lblNumInvParts = New System.Windows.Forms.Label()
        Me.btnLoadPromanBom = New System.Windows.Forms.Button()
        Me.lblNumPromanParts = New System.Windows.Forms.Label()
        Me.lblPromanBom = New System.Windows.Forms.Label()
        Me.lblInventorBom = New System.Windows.Forms.Label()
        Me.lvPromanBom = New System.Windows.Forms.ListView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.InventorMenuStrip.SuspendLayout()
        Me.PromanMenuStrip.SuspendLayout()
        Me.BomMenuStrip.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'InventorMenuStrip
        '
        Me.InventorMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.InventorMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventorMenuStripCOPY, Me.InventorMenuStripFIND})
        Me.InventorMenuStrip.Name = "InventorMenuStrip"
        Me.InventorMenuStrip.Size = New System.Drawing.Size(136, 52)
        '
        'InventorMenuStripCOPY
        '
        Me.InventorMenuStripCOPY.Name = "InventorMenuStripCOPY"
        Me.InventorMenuStripCOPY.Size = New System.Drawing.Size(135, 24)
        Me.InventorMenuStripCOPY.Text = "Copy"
        '
        'InventorMenuStripFIND
        '
        Me.InventorMenuStripFIND.Name = "InventorMenuStripFIND"
        Me.InventorMenuStripFIND.Size = New System.Drawing.Size(135, 24)
        Me.InventorMenuStripFIND.Text = "Find Part"
        '
        'PromanMenuStrip
        '
        Me.PromanMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.PromanMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PromanMenuStripCOPY, Me.PromanMenuStripFIND})
        Me.PromanMenuStrip.Name = "PromanMenuStrip"
        Me.PromanMenuStrip.Size = New System.Drawing.Size(141, 52)
        '
        'PromanMenuStripCOPY
        '
        Me.PromanMenuStripCOPY.Name = "PromanMenuStripCOPY"
        Me.PromanMenuStripCOPY.Size = New System.Drawing.Size(140, 24)
        Me.PromanMenuStripCOPY.Text = "Copy"
        '
        'PromanMenuStripFIND
        '
        Me.PromanMenuStripFIND.Name = "PromanMenuStripFIND"
        Me.PromanMenuStripFIND.Size = New System.Drawing.Size(140, 24)
        Me.PromanMenuStripFIND.Text = "Find Item"
        '
        'btnLoadInventorBOM
        '
        Me.btnLoadInventorBOM.Location = New System.Drawing.Point(4, 4)
        Me.btnLoadInventorBOM.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoadInventorBOM.Name = "btnLoadInventorBOM"
        Me.btnLoadInventorBOM.Size = New System.Drawing.Size(656, 48)
        Me.btnLoadInventorBOM.TabIndex = 5
        Me.btnLoadInventorBOM.Text = "Load Inventor BOM"
        Me.btnLoadInventorBOM.UseVisualStyleBackColor = True
        '
        'BomMenuStrip
        '
        Me.BomMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BomMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BomMenuStripCopy, Me.BomMenuStripFIND})
        Me.BomMenuStrip.Name = "FullBomMenuStrip"
        Me.BomMenuStrip.Size = New System.Drawing.Size(141, 52)
        '
        'BomMenuStripCopy
        '
        Me.BomMenuStripCopy.Name = "BomMenuStripCopy"
        Me.BomMenuStripCopy.Size = New System.Drawing.Size(140, 24)
        Me.BomMenuStripCopy.Text = "Copy"
        '
        'BomMenuStripFIND
        '
        Me.BomMenuStripFIND.Name = "BomMenuStripFIND"
        Me.BomMenuStripFIND.Size = New System.Drawing.Size(140, 24)
        Me.BomMenuStripFIND.Text = "Find Item"
        '
        'lblVersion
        '
        Me.lblVersion.Location = New System.Drawing.Point(604, 59)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(56, 16)
        Me.lblVersion.TabIndex = 25
        Me.lblVersion.Text = "Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage4.Size = New System.Drawing.Size(653, 570)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "BOM Export"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'chkBomExportViewImmediately
        '
        Me.chkBomExportViewImmediately.AutoSize = True
        Me.chkBomExportViewImmediately.Checked = True
        Me.chkBomExportViewImmediately.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomExportViewImmediately.Location = New System.Drawing.Point(499, 482)
        Me.chkBomExportViewImmediately.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBomExportViewImmediately.Name = "chkBomExportViewImmediately"
        Me.chkBomExportViewImmediately.Size = New System.Drawing.Size(137, 21)
        Me.chkBomExportViewImmediately.TabIndex = 28
        Me.chkBomExportViewImmediately.Text = "View Immediately"
        Me.chkBomExportViewImmediately.UseVisualStyleBackColor = True
        '
        'chkBOMExportShowTLAssy
        '
        Me.chkBOMExportShowTLAssy.AutoSize = True
        Me.chkBOMExportShowTLAssy.Location = New System.Drawing.Point(443, 34)
        Me.chkBOMExportShowTLAssy.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBOMExportShowTLAssy.Name = "chkBOMExportShowTLAssy"
        Me.chkBOMExportShowTLAssy.Size = New System.Drawing.Size(165, 21)
        Me.chkBOMExportShowTLAssy.TabIndex = 24
        Me.chkBOMExportShowTLAssy.Text = "Show Top Level Assy"
        Me.chkBOMExportShowTLAssy.UseVisualStyleBackColor = True
        '
        'chkBomExportShowFasteners
        '
        Me.chkBomExportShowFasteners.AutoSize = True
        Me.chkBomExportShowFasteners.Checked = True
        Me.chkBomExportShowFasteners.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomExportShowFasteners.Location = New System.Drawing.Point(443, 90)
        Me.chkBomExportShowFasteners.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBomExportShowFasteners.Name = "chkBomExportShowFasteners"
        Me.chkBomExportShowFasteners.Size = New System.Drawing.Size(180, 21)
        Me.chkBomExportShowFasteners.TabIndex = 23
        Me.chkBomExportShowFasteners.Text = "Show Fasteners (M900)"
        Me.chkBomExportShowFasteners.UseVisualStyleBackColor = True
        '
        'chkBomExportAllowB49Parents
        '
        Me.chkBomExportAllowB49Parents.AutoSize = True
        Me.chkBomExportAllowB49Parents.Checked = True
        Me.chkBomExportAllowB49Parents.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomExportAllowB49Parents.Location = New System.Drawing.Point(443, 62)
        Me.chkBomExportAllowB49Parents.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBomExportAllowB49Parents.Name = "chkBomExportAllowB49Parents"
        Me.chkBomExportAllowB49Parents.Size = New System.Drawing.Size(144, 21)
        Me.chkBomExportAllowB49Parents.TabIndex = 22
        Me.chkBomExportAllowB49Parents.Text = "Allow B49 Parents"
        Me.chkBomExportAllowB49Parents.UseVisualStyleBackColor = True
        '
        'btnBOMExport
        '
        Me.btnBOMExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnBOMExport.Location = New System.Drawing.Point(449, 508)
        Me.btnBOMExport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBOMExport.Name = "btnBOMExport"
        Me.btnBOMExport.Size = New System.Drawing.Size(192, 50)
        Me.btnBOMExport.TabIndex = 21
        Me.btnBOMExport.Text = "Export BOM"
        Me.btnBOMExport.UseVisualStyleBackColor = True
        '
        'txtBomImportNumParts
        '
        Me.txtBomImportNumParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtBomImportNumParts.Location = New System.Drawing.Point(12, 534)
        Me.txtBomImportNumParts.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBomImportNumParts.Name = "txtBomImportNumParts"
        Me.txtBomImportNumParts.Size = New System.Drawing.Size(129, 22)
        Me.txtBomImportNumParts.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 513)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Num Inventor Parts"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 12)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Inventor BOM"
        '
        'lvFullBOM
        '
        Me.lvFullBOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvFullBOM.ContextMenuStrip = Me.BomMenuStrip
        Me.lvFullBOM.FullRowSelect = True
        Me.lvFullBOM.GridLines = True
        Me.lvFullBOM.HideSelection = False
        Me.lvFullBOM.Location = New System.Drawing.Point(8, 34)
        Me.lvFullBOM.Margin = New System.Windows.Forms.Padding(4)
        Me.lvFullBOM.MultiSelect = False
        Me.lvFullBOM.Name = "lvFullBOM"
        Me.lvFullBOM.Size = New System.Drawing.Size(425, 468)
        Me.lvFullBOM.TabIndex = 17
        Me.lvFullBOM.UseCompatibleStateImageBehavior = False
        Me.lvFullBOM.View = System.Windows.Forms.View.Details
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
        Me.TabPage1.Controls.Add(Me.txtNumPromanParts)
        Me.TabPage1.Controls.Add(Me.btnRunCompare)
        Me.TabPage1.Controls.Add(Me.lblNumInvParts)
        Me.TabPage1.Controls.Add(Me.btnLoadPromanBom)
        Me.TabPage1.Controls.Add(Me.lblNumPromanParts)
        Me.TabPage1.Controls.Add(Me.lblPromanBom)
        Me.TabPage1.Controls.Add(Me.lblInventorBom)
        Me.TabPage1.Controls.Add(Me.lvPromanBom)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(653, 570)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "BOM Compare"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkBomCompViewImmediatly
        '
        Me.chkBomCompViewImmediatly.AutoSize = True
        Me.chkBomCompViewImmediatly.Checked = True
        Me.chkBomCompViewImmediatly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompViewImmediatly.Location = New System.Drawing.Point(245, 519)
        Me.chkBomCompViewImmediatly.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBomCompViewImmediatly.Name = "chkBomCompViewImmediatly"
        Me.chkBomCompViewImmediatly.Size = New System.Drawing.Size(137, 21)
        Me.chkBomCompViewImmediatly.TabIndex = 27
        Me.chkBomCompViewImmediatly.Text = "View Immediately"
        Me.chkBomCompViewImmediatly.UseVisualStyleBackColor = True
        '
        'chkBomCompShowTLAssy
        '
        Me.chkBomCompShowTLAssy.AutoSize = True
        Me.chkBomCompShowTLAssy.Location = New System.Drawing.Point(243, 108)
        Me.chkBomCompShowTLAssy.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBomCompShowTLAssy.Name = "chkBomCompShowTLAssy"
        Me.chkBomCompShowTLAssy.Size = New System.Drawing.Size(98, 38)
        Me.chkBomCompShowTLAssy.TabIndex = 26
        Me.chkBomCompShowTLAssy.Text = "Show Top " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Level Assy"
        Me.chkBomCompShowTLAssy.UseVisualStyleBackColor = True
        '
        'chkBOMCompIncB45Children
        '
        Me.chkBOMCompIncB45Children.AutoSize = True
        Me.chkBOMCompIncB45Children.Location = New System.Drawing.Point(244, 314)
        Me.chkBOMCompIncB45Children.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBOMCompIncB45Children.Name = "chkBOMCompIncB45Children"
        Me.chkBOMCompIncB45Children.Size = New System.Drawing.Size(149, 21)
        Me.chkBOMCompIncB45Children.TabIndex = 24
        Me.chkBOMCompIncB45Children.Text = "Show B45 Children"
        Me.chkBOMCompIncB45Children.UseVisualStyleBackColor = True
        '
        'chkBOMCompIncB39Children
        '
        Me.chkBOMCompIncB39Children.AutoSize = True
        Me.chkBOMCompIncB39Children.Checked = True
        Me.chkBOMCompIncB39Children.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBOMCompIncB39Children.Location = New System.Drawing.Point(244, 286)
        Me.chkBOMCompIncB39Children.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBOMCompIncB39Children.Name = "chkBOMCompIncB39Children"
        Me.chkBOMCompIncB39Children.Size = New System.Drawing.Size(149, 21)
        Me.chkBOMCompIncB39Children.TabIndex = 23
        Me.chkBOMCompIncB39Children.Text = "Show B39 Children"
        Me.chkBOMCompIncB39Children.UseVisualStyleBackColor = True
        '
        'chkBomCompIncludeCAssy
        '
        Me.chkBomCompIncludeCAssy.AutoSize = True
        Me.chkBomCompIncludeCAssy.Checked = True
        Me.chkBomCompIncludeCAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompIncludeCAssy.Location = New System.Drawing.Point(244, 241)
        Me.chkBomCompIncludeCAssy.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBomCompIncludeCAssy.Name = "chkBomCompIncludeCAssy"
        Me.chkBomCompIncludeCAssy.Size = New System.Drawing.Size(110, 38)
        Me.chkBomCompIncludeCAssy.TabIndex = 22
        Me.chkBomCompIncludeCAssy.Text = "Show C49s " & Global.Microsoft.VisualBasic.ChrW(10) & "(no children)"
        Me.chkBomCompIncludeCAssy.UseVisualStyleBackColor = True
        '
        'chkBomCompIncludeBAssy
        '
        Me.chkBomCompIncludeBAssy.AutoSize = True
        Me.chkBomCompIncludeBAssy.Checked = True
        Me.chkBomCompIncludeBAssy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompIncludeBAssy.Location = New System.Drawing.Point(244, 197)
        Me.chkBomCompIncludeBAssy.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBomCompIncludeBAssy.Name = "chkBomCompIncludeBAssy"
        Me.chkBomCompIncludeBAssy.Size = New System.Drawing.Size(110, 38)
        Me.chkBomCompIncludeBAssy.TabIndex = 21
        Me.chkBomCompIncludeBAssy.Text = "Show B49s " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(no children)"
        Me.chkBomCompIncludeBAssy.UseVisualStyleBackColor = True
        '
        'chkBomCompShowFasteners
        '
        Me.chkBomCompShowFasteners.AutoSize = True
        Me.chkBomCompShowFasteners.Checked = True
        Me.chkBomCompShowFasteners.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBomCompShowFasteners.Location = New System.Drawing.Point(244, 153)
        Me.chkBomCompShowFasteners.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBomCompShowFasteners.Name = "chkBomCompShowFasteners"
        Me.chkBomCompShowFasteners.Size = New System.Drawing.Size(131, 38)
        Me.chkBomCompShowFasteners.TabIndex = 20
        Me.chkBomCompShowFasteners.Text = "Show Fasteners" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(M900)"
        Me.chkBomCompShowFasteners.UseVisualStyleBackColor = True
        '
        'btnBCExportInventorBOM
        '
        Me.btnBCExportInventorBOM.Location = New System.Drawing.Point(245, 457)
        Me.btnBCExportInventorBOM.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBCExportInventorBOM.Name = "btnBCExportInventorBOM"
        Me.btnBCExportInventorBOM.Size = New System.Drawing.Size(160, 55)
        Me.btnBCExportInventorBOM.TabIndex = 13
        Me.btnBCExportInventorBOM.Text = "Export Inventor BOM <--"
        Me.btnBCExportInventorBOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBCExportInventorBOM.UseVisualStyleBackColor = True
        Me.btnBCExportInventorBOM.Visible = False
        '
        'lvBomCompInventor
        '
        Me.lvBomCompInventor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvBomCompInventor.ContextMenuStrip = Me.InventorMenuStrip
        Me.lvBomCompInventor.FullRowSelect = True
        Me.lvBomCompInventor.GridLines = True
        Me.lvBomCompInventor.HideSelection = False
        Me.lvBomCompInventor.Location = New System.Drawing.Point(8, 34)
        Me.lvBomCompInventor.Margin = New System.Windows.Forms.Padding(4)
        Me.lvBomCompInventor.MultiSelect = False
        Me.lvBomCompInventor.Name = "lvBomCompInventor"
        Me.lvBomCompInventor.Size = New System.Drawing.Size(225, 474)
        Me.lvBomCompInventor.TabIndex = 0
        Me.lvBomCompInventor.UseCompatibleStateImageBehavior = False
        Me.lvBomCompInventor.View = System.Windows.Forms.View.Details
        '
        'txtNumInventorParts
        '
        Me.txtNumInventorParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumInventorParts.Location = New System.Drawing.Point(12, 534)
        Me.txtNumInventorParts.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumInventorParts.Name = "txtNumInventorParts"
        Me.txtNumInventorParts.Size = New System.Drawing.Size(129, 22)
        Me.txtNumInventorParts.TabIndex = 7
        '
        'txtNumPromanParts
        '
        Me.txtNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtNumPromanParts.Location = New System.Drawing.Point(416, 535)
        Me.txtNumPromanParts.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumPromanParts.Name = "txtNumPromanParts"
        Me.txtNumPromanParts.Size = New System.Drawing.Size(129, 22)
        Me.txtNumPromanParts.TabIndex = 9
        '
        'btnRunCompare
        '
        Me.btnRunCompare.Location = New System.Drawing.Point(244, 358)
        Me.btnRunCompare.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRunCompare.Name = "btnRunCompare"
        Me.btnRunCompare.Size = New System.Drawing.Size(160, 62)
        Me.btnRunCompare.TabIndex = 6
        Me.btnRunCompare.Text = "Run Compare"
        Me.btnRunCompare.UseVisualStyleBackColor = True
        '
        'lblNumInvParts
        '
        Me.lblNumInvParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumInvParts.AutoSize = True
        Me.lblNumInvParts.Location = New System.Drawing.Point(8, 513)
        Me.lblNumInvParts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumInvParts.Name = "lblNumInvParts"
        Me.lblNumInvParts.Size = New System.Drawing.Size(129, 17)
        Me.lblNumInvParts.TabIndex = 8
        Me.lblNumInvParts.Text = "Num Inventor Parts"
        '
        'btnLoadPromanBom
        '
        Me.btnLoadPromanBom.Location = New System.Drawing.Point(245, 33)
        Me.btnLoadPromanBom.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoadPromanBom.Name = "btnLoadPromanBom"
        Me.btnLoadPromanBom.Size = New System.Drawing.Size(160, 55)
        Me.btnLoadPromanBom.TabIndex = 4
        Me.btnLoadPromanBom.Text = "Load Proman BOM -->"
        Me.btnLoadPromanBom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLoadPromanBom.UseVisualStyleBackColor = True
        '
        'lblNumPromanParts
        '
        Me.lblNumPromanParts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNumPromanParts.AutoSize = True
        Me.lblNumPromanParts.Location = New System.Drawing.Point(412, 513)
        Me.lblNumPromanParts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumPromanParts.Name = "lblNumPromanParts"
        Me.lblNumPromanParts.Size = New System.Drawing.Size(127, 17)
        Me.lblNumPromanParts.TabIndex = 10
        Me.lblNumPromanParts.Text = "Num Proman Parts"
        '
        'lblPromanBom
        '
        Me.lblPromanBom.AutoSize = True
        Me.lblPromanBom.Location = New System.Drawing.Point(412, 12)
        Me.lblPromanBom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPromanBom.Name = "lblPromanBom"
        Me.lblPromanBom.Size = New System.Drawing.Size(92, 17)
        Me.lblPromanBom.TabIndex = 3
        Me.lblPromanBom.Text = "Proman BOM"
        '
        'lblInventorBom
        '
        Me.lblInventorBom.AutoSize = True
        Me.lblInventorBom.Location = New System.Drawing.Point(5, 12)
        Me.lblInventorBom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInventorBom.Name = "lblInventorBom"
        Me.lblInventorBom.Size = New System.Drawing.Size(94, 17)
        Me.lblInventorBom.TabIndex = 2
        Me.lblInventorBom.Text = "Inventor BOM"
        '
        'lvPromanBom
        '
        Me.lvPromanBom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lvPromanBom.ContextMenuStrip = Me.PromanMenuStrip
        Me.lvPromanBom.FullRowSelect = True
        Me.lvPromanBom.GridLines = True
        Me.lvPromanBom.HideSelection = False
        Me.lvPromanBom.Location = New System.Drawing.Point(416, 33)
        Me.lvPromanBom.Margin = New System.Windows.Forms.Padding(4)
        Me.lvPromanBom.MultiSelect = False
        Me.lvPromanBom.Name = "lvPromanBom"
        Me.lvPromanBom.Size = New System.Drawing.Size(225, 475)
        Me.lvPromanBom.TabIndex = 1
        Me.lvPromanBom.UseCompatibleStateImageBehavior = False
        Me.lvPromanBom.View = System.Windows.Forms.View.Details
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(5, 55)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(661, 599)
        Me.TabControl1.TabIndex = 15
        '
        'frmBomTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 661)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnLoadInventorBOM)
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(687, 1343)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(687, 358)
        Me.Name = "frmBomTools"
        Me.Text = "BOM Tools"
        Me.InventorMenuStrip.ResumeLayout(False)
        Me.PromanMenuStrip.ResumeLayout(False)
        Me.BomMenuStrip.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLoadInventorBOM As Windows.Forms.Button
    Friend WithEvents PromanMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveFileDialog1 As Windows.Forms.SaveFileDialog
    Friend WithEvents PromanMenuStripCOPY As Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventorMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents InventorMenuStripCOPY As Windows.Forms.ToolStripMenuItem
    Friend WithEvents BomMenuStrip As Windows.Forms.ContextMenuStrip
    Friend WithEvents BomMenuStripCopy As Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents InventorMenuStripFIND As Windows.Forms.ToolStripMenuItem
    Friend WithEvents PromanMenuStripFIND As Windows.Forms.ToolStripMenuItem
    Friend WithEvents BomMenuStripFIND As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage4 As Windows.Forms.TabPage
    Friend WithEvents chkBomExportViewImmediately As Windows.Forms.CheckBox
    Friend WithEvents chkBOMExportShowTLAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBomExportShowFasteners As Windows.Forms.CheckBox
    Friend WithEvents chkBomExportAllowB49Parents As Windows.Forms.CheckBox
    Friend WithEvents btnBOMExport As Windows.Forms.Button
    Friend WithEvents txtBomImportNumParts As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents lvFullBOM As Windows.Forms.ListView
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents chkBomCompViewImmediatly As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompShowTLAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBOMCompIncB45Children As Windows.Forms.CheckBox
    Friend WithEvents chkBOMCompIncB39Children As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompIncludeCAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompIncludeBAssy As Windows.Forms.CheckBox
    Friend WithEvents chkBomCompShowFasteners As Windows.Forms.CheckBox
    Friend WithEvents btnBCExportInventorBOM As Windows.Forms.Button
    Friend WithEvents lvBomCompInventor As Windows.Forms.ListView
    Friend WithEvents txtNumInventorParts As Windows.Forms.TextBox
    Friend WithEvents txtNumPromanParts As Windows.Forms.TextBox
    Friend WithEvents btnRunCompare As Windows.Forms.Button
    Friend WithEvents lblNumInvParts As Windows.Forms.Label
    Friend WithEvents btnLoadPromanBom As Windows.Forms.Button
    Friend WithEvents lblNumPromanParts As Windows.Forms.Label
    Friend WithEvents lblPromanBom As Windows.Forms.Label
    Friend WithEvents lblInventorBom As Windows.Forms.Label
    Friend WithEvents lvPromanBom As Windows.Forms.ListView
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
End Class
