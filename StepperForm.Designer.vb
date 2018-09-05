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
        Me.chkLoop = New System.Windows.Forms.CheckBox()
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
        Me.lblCurrentIndex = New System.Windows.Forms.Label()
        Me.lblHorizPos = New System.Windows.Forms.Label()
        Me.txtHorizPos = New System.Windows.Forms.TextBox()
        Me.lblStopwatch = New System.Windows.Forms.Label()
        Me.txtStopwatch = New System.Windows.Forms.TextBox()
        Me.lblVertPos = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.txtCurrentIndex = New System.Windows.Forms.TextBox()
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
        Me.txtVertPos.Location = New System.Drawing.Point(497, 43)
        Me.txtVertPos.Name = "txtVertPos"
        Me.txtVertPos.Size = New System.Drawing.Size(79, 20)
        Me.txtVertPos.TabIndex = 49
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(485, 475)
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
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(477, 449)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Step Tool"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkShowDebug
        '
        Me.chkShowDebug.AutoSize = True
        Me.chkShowDebug.Location = New System.Drawing.Point(12, 418)
        Me.chkShowDebug.Name = "chkShowDebug"
        Me.chkShowDebug.Size = New System.Drawing.Size(107, 17)
        Me.chkShowDebug.TabIndex = 36
        Me.chkShowDebug.Text = "Show More Info?"
        Me.chkShowDebug.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(133, 404)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 34)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkLoop)
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnPlay)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 306)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 86)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "AutoPlay"
        '
        'chkLoop
        '
        Me.chkLoop.AutoSize = True
        Me.chkLoop.Checked = True
        Me.chkLoop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLoop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLoop.Location = New System.Drawing.Point(7, 62)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(56, 17)
        Me.chkLoop.TabIndex = 15
        Me.chkLoop.Text = "Loop?"
        Me.chkLoop.UseVisualStyleBackColor = True
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
        'lstData
        '
        Me.lstData.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstData.BackColor = System.Drawing.SystemColors.Window
        Me.lstData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstData.FullRowSelect = True
        Me.lstData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstData.Location = New System.Drawing.Point(218, 51)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(250, 380)
        Me.lstData.TabIndex = 32
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
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
        Me.btnNextAngle.Location = New System.Drawing.Point(115, 238)
        Me.btnNextAngle.Name = "btnNextAngle"
        Me.btnNextAngle.Size = New System.Drawing.Size(97, 52)
        Me.btnNextAngle.TabIndex = 12
        Me.btnNextAngle.Text = "Next Angle"
        Me.btnNextAngle.UseVisualStyleBackColor = True
        '
        'btnPrevAngle
        '
        Me.btnPrevAngle.Location = New System.Drawing.Point(8, 238)
        Me.btnPrevAngle.Name = "btnPrevAngle"
        Me.btnPrevAngle.Size = New System.Drawing.Size(97, 52)
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
        Me.bxSettings.Location = New System.Drawing.Point(8, 48)
        Me.bxSettings.Name = "bxSettings"
        Me.bxSettings.Size = New System.Drawing.Size(200, 186)
        Me.bxSettings.TabIndex = 3
        Me.bxSettings.TabStop = False
        Me.bxSettings.Text = "Settings"
        '
        'lblAccelThreshold
        '
        Me.lblAccelThreshold.AutoSize = True
        Me.lblAccelThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccelThreshold.Location = New System.Drawing.Point(6, 140)
        Me.lblAccelThreshold.Name = "lblAccelThreshold"
        Me.lblAccelThreshold.Size = New System.Drawing.Size(84, 13)
        Me.lblAccelThreshold.TabIndex = 38
        Me.lblAccelThreshold.Text = "Accel Threshold"
        '
        'txtAccelThreshold
        '
        Me.txtAccelThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccelThreshold.Location = New System.Drawing.Point(9, 157)
        Me.txtAccelThreshold.Name = "txtAccelThreshold"
        Me.txtAccelThreshold.Size = New System.Drawing.Size(76, 20)
        Me.txtAccelThreshold.TabIndex = 7
        Me.txtAccelThreshold.Text = "9"
        '
        'chkIgnoreHoriz
        '
        Me.chkIgnoreHoriz.AutoSize = True
        Me.chkIgnoreHoriz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIgnoreHoriz.Location = New System.Drawing.Point(105, 108)
        Me.chkIgnoreHoriz.Name = "chkIgnoreHoriz"
        Me.chkIgnoreHoriz.Size = New System.Drawing.Size(89, 17)
        Me.chkIgnoreHoriz.TabIndex = 10
        Me.chkIgnoreHoriz.Text = "Ignore Horiz?"
        Me.chkIgnoreHoriz.UseVisualStyleBackColor = True
        '
        'btnNameHelp
        '
        Me.btnNameHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNameHelp.Location = New System.Drawing.Point(6, 108)
        Me.btnNameHelp.Name = "btnNameHelp"
        Me.btnNameHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnNameHelp.TabIndex = 9
        Me.btnNameHelp.Text = "Name Help"
        Me.btnNameHelp.UseVisualStyleBackColor = True
        '
        'lblStepSize
        '
        Me.lblStepSize.AutoSize = True
        Me.lblStepSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStepSize.Location = New System.Drawing.Point(135, 140)
        Me.lblStepSize.Name = "lblStepSize"
        Me.lblStepSize.Size = New System.Drawing.Size(52, 13)
        Me.lblStepSize.TabIndex = 28
        Me.lblStepSize.Text = "Step Size"
        '
        'txtStepSize
        '
        Me.txtStepSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStepSize.Location = New System.Drawing.Point(138, 157)
        Me.txtStepSize.Name = "txtStepSize"
        Me.txtStepSize.Size = New System.Drawing.Size(49, 20)
        Me.txtStepSize.TabIndex = 8
        Me.txtStepSize.Text = "2"
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
        'lblCurrentIndex
        '
        Me.lblCurrentIndex.AutoSize = True
        Me.lblCurrentIndex.Location = New System.Drawing.Point(496, 408)
        Me.lblCurrentIndex.Name = "lblCurrentIndex"
        Me.lblCurrentIndex.Size = New System.Drawing.Size(70, 13)
        Me.lblCurrentIndex.TabIndex = 43
        Me.lblCurrentIndex.Text = "Current Index"
        '
        'lblHorizPos
        '
        Me.lblHorizPos.AutoSize = True
        Me.lblHorizPos.Location = New System.Drawing.Point(496, 68)
        Me.lblHorizPos.Name = "lblHorizPos"
        Me.lblHorizPos.Size = New System.Drawing.Size(52, 13)
        Me.lblHorizPos.TabIndex = 48
        Me.lblHorizPos.Text = "Horiz Pos"
        '
        'txtHorizPos
        '
        Me.txtHorizPos.Location = New System.Drawing.Point(497, 87)
        Me.txtHorizPos.Name = "txtHorizPos"
        Me.txtHorizPos.Size = New System.Drawing.Size(79, 20)
        Me.txtHorizPos.TabIndex = 47
        '
        'lblStopwatch
        '
        Me.lblStopwatch.AutoSize = True
        Me.lblStopwatch.Location = New System.Drawing.Point(496, 111)
        Me.lblStopwatch.Name = "lblStopwatch"
        Me.lblStopwatch.Size = New System.Drawing.Size(80, 13)
        Me.lblStopwatch.TabIndex = 46
        Me.lblStopwatch.Text = "Stopwatch (ms)"
        '
        'txtStopwatch
        '
        Me.txtStopwatch.Location = New System.Drawing.Point(497, 130)
        Me.txtStopwatch.Name = "txtStopwatch"
        Me.txtStopwatch.Size = New System.Drawing.Size(79, 20)
        Me.txtStopwatch.TabIndex = 45
        '
        'lblVertPos
        '
        Me.lblVertPos.AutoSize = True
        Me.lblVertPos.Location = New System.Drawing.Point(496, 24)
        Me.lblVertPos.Name = "lblVertPos"
        Me.lblVertPos.Size = New System.Drawing.Size(47, 13)
        Me.lblVertPos.TabIndex = 50
        Me.lblVertPos.Text = "Vert Pos"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(496, 460)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(30, 13)
        Me.lblVersion.TabIndex = 51
        Me.lblVersion.Text = "vX.X"
        '
        'txtCurrentIndex
        '
        Me.txtCurrentIndex.Location = New System.Drawing.Point(496, 428)
        Me.txtCurrentIndex.Name = "txtCurrentIndex"
        Me.txtCurrentIndex.Size = New System.Drawing.Size(49, 20)
        Me.txtCurrentIndex.TabIndex = 42
        Me.txtCurrentIndex.Text = "0"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(496, 169)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 28)
        Me.btnReset.TabIndex = 52
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblNumConstraints
        '
        Me.lblNumConstraints.AutoSize = True
        Me.lblNumConstraints.Location = New System.Drawing.Point(494, 361)
        Me.lblNumConstraints.Name = "lblNumConstraints"
        Me.lblNumConstraints.Size = New System.Drawing.Size(84, 13)
        Me.lblNumConstraints.TabIndex = 54
        Me.lblNumConstraints.Text = "Num Constraints"
        '
        'txtNumConstraints
        '
        Me.txtNumConstraints.Location = New System.Drawing.Point(494, 381)
        Me.txtNumConstraints.Name = "txtNumConstraints"
        Me.txtNumConstraints.Size = New System.Drawing.Size(49, 20)
        Me.txtNumConstraints.TabIndex = 53
        Me.txtNumConstraints.Text = "0"
        '
        'frmStepper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 482)
        Me.Controls.Add(Me.lblNumConstraints)
        Me.Controls.Add(Me.txtNumConstraints)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.txtVertPos)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblCurrentIndex)
        Me.Controls.Add(Me.lblHorizPos)
        Me.Controls.Add(Me.txtHorizPos)
        Me.Controls.Add(Me.lblStopwatch)
        Me.Controls.Add(Me.txtStopwatch)
        Me.Controls.Add(Me.lblVertPos)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.txtCurrentIndex)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 525)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(510, 525)
        Me.Name = "frmStepper"
        Me.Text = "Position Stepper"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents chkLoop As Windows.Forms.CheckBox
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
    Friend WithEvents lblCurrentIndex As Windows.Forms.Label
    Friend WithEvents lblHorizPos As Windows.Forms.Label
    Friend WithEvents txtHorizPos As Windows.Forms.TextBox
    Friend WithEvents lblStopwatch As Windows.Forms.Label
    Friend WithEvents txtStopwatch As Windows.Forms.TextBox
    Friend WithEvents lblVertPos As Windows.Forms.Label
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents txtCurrentIndex As Windows.Forms.TextBox
    Friend WithEvents btnReset As Windows.Forms.Button
    Friend WithEvents lblNumConstraints As Windows.Forms.Label
    Friend WithEvents txtNumConstraints As Windows.Forms.TextBox
End Class
