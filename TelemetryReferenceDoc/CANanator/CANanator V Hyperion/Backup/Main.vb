Public Class Main

#Region "Public Variable Declarations"

    'Constants
    Public Pi As Double = 4 * Math.Atan(1) 'Pi calculation
    Public TireDiameter As Single = 18.5 'Tire diameter for MPH calculation
    'Serial port variables
    Public splitBuffer As Boolean = 0 'Indicates that a CAN message is split between two or more serial buffers
    Public tempBuffer As Byte() 'Temporary byte array used when CAN messages are split between two or more serial buffers
    Public tempSize As Byte 'Temporary buffer size
    Public SerialControl As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False) 'Allows the serial thread to be paused while the GUI is updated
    'Timer counter
    Public TimerA As Byte = 0 'Initialize Timer A counter
    Public TimerAReset As Byte = 5 'Control the reset speed of Timer A
    'CAN message variables
    Public CANactive As Boolean = False 'Used to determine if non-RTS can messages are present
    Public CANstart As Integer = 0 'Marks the start byte for CAN message decoding
    Public CANvalid As Boolean = 0 'Determines the validity of a CAN message
    Public CANmessage() As Byte = New Byte(13) {} 'Standard PrISUm CAN message (14 byte array)
    Public ID As Short = 0 'CAN message ID (2 bytes)
    Public RTS As Byte = 0 'CAN message RTS (request to send) byte
    Public MessageSize As Short = 0 'Determine the number of data bytes in the message
    Public CANdata() As Byte = New Byte(7) {} 'CAN message data array (up to 8 bytes)
    Public CANtime As Date = Now 'The time that a CAN message was received
    Public CANtimeNonRTS As Date = Now 'The last time a non-RTS CAN message was received
    'Device CAN ID range
    Public bpsLow As UShort = 256 'Lowest BPS CAN ID
    Public bpsHigh As UShort = 324 'Highest BPS CAN ID
    Public FirstModule As UShort = 257 'Lowest battery module info CAN ID
    Public LastModule As UShort = 283 'Highest possible battery module info CAN ID
    Public motorLow As UShort = 768 'Lowerst Motor CAN ID
    Public motorHigh As UShort = 775 'Highest Motor CAN ID
    Public vdtsLow As UShort = 1280 'Lowest VDTS CAN ID
    Public vdtsHigh As UShort = 1283 'Highest VDTS CAN ID
    Public mpptLow As UShort = 1536 'Lowest MPPT ID
    Public mpptHigh As UShort = 1567 'Highest MPPT ID
    Public FirstMPPT As UShort = 1536 'Lowest MPPT info CAN ID
    Public LastMPPT As UShort = 1551 'Highest possible MPPT info CAN ID
    Public dashLow As UShort = 1920 'Lowest Dash ID
    Public dashHigh As UShort = 1920 'Highest Dash ID
    'VDTS
    Public AccScale As Single = 4 / 1000 'Accelerometer scale
    Public GyroScale As Single = 1 / 14.375 'Gyroscope scale
    Public MagScale As Single = 1 / 1370 'Magnetometer scale
    'BPS
    Public ModVScale As Single = 1 / 1000 'Battery module voltage scale
    Public ModTScale As Single = 1 'Battery module temperature scale
    Public IScale As Single = 1 / 100 'Pack current scale
    Public VScale As Single = 1 / 10 'Pack voltage scale
    Public pbScale As Single = 1 / 100 'Powerboard scale
    Public V5Scale As Single = 1 / 10 '5V scale
    Public SystemV As Single 'Main battery pack voltage
    Public NoLoadV As Single 'Main pack voltage with low load
    Public PackPower As Single 'Main battery pack power
    Public ArrayPower As Single 'Solar array power
    Public MotorPower As Single 'Motor power
    'MPPT
    Public mppt0cells As Integer = 99 'MPPT 0 cell count
    Public mppt1cells As Integer = 98 'MPPT 1 cell count
    Public mppt2cells As Integer = 102 'MPPT 2 cell count
    Public mppt3cells As Integer = 92 'MPPT 3 cell count
    Public mpptVinScale As Single = 1 / 100 'MPPT input voltage scale
    Public mpptIinScale As Single = 1 / 1000 'MPPT input current scale
    Public mpptVoutScale As Single = 1 / 100 'MPPT output voltage scale
    Public mpptTempScale As Single = 1 / 100 'MPPT temp scale
    Public mpptCount As Byte = 0 'MPPT RTS message counter
    Public PollMPPTs As Boolean = 1 'Determines whether RTS messages are sent to the MPPTs
    Public ArrayPanelPower As Single = 0 'Input power from solar panels (sum of MPPT power)
    Public RTScount As Double = 0 'Counts RTS messages from BPS for signal strength
    'Motor
    Public MotorVScale As Single = 1 / 10 'Motor supply voltage scale
    Public MotorIScale As Single = 1 / 10 'Motor supply current scale
    Public MotorTScale As Single = 1 / 10 'Motor temperature scale
    Public MotorOdScale As Single = 1 / 10 'Motor trip odometer since last boot
    Public PedalScale As Single = 1 / 100 'Motor pedal scale
    Public MotorEnabled As Boolean = 0 'Motor enable switch
    Public MPH As Single 'Vehicle speed
    'Statistics variables
    Public MPHcount As Double = 0 'Counter variable for speed calculations
    Public MPHmax As Single = 0 'Initialize maximum speed
    Public MPHmin As Single = 10000 'Initialize minimum speed
    Public MPHrecent As Single = 0 'Initialize weighted average of MPH with expected value
    Public MPHavg As Double = 0 'Initialize average speed
    Public MPPTeffCount As Double = 0 'Counter variable for MPPT efficiency calculations
    Public MPPTeffMax As Single = 0 'Initialize maximum MPPT efficiency
    Public MPPTeffMin As Single = 100 'Initialize minimum MPPT efficiency
    Public MPPTeffRecent As Single = 1 'Initialize weighted average of MPPT efficiency with expected value
    Public MPPTeffAvg As Double = 0 'Initialize average MPPT efficiency
    Public ElectronicsPowerCount As Double = 0 'Counter variable for electronics calculations
    Public ElectronicsPowerMax As Single = 0 'Initialize maximum electronics power
    Public ElectronicsPowerMin As Single = 10000 'Initialize minimum electronics power
    Public ElectronicsPowerRecent As Single = 25 'Initialize weighted average of electronics power with expected value
    Public ElectronicsPowerAvg As Double = 0 'Initialize average electronics power
    Public MPGeCount As Double = 0 'Counter variable for MPGe
    Public MPGeMax As Single = 0 'Initialize maximum MPGe
    Public MPGeMin As Single = 10000 'Initialize minimum MPGe
    Public MPGeRecent As Single = 0 'Initialize weighted average of MPGe with expected value
    Public MPGeAvg As Double = 0 'Initialize average MPGe
    Public PackPowerCount As Double = 0 'Counter variable for pack calculations
    Public PackPowerMax As Single = 0 'Initialize maximum pack power
    Public PackPowerMin As Single = 10000 'Initialize minimum pack power
    Public PackPowerRecent As Single = 0 'Initialize weighted average of pack power with expected value
    Public PackPowerAvg As Double = 0 'Initialize average pack power
    Public ArrayPowerCount As Double = 0 'Counter variable for array calculations
    Public ArrayPowerMax As Single = 0 'Initialize maximum array power
    Public ArrayPowerMin As Single = 10000 'Initialize minimum array power
    Public ArrayPowerRecent As Single = 0 'Initialize weighted average of array power with expected value
    Public ArrayPowerAvg As Double = 0 'Initialize average array power
    Public MotorPowerCount As Double = 0 'Counter variable for motor power calculations
    Public MotorPowerMax As Single = 0 'Initialize maximum motor power
    Public MotorPowerMin As Single = 10000 'Initialize minimum motor power
    Public MotorPowerRecent As Single = 0 'Initialize weighted average of motor power with expected value
    Public MotorPowerAvg As Double = 0 'Initialize average motor power
    Public CockpitTCount As Double = 0 'Counter variable for cockpit temp calculations
    Public CockpitTempMax As Single = 0 'Initialize maximum cockpit temp
    Public CockpitTempMin As Single = 10000 'Initialize minimum cockpit temp
    Public CockpitTempRecent As Single = 30 'Initialize weighted average of cockpit temp with expected value
    Public CockpitTempAvg As Double = 0 'Initialize average cockpit temp
    Public MotorTCount As Double = 0 'Counter variable for motor temp calculations
    Public MotorTMax As Single = 0 'Initialize maximum motor temp
    Public MotorTMin As Single = 10000 'Initialize minimum motor temp
    Public MotorTRecent As Single = 30 'Initialize weighted average of motor temp with expected value
    Public MotorTAvg As Double = 0 'Initialize average motor temp
    Public ControllerTCount As Double = 0 'Counter variable for controller temp calculations
    Public ControllerTMax As Single = 0 'Initialize maximum controller temp
    Public ControllerTMin As Single = 10000 'Initialize minimum controller temp
    Public ControllerTRecent As Single = 30 'Initialize weighted average of controller temp with expected value
    Public ControllerTAvg As Double = 0 'Initialize average controller temp
    Public BaseplateTCount As Double = 0 'Counter variable for baseplate temp calculations
    Public BaseplateTMax As Single = 0 'Initialize maximum baseplate temp
    Public BaseplateTMin As Single = 10000 'Initialize minimum baseplate temp
    Public BaseplateTRecent As Single = 30 'Initialize weighted average of baseplate temp with expected value
    Public BaseplateTAvg As Double = 0 'Initialize average baseplate temp
    Public PackTCount As Double = 0 'Counter variable for pack temp calculations
    Public PackTMax As Single = 0 'Initialize maximum pack temp
    Public PackTMin As Single = 10000 'Initialize minimum pack temp
    Public PackTRecent As Single = 30 'Initialize weighted average of pack temp with expected value
    Public PackTAvg As Double = 0 'Initialize average pack temp
    Public MPPTtCount As Double = 0 'Counter variable for MPPT temp calculations
    Public MPPTtMax As Single = 0 'Initialize maximum MPPT temp
    Public MPPTtMin As Single = 10000 'Initialize minimum MPPT temp
    Public MPPTtRecent As Single = 30 'Initialize weighted average of MPPT temp with expected value
    Public MPPTtAvg As Double = 0 'Initialize average MPPT temp
    Public RecentV As Double = 100 'Initialize weighted average of system voltage with expected value
    Public ShortWeight As Double = 100 'Determines how many recent samples are given significant weight
    Public MidWeight As Double = 300 'Determines how many recent samples are given significant weight
    Public LongWeight As Double = 600 'Determines how many recent samples are given significant weight
    'Vehicle Info grid view variables
    Public DirectionRow() As String = {"Driving Direction", "0"} 'Direction {row name, row index}
    Public ThrottlePositionRow() As String = {"Throttle Position", "1"} 'Throttle position {row name, row index}
    Public RegenPositionRow() As String = {"Regen Position", "2"} 'Throttle position {row name, row index}
    Public MotorLimitingRow() As String = {"Motor Limiting", "3"} 'Motor limiting {row name, row index}
    Public TripOdometerRow() As String = {"Trip Odometer (mi)", "4"} 'Trip odometer {row name, row index}
    Public VehicleOdometerRow() As String = {"Vehicle Odometer (mi)", "5"} 'Vehicle odometer {row name, row index}
    Public BatteryStatusRow() As String = {"Battery Status", "6"} 'Battery status {row name, row index}
    Public BatteryCyclesRow() As String = {"Battery Cycles", "7"} 'Battery cycles {row name, row index}
    Public StateOfChargeRow() As String = {"State of Charge", "8"} 'Motor limiting {row name, row index}
    Public BatteryCapacityRow() As String = {"Battery Capacity (kWh)", "9"} 'Motor limiting {row name, row index}
    Public HighModuleTRow() As String = {"High Module (°C)", "10"} 'High module temp {row name, row index}
    Public HighModuleVRow() As String = {"High Module (V)", "11"} 'High module voltage {row name, row index}
    Public LowModuleVRow() As String = {"Low Module (V)", "12"} 'Low module voltage {row name, row index}
    'Runtime Stats grid view variables
    Public SpeedRow() As String = {"Driving Speed (MPH)", "0"} 'Driving speed {row name, row index}
    Public EnergyConsumptionRow() As String = {"Energy Consumption (MPGe)", "1"} 'Energy consumption {row name, row index}
    Public mpptEfficiencyRow() As String = {"MPPT Efficiency", "2"} 'MPPT efficiency {row name, row index}
    Public PackPowerRow() As String = {"Battery Pack Power (W)", "3"} 'Battery pack power {row name, row index}
    Public ArrayPowerRow() As String = {"Solar Array Power (W)", "4"} 'Solar array power {row name, row index}
    Public MotorPowerRow() As String = {"Motor Power (W)", "5"} 'Motor power {row name, row index}
    Public ElectronicsPowerRow() As String = {"Electronics Power (W)", "6"} 'Electronics power {row name, row index}
    Public CockpitTRow() As String = {"Cockpit Temperature (°C)", "7"} 'Cockpit temperature {row name, row index}
    Public MotorTRow() As String = {"Motor Temperature (°C)", "8"} 'Motor temperature {row name, row index}
    Public ControllerTRow() As String = {"Controller Temperature (°C)", "9"} 'Motor contorller ambient temperature {row name, row index}
    Public BaseplateTRow() As String = {"Basepate Temperature (°C)", "10"} 'Motor controller baseplate temperature {row name, row index}
    Public BatteryTRow() As String = {"Battery Termperature (°C)", "11"} 'Battery pack temperature {row name, row index}
    Public mpptTRow() As String = {"MPPT Temperature (°C)", "12"} 'MPPT temperature {row name, row index}
    'System Current and Enable Status grid view variables
    Public PackStatusRow() As String = {"Pack", "0"} 'Pack state {row name, row index}
    Public ArrayStatusRow() As String = {"Array", "1"} 'Array state {row name, row index}
    Public MotorStatusRow() As String = {"Motor", "2"} 'Pack state {row name, row index}
    'Vehicle Voltates grid view variables
    Public SystemVRow() As String = {"System Voltage (V)", "0"} 'System voltage {row name, row index}
    Public noloadVRow() As String = {"No Load Voltage (V)", "1"} 'No load voltage {row name, row index}
    Public RecentVRow() As String = {"Recent Voltage (V)", "2"} 'Avgerage system voltage {row name, row index}
    Public ModuleVRangeRow() As String = {"Module Range (V)", "3"} 'Range of module voltages {row name, row index}
    Public AuxPackVRow() As String = {"Aux Pack (V)", "4"} 'Aux pack voltage {row name, row index}
    Public AuxPackLowRow() As String = {"Aux Pack Level", "5"} 'Aux pack voltage {row name, row index}
    Public V12MainRow() As String = {"12V Main Bus (V)", "6"} '12V main bus voltage {row name, row index}
    Public V12AuxRow() As String = {"12V Aux Bus (V)", "7"} '12V aux bus voltage {row name, row index}
    Public V5Row() As String = {"5V Bus (V)", "8"} '5V bus voltage {row name, row index}

