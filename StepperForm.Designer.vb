<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStepper
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
        Me.txtVertPos = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkShowDebug = New System.Windows.Forms.CheckBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.btnNextAngle = New System.Windows.Forms.Button()
        Me.btnPrevAngle = New System.Windows.Forms.Button()
        Me.bxSettings = New System.Windows.Forms.GroupBox()
        Me.lblAccelThreshold = New System.Windows.Forms.Label()
        Me.txtAccelThreshold = New System.Windows.Forms.TextBox()
        Me.chkIgnoreHoriz = New System.Windows.Forms.CheckBox()
        Me.btnNameHelp = New System.Windows.Forms.Button()
        Me.lblStepSize = New System.Windows.Forms.Label()
        Me.txtStepSize = New System.Windows.Forms.TextBox()
        Me.lblHorizName = New System.Windows.Forms.Label()
        Me.txtHorizName = New System.Windows.Forms.TextBox()
        Me.lblVertName = New System.Windows.Forms.Label()
        Me.txtVertName = New System.Windows.Forms.TextBox()
        Me.lblHorizOffset = New System.Windows.Forms.Label()
        Me.txtHorizOffset = New System.Windows.Forms.TextBox()
        Me.lblVertOffset = New System.Windows.Forms.Label()
        Me.txtVertOffset = New System.Windows.Forms.TextBox()
        Me.lblHorizPos = New System.Windows.Forms.Label()
        Me.txtHorizPos = New System.Windows.Forms.TextBox()
        Me.lblStopwatch = New System.Windows.Forms.Label()
        Me.txtStopwatch = New System.Windows.Forms.TextBox()
        Me.lblVertPos = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblNumConstraints = New System.Windows.Forms.Label()
        Me.txtNumConstraints = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.bxSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtVertPos
        '
        Me.txtVertPos.Location = New System.Drawing.Point(656, 53)
        Me.txtVertPos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVertPos.Name = "txtVertPos"
        Me.txtVertPos.Size = New System.Drawing.Size(104, 22)
        Me.txtVertPos.TabIndex = 49
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(3, 2)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(647, 585)
        Me.TabControl1.TabIndex = 44
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkShowDebug)
        Me.TabPage1.Controls.Add(Me.btnExit)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btnReload)
        Me.TabPage1.Controls.Add(Me.lstData)
        Me.TabPage1.Controls.Add(Me.btnBrowse)
        Me.TabPage1.Controls.Add(Me.txtFilePath)
        Me.TabPage1.Controls.Add(Me.lblFilePath)
        Me.TabPage1.Controls.Add(Me.btnNextAngle)
        Me.TabPage1.Controls.Add(Me.btnPrevAngle)
        Me.TabPage1.Controls.Add(Me.bxSettings)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(639, 556)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Step Tool"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkShowDebug
        '
        Me.chkShowDebug.AutoSize = True
        Me.chkShowDebug.Location = New System.Drawing.Point(16, 514)
        Me.chkShowDebug.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkShowDebug.Name = "chkShowDebug"
        Me.chkShowDebug.Size = New System.Drawing.Size(135, 21)
        Me.chkShowDebug.TabIndex = 36
        Me.chkShowDebug.Text = "Show More Info?"
        Me.chkShowDebug.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(177, 497)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(100, 42)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnPlay)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 377)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(267, 79)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "AutoPlay"
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(147, 23)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(112, 46)
        Me.btnStop.TabIndex = 14
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.Location = New System.Drawing.Point(9, 23)
        Me.btnPlay.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(129, 46)
        Me.btnPlay.TabIndex = 13
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(548, 23)
        Me.btnReload.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(80, 28)
        Me.btnReload.TabIndex = 2
        Me.btnReload.Text = "Reload"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'lstData
        '
        Me.lstData.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstData.BackColor = System.Drawing.SystemColors.Window
        Me.lstData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstData.FullRowSelect = True
        Me.lstData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstData.HideSelection = False
        Me.lstData.Location = New System.Drawing.Point(291, 63)
        Me.lstData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(332, 467)
        Me.lstData.TabIndex = 32
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(463, 23)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(80, 28)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(11, 27)
        Me.txtFilePath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(443, 22)
        Me.txtFilePath.TabIndex = 0
        Me.txtFilePath.Text = "Browse for Path"
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSize = True
        Me.lblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilePath.Location = New System.Drawing.Point(7, 7)
        Me.lblFilePath.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(72, 17)
        Me.lblFilePath.TabIndex = 3
        Me.lblFilePath.Text = "File Path"
        '
        'btnNextAngle
        '
        Me.btnNextAngle.Location = New System.Drawing.Point(153, 293)
        Me.btnNextAngle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNextAngle.Name = "btnNextAngle"
        Me.btnNextAngle.Size = New System.Drawing.Size(129, 64)
        Me.btnNextAngle.TabIndex = 12
        Me.btnNextAngle.Text = "Next Angle"
        Me.btnNextAngle.UseVisualStyleBackColor = True
        '
        'btnPrevAngle
        '
        Me.btnPrevAngle.Location = New System.Drawing.Point(11, 293)
        Me.btnPrevAngle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrevAngle.Name = "btnPrevAngle"
        Me.btnPrevAngle.Size = New System.Drawing.Size(129, 64)
        Me.btnPrevAngle.TabIndex = 11
        Me.btnPrevAngle.Text = "Prev Angle"
        Me.btnPrevAngle.UseVisualStyleBackColor = True
        '
        'bxSettings
        '
        Me.bxSettings.Controls.Add(Me.lblAccelThreshold)
        Me.bxSettings.Controls.Add(Me.txtAccelThreshold)
        Me.bxSettings.Controls.Add(Me.chkIgnoreHoriz)
        Me.bxSettings.Controls.Add(Me.btnNameHelp)
        Me.bxSettings.Controls.Add(Me.lblStepSize)
        Me.bxSettings.Controls.Add(Me.txtStepSize)
        Me.bxSettings.Controls.Add(Me.lblHorizName)
        Me.bxSettings.Controls.Add(Me.txtHorizName)
        Me.bxSettings.Controls.Add(Me.lblVertName)
        Me.bxSettings.Controls.Add(Me.txtVertName)
        Me.bxSettings.Controls.Add(Me.lblHorizOffset)
        Me.bxSettings.Controls.Add(Me.txtHorizOffset)
        Me.bxSettings.Controls.Add(Me.lblVertOffset)
        Me.bxSettings.Controls.Add(Me.txtVertOffset)
        Me.bxSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bxSettings.Location = New System.Drawing.Point(11, 59)
        Me.bxSettings.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bxSettings.Name = "bxSettings"
        Me.bxSettings.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bxSettings.Size = New System.Drawing.Size(267, 229)
        Me.bxSettings.TabIndex = 3
        Me.bxSettings.TabStop = False
        Me.bxSettings.Text = "Settings"
        '
        'lblAccelThreshold
        '
        Me.lblAccelThreshold.AutoSize = True
        Me.lblAccelThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccelThreshold.Location = New System.Drawing.Point(8, 172)
        Me.lblAccelThreshold.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAccelThreshold.Name = "lblAccelThreshold"
        Me.lblAccelThreshold.Size = New System.Drawing.Size(110, 17)
        Me.lblAccelThreshold.TabIndex = 38
        Me.lblAccelThreshold.Text = "Accel Threshold"
        '
        'txtAccelThreshold
        '
        Me.txtAccelThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccelThreshold.Location = New System.Drawing.Point(12, 193)
        Me.txtAccelThreshold.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAccelThreshold.Name = "txtAccelThreshold"
        Me.txtAccelThreshold.Size = New System.Drawing.Size(100, 23)
        Me.txtAccelThreshold.TabIndex = 7
        Me.txtAccelThreshold.Text = "9"
        '
        'chkIgnoreHoriz
        '
        Me.chkIgnoreHoriz.AutoSize = True
        Me.chkIgnoreHoriz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIgnoreHoriz.Location = New System.Drawing.Point(140, 133)
        Me.chkIgnoreHoriz.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkIgnoreHoriz.Name = "chkIgnoreHoriz"
        Me.chkIgnoreHoriz.Size = New System.Drawing.Size(115, 21)
        Me.chkIgnoreHoriz.TabIndex = 10
        Me.chkIgnoreHoriz.Text = "Ignore Horiz?"
        Me.chkIgnoreHoriz.UseVisualStyleBackColor = True
        '
        'btnNameHelp
        '
        Me.btnNameHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNameHelp.Location = New System.Drawing.Point(8, 133)
        Me.btnNameHelp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNameHelp.Name = "btnNameHelp"
        Me.btnNameHelp.Size = New System.Drawing.Size(100, 28)
        Me.btnNameHelp.TabIndex = 9
        Me.btnNameHelp.Text = "Name Help"
        Me.btnNameHelp.UseVisualStyleBackColor = True
        '
        'lblStepSize
        '
        Me.lblStepSize.AutoSize = True
        Me.lblStepSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStepSize.Location = New System.Drawing.Point(180, 172)
        Me.lblStepSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStepSize.Name = "lblStepSize"
        Me.lblStepSize.Size = New System.Drawing.Size(68, 17)
        Me.lblStepSize.TabIndex = 28
        Me.lblStepSize.Text = "Step Size"
        '
        'txtStepSize
        '
        Me.txtStepSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStepSize.Location = New System.Drawing.Point(184, 193)
        Me.txtStepSize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtStepSize.Name = "txtStepSize"
        Me.txtStepSize.Size = New System.Drawing.Size(64, 23)
        Me.txtStepSize.TabIndex = 8
        Me.txtStepSize.Text = "2"
        '
        'lblHorizName
        '
        Me.lblHorizName.AutoSize = True
        Me.lblHorizName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorizName.Location = New System.Drawing.Point(136, 78)
        Me.lblHorizName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHorizName.Name = "lblHorizName"
        Me.lblHorizName.Size = New System.Drawing.Size(82, 17)
        Me.lblHorizName.TabIndex = 11
        Me.lblHorizName.Text = "Horiz Name"
        '
        'txtHorizName
        '
        Me.txtHorizName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorizName.Location = New System.Drawing.Point(140, 98)
        Me.txtHorizName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtHorizName.Name = "txtHorizName"
        Me.txtHorizName.Size = New System.Drawing.Size(108, 23)
        Me.txtHorizName.TabIndex = 6
        Me.txtHorizName.Text = "HorizName"
        '
        'lblVertName
        '
        Me.lblVertName.AutoSize = True
        Me.lblVertName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVertName.Location = New System.Drawing.Point(8, 78)
        Me.lblVertName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVertName.Name = "lblVertName"
        Me.lblVertName.Size = New System.Drawing.Size(75, 17)
        Me.lblVertName.TabIndex = 9
        Me.lblVertName.Text = "Vert Name"
        '
        'txtVertName
        '
        Me.txtVertName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVertName.Location = New System.Drawing.Point(8, 98)
        Me.txtVertName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVertName.Name = "txtVertName"
        Me.txtVertName.Size = New System.Drawing.Size(108, 23)
        Me.txtVertName.TabIndex = 5
        Me.txtVertName.Text = "VertName"
        '
        'lblHorizOffset
        '
        Me.lblHorizOffset.AutoSize = True
        Me.lblHorizOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorizOffset.Location = New System.Drawing.Point(136, 21)
        Me.lblHorizOffset.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHorizOffset.Name = "lblHorizOffset"
        Me.lblHorizOffset.Size = New System.Drawing.Size(119, 17)
        Me.lblHorizOffset.TabIndex = 7
        Me.lblHorizOffset.Text = "Horiz Offset (mm)"
        '
        'txtHorizOffset
        '
        Me.txtHorizOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorizOffset.Location = New System.Drawing.Point(140, 42)
        Me.txtHorizOffset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtHorizOffset.Name = "txtHorizOffset"
        Me.txtHorizOffset.Size = New System.Drawing.Size(108, 23)
        Me.txtHorizOffset.TabIndex = 4
        Me.txtHorizOffset.Text = "123.993"
        '
        'lblVertOffset
        '
        Me.lblVertOffset.AutoSize = True
        Me.lblVertOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVertOffset.Location = New System.Drawing.Point(8, 21)
        Me.lblVertOffset.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVertOffset.Name = "lblVertOffset"
        Me.lblVertOffset.Size = New System.Drawing.Size(112, 17)
        Me.lblVertOffset.TabIndex = 5
        Me.lblVertOffset.Text = "Vert Offset (mm)"
        '
        'txtVertOffset
        '
        Me.txtVertOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVertOffset.Location = New System.Drawing.Point(8, 42)
        Me.txtVertOffset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVertOffset.Name = "txtVertOffset"
        Me.txtVertOffset.Size = New System.Drawing.Size(108, 23)
        Me.txtVertOffset.TabIndex = 3
        Me.txtVertOffset.Text = "261.424"
        '
        'lblHorizPos
        '
        Me.lblHorizPos.AutoSize = True
        Me.lblHorizPos.Location = New System.Drawing.Point(656, 84)
        Me.lblHorizPos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHorizPos.Name = "lblHorizPos"
        Me.lblHorizPos.Size = New System.Drawing.Size(69, 17)
        Me.lblHorizPos.TabIndex = 48
        Me.lblHorizPos.Text = "Horiz Pos"
        '
        'txtHorizPos
        '
        Me.txtHorizPos.Location = New System.Drawing.Point(656, 107)
        Me.txtHorizPos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtHorizPos.Name = "txtHorizPos"
        Me.txtHorizPos.Size = New System.Drawing.Size(104, 22)
        Me.txtHorizPos.TabIndex = 47
        '
        'lblStopwatch
        '
        Me.lblStopwatch.AutoSize = True
        Me.lblStopwatch.Location = New System.Drawing.Point(656, 137)
        Me.lblStopwatch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStopwatch.Name = "lblStopwatch"
        Me.lblStopwatch.Size = New System.Drawing.Size(105, 17)
        Me.lblStopwatch.TabIndex = 46
        Me.lblStopwatch.Text = "Stopwatch (ms)"
        '
        'txtStopwatch
        '
        Me.txtStopwatch.Location = New System.Drawing.Point(656, 160)
        Me.txtStopwatch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtStopwatch.Name = "txtStopwatch"
        Me.txtStopwatch.Size = New System.Drawing.Size(104, 22)
        Me.txtStopwatch.TabIndex = 45
        '
        'lblVertPos
        '
        Me.lblVertPos.AutoSize = True
        Me.lblVertPos.Location = New System.Drawing.Point(656, 30)
        Me.lblVertPos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVertPos.Name = "lblVertPos"
        Me.lblVertPos.Size = New System.Drawing.Size(62, 17)
        Me.lblVertPos.TabIndex = 50
        Me.lblVertPos.Text = "Vert Pos"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(661, 566)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(37, 17)
        Me.lblVersion.TabIndex = 51
        Me.lblVersion.Text = "vX.X"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(656, 255)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(100, 34)
        Me.btnReset.TabIndex = 52
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblNumConstraints
        '
        Me.lblNumConstraints.AutoSize = True
        Me.lblNumConstraints.Location = New System.Drawing.Point(656, 196)
        Me.lblNumConstraints.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumConstraints.Name = "lblNumConstraints"
        Me.lblNumConstraints.Size = New System.Drawing.Size(112, 17)
        Me.lblNumConstraints.TabIndex = 54
        Me.lblNumConstraints.Text = "Num Constraints"
        '
        'txtNumConstraints
        '
        Me.txtNumConstraints.Location = New System.Drawing.Point(656, 218)
        Me.txtNumConstraints.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNumConstraints.Name = "txtNumConstraints"
        Me.txtNumConstraints.Size = New System.Drawing.Size(64, 22)
        Me.txtNumConstraints.TabIndex = 53
        Me.txtNumConstraints.Text = "0"
        '
        'frmStepper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 589)
        Me.Controls.Add(Me.lblNumConstraints)
        Me.Controls.Add(Me.txtNumConstraints)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.txtVertPos)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblHorizPos)
        Me.Controls.Add(Me.txtHorizPos)
        Me.Controls.Add(Me.lblStopwatch)
        Me.Controls.Add(Me.txtStopwatch)
        Me.Controls.Add(Me.lblVertPos)
        Me.Controls.Add(Me.lblVersion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(793, 640)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(673, 640)
        Me.Name = "frmStepper"
        Me.Text = "Position Stepper"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.bxSettings.ResumeLayout(False)
        Me.bxSettings.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtVertPos As Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents chkShowDebug As Windows.Forms.CheckBox
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents btnStop As Windows.Forms.Button
    Friend WithEvents btnPlay As Windows.Forms.Button
    Friend WithEvents btnReload As Windows.Forms.Button
    Friend WithEvents lstData As Windows.Forms.ListView
    Friend WithEvents btnBrowse As Windows.Forms.Button
    Friend WithEvents txtFilePath As Windows.Forms.TextBox
    Friend WithEvents lblFilePath As Windows.Forms.Label
    Friend WithEvents btnNextAngle As Windows.Forms.Button
    Friend WithEvents btnPrevAngle As Windows.Forms.Button
    Friend WithEvents bxSettings As Windows.Forms.GroupBox
    Friend WithEvents lblAccelThreshold As Windows.Forms.Label
    Friend WithEvents txtAccelThreshold As Windows.Forms.TextBox
    Friend WithEvents chkIgnoreHoriz As Windows.Forms.CheckBox
    Friend WithEvents btnNameHelp As Windows.Forms.Button
    Friend WithEvents lblStepSize As Windows.Forms.Label
    Friend WithEvents txtStepSize As Windows.Forms.TextBox
    Friend WithEvents lblHorizName As Windows.Forms.Label
    Friend WithEvents txtHorizName As Windows.Forms.TextBox
    Friend WithEvents lblVertName As Windows.Forms.Label
    Friend WithEvents txtVertName As Windows.Forms.TextBox
    Friend WithEvents lblHorizOffset As Windows.Forms.Label
    Friend WithEvents txtHorizOffset As Windows.Forms.TextBox
    Friend WithEvents lblVertOffset As Windows.Forms.Label
    Friend WithEvents txtVertOffset As Windows.Forms.TextBox
    Friend WithEvents lblHorizPos As Windows.Forms.Label
    Friend WithEvents txtHorizPos As Windows.Forms.TextBox
    Friend WithEvents lblStopwatch As Windows.Forms.Label
    Friend WithEvents txtStopwatch As Windows.Forms.TextBox
    Friend WithEvents lblVertPos As Windows.Forms.Label
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents btnReset As Windows.Forms.Button
    Friend WithEvents lblNumConstraints As Windows.Forms.Label
    Friend WithEvents txtNumConstraints As Windows.Forms.TextBox
End Class
