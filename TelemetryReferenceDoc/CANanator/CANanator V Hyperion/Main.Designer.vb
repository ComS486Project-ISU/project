<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ConnectionBar = New System.Windows.Forms.ToolStrip
        Me.Port = New System.Windows.Forms.ToolStripLabel
        Me.cmbPort = New System.Windows.Forms.ToolStripComboBox
        Me.Baud = New System.Windows.Forms.ToolStripLabel
        Me.cmbBaud = New System.Windows.Forms.ToolStripComboBox
        Me.lblEr = New System.Windows.Forms.ToolStripLabel
        Me.lblCANer = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.lblRx = New System.Windows.Forms.ToolStripLabel
        Me.lblCANrx = New System.Windows.Forms.ToolStripLabel
        Me.btnConnect = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.lblTx = New System.Windows.Forms.ToolStripLabel
        Me.lblCANtx = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnResetStats = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tbCANanatorStatus = New System.Windows.Forms.ToolStripTextBox
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.gvVehicleInfo = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvSystemStatus = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpSerial = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TransmittedData = New System.Windows.Forms.GroupBox
        Me.rtbTransmitted = New System.Windows.Forms.RichTextBox
        Me.ReceiveData = New System.Windows.Forms.GroupBox
        Me.rtbReceived = New System.Windows.Forms.RichTextBox
        Me.TransmitData = New System.Windows.Forms.GroupBox
        Me.btnSend = New System.Windows.Forms.Button
        Me.txtTransmit = New System.Windows.Forms.TextBox
        Me.msSerial = New System.Windows.Forms.MenuStrip
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.miClearReceived = New System.Windows.Forms.ToolStripMenuItem
        Me.miClearSent = New System.Windows.Forms.ToolStripMenuItem
        Me.tpCAN = New System.Windows.Forms.TabPage
        Me.lvCAN = New System.Windows.Forms.ListView
        Me.chID = New System.Windows.Forms.ColumnHeader
        Me.chDevice = New System.Windows.Forms.ColumnHeader
        Me.chRTS = New System.Windows.Forms.ColumnHeader
        Me.chSize = New System.Windows.Forms.ColumnHeader
        Me.chByte0 = New System.Windows.Forms.ColumnHeader
        Me.chByte1 = New System.Windows.Forms.ColumnHeader
        Me.chByte2 = New System.Windows.Forms.ColumnHeader
        Me.chByte3 = New System.Windows.Forms.ColumnHeader
        Me.chByte4 = New System.Windows.Forms.ColumnHeader
        Me.chByte5 = New System.Windows.Forms.ColumnHeader
        Me.chByte6 = New System.Windows.Forms.ColumnHeader
        Me.chByte7 = New System.Windows.Forms.ColumnHeader
        Me.chTime = New System.Windows.Forms.ColumnHeader
        Me.msCAN = New System.Windows.Forms.MenuStrip
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox
        Me.tbCANupdate = New System.Windows.Forms.ToolStripTextBox
        Me.miClearMessages = New System.Windows.Forms.ToolStripMenuItem
        Me.tpError = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.msError = New System.Windows.Forms.MenuStrip
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox
        Me.tpVDTS = New System.Windows.Forms.TabPage
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblMagX = New System.Windows.Forms.Label
        Me.lblMagY = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblMagZ = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblAccX = New System.Windows.Forms.Label
        Me.lblAccY = New System.Windows.Forms.Label
        Me.lblAccZ = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblGyroX = New System.Windows.Forms.Label
        Me.lblGyroY = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblGyroZ = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.msVDTS = New System.Windows.Forms.MenuStrip
        Me.ToolStripTextBox5 = New System.Windows.Forms.ToolStripTextBox
        Me.tbVDTSupdate = New System.Windows.Forms.ToolStripTextBox
        Me.tpMotor = New System.Windows.Forms.TabPage
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.lblActualI = New System.Windows.Forms.Label
        Me.lblDesiredI = New System.Windows.Forms.Label
        Me.lblMotorReverse = New System.Windows.Forms.Label
        Me.lblDriveState = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblMotorT = New System.Windows.Forms.Label
        Me.lblControllerT = New System.Windows.Forms.Label
        Me.lblBaseplateT = New System.Windows.Forms.Label
        Me.lblMotorV = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblRegenLimit = New System.Windows.Forms.Label
        Me.lblRegen = New System.Windows.Forms.Label
        Me.lblThrottle = New System.Windows.Forms.Label
        Me.lblThrottleLimit = New System.Windows.Forms.Label
        Me.msMotor = New System.Windows.Forms.MenuStrip
        Me.ToolStripTextBox6 = New System.Windows.Forms.ToolStripTextBox
        Me.tbMotorUpdate = New System.Windows.Forms.ToolStripTextBox
        Me.tpMPPT = New System.Windows.Forms.TabPage
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.lvMPPT = New System.Windows.Forms.ListView
        Me.chMPPT = New System.Windows.Forms.ColumnHeader
        Me.chMPPTcells = New System.Windows.Forms.ColumnHeader
        Me.chMPPTinV = New System.Windows.Forms.ColumnHeader
        Me.chMPPTinI = New System.Windows.Forms.ColumnHeader
        Me.chMPPTinP = New System.Windows.Forms.ColumnHeader
        Me.chMPPTcellP = New System.Windows.Forms.ColumnHeader
        Me.chMPPToutV = New System.Windows.Forms.ColumnHeader
        Me.chMPPTtemp = New System.Windows.Forms.ColumnHeader
        Me.chMPPTtime = New System.Windows.Forms.ColumnHeader
        Me.chMPPTsection = New System.Windows.Forms.ColumnHeader
        Me.msMPPT = New System.Windows.Forms.MenuStrip
        Me.ToolStripTextBox7 = New System.Windows.Forms.ToolStripTextBox
        Me.tbMPPTupdate = New System.Windows.Forms.ToolStripTextBox
        Me.miClearMPPTs = New System.Windows.Forms.ToolStripMenuItem
        Me.tpBPS = New System.Windows.Forms.TabPage
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.lvBPS = New System.Windows.Forms.ListView
        Me.chModule = New System.Windows.Forms.ColumnHeader
        Me.chModuleVoltage = New System.Windows.Forms.ColumnHeader
        Me.chModuleTemp = New System.Windows.Forms.ColumnHeader
        Me.chModuleTime = New System.Windows.Forms.ColumnHeader
        Me.chModuleStatus = New System.Windows.Forms.ColumnHeader
        Me.msBPS = New System.Windows.Forms.MenuStrip
        Me.ToolStripTextBox9 = New System.Windows.Forms.ToolStripTextBox
        Me.tbBPSupdate = New System.Windows.Forms.ToolStripTextBox
        Me.msClearModules = New System.Windows.Forms.ToolStripMenuItem
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.gvRuntimeStats = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gvVehicleVoltage = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConnectionBar.SuspendLayout()
        CType(Me.gvVehicleInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvSystemStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSerial.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TransmittedData.SuspendLayout()
        Me.ReceiveData.SuspendLayout()
        Me.TransmitData.SuspendLayout()
        Me.msSerial.SuspendLayout()
        Me.tpCAN.SuspendLayout()
        Me.msCAN.SuspendLayout()
        Me.tpError.SuspendLayout()
        Me.msError.SuspendLayout()
        Me.tpVDTS.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.msVDTS.SuspendLayout()
        Me.tpMotor.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.msMotor.SuspendLayout()
        Me.tpMPPT.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.msMPPT.SuspendLayout()
        Me.tpBPS.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.msBPS.SuspendLayout()
        Me.TabControl.SuspendLayout()
        CType(Me.gvRuntimeStats, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvVehicleVoltage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ConnectionBar
        '
        Me.ConnectionBar.BackColor = System.Drawing.SystemColors.MenuBar
        Me.ConnectionBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ConnectionBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ConnectionBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Port, Me.cmbPort, Me.Baud, Me.cmbBaud, Me.lblEr, Me.lblCANer, Me.ToolStripSeparator4, Me.lblRx, Me.lblCANrx, Me.btnConnect, Me.ToolStripSeparator3, Me.lblTx, Me.lblCANtx, Me.ToolStripSeparator2, Me.btnResetStats, Me.ToolStripSeparator1, Me.tbCANanatorStatus})
        Me.ConnectionBar.Location = New System.Drawing.Point(0, 731)
        Me.ConnectionBar.Name = "ConnectionBar"
        Me.ConnectionBar.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ConnectionBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ConnectionBar.ShowItemToolTips = False
        Me.ConnectionBar.Size = New System.Drawing.Size(984, 31)
        Me.ConnectionBar.TabIndex = 9
        Me.ConnectionBar.Text = "ToolStrip1"
        '
        'Port
        '
        Me.Port.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Port.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Port.Name = "Port"
        Me.Port.Size = New System.Drawing.Size(31, 23)
        Me.Port.Text = "Port"
        '
        'cmbPort
        '
        Me.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPort.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmbPort.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPort.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(75, 23)
        Me.cmbPort.Sorted = True
        '
        'Baud
        '
        Me.Baud.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Baud.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Baud.Name = "Baud"
        Me.Baud.Size = New System.Drawing.Size(35, 23)
        Me.Baud.Text = "Baud"
        '
        'cmbBaud
        '
        Me.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBaud.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmbBaud.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBaud.Items.AddRange(New Object() {"110", "300", "600", "1200", "2400", "4800", "9600", "11400", "19200", "22800", "38400", "56000", "57600", "115200"})
        Me.cmbBaud.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.cmbBaud.Name = "cmbBaud"
        Me.cmbBaud.Size = New System.Drawing.Size(75, 23)
        '
        'lblEr
        '
        Me.lblEr.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblEr.Name = "lblEr"
        Me.lblEr.Size = New System.Drawing.Size(13, 24)
        Me.lblEr.Text = "0"
        '
        'lblCANer
        '
        Me.lblCANer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblCANer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCANer.Name = "lblCANer"
        Me.lblCANer.Size = New System.Drawing.Size(48, 24)
        Me.lblCANer.Text = "CAN Er:"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'lblRx
        '
        Me.lblRx.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblRx.Name = "lblRx"
        Me.lblRx.Size = New System.Drawing.Size(13, 24)
        Me.lblRx.Text = "0"
        '
        'lblCANrx
        '
        Me.lblCANrx.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblCANrx.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCANrx.Name = "lblCANrx"
        Me.lblCANrx.Size = New System.Drawing.Size(52, 24)
        Me.lblCANrx.Text = "CAN Rx:"
        '
        'btnConnect
        '
        Me.btnConnect.AutoSize = False
        Me.btnConnect.AutoToolTip = False
        Me.btnConnect.BackColor = System.Drawing.Color.White
        Me.btnConnect.Checked = True
        Me.btnConnect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnConnect.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.Image = CType(resources.GetObject("btnConnect.Image"), System.Drawing.Image)
        Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.Text = "Connect"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'lblTx
        '
        Me.lblTx.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTx.Name = "lblTx"
        Me.lblTx.Size = New System.Drawing.Size(13, 24)
        Me.lblTx.Text = "0"
        '
        'lblCANtx
        '
        Me.lblCANtx.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblCANtx.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCANtx.Name = "lblCANtx"
        Me.lblCANtx.Size = New System.Drawing.Size(51, 24)
        Me.lblCANtx.Text = "CAN Tx:"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'btnResetStats
        '
        Me.btnResetStats.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnResetStats.Checked = True
        Me.btnResetStats.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnResetStats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnResetStats.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetStats.Image = CType(resources.GetObject("btnResetStats.Image"), System.Drawing.Image)
        Me.btnResetStats.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnResetStats.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btnResetStats.Name = "btnResetStats"
        Me.btnResetStats.Size = New System.Drawing.Size(74, 23)
        Me.btnResetStats.Text = "Reset Stats"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'tbCANanatorStatus
        '
        Me.tbCANanatorStatus.AutoSize = False
        Me.tbCANanatorStatus.BackColor = System.Drawing.SystemColors.MenuBar
        Me.tbCANanatorStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCANanatorStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCANanatorStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.tbCANanatorStatus.Name = "tbCANanatorStatus"
        Me.tbCANanatorStatus.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tbCANanatorStatus.ReadOnly = True
        Me.tbCANanatorStatus.Size = New System.Drawing.Size(140, 20)
        Me.tbCANanatorStatus.Text = "Disconnected"
        '
        'SerialPort
        '
        Me.SerialPort.BaudRate = 57600
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 1000
        '
        'gvVehicleInfo
        '
        Me.gvVehicleInfo.AllowUserToAddRows = False
        Me.gvVehicleInfo.AllowUserToDeleteRows = False
        Me.gvVehicleInfo.AllowUserToResizeColumns = False
        Me.gvVehicleInfo.AllowUserToResizeRows = False
        Me.gvVehicleInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvVehicleInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gvVehicleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVehicleInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.gvVehicleInfo.Location = New System.Drawing.Point(12, 12)
        Me.gvVehicleInfo.MultiSelect = False
        Me.gvVehicleInfo.Name = "gvVehicleInfo"
        Me.gvVehicleInfo.ReadOnly = True
        Me.gvVehicleInfo.RowHeadersVisible = False
        Me.gvVehicleInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVehicleInfo.Size = New System.Drawing.Size(221, 307)
        Me.gvVehicleInfo.TabIndex = 12
        '
        'Column1
        '
        Me.Column1.HeaderText = "Vehicle Info"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 120
        '
        'Column2
        '
        Me.Column2.HeaderText = "Status"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gvSystemStatus
        '
        Me.gvSystemStatus.AllowUserToAddRows = False
        Me.gvSystemStatus.AllowUserToDeleteRows = False
        Me.gvSystemStatus.AllowUserToResizeColumns = False
        Me.gvSystemStatus.AllowUserToResizeRows = False
        Me.gvSystemStatus.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvSystemStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gvSystemStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvSystemStatus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column3})
        Me.gvSystemStatus.Location = New System.Drawing.Point(713, 12)
        Me.gvSystemStatus.MultiSelect = False
        Me.gvSystemStatus.Name = "gvSystemStatus"
        Me.gvSystemStatus.ReadOnly = True
        Me.gvSystemStatus.RowHeadersVisible = False
        Me.gvSystemStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvSystemStatus.Size = New System.Drawing.Size(176, 87)
        Me.gvSystemStatus.TabIndex = 13
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "System"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Current (A)"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 65
        '
        'Column3
        '
        Me.Column3.HeaderText = "State"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 60
        '
        'tpSerial
        '
        Me.tpSerial.BackColor = System.Drawing.Color.White
        Me.tpSerial.Controls.Add(Me.Panel1)
        Me.tpSerial.Controls.Add(Me.msSerial)
        Me.tpSerial.Location = New System.Drawing.Point(4, 22)
        Me.tpSerial.Name = "tpSerial"
        Me.tpSerial.Size = New System.Drawing.Size(952, 361)
        Me.tpSerial.TabIndex = 6
        Me.tpSerial.Text = "Serial Terminal"
        Me.tpSerial.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TransmittedData)
        Me.Panel1.Controls.Add(Me.ReceiveData)
        Me.Panel1.Controls.Add(Me.TransmitData)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(952, 337)
        Me.Panel1.TabIndex = 11
        '
        'TransmittedData
        '
        Me.TransmittedData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TransmittedData.Controls.Add(Me.rtbTransmitted)
        Me.TransmittedData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransmittedData.Location = New System.Drawing.Point(610, 63)
        Me.TransmittedData.Name = "TransmittedData"
        Me.TransmittedData.Size = New System.Drawing.Size(329, 264)
        Me.TransmittedData.TabIndex = 9
        Me.TransmittedData.TabStop = False
        Me.TransmittedData.Text = "Transmitted Hex Data Bytes"
        '
        'rtbTransmitted
        '
        Me.rtbTransmitted.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbTransmitted.BackColor = System.Drawing.SystemColors.Window
        Me.rtbTransmitted.DetectUrls = False
        Me.rtbTransmitted.Location = New System.Drawing.Point(19, 27)
        Me.rtbTransmitted.Name = "rtbTransmitted"
        Me.rtbTransmitted.ReadOnly = True
        Me.rtbTransmitted.Size = New System.Drawing.Size(289, 219)
        Me.rtbTransmitted.TabIndex = 0
        Me.rtbTransmitted.Text = ""
        '
        'ReceiveData
        '
        Me.ReceiveData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReceiveData.Controls.Add(Me.rtbReceived)
        Me.ReceiveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReceiveData.Location = New System.Drawing.Point(13, 3)
        Me.ReceiveData.Name = "ReceiveData"
        Me.ReceiveData.Size = New System.Drawing.Size(584, 324)
        Me.ReceiveData.TabIndex = 8
        Me.ReceiveData.TabStop = False
        Me.ReceiveData.Text = "Received Hex Data Bytes"
        '
        'rtbReceived
        '
        Me.rtbReceived.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbReceived.BackColor = System.Drawing.SystemColors.Window
        Me.rtbReceived.DetectUrls = False
        Me.rtbReceived.Location = New System.Drawing.Point(19, 27)
        Me.rtbReceived.Name = "rtbReceived"
        Me.rtbReceived.ReadOnly = True
        Me.rtbReceived.Size = New System.Drawing.Size(544, 279)
        Me.rtbReceived.TabIndex = 0
        Me.rtbReceived.Text = ""
        '
        'TransmitData
        '
        Me.TransmitData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TransmitData.Controls.Add(Me.btnSend)
        Me.TransmitData.Controls.Add(Me.txtTransmit)
        Me.TransmitData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransmitData.Location = New System.Drawing.Point(610, 3)
        Me.TransmitData.Name = "TransmitData"
        Me.TransmitData.Size = New System.Drawing.Size(329, 54)
        Me.TransmitData.TabIndex = 7
        Me.TransmitData.TabStop = False
        Me.TransmitData.Text = "Send Data as Hex Bytes"
        '
        'btnSend
        '
        Me.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSend.Location = New System.Drawing.Point(236, 20)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 1
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtTransmit
        '
        Me.txtTransmit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTransmit.Location = New System.Drawing.Point(20, 22)
        Me.txtTransmit.Name = "txtTransmit"
        Me.txtTransmit.Size = New System.Drawing.Size(210, 20)
        Me.txtTransmit.TabIndex = 0
        '
        'msSerial
        '
        Me.msSerial.BackColor = System.Drawing.Color.White
        Me.msSerial.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.miClearReceived, Me.miClearSent})
        Me.msSerial.Location = New System.Drawing.Point(0, 0)
        Me.msSerial.Name = "msSerial"
        Me.msSerial.Size = New System.Drawing.Size(952, 24)
        Me.msSerial.TabIndex = 10
        Me.msSerial.Text = "MenuStrip9"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.ReadOnly = True
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(390, 20)
        Me.ToolStripTextBox1.Text = "Terminal for sending and receiving raw hex data over the serial port."
        '
        'miClearReceived
        '
        Me.miClearReceived.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.miClearReceived.BackColor = System.Drawing.Color.White
        Me.miClearReceived.Name = "miClearReceived"
        Me.miClearReceived.Size = New System.Drawing.Size(96, 20)
        Me.miClearReceived.Text = "Clear Received"
        '
        'miClearSent
        '
        Me.miClearSent.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.miClearSent.Name = "miClearSent"
        Me.miClearSent.Size = New System.Drawing.Size(72, 20)
        Me.miClearSent.Text = "Clear Sent"
        '
        'tpCAN
        '
        Me.tpCAN.BackColor = System.Drawing.Color.White
        Me.tpCAN.Controls.Add(Me.lvCAN)
        Me.tpCAN.Controls.Add(Me.msCAN)
        Me.tpCAN.Location = New System.Drawing.Point(4, 22)
        Me.tpCAN.Name = "tpCAN"
        Me.tpCAN.Size = New System.Drawing.Size(952, 361)
        Me.tpCAN.TabIndex = 0
        Me.tpCAN.Text = "CAN Messages"
        Me.tpCAN.UseVisualStyleBackColor = True
        '
        'lvCAN
        '
        Me.lvCAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvCAN.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chID, Me.chDevice, Me.chRTS, Me.chSize, Me.chByte0, Me.chByte1, Me.chByte2, Me.chByte3, Me.chByte4, Me.chByte5, Me.chByte6, Me.chByte7, Me.chTime})
        Me.lvCAN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCAN.FullRowSelect = True
        Me.lvCAN.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvCAN.LabelWrap = False
        Me.lvCAN.Location = New System.Drawing.Point(0, 24)
        Me.lvCAN.Name = "lvCAN"
        Me.lvCAN.Size = New System.Drawing.Size(952, 337)
        Me.lvCAN.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvCAN.TabIndex = 0
        Me.lvCAN.UseCompatibleStateImageBehavior = False
        Me.lvCAN.View = System.Windows.Forms.View.Details
        '
        'chID
        '
        Me.chID.Text = "ID"
        Me.chID.Width = 50
        '
        'chDevice
        '
        Me.chDevice.Text = "Device"
        '
        'chRTS
        '
        Me.chRTS.Text = "RTS"
        Me.chRTS.Width = 40
        '
        'chSize
        '
        Me.chSize.Text = "Size"
        Me.chSize.Width = 40
        '
        'chByte0
        '
        Me.chByte0.Text = "Byte 0"
        Me.chByte0.Width = 50
        '
        'chByte1
        '
        Me.chByte1.Text = "Byte 1"
        Me.chByte1.Width = 50
        '
        'chByte2
        '
        Me.chByte2.Text = "Byte 2"
        Me.chByte2.Width = 50
        '
        'chByte3
        '
        Me.chByte3.Text = "Byte 3"
        Me.chByte3.Width = 50
        '
        'chByte4
        '
        Me.chByte4.Text = "Byte 4"
        Me.chByte4.Width = 50
        '
        'chByte5
        '
        Me.chByte5.Text = "Byte 5"
        Me.chByte5.Width = 50
        '
        'chByte6
        '
        Me.chByte6.Text = "Byte 6"
        Me.chByte6.Width = 50
        '
        'chByte7
        '
        Me.chByte7.Text = "Byte 7"
        Me.chByte7.Width = 50
        '
        'chTime
        '
        Me.chTime.Text = "Time"
        Me.chTime.Width = 65
        '
        'msCAN
        '
        Me.msCAN.BackColor = System.Drawing.Color.White
        Me.msCAN.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox2, Me.tbCANupdate, Me.miClearMessages})
        Me.msCAN.Location = New System.Drawing.Point(0, 0)
        Me.msCAN.Name = "msCAN"
        Me.msCAN.Size = New System.Drawing.Size(952, 24)
        Me.msCAN.TabIndex = 2
        Me.msCAN.Text = "MenuStrip2"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.ReadOnly = True
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(215, 20)
        Me.ToolStripTextBox2.Text = "Send and receive raw CAN messages."
        '
        'tbCANupdate
        '
        Me.tbCANupdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbCANupdate.AutoSize = False
        Me.tbCANupdate.BackColor = System.Drawing.Color.White
        Me.tbCANupdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCANupdate.Margin = New System.Windows.Forms.Padding(0)
        Me.tbCANupdate.Name = "tbCANupdate"
        Me.tbCANupdate.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tbCANupdate.ReadOnly = True
        Me.tbCANupdate.Size = New System.Drawing.Size(120, 20)
        Me.tbCANupdate.Text = "Last Update: Never"
        Me.tbCANupdate.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'miClearMessages
        '
        Me.miClearMessages.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.miClearMessages.Name = "miClearMessages"
        Me.miClearMessages.Size = New System.Drawing.Size(100, 20)
        Me.miClearMessages.Text = "Clear Messages"
        '
        'tpError
        '
        Me.tpError.BackColor = System.Drawing.Color.White
        Me.tpError.Controls.Add(Me.Panel2)
        Me.tpError.Controls.Add(Me.msError)
        Me.tpError.Location = New System.Drawing.Point(4, 22)
        Me.tpError.Name = "tpError"
        Me.tpError.Size = New System.Drawing.Size(952, 361)
        Me.tpError.TabIndex = 4
        Me.tpError.Text = "Error Log"
        Me.tpError.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(952, 337)
        Me.Panel2.TabIndex = 1
        '
        'msError
        '
        Me.msError.BackColor = System.Drawing.Color.White
        Me.msError.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox3})
        Me.msError.Location = New System.Drawing.Point(0, 0)
        Me.msError.Name = "msError"
        Me.msError.Size = New System.Drawing.Size(952, 24)
        Me.msError.TabIndex = 0
        Me.msError.Text = "MenuStrip8"
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.ReadOnly = True
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(225, 20)
        Me.ToolStripTextBox3.Text = "List of telemetry system error messages."
        '
        'tpVDTS
        '
        Me.tpVDTS.BackColor = System.Drawing.Color.White
        Me.tpVDTS.Controls.Add(Me.Panel4)
        Me.tpVDTS.Controls.Add(Me.msVDTS)
        Me.tpVDTS.Location = New System.Drawing.Point(4, 22)
        Me.tpVDTS.Name = "tpVDTS"
        Me.tpVDTS.Size = New System.Drawing.Size(952, 361)
        Me.tpVDTS.TabIndex = 3
        Me.tpVDTS.Text = "Vehicle Dynamics (VTDS)"
        Me.tpVDTS.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 24)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(952, 337)
        Me.Panel4.TabIndex = 14
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblMagX)
        Me.GroupBox3.Controls.Add(Me.lblMagY)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.lblMagZ)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(506, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(225, 186)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Magnetometer (gauss)"
        '
        'lblMagX
        '
        Me.lblMagX.AutoSize = True
        Me.lblMagX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMagX.Location = New System.Drawing.Point(94, 31)
        Me.lblMagX.Name = "lblMagX"
        Me.lblMagX.Size = New System.Drawing.Size(14, 20)
        Me.lblMagX.TabIndex = 9
        Me.lblMagX.Text = "-"
        '
        'lblMagY
        '
        Me.lblMagY.AutoSize = True
        Me.lblMagY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMagY.Location = New System.Drawing.Point(94, 89)
        Me.lblMagY.Name = "lblMagY"
        Me.lblMagY.Size = New System.Drawing.Size(14, 20)
        Me.lblMagY.TabIndex = 10
        Me.lblMagY.Text = "-"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Z Axis:"
        '
        'lblMagZ
        '
        Me.lblMagZ.AutoSize = True
        Me.lblMagZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMagZ.Location = New System.Drawing.Point(94, 146)
        Me.lblMagZ.Name = "lblMagZ"
        Me.lblMagZ.Size = New System.Drawing.Size(14, 20)
        Me.lblMagZ.TabIndex = 11
        Me.lblMagZ.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "X Axis:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 20)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Y Axis:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAccX)
        Me.GroupBox1.Controls.Add(Me.lblAccY)
        Me.GroupBox1.Controls.Add(Me.lblAccZ)
        Me.GroupBox1.Controls.Add(Me.label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 186)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Accelerometer (g-force)"
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'lblAccX
        '
        Me.lblAccX.AutoSize = True
        Me.lblAccX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccX.Location = New System.Drawing.Point(98, 31)
        Me.lblAccX.Name = "lblAccX"
        Me.lblAccX.Size = New System.Drawing.Size(14, 20)
        Me.lblAccX.TabIndex = 3
        Me.lblAccX.Text = "-"
        '
        'lblAccY
        '
        Me.lblAccY.AutoSize = True
        Me.lblAccY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccY.Location = New System.Drawing.Point(98, 89)
        Me.lblAccY.Name = "lblAccY"
        Me.lblAccY.Size = New System.Drawing.Size(14, 20)
        Me.lblAccY.TabIndex = 4
        Me.lblAccY.Text = "-"
        '
        'lblAccZ
        '
        Me.lblAccZ.AutoSize = True
        Me.lblAccZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccZ.Location = New System.Drawing.Point(98, 146)
        Me.lblAccZ.Name = "lblAccZ"
        Me.lblAccZ.Size = New System.Drawing.Size(14, 20)
        Me.lblAccZ.TabIndex = 5
        Me.lblAccZ.Text = "-"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(32, 31)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(57, 20)
        Me.label1.TabIndex = 0
        Me.label1.Text = "X Axis:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Y Axis:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Z Axis:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblGyroX)
        Me.GroupBox2.Controls.Add(Me.lblGyroY)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblGyroZ)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(263, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(225, 186)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gyroscope (deg/s)"
        '
        'lblGyroX
        '
        Me.lblGyroX.AutoSize = True
        Me.lblGyroX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGyroX.Location = New System.Drawing.Point(95, 31)
        Me.lblGyroX.Name = "lblGyroX"
        Me.lblGyroX.Size = New System.Drawing.Size(14, 20)
        Me.lblGyroX.TabIndex = 6
        Me.lblGyroX.Text = "-"
        '
        'lblGyroY
        '
        Me.lblGyroY.AutoSize = True
        Me.lblGyroY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGyroY.Location = New System.Drawing.Point(95, 89)
        Me.lblGyroY.Name = "lblGyroY"
        Me.lblGyroY.Size = New System.Drawing.Size(14, 20)
        Me.lblGyroY.TabIndex = 7
        Me.lblGyroY.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Z Axis:"
        '
        'lblGyroZ
        '
        Me.lblGyroZ.AutoSize = True
        Me.lblGyroZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGyroZ.Location = New System.Drawing.Point(95, 146)
        Me.lblGyroZ.Name = "lblGyroZ"
        Me.lblGyroZ.Size = New System.Drawing.Size(14, 20)
        Me.lblGyroZ.TabIndex = 8
        Me.lblGyroZ.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "X Axis:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Y Axis:"
        '
        'msVDTS
        '
        Me.msVDTS.BackColor = System.Drawing.Color.White
        Me.msVDTS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox5, Me.tbVDTSupdate})
        Me.msVDTS.Location = New System.Drawing.Point(0, 0)
        Me.msVDTS.Name = "msVDTS"
        Me.msVDTS.Size = New System.Drawing.Size(952, 24)
        Me.msVDTS.TabIndex = 13
        Me.msVDTS.Text = "MenuStrip6"
        '
        'ToolStripTextBox5
        '
        Me.ToolStripTextBox5.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox5.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox5.Name = "ToolStripTextBox5"
        Me.ToolStripTextBox5.ReadOnly = True
        Me.ToolStripTextBox5.Size = New System.Drawing.Size(375, 20)
        Me.ToolStripTextBox5.Text = "Solar car vehicle dynamics information."
        '
        'tbVDTSupdate
        '
        Me.tbVDTSupdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbVDTSupdate.AutoSize = False
        Me.tbVDTSupdate.BackColor = System.Drawing.Color.White
        Me.tbVDTSupdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbVDTSupdate.Margin = New System.Windows.Forms.Padding(0)
        Me.tbVDTSupdate.Name = "tbVDTSupdate"
        Me.tbVDTSupdate.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tbVDTSupdate.ReadOnly = True
        Me.tbVDTSupdate.Size = New System.Drawing.Size(120, 20)
        Me.tbVDTSupdate.Text = "Last Update: Never"
        Me.tbVDTSupdate.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tpMotor
        '
        Me.tpMotor.BackColor = System.Drawing.Color.White
        Me.tpMotor.Controls.Add(Me.Panel5)
        Me.tpMotor.Controls.Add(Me.msMotor)
        Me.tpMotor.Location = New System.Drawing.Point(4, 22)
        Me.tpMotor.Name = "tpMotor"
        Me.tpMotor.Size = New System.Drawing.Size(952, 361)
        Me.tpMotor.TabIndex = 7
        Me.tpMotor.Text = "Motor"
        Me.tpMotor.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.GroupBox6)
        Me.Panel5.Controls.Add(Me.GroupBox5)
        Me.Panel5.Controls.Add(Me.GroupBox4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 24)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(952, 337)
        Me.Panel5.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblActualI)
        Me.GroupBox6.Controls.Add(Me.lblDesiredI)
        Me.GroupBox6.Controls.Add(Me.lblMotorReverse)
        Me.GroupBox6.Controls.Add(Me.lblDriveState)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(14, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(275, 183)
        Me.GroupBox6.TabIndex = 23
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Controller Status"
        Me.GroupBox6.UseCompatibleTextRendering = True
        '
        'lblActualI
        '
        Me.lblActualI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualI.Location = New System.Drawing.Point(6, 149)
        Me.lblActualI.Name = "lblActualI"
        Me.lblActualI.Size = New System.Drawing.Size(263, 25)
        Me.lblActualI.TabIndex = 21
        Me.lblActualI.Text = "Actual Output Current: -"
        Me.lblActualI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDesiredI
        '
        Me.lblDesiredI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesiredI.Location = New System.Drawing.Point(6, 108)
        Me.lblDesiredI.Name = "lblDesiredI"
        Me.lblDesiredI.Size = New System.Drawing.Size(263, 25)
        Me.lblDesiredI.TabIndex = 20
        Me.lblDesiredI.Text = "Desired Output Current: -"
        Me.lblDesiredI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMotorReverse
        '
        Me.lblMotorReverse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotorReverse.Location = New System.Drawing.Point(6, 67)
        Me.lblMotorReverse.Name = "lblMotorReverse"
        Me.lblMotorReverse.Size = New System.Drawing.Size(263, 25)
        Me.lblMotorReverse.TabIndex = 17
        Me.lblMotorReverse.Text = "Drive Direction: -"
        Me.lblMotorReverse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDriveState
        '
        Me.lblDriveState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDriveState.Location = New System.Drawing.Point(6, 27)
        Me.lblDriveState.Name = "lblDriveState"
        Me.lblDriveState.Size = New System.Drawing.Size(263, 25)
        Me.lblDriveState.TabIndex = 16
        Me.lblDriveState.Text = "System State: -"
        Me.lblDriveState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblMotorT)
        Me.GroupBox5.Controls.Add(Me.lblControllerT)
        Me.GroupBox5.Controls.Add(Me.lblBaseplateT)
        Me.GroupBox5.Controls.Add(Me.lblMotorV)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(309, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(213, 183)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Sensors"
        Me.GroupBox5.UseCompatibleTextRendering = True
        '
        'lblMotorT
        '
        Me.lblMotorT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotorT.Location = New System.Drawing.Point(6, 149)
        Me.lblMotorT.Name = "lblMotorT"
        Me.lblMotorT.Size = New System.Drawing.Size(201, 25)
        Me.lblMotorT.TabIndex = 7
        Me.lblMotorT.Text = "Motor Temp: -"
        Me.lblMotorT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblControllerT
        '
        Me.lblControllerT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControllerT.Location = New System.Drawing.Point(6, 108)
        Me.lblControllerT.Name = "lblControllerT"
        Me.lblControllerT.Size = New System.Drawing.Size(201, 25)
        Me.lblControllerT.TabIndex = 6
        Me.lblControllerT.Text = "Controller Temp: -"
        Me.lblControllerT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBaseplateT
        '
        Me.lblBaseplateT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseplateT.Location = New System.Drawing.Point(6, 67)
        Me.lblBaseplateT.Name = "lblBaseplateT"
        Me.lblBaseplateT.Size = New System.Drawing.Size(201, 25)
        Me.lblBaseplateT.TabIndex = 5
        Me.lblBaseplateT.Text = "Baseplate Temp: -"
        Me.lblBaseplateT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMotorV
        '
        Me.lblMotorV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotorV.Location = New System.Drawing.Point(6, 27)
        Me.lblMotorV.Name = "lblMotorV"
        Me.lblMotorV.Size = New System.Drawing.Size(201, 25)
        Me.lblMotorV.TabIndex = 4
        Me.lblMotorV.Text = "Supply Voltage: -"
        Me.lblMotorV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRegenLimit)
        Me.GroupBox4.Controls.Add(Me.lblRegen)
        Me.GroupBox4.Controls.Add(Me.lblThrottle)
        Me.GroupBox4.Controls.Add(Me.lblThrottleLimit)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(540, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(194, 183)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Pedals"
        Me.GroupBox4.UseCompatibleTextRendering = True
        '
        'lblRegenLimit
        '
        Me.lblRegenLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegenLimit.Location = New System.Drawing.Point(7, 149)
        Me.lblRegenLimit.Name = "lblRegenLimit"
        Me.lblRegenLimit.Size = New System.Drawing.Size(181, 25)
        Me.lblRegenLimit.TabIndex = 20
        Me.lblRegenLimit.Text = "Regen Limit Code: -"
        Me.lblRegenLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRegen
        '
        Me.lblRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegen.Location = New System.Drawing.Point(7, 67)
        Me.lblRegen.Name = "lblRegen"
        Me.lblRegen.Size = New System.Drawing.Size(181, 25)
        Me.lblRegen.TabIndex = 19
        Me.lblRegen.Text = "Regen Position: -"
        Me.lblRegen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblThrottle
        '
        Me.lblThrottle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThrottle.Location = New System.Drawing.Point(7, 27)
        Me.lblThrottle.Name = "lblThrottle"
        Me.lblThrottle.Size = New System.Drawing.Size(181, 25)
        Me.lblThrottle.TabIndex = 18
        Me.lblThrottle.Text = "Throttle Position: -"
        Me.lblThrottle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblThrottleLimit
        '
        Me.lblThrottleLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThrottleLimit.Location = New System.Drawing.Point(7, 108)
        Me.lblThrottleLimit.Name = "lblThrottleLimit"
        Me.lblThrottleLimit.Size = New System.Drawing.Size(181, 25)
        Me.lblThrottleLimit.TabIndex = 19
        Me.lblThrottleLimit.Text = "Throttle Limit Code: -"
        Me.lblThrottleLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'msMotor
        '
        Me.msMotor.BackColor = System.Drawing.Color.White
        Me.msMotor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox6, Me.tbMotorUpdate})
        Me.msMotor.Location = New System.Drawing.Point(0, 0)
        Me.msMotor.Name = "msMotor"
        Me.msMotor.Size = New System.Drawing.Size(952, 24)
        Me.msMotor.TabIndex = 0
        Me.msMotor.Text = "MenuStrip5"
        '
        'ToolStripTextBox6
        '
        Me.ToolStripTextBox6.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox6.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox6.Name = "ToolStripTextBox6"
        Me.ToolStripTextBox6.ReadOnly = True
        Me.ToolStripTextBox6.Size = New System.Drawing.Size(200, 20)
        Me.ToolStripTextBox6.Text = "Motor and controller information."
        '
        'tbMotorUpdate
        '
        Me.tbMotorUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbMotorUpdate.AutoSize = False
        Me.tbMotorUpdate.BackColor = System.Drawing.Color.White
        Me.tbMotorUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbMotorUpdate.Margin = New System.Windows.Forms.Padding(0)
        Me.tbMotorUpdate.Name = "tbMotorUpdate"
        Me.tbMotorUpdate.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tbMotorUpdate.ReadOnly = True
        Me.tbMotorUpdate.Size = New System.Drawing.Size(120, 20)
        Me.tbMotorUpdate.Text = "Last Update: Never"
        Me.tbMotorUpdate.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tpMPPT
        '
        Me.tpMPPT.BackColor = System.Drawing.Color.White
        Me.tpMPPT.Controls.Add(Me.Panel6)
        Me.tpMPPT.Controls.Add(Me.msMPPT)
        Me.tpMPPT.Location = New System.Drawing.Point(4, 22)
        Me.tpMPPT.Name = "tpMPPT"
        Me.tpMPPT.Size = New System.Drawing.Size(952, 361)
        Me.tpMPPT.TabIndex = 2
        Me.tpMPPT.Text = "Power Trackers (MPPT)"
        Me.tpMPPT.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lvMPPT)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 24)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(952, 337)
        Me.Panel6.TabIndex = 1
        '
        'lvMPPT
        '
        Me.lvMPPT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvMPPT.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chMPPT, Me.chMPPTcells, Me.chMPPTinV, Me.chMPPTinI, Me.chMPPTinP, Me.chMPPTcellP, Me.chMPPToutV, Me.chMPPTtemp, Me.chMPPTtime, Me.chMPPTsection})
        Me.lvMPPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvMPPT.FullRowSelect = True
        Me.lvMPPT.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvMPPT.LabelWrap = False
        Me.lvMPPT.Location = New System.Drawing.Point(0, 0)
        Me.lvMPPT.Name = "lvMPPT"
        Me.lvMPPT.Size = New System.Drawing.Size(952, 337)
        Me.lvMPPT.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvMPPT.TabIndex = 2
        Me.lvMPPT.UseCompatibleStateImageBehavior = False
        Me.lvMPPT.View = System.Windows.Forms.View.Details
        '
        'chMPPT
        '
        Me.chMPPT.Text = "MPPT"
        Me.chMPPT.Width = 45
        '
        'chMPPTcells
        '
        Me.chMPPTcells.Text = "Cells"
        Me.chMPPTcells.Width = 40
        '
        'chMPPTinV
        '
        Me.chMPPTinV.Text = "Vin (V)"
        Me.chMPPTinV.Width = 45
        '
        'chMPPTinI
        '
        Me.chMPPTinI.Text = "Iin (A)"
        Me.chMPPTinI.Width = 40
        '
        'chMPPTinP
        '
        Me.chMPPTinP.Text = "Pin (W)"
        Me.chMPPTinP.Width = 50
        '
        'chMPPTcellP
        '
        Me.chMPPTcellP.Text = "Pcell (W)"
        '
        'chMPPToutV
        '
        Me.chMPPToutV.Text = "Vout (V)"
        Me.chMPPToutV.Width = 50
        '
        'chMPPTtemp
        '
        Me.chMPPTtemp.Text = "Temp (°C)"
        '
        'chMPPTtime
        '
        Me.chMPPTtime.Text = "Time"
        Me.chMPPTtime.Width = 65
        '
        'chMPPTsection
        '
        Me.chMPPTsection.Text = "Section"
        Me.chMPPTsection.Width = 200
        '
        'msMPPT
        '
        Me.msMPPT.BackColor = System.Drawing.Color.White
        Me.msMPPT.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox7, Me.tbMPPTupdate, Me.miClearMPPTs})
        Me.msMPPT.Location = New System.Drawing.Point(0, 0)
        Me.msMPPT.Name = "msMPPT"
        Me.msMPPT.Size = New System.Drawing.Size(952, 24)
        Me.msMPPT.TabIndex = 0
        Me.msMPPT.Text = "MenuStrip4"
        '
        'ToolStripTextBox7
        '
        Me.ToolStripTextBox7.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox7.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox7.Name = "ToolStripTextBox7"
        Me.ToolStripTextBox7.ReadOnly = True
        Me.ToolStripTextBox7.Size = New System.Drawing.Size(250, 20)
        Me.ToolStripTextBox7.Text = "Maximum power point tracker information."
        '
        'tbMPPTupdate
        '
        Me.tbMPPTupdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbMPPTupdate.AutoSize = False
        Me.tbMPPTupdate.BackColor = System.Drawing.Color.White
        Me.tbMPPTupdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbMPPTupdate.Margin = New System.Windows.Forms.Padding(0)
        Me.tbMPPTupdate.Name = "tbMPPTupdate"
        Me.tbMPPTupdate.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tbMPPTupdate.ReadOnly = True
        Me.tbMPPTupdate.Size = New System.Drawing.Size(120, 20)
        Me.tbMPPTupdate.Text = "Last Update: Never"
        Me.tbMPPTupdate.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'miClearMPPTs
        '
        Me.miClearMPPTs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.miClearMPPTs.Name = "miClearMPPTs"
        Me.miClearMPPTs.Size = New System.Drawing.Size(86, 20)
        Me.miClearMPPTs.Text = "Clear MPPTs"
        '
        'tpBPS
        '
        Me.tpBPS.BackColor = System.Drawing.Color.White
        Me.tpBPS.Controls.Add(Me.Panel7)
        Me.tpBPS.Controls.Add(Me.msBPS)
        Me.tpBPS.Location = New System.Drawing.Point(4, 22)
        Me.tpBPS.Name = "tpBPS"
        Me.tpBPS.Size = New System.Drawing.Size(952, 361)
        Me.tpBPS.TabIndex = 1
        Me.tpBPS.Text = "Battery Protection (BPS)"
        Me.tpBPS.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lvBPS)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 24)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(952, 337)
        Me.Panel7.TabIndex = 1
        '
        'lvBPS
        '
        Me.lvBPS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvBPS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chModule, Me.chModuleVoltage, Me.chModuleTemp, Me.chModuleTime, Me.chModuleStatus})
        Me.lvBPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvBPS.FullRowSelect = True
        Me.lvBPS.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvBPS.LabelWrap = False
        Me.lvBPS.Location = New System.Drawing.Point(0, 0)
        Me.lvBPS.Name = "lvBPS"
        Me.lvBPS.Size = New System.Drawing.Size(952, 337)
        Me.lvBPS.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvBPS.TabIndex = 1
        Me.lvBPS.UseCompatibleStateImageBehavior = False
        Me.lvBPS.View = System.Windows.Forms.View.Details
        '
        'chModule
        '
        Me.chModule.Text = "Module"
        Me.chModule.Width = 50
        '
        'chModuleVoltage
        '
        Me.chModuleVoltage.Text = "Voltage (V)"
        Me.chModuleVoltage.Width = 65
        '
        'chModuleTemp
        '
        Me.chModuleTemp.Text = "Temp (°C)"
        '
        'chModuleTime
        '
        Me.chModuleTime.Text = "Time"
        Me.chModuleTime.Width = 65
        '
        'chModuleStatus
        '
        Me.chModuleStatus.Text = "Status"
        Me.chModuleStatus.Width = 360
        '
        'msBPS
        '
        Me.msBPS.BackColor = System.Drawing.Color.White
        Me.msBPS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox9, Me.tbBPSupdate, Me.msClearModules})
        Me.msBPS.Location = New System.Drawing.Point(0, 0)
        Me.msBPS.Name = "msBPS"
        Me.msBPS.Size = New System.Drawing.Size(952, 24)
        Me.msBPS.TabIndex = 0
        Me.msBPS.Text = "MenuStrip3"
        '
        'ToolStripTextBox9
        '
        Me.ToolStripTextBox9.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox9.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox9.Name = "ToolStripTextBox9"
        Me.ToolStripTextBox9.ReadOnly = True
        Me.ToolStripTextBox9.Size = New System.Drawing.Size(220, 20)
        Me.ToolStripTextBox9.Text = "Battery protection system information."
        '
        'tbBPSupdate
        '
        Me.tbBPSupdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tbBPSupdate.AutoSize = False
        Me.tbBPSupdate.BackColor = System.Drawing.Color.White
        Me.tbBPSupdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbBPSupdate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBPSupdate.Margin = New System.Windows.Forms.Padding(0)
        Me.tbBPSupdate.Name = "tbBPSupdate"
        Me.tbBPSupdate.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tbBPSupdate.ReadOnly = True
        Me.tbBPSupdate.Size = New System.Drawing.Size(120, 20)
        Me.tbBPSupdate.Text = "Last Update: Never"
        Me.tbBPSupdate.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'msClearModules
        '
        Me.msClearModules.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.msClearModules.Name = "msClearModules"
        Me.msClearModules.Size = New System.Drawing.Size(95, 20)
        Me.msClearModules.Text = "Clear Modules"
        '
        'TabControl
        '
        Me.TabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl.Controls.Add(Me.tpBPS)
        Me.TabControl.Controls.Add(Me.tpMPPT)
        Me.TabControl.Controls.Add(Me.tpMotor)
        Me.TabControl.Controls.Add(Me.tpVDTS)
        Me.TabControl.Controls.Add(Me.tpError)
        Me.TabControl.Controls.Add(Me.tpCAN)
        Me.TabControl.Controls.Add(Me.tpSerial)
        Me.TabControl.Location = New System.Drawing.Point(12, 330)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(960, 387)
        Me.TabControl.TabIndex = 10
        Me.TabControl.TabStop = False
        '
        'gvRuntimeStats
        '
        Me.gvRuntimeStats.AllowUserToAddRows = False
        Me.gvRuntimeStats.AllowUserToDeleteRows = False
        Me.gvRuntimeStats.AllowUserToResizeColumns = False
        Me.gvRuntimeStats.AllowUserToResizeRows = False
        Me.gvRuntimeStats.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvRuntimeStats.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gvRuntimeStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvRuntimeStats.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.Column7, Me.Column4, Me.Column5, Me.Column6})
        Me.gvRuntimeStats.Location = New System.Drawing.Point(247, 12)
        Me.gvRuntimeStats.MultiSelect = False
        Me.gvRuntimeStats.Name = "gvRuntimeStats"
        Me.gvRuntimeStats.ReadOnly = True
        Me.gvRuntimeStats.RowHeadersVisible = False
        Me.gvRuntimeStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvRuntimeStats.Size = New System.Drawing.Size(451, 307)
        Me.gvRuntimeStats.TabIndex = 14
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Runtime Stats"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Now"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'Column7
        '
        Me.Column7.HeaderText = "Recent"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "Average"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 60
        '
        'Column5
        '
        Me.Column5.HeaderText = "Max"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 60
        '
        'Column6
        '
        Me.Column6.HeaderText = "Min"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 60
        '
        'gvVehicleVoltage
        '
        Me.gvVehicleVoltage.AllowUserToAddRows = False
        Me.gvVehicleVoltage.AllowUserToDeleteRows = False
        Me.gvVehicleVoltage.AllowUserToResizeColumns = False
        Me.gvVehicleVoltage.AllowUserToResizeRows = False
        Me.gvVehicleVoltage.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvVehicleVoltage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gvVehicleVoltage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVehicleVoltage.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6})
        Me.gvVehicleVoltage.Location = New System.Drawing.Point(713, 100)
        Me.gvVehicleVoltage.MultiSelect = False
        Me.gvVehicleVoltage.Name = "gvVehicleVoltage"
        Me.gvVehicleVoltage.ReadOnly = True
        Me.gvVehicleVoltage.RowHeadersVisible = False
        Me.gvVehicleVoltage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvVehicleVoltage.Size = New System.Drawing.Size(176, 219)
        Me.gvVehicleVoltage.TabIndex = 30
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Vehicle Voltage"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 115
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(984, 762)
        Me.Controls.Add(Me.gvVehicleVoltage)
        Me.Controls.Add(Me.gvRuntimeStats)
        Me.Controls.Add(Me.gvSystemStatus)
        Me.Controls.Add(Me.gvVehicleInfo)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.ConnectionBar)
        Me.DoubleBuffered = True
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CANanator V"
        Me.ConnectionBar.ResumeLayout(False)
        Me.ConnectionBar.PerformLayout()
        CType(Me.gvVehicleInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvSystemStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSerial.ResumeLayout(False)
        Me.tpSerial.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TransmittedData.ResumeLayout(False)
        Me.ReceiveData.ResumeLayout(False)
        Me.TransmitData.ResumeLayout(False)
        Me.TransmitData.PerformLayout()
        Me.msSerial.ResumeLayout(False)
        Me.msSerial.PerformLayout()
        Me.tpCAN.ResumeLayout(False)
        Me.tpCAN.PerformLayout()
        Me.msCAN.ResumeLayout(False)
        Me.msCAN.PerformLayout()
        Me.tpError.ResumeLayout(False)
        Me.tpError.PerformLayout()
        Me.msError.ResumeLayout(False)
        Me.msError.PerformLayout()
        Me.tpVDTS.ResumeLayout(False)
        Me.tpVDTS.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.msVDTS.ResumeLayout(False)
        Me.msVDTS.PerformLayout()
        Me.tpMotor.ResumeLayout(False)
        Me.tpMotor.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.msMotor.ResumeLayout(False)
        Me.msMotor.PerformLayout()
        Me.tpMPPT.ResumeLayout(False)
        Me.tpMPPT.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.msMPPT.ResumeLayout(False)
        Me.msMPPT.PerformLayout()
        Me.tpBPS.ResumeLayout(False)
        Me.tpBPS.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.msBPS.ResumeLayout(False)
        Me.msBPS.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        CType(Me.gvRuntimeStats, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvVehicleVoltage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConnectionBar As System.Windows.Forms.ToolStrip
    Friend WithEvents cmbPort As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cmbBaud As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Port As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Baud As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCANrx As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblCANtx As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblRx As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTx As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents btnResetStats As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gvVehicleInfo As System.Windows.Forms.DataGridView
    Friend WithEvents gvSystemStatus As System.Windows.Forms.DataGridView
    Friend WithEvents tpSerial As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TransmittedData As System.Windows.Forms.GroupBox
    Friend WithEvents rtbTransmitted As System.Windows.Forms.RichTextBox
    Friend WithEvents ReceiveData As System.Windows.Forms.GroupBox
    Friend WithEvents rtbReceived As System.Windows.Forms.RichTextBox
    Friend WithEvents TransmitData As System.Windows.Forms.GroupBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents txtTransmit As System.Windows.Forms.TextBox
    Friend WithEvents msSerial As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents miClearReceived As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miClearSent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tpCAN As System.Windows.Forms.TabPage
    Friend WithEvents lvCAN As System.Windows.Forms.ListView
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDevice As System.Windows.Forms.ColumnHeader
    Friend WithEvents chRTS As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents chByte0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chByte1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chByte2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chByte3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chByte4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chByte5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chByte6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chByte7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents msCAN As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tbCANupdate As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents miClearMessages As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tpError As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents msError As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tpVDTS As System.Windows.Forms.TabPage
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMagX As System.Windows.Forms.Label
    Friend WithEvents lblMagY As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblMagZ As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAccX As System.Windows.Forms.Label
    Friend WithEvents lblAccY As System.Windows.Forms.Label
    Friend WithEvents lblAccZ As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblGyroX As System.Windows.Forms.Label
    Friend WithEvents lblGyroY As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblGyroZ As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents msVDTS As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripTextBox5 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tbVDTSupdate As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tpMotor As System.Windows.Forms.TabPage
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMotorReverse As System.Windows.Forms.Label
    Friend WithEvents lblThrottleLimit As System.Windows.Forms.Label
    Friend WithEvents lblDriveState As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMotorT As System.Windows.Forms.Label
    Friend WithEvents lblControllerT As System.Windows.Forms.Label
    Friend WithEvents lblBaseplateT As System.Windows.Forms.Label
    Friend WithEvents lblMotorV As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRegen As System.Windows.Forms.Label
    Friend WithEvents lblThrottle As System.Windows.Forms.Label
    Friend WithEvents msMotor As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripTextBox6 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tbMotorUpdate As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tpMPPT As System.Windows.Forms.TabPage
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lvMPPT As System.Windows.Forms.ListView
    Friend WithEvents chMPPT As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMPPTinV As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMPPTinI As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMPPTinP As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMPPToutV As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMPPTtemp As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMPPTtime As System.Windows.Forms.ColumnHeader
    Friend WithEvents msMPPT As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripTextBox7 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tbMPPTupdate As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents miClearMPPTs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tpBPS As System.Windows.Forms.TabPage
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lvBPS As System.Windows.Forms.ListView
    Friend WithEvents chModule As System.Windows.Forms.ColumnHeader
    Friend WithEvents chModuleVoltage As System.Windows.Forms.ColumnHeader
    Friend WithEvents chModuleTemp As System.Windows.Forms.ColumnHeader
    Friend WithEvents chModuleTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents chModuleStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents msBPS As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripTextBox9 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tbBPSupdate As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents msClearModules As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbCANanatorStatus As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents gvRuntimeStats As System.Windows.Forms.DataGridView
    Friend WithEvents lblActualI As System.Windows.Forms.Label
    Friend WithEvents lblDesiredI As System.Windows.Forms.Label
    Friend WithEvents lblRegenLimit As System.Windows.Forms.Label
    Friend WithEvents gvVehicleVoltage As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblEr As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblCANer As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chMPPTsection As System.Windows.Forms.ColumnHeader
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chMPPTcells As System.Windows.Forms.ColumnHeader
    Friend WithEvents chMPPTcellP As System.Windows.Forms.ColumnHeader

End Class
