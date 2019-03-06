<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAnimateAssembly
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnLoadColumn = New System.Windows.Forms.Button()
        Me.lblStopwatch = New System.Windows.Forms.Label()
        Me.lblStepSize = New System.Windows.Forms.Label()
        Me.txtStepSize = New System.Windows.Forms.TextBox()
        Me.btnAssignParam = New System.Windows.Forms.Button()
        Me.txtStopwatch = New System.Windows.Forms.TextBox()
        Me.btnDeleteColumn = New System.Windows.Forms.Button()
        Me.btnAddColumn = New System.Windows.Forms.Button()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Angle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VertParam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HorizParam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblNumConstraints = New System.Windows.Forms.Label()
        Me.txtNumConstraints = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.btnNextAngle = New System.Windows.Forms.Button()
        Me.btnPrevAngle = New System.Windows.Forms.Button()
        Me.Information = New System.Windows.Forms.TabPage()
        Me.lblReference = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.bxSettings = New System.Windows.Forms.GroupBox()
        Me.lblHorizName = New System.Windows.Forms.Label()
        Me.txtHorizName = New System.Windows.Forms.TextBox()
        Me.lblVertName = New System.Windows.Forms.Label()
        Me.txtVertName = New System.Windows.Forms.TextBox()
        Me.lblHorizOffset = New System.Windows.Forms.Label()
        Me.txtHorizOffset = New System.Windows.Forms.TextBox()
        Me.lblVertOffset = New System.Windows.Forms.Label()
        Me.txtVertOffset = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Information.SuspendLayout()
        Me.bxSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.Information)
        Me.TabControl1.Location = New System.Drawing.Point(5, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(487, 590)
        Me.TabControl1.TabIndex = 45
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnLoadColumn)
        Me.TabPage1.Controls.Add(Me.lblStopwatch)
        Me.TabPage1.Controls.Add(Me.lblStepSize)
        Me.TabPage1.Controls.Add(Me.txtStepSize)
        Me.TabPage1.Controls.Add(Me.btnAssignParam)
        Me.TabPage1.Controls.Add(Me.txtStopwatch)
        Me.TabPage1.Controls.Add(Me.btnDeleteColumn)
        Me.TabPage1.Controls.Add(Me.btnAddColumn)
        Me.TabPage1.Controls.Add(Me.DataGridView)
        Me.TabPage1.Controls.Add(Me.lblVersion)
        Me.TabPage1.Controls.Add(Me.lblNumConstraints)
        Me.TabPage1.Controls.Add(Me.txtNumConstraints)
        Me.TabPage1.Controls.Add(Me.btnExit)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btnReload)
        Me.TabPage1.Controls.Add(Me.btnBrowse)
        Me.TabPage1.Controls.Add(Me.txtFilePath)
        Me.TabPage1.Controls.Add(Me.lblFilePath)
        Me.TabPage1.Controls.Add(Me.btnNextAngle)
        Me.TabPage1.Controls.Add(Me.btnPrevAngle)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(479, 564)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Step Tool"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnLoadColumn
        '
        Me.btnLoadColumn.Location = New System.Drawing.Point(416, 112)
        Me.btnLoadColumn.Name = "btnLoadColumn"
        Me.btnLoadColumn.Size = New System.Drawing.Size(55, 40)
        Me.btnLoadColumn.TabIndex = 62
        Me.btnLoadColumn.Text = "Load Column"
        Me.btnLoadColumn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnLoadColumn.UseVisualStyleBackColor = True
        '
        'lblStopwatch
        '
        Me.lblStopwatch.AutoSize = True
        Me.lblStopwatch.Location = New System.Drawing.Point(270, 452)
        Me.lblStopwatch.Name = "lblStopwatch"
        Me.lblStopwatch.Size = New System.Drawing.Size(80, 13)
        Me.lblStopwatch.TabIndex = 61
        Me.lblStopwatch.Text = "Stopwatch (ms)"
        '
        'lblStepSize
        '
        Me.lblStepSize.AutoSize = True
        Me.lblStepSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStepSize.Location = New System.Drawing.Point(214, 452)
        Me.lblStepSize.Name = "lblStepSize"
        Me.lblStepSize.Size = New System.Drawing.Size(52, 13)
        Me.lblStepSize.TabIndex = 28
        Me.lblStepSize.Text = "Step Size"
        '
        'txtStepSize
        '
        Me.txtStepSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStepSize.Location = New System.Drawing.Point(214, 470)
        Me.txtStepSize.Name = "txtStepSize"
        Me.txtStepSize.Size = New System.Drawing.Size(49, 20)
        Me.txtStepSize.TabIndex = 8
        Me.txtStepSize.Text = "2"
        '
        'btnAssignParam
        '
        Me.btnAssignParam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssignParam.Location = New System.Drawing.Point(416, 52)
        Me.btnAssignParam.Name = "btnAssignParam"
        Me.btnAssignParam.Size = New System.Drawing.Size(55, 42)
        Me.btnAssignParam.TabIndex = 9
        Me.btnAssignParam.Text = "Assign" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Param"
        Me.btnAssignParam.UseVisualStyleBackColor = True
        '
        'txtStopwatch
        '
        Me.txtStopwatch.Location = New System.Drawing.Point(271, 470)
        Me.txtStopwatch.Name = "txtStopwatch"
        Me.txtStopwatch.Size = New System.Drawing.Size(79, 20)
        Me.txtStopwatch.TabIndex = 60
        '
        'btnDeleteColumn
        '
        Me.btnDeleteColumn.Location = New System.Drawing.Point(416, 228)
        Me.btnDeleteColumn.Name = "btnDeleteColumn"
        Me.btnDeleteColumn.Size = New System.Drawing.Size(55, 40)
        Me.btnDeleteColumn.TabIndex = 59
        Me.btnDeleteColumn.Text = "Delete" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Column"
        Me.btnDeleteColumn.UseVisualStyleBackColor = True
        '
        'btnAddColumn
        '
        Me.btnAddColumn.Location = New System.Drawing.Point(416, 170)
        Me.btnAddColumn.Name = "btnAddColumn"
        Me.btnAddColumn.Size = New System.Drawing.Size(55, 40)
        Me.btnAddColumn.TabIndex = 58
        Me.btnAddColumn.Text = "Add" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Column"
        Me.btnAddColumn.UseVisualStyleBackColor = True
        '
        'DataGridView
        '
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Index, Me.Angle, Me.VertParam, Me.HorizParam})
        Me.DataGridView.Location = New System.Drawing.Point(8, 52)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.Size = New System.Drawing.Size(399, 380)
        Me.DataGridView.TabIndex = 57
        '
        'Index
        '
        Me.Index.Frozen = True
        Me.Index.HeaderText = "Index"
        Me.Index.MinimumWidth = 40
        Me.Index.Name = "Index"
        Me.Index.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Index.Width = 40
        '
        'Angle
        '
        Me.Angle.Frozen = True
        Me.Angle.HeaderText = "Angle"
        Me.Angle.MinimumWidth = 40
        Me.Angle.Name = "Angle"
        Me.Angle.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Angle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Angle.Width = 40
        '
        'VertParam
        '
        Me.VertParam.HeaderText = "VertParam"
        Me.VertParam.MinimumWidth = 65
        Me.VertParam.Name = "VertParam"
        Me.VertParam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VertParam.Width = 110
        '
        'HorizParam
        '
        Me.HorizParam.HeaderText = "HorizParam"
        Me.HorizParam.MinimumWidth = 65
        Me.HorizParam.Name = "HorizParam"
        Me.HorizParam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.HorizParam.Width = 110
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(354, 543)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(30, 13)
        Me.lblVersion.TabIndex = 52
        Me.lblVersion.Text = "vX.X"
        '
        'lblNumConstraints
        '
        Me.lblNumConstraints.AutoSize = True
        Me.lblNumConstraints.Location = New System.Drawing.Point(354, 439)
        Me.lblNumConstraints.Name = "lblNumConstraints"
        Me.lblNumConstraints.Size = New System.Drawing.Size(59, 26)
        Me.lblNumConstraints.TabIndex = 56
        Me.lblNumConstraints.Text = "Num" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Constraints"
        '
        'txtNumConstraints
        '
        Me.txtNumConstraints.Location = New System.Drawing.Point(357, 470)
        Me.txtNumConstraints.Name = "txtNumConstraints"
        Me.txtNumConstraints.Size = New System.Drawing.Size(49, 20)
        Me.txtNumConstraints.TabIndex = 55
        Me.txtNumConstraints.Text = "0"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(396, 522)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 34)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnPlay)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 496)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 64)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "AutoPlay"
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(110, 19)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(84, 37)
        Me.btnStop.TabIndex = 14
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.Location = New System.Drawing.Point(7, 19)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(97, 37)
        Me.btnPlay.TabIndex = 13
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(411, 19)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(60, 23)
        Me.btnReload.TabIndex = 2
        Me.btnReload.Text = "Reload"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(347, 19)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(60, 23)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(8, 22)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(333, 20)
        Me.txtFilePath.TabIndex = 0
        Me.txtFilePath.Text = "Browse for Path"
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSize = True
        Me.lblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilePath.Location = New System.Drawing.Point(5, 6)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(57, 13)
        Me.lblFilePath.TabIndex = 3
        Me.lblFilePath.Text = "File Path"
        '
        'btnNextAngle
        '
        Me.btnNextAngle.Location = New System.Drawing.Point(111, 438)
        Me.btnNextAngle.Name = "btnNextAngle"
        Me.btnNextAngle.Size = New System.Drawing.Size(97, 52)
        Me.btnNextAngle.TabIndex = 12
        Me.btnNextAngle.Text = "Next Angle"
        Me.btnNextAngle.UseVisualStyleBackColor = True
        '
        'btnPrevAngle
        '
        Me.btnPrevAngle.Location = New System.Drawing.Point(8, 438)
        Me.btnPrevAngle.Name = "btnPrevAngle"
        Me.btnPrevAngle.Size = New System.Drawing.Size(97, 52)
        Me.btnPrevAngle.TabIndex = 11
        Me.btnPrevAngle.Text = "Prev Angle"
        Me.btnPrevAngle.UseVisualStyleBackColor = True
        '
        'Information
        '
        Me.Information.Controls.Add(Me.lblReference)
        Me.Information.Controls.Add(Me.RichTextBox1)
        Me.Information.Controls.Add(Me.bxSettings)
        Me.Information.Location = New System.Drawing.Point(4, 22)
        Me.Information.Name = "Information"
        Me.Information.Padding = New System.Windows.Forms.Padding(3)
        Me.Information.Size = New System.Drawing.Size(479, 564)
        Me.Information.TabIndex = 1
        Me.Information.Text = "Reference"
        Me.Information.UseVisualStyleBackColor = True
        '
        'lblReference
        '
        Me.lblReference.AutoSize = True
        Me.lblReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReference.Location = New System.Drawing.Point(6, 8)
        Me.lblReference.Name = "lblReference"
        Me.lblReference.Size = New System.Drawing.Size(112, 13)
        Me.lblReference.TabIndex = 6
        Me.lblReference.Text = "Reference Information"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 24)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(442, 342)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'bxSettings
        '
        Me.bxSettings.Controls.Add(Me.lblHorizName)
        Me.bxSettings.Controls.Add(Me.txtHorizName)
        Me.bxSettings.Controls.Add(Me.lblVertName)
        Me.bxSettings.Controls.Add(Me.txtVertName)
        Me.bxSettings.Controls.Add(Me.lblHorizOffset)
        Me.bxSettings.Controls.Add(Me.txtHorizOffset)
        Me.bxSettings.Controls.Add(Me.lblVertOffset)
        Me.bxSettings.Controls.Add(Me.txtVertOffset)
        Me.bxSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bxSettings.Location = New System.Drawing.Point(248, 382)
        Me.bxSettings.Name = "bxSettings"
        Me.bxSettings.Size = New System.Drawing.Size(200, 137)
        Me.bxSettings.TabIndex = 4
        Me.bxSettings.TabStop = False
        Me.bxSettings.Text = "Settings"
        '
        'lblHorizName
        '
        Me.lblHorizName.AutoSize = True
        Me.lblHorizName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorizName.Location = New System.Drawing.Point(102, 63)
        Me.lblHorizName.Name = "lblHorizName"
        Me.lblHorizName.Size = New System.Drawing.Size(62, 13)
        Me.lblHorizName.TabIndex = 11
        Me.lblHorizName.Text = "Horiz Name"
        '
        'txtHorizName
        '
        Me.txtHorizName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorizName.Location = New System.Drawing.Point(105, 80)
        Me.txtHorizName.Name = "txtHorizName"
        Me.txtHorizName.Size = New System.Drawing.Size(82, 20)
        Me.txtHorizName.TabIndex = 6
        Me.txtHorizName.Text = "HorizName"
        '
        'lblVertName
        '
        Me.lblVertName.AutoSize = True
        Me.lblVertName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVertName.Location = New System.Drawing.Point(6, 63)
        Me.lblVertName.Name = "lblVertName"
        Me.lblVertName.Size = New System.Drawing.Size(57, 13)
        Me.lblVertName.TabIndex = 9
        Me.lblVertName.Text = "Vert Name"
        '
        'txtVertName
        '
        Me.txtVertName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVertName.Location = New System.Drawing.Point(6, 80)
        Me.txtVertName.Name = "txtVertName"
        Me.txtVertName.Size = New System.Drawing.Size(82, 20)
        Me.txtVertName.TabIndex = 5
        Me.txtVertName.Text = "VertName"
        '
        'lblHorizOffset
        '
        Me.lblHorizOffset.AutoSize = True
        Me.lblHorizOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorizOffset.Location = New System.Drawing.Point(102, 17)
        Me.lblHorizOffset.Name = "lblHorizOffset"
        Me.lblHorizOffset.Size = New System.Drawing.Size(87, 13)
        Me.lblHorizOffset.TabIndex = 7
        Me.lblHorizOffset.Text = "Horiz Offset (mm)"
        '
        'txtHorizOffset
        '
        Me.txtHorizOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorizOffset.Location = New System.Drawing.Point(105, 34)
        Me.txtHorizOffset.Name = "txtHorizOffset"
        Me.txtHorizOffset.Size = New System.Drawing.Size(82, 20)
        Me.txtHorizOffset.TabIndex = 4
        Me.txtHorizOffset.Text = "123.993"
        '
        'lblVertOffset
        '
        Me.lblVertOffset.AutoSize = True
        Me.lblVertOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVertOffset.Location = New System.Drawing.Point(6, 17)
        Me.lblVertOffset.Name = "lblVertOffset"
        Me.lblVertOffset.Size = New System.Drawing.Size(82, 13)
        Me.lblVertOffset.TabIndex = 5
        Me.lblVertOffset.Text = "Vert Offset (mm)"
        '
        'txtVertOffset
        '
        Me.txtVertOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVertOffset.Location = New System.Drawing.Point(6, 34)
        Me.txtVertOffset.Name = "txtVertOffset"
        Me.txtVertOffset.Size = New System.Drawing.Size(82, 20)
        Me.txtVertOffset.TabIndex = 3
        Me.txtVertOffset.Text = "261.424"
        '
        'frmAnimateAssembly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 599)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmAnimateAssembly"
        Me.Text = "AnimateAssembly"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Information.ResumeLayout(False)
        Me.Information.PerformLayout()
        Me.bxSettings.ResumeLayout(False)
        Me.bxSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents btnStop As Windows.Forms.Button
    Friend WithEvents btnPlay As Windows.Forms.Button
    Friend WithEvents btnReload As Windows.Forms.Button
    Friend WithEvents btnBrowse As Windows.Forms.Button
    Friend WithEvents txtFilePath As Windows.Forms.TextBox
    Friend WithEvents lblFilePath As Windows.Forms.Label
    Friend WithEvents btnNextAngle As Windows.Forms.Button
    Friend WithEvents btnPrevAngle As Windows.Forms.Button
    Friend WithEvents btnAssignParam As Windows.Forms.Button
    Friend WithEvents lblStepSize As Windows.Forms.Label
    Friend WithEvents txtStepSize As Windows.Forms.TextBox
    Friend WithEvents lblNumConstraints As Windows.Forms.Label
    Friend WithEvents txtNumConstraints As Windows.Forms.TextBox
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents DataGridView As Windows.Forms.DataGridView
    Friend WithEvents btnDeleteColumn As Windows.Forms.Button
    Friend WithEvents btnAddColumn As Windows.Forms.Button
    Friend WithEvents txtStopwatch As Windows.Forms.TextBox
    Friend WithEvents lblStopwatch As Windows.Forms.Label
    Friend WithEvents Information As Windows.Forms.TabPage
    Friend WithEvents bxSettings As Windows.Forms.GroupBox
    Friend WithEvents lblHorizName As Windows.Forms.Label
    Friend WithEvents txtHorizName As Windows.Forms.TextBox
    Friend WithEvents lblVertName As Windows.Forms.Label
    Friend WithEvents txtVertName As Windows.Forms.TextBox
    Friend WithEvents lblHorizOffset As Windows.Forms.Label
    Friend WithEvents txtHorizOffset As Windows.Forms.TextBox
    Friend WithEvents lblVertOffset As Windows.Forms.Label
    Friend WithEvents txtVertOffset As Windows.Forms.TextBox
    Friend WithEvents Index As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Angle As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VertParam As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HorizParam As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RichTextBox1 As Windows.Forms.RichTextBox
    Friend WithEvents lblReference As Windows.Forms.Label
    Friend WithEvents btnLoadColumn As Windows.Forms.Button
End Class