#End Region

#Region "Program Initialization"

    'Actions to perform when program opens
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgramParameters() 'Set program constants and parameters
        Initialization() 'Dimension variables and set initial values
    End Sub

    'Set program constants and parameters
    Public Sub ProgramParameters()
        'Serial port parameters
        cmbBaud.Text = "57600" 'Set the default baud rate (must be a value from the dropdown list)
        SerialPort.Parity = IO.Ports.Parity.None 'Set parity error protection
        SerialPort.StopBits = IO.Ports.StopBits.One 'Stop bits sent at the end of each character
        SerialPort.DataBits = 8 'Number of data bits in each character
        'Timer parameters
        Timer.Interval = 100 'Timer interval in mili-seconds
    End Sub

    'Dimension variables and set initial values
    Public Sub Initialization()
        'Serial port variables
        Dim Ports() As String = IO.Ports.SerialPort.GetPortNames() 'Get all COM ports available upon startup
        If Ports.GetLength(0) = 0 Then
            cmbPort.Text = "" 'Leave drop down blank since no COM ports are detected
        Else
            PopulatePortList() 'Add available ports to the drop down list
            cmbPort.Text = Ports(0) 'Select the first COM port detected
            SerialPort.PortName = Ports(0) 'Set the initial COM port
        End If
        SerialPort.BaudRate = cmbBaud.Text 'Set the initial baud rate for data transmission
        'Vehicle info grid view
        gvVehicleInfo.DefaultCellStyle.SelectionBackColor = gvVehicleInfo.BackgroundColor 'Don't change color on select
        gvVehicleInfo.DefaultCellStyle.SelectionForeColor = gvVehicleInfo.ForeColor 'Don't change color on select
        gvVehicleInfo.Rows.Add(DirectionRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(ThrottlePositionRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(RegenPositionRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(MotorLimitingRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(TripOdometerRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(VehicleOdometerRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(BatteryStatusRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(BatteryCyclesRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(StateOfChargeRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(BatteryCapacityRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(HighModuleTRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(HighModuleVRow(0), "-") 'Add row
        gvVehicleInfo.Rows.Add(LowModuleVRow(0), "-") 'Add row
        'Runtime stats grid
        gvRuntimeStats.DefaultCellStyle.SelectionBackColor = gvRuntimeStats.BackgroundColor 'Don't change color on select
        gvRuntimeStats.DefaultCellStyle.SelectionForeColor = gvRuntimeStats.ForeColor 'Don't change color on select
        gvRuntimeStats.Rows.Add(SpeedRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(EnergyConsumptionRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(mpptEfficiencyRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(PackPowerRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(ArrayPowerRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(MotorPowerRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(ElectronicsPowerRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(CockpitTRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(MotorTRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(ControllerTRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(BaseplateTRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(BatteryTRow(0), "-", "-", "-", "-", "-") 'Add row
        gvRuntimeStats.Rows.Add(mpptTRow(0), "-", "-", "-", "-", "-") 'Add row
        'System current and enable status info grid
        gvSystemStatus.DefaultCellStyle.SelectionBackColor = gvSystemStatus.BackgroundColor 'Don't change color on select
        gvSystemStatus.DefaultCellStyle.SelectionForeColor = gvSystemStatus.ForeColor 'Don't change color on select
        gvSystemStatus.Rows.Add(PackStatusRow(0), "-", "-") 'Add row
        gvSystemStatus.Rows.Add(ArrayStatusRow(0), "-", "-") 'Add row
        gvSystemStatus.Rows.Add(MotorStatusRow(0), "-", "-") 'Add row
        'Vehicle voltage grid
        gvVehicleVoltage.DefaultCellStyle.SelectionBackColor = gvSystemStatus.BackgroundColor 'Don't change color on select
        gvVehicleVoltage.DefaultCellStyle.SelectionForeColor = gvSystemStatus.ForeColor 'Don't change color on select
        gvVehicleVoltage.Rows.Add(SystemVRow(0), "-") 'Add row
        gvVehicleVoltage.Rows.Add(noloadVRow(0), "-") 'Add row
        gvVehicleVoltage.Rows.Add(RecentVRow(0), "-") 'Add row
        gvVehicleVoltage.Rows.Add(ModuleVRangeRow(0), "-") 'Add row
        gvVehicleVoltage.Rows.Add(AuxPackVRow(0), "-") 'Add row
        gvVehicleVoltage.Rows.Add(AuxPackLowRow(0), "-") 'Add row
        gvVehicleVoltage.Rows.Add(V12MainRow(0), "-") 'Add row
        gvVehicleVoltage.Rows.Add(V12AuxRow(0), "-") 'Add row
        gvVehicleVoltage.Rows.Add(V5Row(0), "-") 'Add row        
    End Sub

#End Region

#Region "Serial Port Control"

    'Actions performed when the COM port dropdown list is opened
    Private Sub cmbPort_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPort.DropDown
        cmbPort.Items.Clear() 'Clear the COM port list
        PopulatePortList() 'Update the COM port list
    End Sub

    'Add all available COM ports to the drop down list
    Private Sub PopulatePortList()
        For Each ListItem As String In IO.Ports.SerialPort.GetPortNames()
            cmbPort.Items.Add(ListItem) 'Add ports to the drop down list
        Next
    End Sub

    'Actions performed when a new COM port is selected from the dropdown list
    Private Sub cmbPort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPort.SelectedIndexChanged
        If SerialPort.IsOpen = False Then
            SerialPort.PortName = cmbPort.Text 'If another COM port isn't already connected, switch to the selected port
        Else
            If Not cmbPort.Text = SerialPort.PortName Then
                MsgBox("Disconnect before changing port.")
                cmbPort.Text = SerialPort.PortName 'If another COM port is already connected, don't switch ports
            End If
        End If
    End Sub

    'Actions performed when the COM port dropdown list is closed
    Private Sub cmbPort_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPort.DropDownClosed
        If cmbPort.Text = "" Then cmbPort.Text = SerialPort.PortName 'If a COM port is available, don't let the user leave the dropdown menu blank
    End Sub

    'Actions performed when a new baud rate is selected from the dropdown list
    Private Sub cmbBaud_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBaud.SelectedIndexChanged
        If SerialPort.IsOpen = False Then
            SerialPort.BaudRate = cmbBaud.Text 'If a COM port isn't already connected, switch to the selected baud rate
        ElseIf Not cmbBaud.Text = SerialPort.BaudRate Then
            MsgBox("Disconnect before changing baud rate.")
            cmbBaud.Text = SerialPort.BaudRate 'If a COM port is already connected, don't switch baud rates
        End If
    End Sub

    'Actions performed when the serial Connect/Disconnect button is clicked
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If btnConnect.Text = "Connect" Then 'Connect button click
            If Not cmbPort.Text = "" Then 'Check that a COM port is selected
                Try
                    SerialPort.PortName = cmbPort.Text 'Set the serial port to the selected COM port
                    If Not SerialPort.IsOpen() Then SerialPort.Open() 'Open the serial port
                    btnConnect.Text = "Disconnect" 'Configure button for disconnecting
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No serial port selected.")
            End If
        ElseIf btnConnect.Text = "Disconnect" Then 'Disconnect button click
            Try
                SerialControl.Set() 'Release the serial port thread
                If SerialPort.IsOpen Then SerialPort.Close() 'Close the serial port
                btnConnect.Text = "Connect" 'Configure button for connecting
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    'Read incoming data on the serial port
    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Dim bytes As Integer = SerialPort.BytesToRead 'Retrieve number of unread bytes in the serial port buffer
        Dim comBuffer As Byte() = New Byte(bytes - 1) {} 'Create a new byte array to hold the awaiting data
        SerialControl = New System.Threading.AutoResetEvent(False) 'Allows a thread to be paused
        For i As Integer = 0 To bytes - 1 'Read all data available on the incoming serial port buffer
            Try
                comBuffer(i) = SerialPort.ReadByte() 'Read each byte on serial port buffer
            Catch
                'Error reading serial port
            End Try
        Next
        'Display serial data for the user using safe threading (BeginInvoke prevents random lockups when serial is disconnected)
        If rtbReceived.InvokeRequired Then
            BeginInvoke(New AddDataDelegate(AddressOf AddData), ByteToHex(comBuffer) + "") 'Make call using a delegate
        Else
            AddData(ByteToHex(comBuffer) + "") 'Make call directly
        End If
        'Search for CAN messages in the incoming serial data
        For i As Integer = 0 To bytes - 1
            If Not splitBuffer Then 'Verify that a partial CAN message array has not already been started
                If comBuffer(i) = CByte(Asc("!")) Then 'Check for CAN message start byte
                    CANstart = i 'Mark the start byte of the CAN message
                    'Normal operation (CAN message not split between two serial buffers)
                    If bytes - i >= 14 Then 'Check that there are enough bytes to construct a full CAN message
                        For j As Byte = 0 To 13
                            CANmessage(j) = comBuffer(j + CANstart) 'Populate CAN message array from the serial buffer
                        Next
                        CANvalidation() 'Validate the CAN message
                        If CANvalid Then 'A valid new CAN message was received
                            'Display serial data for the user using safe threading (BeginInvoke prevents random lockups when serial is disconnected)
                            If lvCAN.InvokeRequired Then
                                BeginInvoke(New AddMessageDelegate(AddressOf AddMessage)) 'Make call using a delegate
                            Else
                                AddMessage() 'Make call directly
                            End If
                            'Display serial data for the user using safe threading (BeginInvoke prevents random lockups when serial is disconnected)
                            If ConnectionBar.InvokeRequired Then
                                BeginInvoke(New rxCounterDelegate(AddressOf rxCounter)) 'Make call using a delegate
                            Else
                                rxCounter() 'Make call directly
                            End If
                            i += 13 'Jump ahead to the end of the successful message
                            SerialControl.WaitOne() 'Pause the serial port thread
                        End If
                    ElseIf bytes - i > 0 Then 'If there are still unread bytes in the serial buffer but not enough to form a complete CAN message
                        ReDim Preserve tempBuffer(bytes - 1 - CANstart) 'Increase the size of the temporary buffer as necessary
                        For j As Byte = 0 To bytes - 1 - CANstart 'Read the remaining available bytes into the temporary buffer
                            splitBuffer = 1 'Indicate that the CAN message is split between two or more serial buffers
                            tempBuffer(j) = comBuffer(j + CANstart) 'Add data from the serial buffer to the temporary buffer
                        Next
                        Exit For 'Exit CAN message search loop
                    End If
                End If
            Else 'If a CAN message is split between two or more buffers
                tempSize = tempBuffer.Length 'Determine the length of the temporary buffer
                ReDim Preserve tempBuffer(tempBuffer.Length + bytes - 1) 'Increase the size of the temporary buffer as necessary
                For j As Integer = 0 To bytes - 1
                    tempBuffer(tempSize + j) = comBuffer(j) 'Add data from the serial buffer to the temporary buffer
                Next
                If tempBuffer.Length >= 14 Then 'Check if there are enough bytes in the temporary buffer to form a CAN message
                    For c As Integer = 0 To 13
                        CANmessage(c) = tempBuffer(c) 'Construct the CAN message array from the temp buffer
                    Next
                    CANvalidation() 'Validate the CAN message
                    If CANvalid Then 'New CAN message successfully received
                        'Display serial data for the user using safe threading (BeginInvoke prevents random lockups when serial is disconnected)
                        If lvCAN.InvokeRequired Then
                            BeginInvoke(New AddMessageDelegate(AddressOf AddMessage)) 'Make call using a delegate
                        Else
                            AddMessage() 'Make call directly
                        End If
                        'Display serial data for the user using safe threading (BeginInvoke prevents random lockups when serial is disconnected)
                        If ConnectionBar.InvokeRequired Then
                            BeginInvoke(New rxCounterDelegate(AddressOf rxCounter)) 'Make call using a delegate
                        Else
                            rxCounter() 'Make call directly
                        End If
                        i = 13 - tempSize 'Jump ahead to the end of the successful message
                        SerialControl.WaitOne() 'Pause the serial port thread
                    Else
                        i = -1 'Reset serial buffer counter
                    End If
                    splitBuffer = 0 'Indicate the end of a split message
                    ReDim tempBuffer(0) 'Reset the temporary buffer
                Else
                    Exit For 'Exit CAN message search loop
                End If
            End If
        Next
    End Sub

    'Send out data on the serial port
    Private Sub WriteData(ByVal msg As String)
        msg = msg.Replace(" ", "") 'Remove spaces from the string
        If msg.Length Mod 2 = 0 Then 'Check that there is an even number of hex digits
            Dim newMsg As Byte() = HexToByte(msg) 'Convert the hex data to a byte array
            SerialPort.Write(newMsg, 0, newMsg.Length) 'Send the byte array to the serial port
            rtbTransmitted.AppendText(ByteToHex(newMsg) + "") 'Convert the message back to hex and display for the user
            rtbTransmitted.ScrollToCaret() 'Automatically scroll to keep up with the most recent data
            'Search for CAN messages in the outgoing serial data
            For i As Integer = 0 To newMsg.Length - 1
                If newMsg.Length - i >= 14 Then 'Check that there are enough bytes to construct a full CAN message
                    If newMsg(i) = CByte(Asc("!")) Then 'Check for CAN message start byte
                        CANstart = i 'Mark the start of the CAN message
                        For j As Byte = 0 To 13
                            CANmessage(j) = newMsg(j + CANstart) 'Populate CAN message array from the serial buffer
                        Next
                        CANvalidation() 'Validate the CAN message
                        If CANvalid Then 'A valid new CAN message was received
                            lblTx.Text += 1 'Increment CAN message received count
                            i += 13 'Jump ahead to the end of the successful message
                        End If
                    End If
                End If
            Next
        Else
            MsgBox("There must be an even number of hex digits.")
        End If
    End Sub

    'Required to prevent threading errors during receiveing of serial data
    Delegate Sub rxCounterDelegate()

    'Increment incoming CAN message counter
    Private Sub rxCounter()
        lblRx.Text += 1 'Increment CAN message received count
    End Sub

    'Actions performed when the reset stats button is clicked
    Private Sub btnResetStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetStats.Click
        lblRx.Text = 0 'Reset CAN received count
        lblTx.Text = 0 'Reset CAN sent count
    End Sub

#End Region

#Region "CAN Message Construction and Validation"

    Private Sub CANvalidation()
        Dim CheckSum As Integer = 0 'Initialize checksum
        Try
            'Record the time that the message was validated
            CANtime = Now
            'Decode message header
            ID = CANmessage(1) * 256 + CANmessage(2) '2 byte message ID
            'Check that the ID is within the allowed range
            If ID < 0 Or ID > 2047 Then
                CANvalid = 0 'Invalid CAN ID
            Else 'Extract CAN message information
                RTS = CANmessage(3) 'CAN request to send (used to request CAN data from boards that don't send automatically)
                If Not (RTS = 1 Or RTS = 0) Then
                    CANvalid = 0 'RTS byte must be either 1 (true) or 0 (false)
                Else
                    MessageSize = CANmessage(4) 'Message data size in bytes
                    If MessageSize < 0 Or MessageSize > 8 Then
                        CANvalid = 0 'Invalid message data length
                    ElseIf Not MessageSize = 0 Then 'If message contains no data, don't validate the checksum
                        'Extract CAN message data
                        For i As Integer = 0 To MessageSize - 1
                            CANdata(i) = CANmessage(i + 5) 'Populate data array
                            CheckSum += CANdata(i) 'Increment checksum
                        Next
                        Dim c As Byte = CANmessage(13) 'CAN message checksum value
                        'Validate message data
                        If Not (CheckSum Mod 256) = c Then
                            CANvalid = 0 'Invalid checksum
                        Else
                            CANvalid = 1 'CAN message contains valid data
                        End If
                    Else
                        CANvalid = 1 'CAN message is valid but contains no data
                    End If
                End If
            End If
            If CANvalid And Not RTS = 1 Then CANtimeNonRTS = Now
        Catch
            CANvalid = 0 'Error decoding CAN message
        End Try
    End Sub

    'Send a CAN message
    Sub SendCAN(ByVal sendID As Short, ByVal sendRTS As Byte, ByVal sendSize As Byte, Optional ByVal sendData() As Byte = Nothing)
        Dim ckSum As Integer = 0 'Initialize checksum
        Dim Constructor As String = "21" 'Initialize CAN message string
        Constructor &= sendID.ToString("X4") & Format(sendRTS, "00").ToString & Format(sendSize, "00").ToString 'Populate message string header
        'Populate message string data
        If sendSize = 0 Then
            Constructor &= "000000000000000000" 'Add empty data and checksum
        Else
            For i As Integer = 0 To 7
                If i <= sendSize Then
                    Constructor &= Format(sendData(i), "00").ToString 'Add data to message
                    ckSum += sendData(i) 'Increment checksum
                Else
                    Constructor &= "00" 'Add empty data
                End If
                Constructor &= (ckSum Mod 256).ToString("X4") 'Add message checksum
            Next
        End If
        WriteData(Constructor) 'Send CAN message
    End Sub

#End Region

#Region "Conversion Functions"

    'Convert byte array into hex string
    Private Function ByteToHex(ByVal comByte As Byte()) As String
        Dim builder As New System.Text.StringBuilder(comByte.Length * 3) 'create a new StringBuilder object
        For Each data As Byte In comByte 'Loop through each byte in the array
            builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c)) 'Convert the byte to a string and add to the stringbuilder
        Next
        Return builder.ToString().ToUpper() 'Return the converted value
    End Function

    'Convert hex data to a byte array
    Private Function HexToByte(ByVal msg As String) As Byte()
        Dim comBuffer As Byte() = New Byte(msg.Length / 2 - 1) {} 'Create a byte array of length equal to the hex digits divided by 2
        For i As Integer = 0 To msg.Length - 1 Step 2
            comBuffer(i / 2) = CByte(Convert.ToByte(msg.Substring(i, 2), 16)) 'Create byte string
        Next
        Return comBuffer 'Loop through the length of the provided string convert each set of 2 digits to a byte and add to the array return the array
    End Function

    'Combine two bytes into a signed short value
    Private Function ToSigned(ByVal msb As Byte, ByVal lsb As Byte) As Short
        Return CShort((CShort(msb) << 8) Or (CInt(lsb) << 16 >> 16)) 'Byte shift and bitwise OR to get the desired value
    End Function

    'Combine two bytes into an unsigned short value
    Private Function ToUnsigned(ByVal msb As Byte, ByVal lsb As Byte) As UShort
        Return CUShort((CUShort(msb) << 8) Or (CInt(lsb))) 'Byte shift and bitwise OR to get the desired value
    End Function

    'Convert Fahrenheit to Celsius
    Private Function ToCelsius(ByVal Temp As Single) As Single
        Return (Temp - 32) * 5 / 9
    End Function

    'Convert Celsius to Fahrenheit
    Private Function ToFahrenheit(ByVal Temp As Single) As Single
        Return (Temp * 9 / 5) + 32
    End Function

#End Region

#Region "Timer Control"

    'Main program timer
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Dim MPPTeff As Single = 0 'MPPT efficiency
        Dim ElectronicsPower As Single = 0 'Electroincs power
        Dim MPGe As Single = 0 'Energy consumption
        'Fast main timer events
        If SerialPort.IsOpen And Not lvCAN.Items.Count = 0 Then
            ''Get data from MPPTs
            'If PollMPPTs Then
            '    'Send RTS messages to all possible MPPT IDs
            '    Dim sendID As Short = &H710 Or mpptCount 'Select CAN ID 
            '    SendCAN(sendID, 1, 0) 'Send RTS CAN message
            '    'MPPT counter control
            '    If mpptCount = LastMPPT - FirstMPPT Then
            '        mpptCount = 0 'Reset MPPT counter
            '    Else
            '        mpptCount += 1 'Increment MPPT counter
            '    End If
            For Each lviCAN As ListViewItem In lvCAN.Items
                If CUShort(lviCAN.SubItems(1).Text = "BPS") Then
                    BPS(lviCAN) 'Process BPS data
                    tbBPSupdate.Text = "Last Update: " & lviCAN.SubItems(12).Text.ToString 'Time of last module update
                End If
                If CUShort(lviCAN.SubItems(1).Text = "MPPT") Then
                    MPPT(lviCAN) 'Process MPPT data
                    If Not lviCAN.SubItems(2).Text = "Yes" Then tbMPPTupdate.Text = "Last Update: " & lviCAN.SubItems(12).Text.ToString 'Time of last MPPT update (not including RTS messages)
                End If
                If CUShort(lviCAN.SubItems(1).Text = "Motor") Then
                    Motor(lviCAN) 'Process Motor data
                    If Not lviCAN.Text = "0775" Then tbMotorUpdate.Text = "Last Update: " & lviCAN.SubItems(12).Text.ToString 'Time of last motor update (not including error message)
                End If
                If CUShort(lviCAN.SubItems(1).Text = "Dash") Then
                    Dash(lviCAN) 'Process Dash data
                End If
                If CUShort(lviCAN.SubItems(1).Text = "VDTS") Then
                    VDTS(lviCAN) 'Process VDTS data
                    tbVDTSupdate.Text = "Last Update: " & lviCAN.SubItems(12).Text.ToString 'Time of last VDTS update
                End If
            Next
        End If
        'Update CANanator status
        If SerialPort.IsOpen Then
            If DateDiff(DateInterval.Second, CANtimeNonRTS, Now) < 1 And Not RTS Then
                tbCANanatorStatus.ForeColor = Color.Green 'Set text color to green
                tbCANanatorStatus.Text = "Connected: CAN Active" 'There is CAN activity other than RTS messages
                CANactive = True
            Else
                tbCANanatorStatus.ForeColor = Color.Red 'Set text color to red
                tbCANanatorStatus.Text = "Connected: CAN Inactive" 'CAN messages aren't being sent or received
                CANactive = False
            End If
        Else
            tbCANanatorStatus.ForeColor = Color.Black 'Set text color to black
            tbCANanatorStatus.Text = "Disconnected" 'The serial port is disconnected
        End If
        'Increment & reset sub-timers
        If TimerA = TimerAReset Then
            TimerA = 0 'Reset Timer A counter
        Else
            TimerA += 1 'Increment Timer A counter
        End If
        'Calculate values
        MPPTeff = ArrayPower / ArrayPanelPower 'MPPT efficiency
        ElectronicsPower = ArrayPower - MotorPower - PackPower 'Electronics power (W)
        If PackPower < 0 Then MPGe = Math.Abs(MPH) * 1000 / -PackPower * 33.7 Else MPGe = "Infinity" 'Energy consumption
        'Calculate stats
        If CANactive Then
            If Not MPPTeff.ToString = "NaN" And Not MPPTeff.ToString = "Infinity" Then
                MPPTeffCount += 1 'Increment MPPT efficiency counter
                MPPTeffRecent = (MPPTeffRecent * (LongWeight - 1) + MPPTeff) / LongWeight 'Update weighted average for MPPT efficiency
                MPPTeffAvg = MPPTeffAvg * ((MPPTeffCount - 1) / MPPTeffCount) + MPPTeff / MPPTeffCount 'Update average MPPT efficiency
                If MPPTeff > MPPTeffMax Then MPPTeffMax = MPPTeff 'Update maximum MPPT efficiency
                If MPPTeff < MPPTeffMin And MPPTeff > 0 Then MPPTeffMin = MPPTeff 'Update minimum MPPT efficiency
            End If
            ElectronicsPowerRecent = (ElectronicsPowerRecent * (LongWeight - 1) + ElectronicsPower) / LongWeight 'Update weighted average for electronics power
            ElectronicsPowerCount += 1 'Increment electronics power counter
            ElectronicsPowerAvg = ElectronicsPowerAvg * ((ElectronicsPowerCount - 1) / ElectronicsPowerCount) + ElectronicsPower / ElectronicsPowerCount 'Update average electronics power
            If ElectronicsPower > ElectronicsPowerMax Then ElectronicsPowerMax = ElectronicsPower 'Update maximum electronics power
            If ElectronicsPower < ElectronicsPowerMin Then ElectronicsPowerMin = ElectronicsPower 'Update minimum electronics power
            MPGeCount += 1 'Increment MPGe counter
            If Not MPGe.ToString = "NaN" And Not MPGe.ToString = "Infinity" Then
                MPGeRecent = (MPGeRecent * (LongWeight - 1) + MPGe) / LongWeight 'Update weighted average for MPGe
                MPGeAvg = MPGeAvg * ((MPGeCount - 1) / MPGeCount) + MPGe / MPGeCount 'Update average MPGe
                If MPGe > MPGeMax Then MPGeMax = MPGe 'Update maximum MPGe
                If MPGe < MPGeMin Then MPGeMin = MPGe 'Update minimum MPGe
            End If
        End If
        'Update main display window
        If SerialPort.IsOpen And Not lvCAN.Items.Count = 0 Then 'Check for connection and CAN messages
            gvRuntimeStats.Item(1, CByte(mpptEfficiencyRow(1))).Value = Format(MPPTeff, "0.0%") 'MPPT efficiency
            gvRuntimeStats.Item(2, CByte(mpptEfficiencyRow(1))).Value = Format(MPPTeffRecent, "0.0%") 'MPPT recemt efficiency
            gvRuntimeStats.Item(3, CByte(mpptEfficiencyRow(1))).Value = Format(MPPTeffAvg, "0.0%") 'MPPT average efficiency
            gvRuntimeStats.Item(4, CByte(mpptEfficiencyRow(1))).Value = Format(MPPTeffMax, "0.0%") 'MPPT maximum efficiency
            gvRuntimeStats.Item(5, CByte(mpptEfficiencyRow(1))).Value = Format(MPPTeffMin, "0.0%") 'MPPT minimum efficiency
            gvRuntimeStats.Item(1, CByte(ElectronicsPowerRow(1))).Value = Format(ElectronicsPower, "0.0") 'Electronics power
            gvRuntimeStats.Item(2, CByte(ElectronicsPowerRow(1))).Value = Format(ElectronicsPowerRecent, "0.0") 'Recent electronics power
            gvRuntimeStats.Item(3, CByte(ElectronicsPowerRow(1))).Value = Format(ElectronicsPowerAvg, "0.0") 'Average electronics power
            gvRuntimeStats.Item(4, CByte(ElectronicsPowerRow(1))).Value = Format(ElectronicsPowerMax, "0.0") 'Maximum electronics power
            gvRuntimeStats.Item(5, CByte(ElectronicsPowerRow(1))).Value = Format(ElectronicsPowerMin, "0.0") 'Minimum electronics power
            gvRuntimeStats.Item(1, CByte(EnergyConsumptionRow(1))).Value = Format(MPGe, "0.0") 'Energy consumption
            gvRuntimeStats.Item(2, CByte(EnergyConsumptionRow(1))).Value = Format(MPGeRecent, "0.0") 'Recent energy consumption
            gvRuntimeStats.Item(3, CByte(EnergyConsumptionRow(1))).Value = Format(MPGeAvg, "0.0") 'Average energy consumption
            gvRuntimeStats.Item(4, CByte(EnergyConsumptionRow(1))).Value = Format(MPGeMax, "0.0") 'Max energy consumption
            gvRuntimeStats.Item(5, CByte(EnergyConsumptionRow(1))).Value = Format(MPGeMin, "0.0") 'Min energy consumption
        End If
    End Sub

#End Region

#Region "Data Logging"

#End Region

#Region "Main Display Window"

#End Region

#Region "Battery Protection (BPS)"

    'Process BPS data
    Private Sub BPS(ByVal lviCAN As ListViewItem)
        'Populate BPS list view on Timer A
        Dim Sum0 As Single = 0 'Initialize temporary sum variable
        Dim Sum1 As Single = 0 'Initialize temporary sum variable
        Dim Counter As Single = 0 'Initilize counter
        Dim HighT As Single 'High module temperature
        Dim HighTmod As Byte 'Module number
        Dim HighV As Single 'High module voltage
        Dim HighVmod As Byte 'Module number
        Dim LowV As Single 'Low module voltage
        Dim LowVmod As Byte 'Module number
        Dim vRange As Single = 0 'Range between modules
        Dim found As Boolean = False 'Initialize variable
        If TimerA = TimerAReset And CANactive And CUShort(lviCAN.Text) >= FirstModule And CUShort(lviCAN.Text) <= LastModule And Not CUShort(lviCAN.SubItems(3).Text = "0") Then
            Try
                'Convert & scale module information
                Dim modID As UInteger = lviCAN.Text 'Module number
                Dim modV As Single = ToUnsigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) * ModVScale 'Voltage (V)
                Dim modT As Single = ToSigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) * ModTScale 'Temperature (C)
                Dim vReadErr As Boolean = lviCAN.SubItems(8).Text And 64 'Voltage read error (bit 6)
                Dim tReadErr As Boolean = lviCAN.SubItems(8).Text And 128 'Temp read error (bit 7)
                Dim otFault As Boolean = lviCAN.SubItems(9).Text And 1 'Over temp fault (bit 0)
                Dim otWarn As Boolean = lviCAN.SubItems(9).Text And 2 'Over temp warning (bit 1)
                Dim utFault As Boolean = lviCAN.SubItems(9).Text And 4 'Under temp fault (bit 2)
                Dim utWarn As Boolean = lviCAN.SubItems(9).Text And 8 'Under temp warning (bit 3)
                Dim ovFault As Boolean = lviCAN.SubItems(9).Text And 16 'Over voltage fault (bit 4)
                Dim ovWarn As Boolean = lviCAN.SubItems(9).Text And 32 'Over voltage warning (bit 5)
                Dim uvFault As Boolean = lviCAN.SubItems(9).Text And 64 'Under voltage fault (bit 6)
                Dim uvWarn As Boolean = lviCAN.SubItems(9).Text And 128 'Under voltage warning (bit 7)
                Dim UpdateTime As String = lviCAN.SubItems(12).Text.ToString 'Time of last update
                'Set battery module status
                Dim modStatus As String = "" 'Initialize module status
                If vReadErr Then
                    modStatus &= IIf(modStatus.Length, ", ", "") & "V Read Err" 'Add fault to string
                Else
                    If ovFault Then
                        modStatus &= IIf(modStatus.Length, ", ", "") & "OV Fault" 'Add fault to string
                    ElseIf ovWarn Then
                        modStatus &= IIf(modStatus.Length, ", ", "") & "OV Warning" 'Add warning to string
                    End If
                    If uvFault Then
                        modStatus &= IIf(modStatus.Length, ", ", "") & "UV Fault" 'Add fault to string
                    ElseIf uvWarn Then
                        modStatus &= IIf(modStatus.Length, ", ", "") & "UV Warning" 'Add warning to string
                    End If
                End If
                If tReadErr Then
                    modStatus &= IIf(modStatus.Length, ", ", "") & "T Read Err" 'Add fault to string
                Else
                    If otFault Then
                        modStatus &= IIf(modStatus.Length, ", ", "") & "OT Fault" 'Add fault to string
                    ElseIf otWarn Then
                        modStatus &= IIf(modStatus.Length, ", ", "") & "OT Warning" 'Add warning to string
                    End If
                    If utFault Then
                        modStatus &= IIf(modStatus.Length, ", ", "") & "UT Fault" 'Add fault to string
                    ElseIf otWarn Then
                        modStatus &= IIf(modStatus.Length, ", ", "") & "UT Warning" 'Add warning to string
                    End If
                End If
                If modStatus = "" Then modStatus = "Normal" 'No issues to report
                'Check whether the module already exists in the BPS list view
                For Each lviModule As ListViewItem In lvBPS.Items
                    If lviModule.Text = String.Format(Format(CUShort(modID) - FirstModule, "00")) Then
                        'If the battery module exists in the list view, update the module data
                        lviModule.SubItems(1).Text = Format(modV, "0.000") 'Format and update module voltage
                        lviModule.SubItems(2).Text = Format(modT, "0") 'Format and update module temperature
                        lviModule.SubItems(3).Text = UpdateTime 'Update module refresh time stamp
                        lviModule.SubItems(4).Text = modStatus 'Update module status
                        found = True 'Confirm that the module has been found in the list view and updated
                        Exit For
                    End If
                Next
                'Add a new battery module to the list view if it doesn't exist yet
                If Not found And modV > 0 Then
                    'If the battery module doesn't exist in the list view, add it as a new module
                    Dim lviModule As New ListViewItem(Format(CUShort(modID) - FirstModule, "00")) 'Format and add module number
                    lviModule.SubItems.Add(Format(modV, "0.000")) 'Format and add module voltage
                    lviModule.SubItems.Add(Format(modT, "0")) 'Format and add module temperature
                    lviModule.SubItems.Add(UpdateTime) 'Add module refresh time stamp
                    lviModule.SubItems.Add(modStatus) 'Add module status
                    lvBPS.Items.Add(lviModule) 'Add the battery module to the BPS list view
                End If
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If CUShort(lviCAN.Text) = "0305" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then
            Try
                'Convert & scale module information
                SystemV = ToUnsigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) * VScale 'Pack voltage (V)
                Dim PackCurrent As Single = ToSigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) * IScale 'Pack current (A)
                Dim ocFault As Boolean = lviCAN.SubItems(8).Text And 0 'Over charge fault (bit 0)
                Dim ocWarn As Boolean = lviCAN.SubItems(8).Text And 2 'Over charge warning (bit 1)
                Dim odFault As Boolean = lviCAN.SubItems(8).Text And 4 'Over discharge fault (bit 2)
                Dim odWarn As Boolean = lviCAN.SubItems(8).Text And 8 'Over discharge warning (bit 3)
                Dim vPackReadErr As Boolean = lviCAN.SubItems(8).Text And 16 'Pack (system) voltage read error (bit 4)
                Dim iPackReadErr As Boolean = lviCAN.SubItems(8).Text And 32 'Pack current read error (bit 5)
                PackPower = SystemV * PackCurrent 'Pack current
                'Calculate stats
                If CANactive Then
                    If PackPower > PackPowerMax Then PackPowerMax = PackPower 'Update maximum pack power
                    If PackPower < PackPowerMin Then PackPowerMin = PackPower 'Update minimum pack power
                    PackPowerRecent = (PackPowerRecent * (LongWeight - 1) + PackPower) / LongWeight 'Update weighted average for pack power
                    PackPowerCount += 1 'Increment pack power counter
                    PackPowerAvg = PackPowerAvg * ((PackPowerCount - 1) / PackPowerCount) + PackPower / PackPowerCount 'Update average pack power
                    RecentV = (RecentV * (MidWeight - 1) + SystemV) / MidWeight 'Update weighted average for system voltage
                End If
                'Update main display window
                gvSystemStatus.Item(1, CByte(PackStatusRow(1))).Value = Format(PackCurrent, "0.00") 'Pack current
                gvRuntimeStats.Item(1, CByte(PackPowerRow(1))).Value = Format(PackPower, "0.0") 'Pack power
                gvRuntimeStats.Item(2, CByte(PackPowerRow(1))).Value = Format(PackPowerRecent, "0.0") 'Pack power recent
                gvRuntimeStats.Item(3, CByte(PackPowerRow(1))).Value = Format(PackPowerAvg, "0.0") 'Pack power average
                gvRuntimeStats.Item(4, CByte(PackPowerRow(1))).Value = Format(PackPowerMax, "0.0") 'Pack power max
                gvRuntimeStats.Item(5, CByte(PackPowerRow(1))).Value = Format(PackPowerMin, "0.0") 'Pack power min
                gvVehicleVoltage.Item(1, CByte(RecentVRow(1))).Value = Format(RecentV, "0.0") 'Weighted average of system voltage
                If PackCurrent > 0 Then
                    gvVehicleInfo.Item(1, CByte(BatteryStatusRow(1))).Value = "Charging" 'Pack is charging
                ElseIf PackCurrent < 0 Then
                    gvVehicleInfo.Item(1, CByte(BatteryStatusRow(1))).Value = "Draining" 'Pack is draining
                Else
                    gvVehicleInfo.Item(1, CByte(BatteryStatusRow(1))).Value = "Equillibrium" 'Pack is neither charging nor draining
                End If
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If CUShort(lviCAN.Text) = "0306" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then
            Try
                Dim ArrayCurrent As Single = ToSigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) * IScale 'Array current (A)
                Dim iArrayReadErr As Boolean = lviCAN.SubItems(8).Text And 32 'Array current read error (bit 5)
                'Calculate values
                ArrayPower = ArrayCurrent * SystemV
                'Calculate stats
                If CANactive Then
                    If ArrayPower > ArrayPowerMax Then ArrayPowerMax = ArrayPower 'Update maximum array power
                    If ArrayPower < ArrayPowerMin Then ArrayPowerMin = ArrayPower 'Update minimum array power
                    ArrayPowerRecent = (ArrayPowerRecent * (LongWeight - 1) + ArrayPower) / LongWeight 'Update weighted average for array power
                    ArrayPowerCount += 1 'Increment array power counter
                    ArrayPowerAvg = ArrayPowerAvg * ((ArrayPowerCount - 1) / ArrayPowerCount) + ArrayPower / ArrayPowerCount 'Update average array power
                End If
                'Update main display window
                gvSystemStatus.Item(1, CByte(ArrayStatusRow(1))).Value = Format(ArrayCurrent, "0.00") 'Array current
                gvRuntimeStats.Item(1, CByte(ArrayPowerRow(1))).Value = Format(ArrayPower, "0.0") 'Array power
                gvRuntimeStats.Item(2, CByte(ArrayPowerRow(1))).Value = Format(ArrayPowerRecent, "0.0") 'Array power recent
                gvRuntimeStats.Item(3, CByte(ArrayPowerRow(1))).Value = Format(ArrayPowerAvg, "0.0") 'Array power average
                gvRuntimeStats.Item(4, CByte(ArrayPowerRow(1))).Value = Format(ArrayPowerMax, "0.0") 'Array power max
                gvRuntimeStats.Item(5, CByte(ArrayPowerRow(1))).Value = Format(ArrayPowerMin, "0.0") 'Array power min
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If CUShort(lviCAN.Text) = "0307" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then
            Try
                Dim MotorCurrent As Single = ToSigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) * IScale 'Array current (A)
                Dim iMotorReadErr As Boolean = lviCAN.SubItems(8).Text And 32 'Motor current read error (bit 5)
                'Calculate values
                MotorPower = MotorCurrent * SystemV
                'Calculate stats
                If CANactive Then
                    If MotorPower > MotorPowerMax Then MotorPowerMax = MotorPower 'Update maximum motor power
                    If MotorPower < MotorPowerMin Then MotorPowerMin = MotorPower 'Update minimum motor power
                    MotorPowerRecent = (MotorPowerRecent * (LongWeight - 1) + MotorPower) / LongWeight 'Update weighted average for motor power
                    MotorPowerCount += 1 'Increment motor power counter
                    MotorPowerAvg = MotorPowerAvg * ((MotorPowerCount - 1) / MotorPowerCount) + MotorPower / MotorPowerCount 'Update average motor power
                End If
                'Update main display window
                gvSystemStatus.Item(1, CByte(MotorStatusRow(1))).Value = Format(MotorCurrent, "0.00") 'Motor current
                gvRuntimeStats.Item(1, CByte(MotorPowerRow(1))).Value = Format(MotorPower, "0.0") 'Motor power
                gvRuntimeStats.Item(2, CByte(MotorPowerRow(1))).Value = Format(MotorPowerRecent, "0.0") 'Motor power recent
                gvRuntimeStats.Item(3, CByte(MotorPowerRow(1))).Value = Format(MotorPowerAvg, "0.0") 'Motor power average
                gvRuntimeStats.Item(4, CByte(MotorPowerRow(1))).Value = Format(MotorPowerMax, "0.0") 'Motor power max
                gvRuntimeStats.Item(5, CByte(MotorPowerRow(1))).Value = Format(MotorPowerMin, "0.0") 'Motor power min
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If CUShort(lviCAN.Text) = "0310" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then
            Try
                'Update powerboard info
                Dim AuxV As Single = ToUnsigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) * pbScale 'Aux pack voltage (V)
                Dim V12Main As Single = ToUnsigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) * pbScale '12V main bus voltage (V)
                Dim V12Aux As Single = ToUnsigned(CByte(lviCAN.SubItems(8).Text), CByte(lviCAN.SubItems(9).Text)) * pbScale '12V aux bus voltage (V)
                Dim V5 = CByte(lviCAN.SubItems(10).Text) * V5Scale '5V bus voltage (V)
                Dim AuxReadErr As Boolean = lviCAN.SubItems(11).Text And 0 'Aux pack read error (bit 0)
                Dim MainV12ReadErr As Boolean = lviCAN.SubItems(11).Text And 2 '12V main read error (bit 1)
                Dim AuxV12ReadErr As Boolean = lviCAN.SubItems(11).Text And 4 '12V aux read error (bit 2)
                Dim V5ReadErr As Boolean = lviCAN.SubItems(11).Text And 8 '5V read error (bit 3)
                Dim AuxPackLow As Boolean = lviCAN.SubItems(11).Text And 16 'Aux pack low (bit 4)
                'Update main display window
                gvVehicleVoltage.Item(1, CByte(AuxPackVRow(1))).Value = Format(AuxV, "0.00") 'Aux pack voltage
                gvVehicleVoltage.Item(1, CByte(V12MainRow(1))).Value = Format(V12Main, "0.00") 'Aux pack voltage
                gvVehicleVoltage.Item(1, CByte(V12AuxRow(1))).Value = Format(V12Aux, "0.00") 'Aux pack voltage
                gvVehicleVoltage.Item(1, CByte(V5Row(1))).Value = Format(V5, "0.0") 'Aux pack voltage
                If AuxPackLow Then
                    gvVehicleVoltage.Item(1, CByte(AuxPackLowRow(1))).Value = "Low" 'Aux pack low
                Else
                    gvVehicleVoltage.Item(1, CByte(AuxPackLowRow(1))).Value = "Normal" 'Aux pack normal
                End If
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If CUShort(lviCAN.Text) = "0323" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then
            Try
                Dim SOC As Integer = lviCAN.SubItems(6).Text 'State of charge
                Dim mpptEn As Boolean = lviCAN.SubItems(7).Text And 0 'MPPT enable (bit 0)
                Dim ArrayEn As Boolean = lviCAN.SubItems(7).Text And 2 'Array enable (bit 1)
                Dim ArraySw As Boolean = lviCAN.SubItems(7).Text And 4 'Array switch (bit 2)
                Dim PackEn As Boolean = lviCAN.SubItems(7).Text And 8 'Pack enable (bit 3)
                Dim PreCharge As Boolean = lviCAN.SubItems(7).Text And 16 'Pack pre-charge (bit 4)
                If Not ArraySw Then
                    gvSystemStatus.Item(2, CByte(ArrayStatusRow(1))).Value = "Disabled" 'Array disabled
                Else
                    If Not ArrayEn Then
                        gvSystemStatus.Item(2, CByte(ArrayStatusRow(1))).Value = "Batt Full" 'Battery full
                    Else
                        gvSystemStatus.Item(2, CByte(ArrayStatusRow(1))).Value = "Enabled" 'Array enabled
                    End If
                End If
                If PackEn Then
                    gvSystemStatus.Item(2, CByte(PackStatusRow(1))).Value = "Enabled" 'Pack enabled
                ElseIf PreCharge Then
                    gvSystemStatus.Item(2, CByte(PackStatusRow(1))).Value = "Precharge" 'Pre-charge
                Else
                    gvSystemStatus.Item(2, CByte(PackStatusRow(1))).Value = "Disabled" 'Pack disabled
                End If
                gvVehicleInfo.Item(1, CByte(StateOfChargeRow(1))).Value = Format(SOC / 100, "0%") 'State of charge
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If CUShort(lviCAN.Text) = "0324" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then
            Try
                Dim Cycles As Integer = ToUnsigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) 'Battery pack cycle count
                Dim BatteryCapacity As Integer = ToUnsigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) * 99.9 / 1000 'Current battery pack capacity
                'Update main display window
                gvVehicleInfo.Item(1, CByte(BatteryCapacityRow(1))).Value = Format(BatteryCapacity, "0.00") 'Battery capacity (kWh)
                gvVehicleInfo.Item(1, CByte(BatteryCyclesRow(1))).Value = Cycles 'Battery cycles (count)
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        'Calculated values
        If Math.Abs(PackPower) < 200 Then NoLoadV = SystemV
        HighT = 0 'Initialize high module temperature
        HighV = 0 'Initialize high module voltage
        LowV = 100 'Initialize low module voltage as an arbitrary high number
        For Each lviModule As ListViewItem In lvBPS.Items
            Sum1 += lviModule.SubItems(2).Text 'Sum module temperatures
            Counter += 1 'Increment counter
            If CSng(lviModule.SubItems(2).Text) > HighT Then
                HighT = lviModule.SubItems(2).Text 'Update high module temperature
                HighTmod = lviModule.Text 'Update module number
            End If
            If CSng(lviModule.SubItems(1).Text) > HighV Then
                HighV = lviModule.SubItems(1).Text 'Update high module voltage
                HighVmod = lviModule.Text 'Update module number
            End If
            If CSng(lviModule.SubItems(1).Text) < LowV Then
                LowV = lviModule.SubItems(1).Text 'Update low module voltage
                LowVmod = lviModule.Text 'Update module number
            End If
        Next
        If HighV - LowV > 0 Then vRange = HighV - LowV 'Voltage range of modules
        Dim instModuleTemp As Single = Sum1 / Counter 'Instantaneous average module temp
        'Calculate stats
        If CANactive Then
            If instModuleTemp > PackTMax Then PackTMax = instModuleTemp 'Update maximum pack temp
            If instModuleTemp < PackTMin Then PackTMin = instModuleTemp 'Update minimum pack temp
            If Not instModuleTemp.ToString = "NaN" Then
                PackTCount += 1 'Increment pack temp counter
                PackTRecent = (PackTRecent * (LongWeight - 1) + instModuleTemp) / LongWeight 'Update weighted average for pack temp
                PackTAvg = PackTAvg * ((PackTCount - 1) / PackTCount) + instModuleTemp / PackTCount 'Update average pack temp
            End If
        End If
        'Update main display window
        gvVehicleVoltage.Item(1, CByte(SystemVRow(1))).Value = Format(SystemV, "0.0") 'System voltage
        gvVehicleVoltage.Item(1, CByte(NoLoadVRow(1))).Value = Format(NoLoadV, "0.0") 'System voltage at low load
        gvVehicleInfo.Item(1, CByte(HighModuleTRow(1))).Value = Format(HighT, "0.0") & " (Module " & HighTmod & ")" 'High module temperature
        gvVehicleInfo.Item(1, CByte(HighModuleVRow(1))).Value = Format(HighV, "0.000") & " (Module " & HighVmod & ")" 'High module voltage
        gvVehicleInfo.Item(1, CByte(LowModuleVRow(1))).Value = Format(LowV, "0.000") & " (Module " & LowVmod & ")" 'Low module voltage
        gvVehicleVoltage.Item(1, CByte(ModuleVRangeRow(1))).Value = Format(vRange, "0.000") 'Voltage range of modules
        gvRuntimeStats.Item(1, CByte(BatteryTRow(1))).Value = Format(instModuleTemp, "0.0") 'Pack temp
        gvRuntimeStats.Item(2, CByte(BatteryTRow(1))).Value = Format(PackTRecent, "0.0") 'Recent pack temp
        gvRuntimeStats.Item(3, CByte(BatteryTRow(1))).Value = Format(PackTAvg, "0.0") 'Average pack temp
        gvRuntimeStats.Item(4, CByte(BatteryTRow(1))).Value = Format(PackTMax, "0.0") 'Max pack temp
        gvRuntimeStats.Item(5, CByte(BatteryTRow(1))).Value = Format(PackTMin, "0.0") 'Min pack temp
    End Sub

    'Actions performed when the clear modules button is clicked
    Private Sub msClearModules_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msClearModules.Click
        lvBPS.Items.Clear() 'Clear list view items
    End Sub

#End Region

#Region "Power Trackers (MPPT)"

    'Process MPPT data
    Private Sub MPPT(ByVal lviCAN As ListViewItem)
        Dim Sum0 As Single = 0 'Initilaize temporary sum variable
        Dim Sum1 As Single = 0 'Initialize temporary sum variable
        Dim Counter As Integer = 0 'Initialize counter
        Dim found As Boolean = False 'Initialize variable
        'Populate MPPT list view on Timer A
        If TimerA = TimerAReset And CANactive And CUShort(lviCAN.Text) >= FirstMPPT And CUShort(lviCAN.Text) <= LastMPPT And CUShort(lviCAN.SubItems(2).Text = "No") And Not CUShort(lviCAN.SubItems(3).Text = "0") Then
            Try
                'Convert & scale module information
                Dim mpptNumber As UInteger = lviCAN.Text 'Module number
                Dim inputV As Single = ToUnsigned(CByte(lviCAN.SubItems(5).Text), CByte(lviCAN.SubItems(4).Text)) * mpptVinScale 'Input voltage (V)
                Dim inputI As Single = ToUnsigned(CByte(lviCAN.SubItems(7).Text), CByte(lviCAN.SubItems(6).Text)) * mpptIinScale 'Input current (A)
                Dim inputP As Single = inputV * inputI 'Calculated input power (W)
                Dim cellP As Single 'Power per cell (W)
                Dim outputV As Single = ToUnsigned(CByte(lviCAN.SubItems(9).Text), CByte(lviCAN.SubItems(8).Text)) * mpptVoutScale 'Output voltage (V)
                Dim ambTemp As Single = ToUnsigned(CByte(lviCAN.SubItems(11).Text), CByte(lviCAN.SubItems(10).Text)) * mpptTempScale 'Ambient temperature (C)
                Dim UpdateTime As String = lviCAN.SubItems(12).Text 'Time of last update
                'Check whether the MPPT already exists in the MPPT list view
                For Each lviMPPT As ListViewItem In lvMPPT.Items
                    If lviMPPT.Text = String.Format(Format(CUShort(mpptNumber) - FirstMPPT, "00")) Then
                        'If the MPPT exists in the list view, update the MPPT data
                        If CUShort(mpptNumber) - FirstMPPT = 0 Then
                            lviMPPT.SubItems(1).Text = mppt0cells
                            cellP = inputP / mppt0cells
                        ElseIf CUShort(mpptNumber) - FirstMPPT = 1 Then
                            lviMPPT.SubItems(1).Text = mppt1cells
                            cellP = inputP / mppt1cells
                        ElseIf CUShort(mpptNumber) - FirstMPPT = 2 Then
                            lviMPPT.SubItems(1).Text = mppt2cells
                            cellP = inputP / mppt2cells
                        ElseIf CUShort(mpptNumber) - FirstMPPT = 3 Then
                            lviMPPT.SubItems(1).Text = mppt3cells
                            cellP = inputP / mppt3cells
                        End If
                        lviMPPT.SubItems(2).Text = Format(inputV, "0.0") 'Update MPPT input voltage
                        lviMPPT.SubItems(3).Text = Format(inputI, "0.00") 'Update MPPT input current
                        lviMPPT.SubItems(4).Text = Format(inputP, "0.0") 'Update MPPT input power
                        lviMPPT.SubItems(5).Text = Format(cellP, "0.00") 'Update power per cell
                        lviMPPT.SubItems(6).Text = Format(outputV, "0.0") 'Update MPPT output voltage
                        lviMPPT.SubItems(7).Text = Format(ambTemp, "0.0") 'Update MPPT temperature
                        lviMPPT.SubItems(8).Text = UpdateTime 'Update MPPT refresh time stamp
                        If CUShort(mpptNumber) - FirstMPPT = 0 Then
                            lviMPPT.SubItems(9).Text = "A - Front"
                        ElseIf CUShort(mpptNumber) - FirstMPPT = 1 Then
                            lviMPPT.SubItems(9).Text = "B - Middle"
                        ElseIf CUShort(mpptNumber) - FirstMPPT = 2 Then
                            lviMPPT.SubItems(9).Text = "C - Rear Left"
                        ElseIf CUShort(mpptNumber) - FirstMPPT = 3 Then
                            lviMPPT.SubItems(9).Text = "D - Rear Right"
                        End If
                        found = True 'Confirm that the module has been found in the list view and updated
                        Exit For
                    End If
                Next
                'Add a new battery module to the list view if it doesn't exist yet
                If Not found Then
                    'If the MPPT doesn't exist in the list view, add it as a new MPPT
                    Dim lviMPPT As New ListViewItem(Format(CUShort(mpptNumber) - FirstMPPT, "00")) 'Format and add module number
                    If CUShort(mpptNumber) - FirstMPPT = 0 Then
                        lviMPPT.SubItems.Add(mppt0cells)
                        cellP = inputP / mppt0cells
                    ElseIf CUShort(mpptNumber) - FirstMPPT = 1 Then
                        lviMPPT.SubItems.Add(mppt1cells)
                        cellP = inputP / mppt1cells
                    ElseIf CUShort(mpptNumber) - FirstMPPT = 2 Then
                        lviMPPT.SubItems.Add(mppt2cells)
                        cellP = inputP / mppt2cells
                    ElseIf CUShort(mpptNumber) - FirstMPPT = 3 Then
                        lviMPPT.SubItems.Add(mppt3cells)
                        cellP = inputP / mppt3cells
                    End If
                    lviMPPT.SubItems.Add(Format(inputV, "0.0")) 'Add MPPT input voltage
                    lviMPPT.SubItems.Add(Format(inputI, "0.00")) 'Add MPPT input current
                    lviMPPT.SubItems.Add(Format(inputP, "0.0")) 'Add MPPT input power
                    lviMPPT.SubItems.Add(Format(cellP, "0.00")) 'Add power per cell
                    lviMPPT.SubItems.Add(Format(outputV, "0.0")) 'Add MPPT ouput voltage
                    lviMPPT.SubItems.Add(Format(ambTemp, "0.0")) 'Add MPPT ambient temperature
                    lviMPPT.SubItems.Add(UpdateTime) 'Add MPPT refresh time stamp
                    lvMPPT.Items.Add(lviMPPT) 'Add the battery module to the MPPT list view
                    If CUShort(mpptNumber) - FirstMPPT = 0 Then
                        lviMPPT.SubItems.Add("A - Front")
                    ElseIf CUShort(mpptNumber) - FirstMPPT = 1 Then
                        lviMPPT.SubItems.Add("B - Middle")
                    ElseIf CUShort(mpptNumber) - FirstMPPT = 2 Then
                        lviMPPT.SubItems.Add("C - Rear Left")
                    ElseIf CUShort(mpptNumber) - FirstMPPT = 3 Then
                        lviMPPT.SubItems.Add("D - Rear Right")
                    End If
                End If
                'Calculate values
                For Each lviMPPT As ListViewItem In lvMPPT.Items
                    Sum0 += lviMPPT.SubItems(4).Text 'Sum MPPT input power
                    Sum1 += lviMPPT.SubItems(7).Text 'Sum MPPT temperature
                    Counter += 1 'Increment counter
                Next
                Dim instMPPTtemp As Single = Sum1 / Counter 'Instantaneous average MPPT temp 
                ArrayPanelPower = Sum0 'Total array power
                'Calculate stats
                If CANactive Then
                    If instMPPTtemp > MPPTtMax Then MPPTtMax = instMPPTtemp 'Update maximum MPPT temp
                    If instMPPTtemp < MPPTtMin Then MPPTtMin = instMPPTtemp 'Update minimum MPPT temp
                    MPPTtRecent = (MPPTtRecent * (MidWeight - 1) + instMPPTtemp) / MidWeight 'Update weighted average for MPPT temp
                    MPPTtCount += 1 'Increment MPPT temp counter
                    MPPTtAvg = MPPTtAvg * ((MPPTtCount - 1) / MPPTtCount) + instMPPTtemp / MPPTtCount 'Update average MPPT temp
                End If
                'Update main display window
                gvRuntimeStats.Item(1, CByte(mpptTRow(1))).Value = Format(instMPPTtemp, "0.0") 'MPPT temp
                gvRuntimeStats.Item(2, CByte(mpptTRow(1))).Value = Format(MPPTtRecent, "0.0") 'Recent MPPT temp
                gvRuntimeStats.Item(3, CByte(mpptTRow(1))).Value = Format(MPPTtAvg, "0.0") 'Average MPPT temp
                gvRuntimeStats.Item(4, CByte(mpptTRow(1))).Value = Format(MPPTtMax, "0.0") 'Max MPPT temp
                gvRuntimeStats.Item(5, CByte(mpptTRow(1))).Value = Format(MPPTtMin, "0.0") 'Min MPPT temp
                gvRuntimeStats.Item(1, CByte(ArrayPowerRow(1))).Value = Format(ArrayPower, "0.0") 'Array power
                gvSystemStatus.Item(1, CByte(ArrayStatusRow(1))).Value = Format(ArrayPower / SystemV, "0.0") 'Array current
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
    End Sub

    'Actions performed when the clear MPPTs button is clicked
    Private Sub clearMPPTs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miClearMPPTs.Click
        lvMPPT.Items.Clear() 'Clear list view items
    End Sub

#End Region

#Region "Motor"

    Private Sub Motor(ByVal lviCAN As ListViewItem)
        If lviCAN.Text = "0769" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Motor speed & status data
            Try
                'Convert and scale speed & status data
                Dim RPM As Single = ToSigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) 'Motor speed (RPM)
                MPH = Math.Abs(RPM * TireDiameter * Pi * 60 / 63360) 'Motor speed (MPH)
                Dim Throttle As Single = lviCAN.SubItems(8).Text * PedalScale 'Throttle position (%)
                Dim Regen As Single = lviCAN.SubItems(9).Text * PedalScale 'Regen position (%)
                Dim DriveState As Short = Hex(ToUnsigned(CByte(lviCAN.SubItems(10).Text), CByte(lviCAN.SubItems(11).Text)) And &HFFF0) 'Controller is transitioning out of torque production (bit 7)
                MotorEnabled = lviCAN.SubItems(10).Text And 4 'Motor is enabled (bit 2)
                Dim Reverse As Boolean = lviCAN.SubItems(11).Text And 1 'Motor is in reverse mode (bit 0)
                Dim SpeedControl As Boolean = lviCAN.SubItems(11).Text And 2 'Controler is in speed control mode (bit 1)
                Dim Limiting As Boolean = lviCAN.SubItems(11).Text And 4 'Controller is limiting output current (bit 2)
                'Calculate stats
                If CANactive Then
                    If MPH > MPHmax Then MPHmax = MPH 'Update maximum MPH
                    If MPH < MPHmin Then MPHmin = MPH 'Update minimum MPH
                    MPHrecent = (MPHrecent * (MidWeight - 1) + MPH) / MidWeight 'Update weighted average for MPH
                    MPHcount += 1 'Increment MPH counter
                    MPHavg = MPHavg * ((MPHcount - 1) / MPHcount) + MPH / MPHcount 'Update average MPH
                End If
                'Display speed & status data
                gvRuntimeStats.Item(1, CByte(SpeedRow(1))).Value = Format(MPH, "0.0") 'Driving speed
                gvRuntimeStats.Item(2, CByte(SpeedRow(1))).Value = Format(MPHrecent, "0.0") 'Recent speed
                gvRuntimeStats.Item(3, CByte(SpeedRow(1))).Value = Format(MPHavg, "0.0") 'Average speed
                gvRuntimeStats.Item(4, CByte(SpeedRow(1))).Value = Format(MPHmax, "0.0") 'Max speed
                gvRuntimeStats.Item(5, CByte(SpeedRow(1))).Value = Format(MPHmin, "0.0") 'Min speed
                'Throttle position (%)
                lblThrottle.Text = "Throttle Position: " & Format(Throttle, "0%").ToString 'Update motor tab
                gvVehicleInfo.Item(1, CByte(ThrottlePositionRow(1))).Value = Format(Throttle, "0%") 'Update main display window
                'Regen position (%)
                lblRegen.Text = "Regen Position: " & Format(Regen, "0%").ToString 'Update motor tab
                gvVehicleInfo.Item(1, CByte(RegenPositionRow(1))).Value = Format(Regen, "0%") 'Update main display window
                If DriveState = "1000" Then lblDriveState.Text = "System State: Controller Startup" 'The controller is performing its initialization
                If DriveState = "5100" Then lblDriveState.Text = "System State: Controller Standby" 'The controller is in low power standby mode
                If DriveState = "5000" Then lblDriveState.Text = "System State: No Motor Connected" 'Initialized but no motor sense cable is connected
                If DriveState = "7100" Then lblDriveState.Text = "System State: Charging Ignition" 'Charger is plugged in and the ignition is off
                If DriveState = "7000" Then lblDriveState.Text = "System State: Charging No Ignition" 'Charger is plugged in and ignition is on
                If DriveState = "4000" Then lblDriveState.Text = "System State: Controller Shutdown" 'Normal powered down mode
                If DriveState = "4800" Then lblDriveState.Text = "System State: Controller Interlock" 'A disable input must be asserted to leave this state
                If DriveState = "4400" Then lblDriveState.Text = "System State: Controller Enabled" 'The controller is enabled but the phase current input is zero
                If DriveState = "4600" Then lblDriveState.Text = "System State: Motor Active" 'The drive system is producing accelerating torque
                If DriveState = "4680" Then lblDriveState.Text = "System State: Transition" 'The controller is leaving the active state
                If Reverse = True Then
                    'Direction is reverse
                    lblMotorReverse.Text = "Drive Direction: Reverse" 'Update motor tab
                    gvVehicleInfo.Item(1, CByte(DirectionRow(1))).Value = "Reverse" 'Update main display window
                Else
                    'Direction is forward
                    lblMotorReverse.Text = "Drive Direction: Forward" 'Update motor tab
                    gvVehicleInfo.Item(1, CByte(DirectionRow(1))).Value = "Forward" 'Update main display window
                End If
                If Limiting = True Then
                    gvVehicleInfo.Item(1, CByte(MotorLimitingRow(1))).Value = "Yes" 'Controller is limiting output current
                Else
                    gvVehicleInfo.Item(1, CByte(MotorLimitingRow(1))).Value = "No" 'Controller is not limiting output current
                End If
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If TimerA = TimerAReset And lviCAN.Text = "0770" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Motor supply data
            Try
                'Convert and scale supply data
                Dim MotorV As Single = ToSigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) * MotorVScale 'Motor supply voltage (V)
                Dim mcPackCurrent As Single = ToSigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) * MotorIScale 'Pack current measured by motor controller (A)
                Dim TripOdometer As Single = ToUnsigned(CByte(lviCAN.SubItems(8).Text), CByte(lviCAN.SubItems(9).Text)) * MotorOdScale 'Trip odometer since last boot (mi)
                'Display supply data
                lblMotorV.Text = "Supply Voltage: " & Format(MotorV, "0.0V").ToString 'Motor supply voltage (V)
                'Update main window
                gvVehicleInfo.Item(1, CByte(TripOdometerRow(1))).Value = Format(TripOdometer, "0.0") 'Trip odometer (mi)
                ''Display pack current and power measured by the motor
                'PackPower = SystemV * mcPackCurrent 'Pack current
                'gvSystemStatus.Item(1, CByte(PackStatusRow(1))).Value = Format(mcPackCurrent, "0.00") 'Pack current
                'gvRuntimeStats.Item(1, CByte(PackPowerRow(1))).Value = Format(PackPower, "0.0") 'Pack power
                'If mcPackCurrent > 0 Then
                '    gvVehicleInfo.Item(1, CByte(BatteryStatusRow(1))).Value = "Charging" 'Pack is charging
                'ElseIf mcPackCurrent < 0 Then
                '    gvVehicleInfo.Item(1, CByte(BatteryStatusRow(1))).Value = "Draining" 'Pack is draining
                'Else
                '    gvVehicleInfo.Item(1, CByte(BatteryStatusRow(1))).Value = "Equillibrium" 'Pack is neither charging nor draining
                'End If
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If TimerA = TimerAReset And lviCAN.Text = "0771" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Motor temperature data
            Try
                'Convert and scale temperature data
                Dim BaseplateT As Single = ToSigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) * MotorTScale 'Controller baseplate temperature (C)
                Dim ControllerT As Single = ToSigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) * MotorTScale 'Controller ambient temperature (C)
                Dim MotorT As Single = ToSigned(CByte(lviCAN.SubItems(8).Text), CByte(lviCAN.SubItems(9).Text)) * MotorTScale 'Motor temperature (C)
                'Calculate stats
                If CANactive Then
                    If MotorT > MotorTMax Then MotorTMax = MotorT 'Update maximum motor temp
                    If MotorT < MotorTMin Then MotorTMin = MotorT 'Update minimum motor temp
                    MotorTRecent = (MotorTRecent * (ShortWeight - 1) + MotorT) / ShortWeight 'Update weighted average for motor temp
                    MotorTCount += 1 'Increment motor temp counter
                    MotorTAvg = MotorTAvg * ((MotorTCount - 1) / MotorTCount) + MotorT / MotorTCount 'Update average motor temp
                    If ControllerT > ControllerTMax Then ControllerTMax = ControllerT 'Update maximum controller temp
                    If ControllerT < ControllerTMin Then ControllerTMin = ControllerT 'Update minimum controller temp
                    ControllerTRecent = (ControllerTRecent * (ShortWeight - 1) + ControllerT) / ShortWeight 'Update weighted average for controller temp
                    ControllerTCount += 1 'Increment controller temp counter
                    ControllerTAvg = ControllerTAvg * ((ControllerTCount - 1) / ControllerTCount) + ControllerT / ControllerTCount 'Update average controller temp
                    If BaseplateT > BaseplateTMax Then BaseplateTMax = BaseplateT 'Update maximum baseplate temp
                    If BaseplateT < BaseplateTMin Then BaseplateTMin = BaseplateT 'Update minimum baseplate temp
                    BaseplateTRecent = (BaseplateTRecent * (ShortWeight - 1) + BaseplateT) / ShortWeight 'Update weighted average for baseplate temp
                    BaseplateTCount += 1 'Increment baseplate temp counter
                    BaseplateTAvg = BaseplateTAvg * ((BaseplateTCount - 1) / BaseplateTCount) + BaseplateT / BaseplateTCount 'Update average baseplate temp
                End If
                'Display temperature data
                lblBaseplateT.Text = "Baseplate Temp: " & Format(BaseplateT, "0.0°C").ToString 'Controller baseplate temperature (C)
                lblControllerT.Text = "Controller Temp: " & Format(ControllerT, "0.0°C").ToString 'Controller ambient temperature (C)
                If MotorT > -50 Then lblMotorT.Text = "Motor Temp: " & Format(MotorT, "0.0°C").ToString 'Motor temperature (C)
                'Update main display window
                gvRuntimeStats.Item(1, CByte(BaseplateTRow(1))).Value = Format(BaseplateT, "0.0") 'Baseplate temperature (C)
                gvRuntimeStats.Item(2, CByte(BaseplateTRow(1))).Value = Format(BaseplateTRecent, "0.0") 'Recent baseplate temperature (C)
                gvRuntimeStats.Item(3, CByte(BaseplateTRow(1))).Value = Format(BaseplateTAvg, "0.0") 'Average baseplate temperature (C)
                gvRuntimeStats.Item(4, CByte(BaseplateTRow(1))).Value = Format(BaseplateTMax, "0.0") 'Max baseplate temperature (C)
                gvRuntimeStats.Item(5, CByte(BaseplateTRow(1))).Value = Format(BaseplateTMin, "0.0") 'Min baseplate temperature (C)
                gvRuntimeStats.Item(1, CByte(ControllerTRow(1))).Value = Format(ControllerT, "0.0") 'Controller temperature (C)
                gvRuntimeStats.Item(2, CByte(ControllerTRow(1))).Value = Format(ControllerTRecent, "0.0") 'Recent controller temperature (C)
                gvRuntimeStats.Item(3, CByte(ControllerTRow(1))).Value = Format(ControllerTAvg, "0.0") 'Average controller temperature (C)
                gvRuntimeStats.Item(4, CByte(ControllerTRow(1))).Value = Format(ControllerTMax, "0.0") 'Max controller temperature (C)
                gvRuntimeStats.Item(5, CByte(ControllerTRow(1))).Value = Format(ControllerTMin, "0.0") 'Min controller temperature (C)
                If MotorT > -50 Then gvRuntimeStats.Item(1, CByte(MotorTRow(1))).Value = Format(MotorT, "0.0") 'Motor temperature (C)
                If MotorT > -50 Then gvRuntimeStats.Item(2, CByte(MotorTRow(1))).Value = Format(MotorTRecent, "0.0") 'Recent motor temperature (C)
                If MotorT > -50 Then gvRuntimeStats.Item(3, CByte(MotorTRow(1))).Value = Format(MotorTAvg, "0.0") 'Average motor temperature (C)
                If MotorT > -50 Then gvRuntimeStats.Item(4, CByte(MotorTRow(1))).Value = Format(MotorTMax, "0.0") 'Max motor temperature (C)
                If MotorT > -50 Then gvRuntimeStats.Item(5, CByte(MotorTRow(1))).Value = Format(MotorTMin, "0.0") 'Min motor temperature (C)
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If TimerA = TimerAReset And lviCAN.Text = "0772" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Pedal state
            Try
                'Convert pedal state and motor controller output current data
                Dim DesiredCurrent As Single = ToSigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) * MotorIScale 'Controller output current desired by driver
                Dim ActualCurrent As Single = ToSigned(CByte(lviCAN.SubItems(8).Text), CByte(lviCAN.SubItems(9).Text)) * MotorIScale 'Actual controller output current
                Dim ThrottleEn As Boolean = lviCAN.SubItems(11).Text And 0 'Throttle enable in motor board(bit 0)
                Dim RegenEn As Boolean = lviCAN.SubItems(11).Text And 2 'Regen enable in motor board(bit 1)
                'Display motor controller output current
                lblDesiredI.Text = "Desired Output Current: " & Format(DesiredCurrent, "0.0A") 'Desired output current (A)
                lblActualI.Text = "Actual Output Current: " & Format(ActualCurrent, "0.0A") 'Actual output current (A)
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If TimerA = TimerAReset And lviCAN.Text = "0773" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Motor fault data
            Try
                'Convert fault data
                Dim StuckThrottle As Boolean = lviCAN.SubItems(4).Text And 2 'Throttle was non-zero when asserting forward or reverse signal (bit 0)
                Dim ZeroTimeOut As Boolean = lviCAN.SubItems(5).Text And 32 'Serial time out duration is zero (bit 3)
                Dim LostCom As Boolean = lviCAN.SubItems(5).Text And 64 'Lost serial communication (bit 4)
                Dim IntPowerError As Boolean = lviCAN.SubItems(5).Text And 128 'Internal over voltage or over temperature (bit 5)
                Dim ThrottleExcite As Boolean = lviCAN.SubItems(8).Text And 64 'Throttle signal out of range (bit 4)
                Dim RegenExcite As Boolean = lviCAN.SubItems(8).Text And 128 'Regen signal out of range (bit 5)
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If TimerA = TimerAReset And lviCAN.Text = "0774" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Motor limiting data
            Try
                'Convert motor limiting data
                Dim ThrottleLimit As Integer = ToSigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) 'Controller throttle limiting code number
                Dim RegenLimit As Integer = ToSigned(CByte(lviCAN.SubItems(6).Text), CByte(lviCAN.SubItems(7).Text)) 'Controller regen limiting code number
                lblThrottleLimit.Text = "Throttle Limit Code: " & ThrottleLimit 'Throttle limit code
                lblRegenLimit.Text = "Regen Limit Code: " & RegenLimit 'Regen limit code
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If TimerA = TimerAReset And lviCAN.Text = "0775" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Motor status data
            Try
                Dim ComError As Boolean
                'Convert status data
                Dim ComConnect As Integer = lviCAN.SubItems(4).Text 'Serial communication established with motor
                Dim MotorInitialized As Boolean = lviCAN.SubItems(5).Text 'Motor controller has been initialized
                If lviCAN.SubItems(7).Text = 0 Then
                    ComError = 0 'No serial communication error detected
                Else
                    ComError = 1 'Serial communication error detected
                End If
                If Not ComConnect = 1 Then
                    gvSystemStatus.Item(2, CByte(MotorStatusRow(1))).Value = "No Com" 'Serial cable disconnected
                Else
                    If ComError Then
                        gvSystemStatus.Item(2, CByte(MotorStatusRow(1))).Value = "Com Error" 'Serial communication error
                    Else
                        If Not MotorInitialized Then
                            gvSystemStatus.Item(2, CByte(MotorStatusRow(1))).Value = "Initializing" 'Motor board initializing the motor controller
                        Else
                            If Not MotorEnabled Then
                                gvSystemStatus.Item(2, CByte(MotorStatusRow(1))).Value = "Initialized" 'Motor controller initialized
                            Else
                                gvSystemStatus.Item(2, CByte(MotorStatusRow(1))).Value = "Enabled" 'Motor controller enabled
                            End If
                        End If
                    End If
                End If
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
    End Sub

#End Region

#Region "Dash"

    Private Sub Dash(ByVal lviCAN As ListViewItem)
        Try
            If lviCAN.Text = "1920" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Motor speed & status data
                'Convert and scale cockpt data
                Dim CockpitTemp As Single = ToSigned(CByte(lviCAN.SubItems(4).Text), CByte(lviCAN.SubItems(5).Text)) 'Cockpit temp (C)
                'Calculate stats
                If CANactive Then
                    CockpitTempRecent = (CockpitTempRecent * (ShortWeight - 1) + CockpitTemp) / ShortWeight 'Update weighted average for cockpit temp
                    CockpitTCount += 1 'Increment cockpit temp counter
                    CockpitTempAvg = CockpitTempAvg * ((CockpitTCount - 1) / CockpitTCount) + CockpitTemp / CockpitTCount 'Update average cockpit temp
                    If CockpitTemp > CockpitTempMax Then CockpitTempMax = CockpitTemp 'Update maximum cockpit temp
                    If CockpitTemp < CockpitTempMin Then CockpitTempMin = CockpitTemp 'Update minimum cockpit temp
                End If
                'Update main display window
                gvRuntimeStats.Item(1, CByte(CockpitTRow(1))).Value = Format(CockpitTemp, "0") 'Cockpit temperature (C)
                gvRuntimeStats.Item(2, CByte(CockpitTRow(1))).Value = Format(CockpitTempRecent, "0") 'Recent cockpit temperature (C)
                gvRuntimeStats.Item(3, CByte(CockpitTRow(1))).Value = Format(CockpitTempAvg, "0") 'Average cockpit temperature (C)
                gvRuntimeStats.Item(4, CByte(CockpitTRow(1))).Value = Format(CockpitTempMax, "0") 'Max cockpit temperature (C)
                gvRuntimeStats.Item(5, CByte(CockpitTRow(1))).Value = Format(CockpitTempMin, "0") 'Min cockpit temperature (C)
            End If
        Catch
            lblEr.Text += 1 'Increment CAN message error count
        End Try
    End Sub

#End Region

#Region "Vehicle Dynamics (VDTS)"

    'Process VDTS data
    Private Sub VDTS(ByVal lviCAN As ListViewItem)
        'Display VDTS board messages (Vehicle Dynamics Telemetry System)
        If lviCAN.Text = "1281" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Accelerometer data
            Try
                'Convert & scale accelerometer data
                Dim AccX As Single = ToSigned(lviCAN.SubItems(4).Text, lviCAN.SubItems(5).Text) * AccScale 'X axis (G Force)
                Dim AccY As Single = ToSigned(lviCAN.SubItems(6).Text, lviCAN.SubItems(7).Text) * AccScale 'Y axis (G Force)
                Dim AccZ As Single = ToSigned(lviCAN.SubItems(8).Text, lviCAN.SubItems(9).Text) * AccScale 'Z axis (G Force)
                'Display data
                lblAccX.Text = Format(AccX, "0.000") 'Format and display X axis data
                lblAccY.Text = Format(AccY, "0.000") 'Format and display Y axis data
                lblAccZ.Text = Format(AccZ, "0.000") 'Format and display Z axis data
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If lviCAN.Text = "1282" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Gyroscope data
            Try
                'Convert & scale gyroscope data
                Dim GyroX As Single = ToSigned(lviCAN.SubItems(4).Text, lviCAN.SubItems(5).Text) * GyroScale 'X axis (Deg/s)
                Dim GyroY As Single = ToSigned(lviCAN.SubItems(6).Text, lviCAN.SubItems(7).Text) * GyroScale 'Y axis (Deg/s)
                Dim GyroZ As Single = ToSigned(lviCAN.SubItems(8).Text, lviCAN.SubItems(9).Text) * GyroScale 'Z axis (Deg/s)
                'Display data
                lblGyroX.Text = Format(GyroX, "0.000") 'Format and display X axis data
                lblGyroY.Text = Format(GyroY, "0.000") 'Format and display Y axis data
                lblGyroZ.Text = Format(GyroZ, "0.000") 'Format and display Z axis data
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
        If lviCAN.Text = "1283" And Not CUShort(lviCAN.SubItems(3).Text = "0") Then 'Magnetometer data
            Try
                'Convert & scale magnetometer data
                Dim MagX As Single = ToSigned(lviCAN.SubItems(4).Text, lviCAN.SubItems(5).Text) * MagScale 'X axis (Gauss)
                Dim MagY As Single = ToSigned(lviCAN.SubItems(6).Text, lviCAN.SubItems(7).Text) * MagScale 'Y axis (Gauss)
                Dim MagZ As Single = ToSigned(lviCAN.SubItems(8).Text, lviCAN.SubItems(9).Text) * MagScale 'Z axis (Gauss)
                'Display data
                lblMagX.Text = Format(MagX, "0.000") 'Format and display X axis data
                lblMagY.Text = Format(MagY, "0.000") 'Format and display Y axis data
                lblMagZ.Text = Format(MagZ, "0.000") 'Format and display Z axis data
            Catch
                lblEr.Text += 1 'Increment CAN message error count
            End Try
        End If
    End Sub

#End Region

#Region "Error Log"

#End Region

#Region "CAN Messages"

    'Required to prevent threading errors during receiveing of serial data
    Delegate Sub AddMessageDelegate()

    'Add incoming CAN messages to the list view
    Private Sub AddMessage()
        'If the message ID already exists in the list view, update it with new CAN data
        For Each lviCAN As ListViewItem In lvCAN.Items
            If lviCAN.Text = CStr(Format(ID, "0000")) Then 'Format and update message ID
                If RTS = 0 Then lviCAN.SubItems(2).Text = "No" Else lviCAN.SubItems(2).Text = "Yes" 'Update RTS (Request to Send) status
                lviCAN.SubItems(3).Text = MessageSize 'Update the number of bytes in the message
                'Based on the number of bytes in the CAN message, update the message data
                If MessageSize > 0 Then lviCAN.SubItems(4).Text = CANdata(0) Else lviCAN.SubItems(4).Text = "" 'Update byte 0 data
                If MessageSize > 1 Then lviCAN.SubItems(5).Text = CANdata(1) Else lviCAN.SubItems(5).Text = "" 'Update byte 1 data
                If MessageSize > 2 Then lviCAN.SubItems(6).Text = CANdata(2) Else lviCAN.SubItems(6).Text = "" 'Update byte 2 data
                If MessageSize > 3 Then lviCAN.SubItems(7).Text = CANdata(3) Else lviCAN.SubItems(7).Text = "" 'Update byte 3 data
                If MessageSize > 4 Then lviCAN.SubItems(8).Text = CANdata(4) Else lviCAN.SubItems(8).Text = "" 'Update byte 4 data
                If MessageSize > 5 Then lviCAN.SubItems(9).Text = CANdata(5) Else lviCAN.SubItems(9).Text = "" 'Update byte 5 data
                If MessageSize > 6 Then lviCAN.SubItems(10).Text = CANdata(6) Else lviCAN.SubItems(10).Text = "" 'Update byte 6 data
                If MessageSize > 7 Then lviCAN.SubItems(11).Text = CANdata(7) Else lviCAN.SubItems(11).Text = "" 'Update byte 7 data
                lviCAN.SubItems(12).Text = Format(CANtime, "hh:mm:ss") 'Update message received time
                tbCANupdate.Text = "Last Update: " & lviCAN.SubItems(12).Text.ToString 'Time of last module update
                SerialControl.Set() 'Release the serial port thread
                Return
            End If
        Next
        'If the message ID doesn't exist in the list view, add a new CAN message to the list
        Dim lviMessage As New ListViewItem(CStr(Format(ID, "0000"))) 'Format and add message ID
        'Add device name
        If CUShort(ID) >= bpsLow And CUShort(ID) <= bpsHigh Then
            lviMessage.SubItems.Add("BPS") 'Device is BPS
        ElseIf CUShort(ID) >= motorLow And CUShort(ID) <= motorHigh Then
            lviMessage.SubItems.Add("Motor") 'Device is Motor
        ElseIf CUShort(ID) >= vdtsLow And CUShort(ID) <= vdtsHigh Then
            lviMessage.SubItems.Add("VDTS") 'Device is VDTS
        ElseIf CUShort(ID) >= mpptLow And CUShort(ID) <= mpptHigh Then
            lviMessage.SubItems.Add("MPPT") 'Device is MPPT
        ElseIf CUShort(ID) >= dashLow And CUShort(ID) <= dashHigh Then
            lviMessage.SubItems.Add("Dash") 'Device is Dash
        Else
            lviMessage.SubItems.Add("Unknown") 'Device is Unknown
        End If
        If RTS = 0 Then lviMessage.SubItems.Add("No") Else lviMessage.SubItems.Add("Yes") 'Add RTS (Request to Send) status
        lviMessage.SubItems.Add(MessageSize) 'Add the number of bytes in the message
        'Based on the number of bytes in the message, add the message data
        If MessageSize > 0 Then lviMessage.SubItems.Add(CANdata(0)) Else lviMessage.SubItems.Add("") 'Add byte 0 data
        If MessageSize > 1 Then lviMessage.SubItems.Add(CANdata(1)) Else lviMessage.SubItems.Add("") 'Add byte 1 data
        If MessageSize > 2 Then lviMessage.SubItems.Add(CANdata(2)) Else lviMessage.SubItems.Add("") 'Add byte 2 data
        If MessageSize > 3 Then lviMessage.SubItems.Add(CANdata(3)) Else lviMessage.SubItems.Add("") 'Add byte 3 data
        If MessageSize > 4 Then lviMessage.SubItems.Add(CANdata(4)) Else lviMessage.SubItems.Add("") 'Add byte 4 data
        If MessageSize > 5 Then lviMessage.SubItems.Add(CANdata(5)) Else lviMessage.SubItems.Add("") 'Add byte 5 data
        If MessageSize > 6 Then lviMessage.SubItems.Add(CANdata(6)) Else lviMessage.SubItems.Add("") 'Add byte 6 data
        If MessageSize > 7 Then lviMessage.SubItems.Add(CANdata(7)) Else lviMessage.SubItems.Add("") 'Add byte 7 data
        lviMessage.SubItems.Add(Format(CANtime, "hh:mm:ss")) 'Add message received time
        lvCAN.Items.Add(lviMessage) 'Add the CAN message to the list view
        tbCANupdate.Text = "Last Update: " & lviMessage.SubItems(12).Text.ToString 'Time of last module update
        SerialControl.Set() 'Release the serial port thread
    End Sub

    'Actions performed when the clear messages button is clicked
    Private Sub miClearMessags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miClearMessages.Click
        lvCAN.Items.Clear() 'Clear list view items
    End Sub

#End Region

#Region "Serial Terminal"

    'Required to prevent threading errors during receiveing of serial data
    Delegate Sub AddDataDelegate(ByVal data As String)

    'Display serial data for the user as a byte string of hex values
    Private Sub AddData(ByVal data As String)
        rtbReceived.AppendText(data) 'Display serial data
        rtbReceived.ScrollToCaret() 'Automatically scroll to keep up with the most recent data
    End Sub

    'Send data 
    Private Sub txtTransmit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransmit.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSend.PerformClick() 'When the enter/return key is pressed, click the send button
        End If
    End Sub

    'Actions performed when the data transmit button is clicked
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If SerialPort.IsOpen Then
            WriteData(txtTransmit.Text) 'Send data
        Else
            MsgBox("Not connected to a serial port.")
            btnConnect.Text = "Connect" 'Configure button for connecting
        End If
    End Sub

    'Actions performed when the clear received button is clicked
    Private Sub miClearReceived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miClearReceived.Click
        rtbReceived.Clear() 'Clear received data
    End Sub

    'Actions performed when the clear sent button is clicked
    Private Sub miClearSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miClearSent.Click
        rtbTransmitted.Clear() 'Clear sent data
    End Sub

#End Region

End Class