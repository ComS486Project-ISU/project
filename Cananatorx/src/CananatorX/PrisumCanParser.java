/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


package CananatorX;
import CananatorX.CanDataArg.PrisumCanDataType;
import CananatorX.PrisumSolarCarState.BatteryModuleError;
import CananatorX.PrisumSolarCarState.PackError;
import CananatorX.PrisumSolarCarState;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.text.DecimalFormat;
import java.util.Arrays;
import java.util.Date;
import javax.swing.JComboBox;
import jssc.SerialPortList;
import jssc.SerialPort;
import jssc.SerialPortEvent;
import jssc.SerialPortEventListener;
import jssc.SerialPortException;

import CananatorX.PrisumSolarCarState.PackStatus;
 
import CananatorX.PrisumSolarCarState.PowerBoardStatus;
import CananatorX.PrisumSolarCarState.BpsStatus;
/**
 *
 * @author prisum
 */
public class PrisumCanParser {
    
    public int k=0;
    private boolean[] info = new boolean[20];
    public boolean running = false;
    public String error= "";
    
    
    public byte[] CANmessage=new byte[14];
    public byte[] CANmessages= new byte[140];
    public int[] intCANmessage= new int[14];
    public String[] stringCANmessage= new String[14];
    public int[] CANdata=new int[8];
    public boolean CANvalid=false;
    public int ID = 0;
    public int numInvalidCAN=0;
    public String CANtype ="";
    public int CheckSum=0;
    public int messageSize=0;
    public int baudRate= 57600;
    public Date lastCANmessage = new Date();
    DecimalFormat df= new DecimalFormat("#.###");
    public int bpsLow = 256; //Lowest BPS CAN ID
    public int bpsHigh = 324; //Highest BPS CAN ID
    public int FirstModule = 257; //Lowest battery module info CAN ID
    public int LastModule = 283; //Highest possible battery module info CAN ID
    public int motorLow = 768; //Lowerst Motor CAN ID
    public int motorHigh = 775; //Highest Motor CAN ID
    public int vdtsLow = 1280; //Lowest VDTS CAN ID
    public int vdtsHigh = 1283; //Highest VDTS CAN ID
    public int mpptLow = 1536; //Lowest MPPT ID
    public int mpptHigh = 1567; //Highest MPPT ID
    public int FirstMPPT = 1536; //Lowest MPPT info CAN ID
    public int LastMPPT = 1551; //Highest possible MPPT info CAN ID
    public int dashLow = 1920; //Lowest Dash ID
    public int dashHigh = 1920; //Highest Dash ID
    
    public int MPHcount  = 0; //Counter variable for speed calculations
    public int MPHmax  = 0; //Initialize maximum speed
    public int MPHmin  = 10000; //Initialize minimum speed
    public int MPHrecent  = 0; //Initialize weighted average of MPH with expected value
    public int MPHavg  = 0; //Initialize average speed
    public int MPPTeffCount  = 0; //Counter variable for MPPT efficiency calculations
    public int MPPTeffMax  = 0; //Initialize maximum MPPT efficiency
    public int MPPTeffMin  = 100; //Initialize minimum MPPT efficiency
    public int MPPTeffRecent  = 1; //Initialize weighted average of MPPT efficiency with expected value
    public int MPPTeffAvg  = 0; //Initialize average MPPT efficiency
    public int ElectronicsPowerCount  = 0; //Counter variable for electronics calculations
    public int ElectronicsPowerMax  = 0; //Initialize maximum electronics power
    public int ElectronicsPowerMin  = 10000; //Initialize minimum electronics power
    public int ElectronicsPowerRecent  = 25; //Initialize weighted average of electronics power with expected value
    public int ElectronicsPowerAvg  = 0; //Initialize average electronics power
    public int MPGeCount  = 0; //Counter variable for MPGe
    public int MPGeMax  = 0; //Initialize maximum MPGe
    public int MPGeMin  = 10000; //Initialize minimum MPGe
    public int MPGeRecent  = 0; //Initialize weighted average of MPGe with expected value
    public int MPGeAvg  = 0; //Initialize average MPGe
    public int PackPowerCount  = 0; //Counter variable for pack calculations
    public double PackPowerMax  = -10000; //Initialize maximum pack power
    public double PackPowerMin  = 10000; //Initialize minimum pack power
    public double PackPowerRecent  = 0; //Initialize weighted average of pack power with expected value
    public double PackPowerAvg  = 0; //Initialize average pack power
    public int ArrayPowerCount  = 0; //Counter variable for array calculations
    public double ArrayPowerMax  = 0; //Initialize maximum array power
    public double ArrayPowerMin  = 10000; //Initialize minimum array power
    public double ArrayPowerRecent  = 0; //Initialize weighted average of array power with expected value
    public double ArrayPowerAvg  = 0; //Initialize average array power
    public int MotorPowerCount  = 0; //Counter variable for motor power calculations
    public double MotorPowerMax  = 0; //Initialize maximum motor power
    public double MotorPowerMin  = 10000; //Initialize minimum motor power
    public double MotorPowerRecent  = 0; //Initialize weighted average of motor power with expected value
    public double MotorPowerAvg  = 0; //Initialize average motor power
    public int CockpitTCount  = 0; //Counter variable for cockpit temp calculations
    public double CockpitTempMax  = 0; //Initialize maximum cockpit temp
    public double CockpitTempMin  = 10000; //Initialize minimum cockpit temp
    public double CockpitTempRecent  = 30; //Initialize weighted average of cockpit temp with expected value
    public double CockpitTempAvg  = 0; //Initialize average cockpit temp
    public int MotorTCount  = 0; //Counter variable for motor temp calculations
    public int MotorTMax  = 0; //Initialize maximum motor temp
    public int MotorTMin  = 10000; //Initialize minimum motor temp
    public int MotorTRecent  = 30; //Initialize weighted average of motor temp with expected value
    public int MotorTAvg  = 0; //Initialize average motor temp
    public int ControllerTCount  = 0; //Counter variable for controller temp calculations
    public int ControllerTMax  = 0; //Initialize maximum controller temp
    public int ControllerTMin  = 10000; //Initialize minimum controller temp
    public int ControllerTRecent  = 30; //Initialize weighted average of controller temp with expected value
    public int ControllerTAvg  = 0; //Initialize average controller temp
    public int BaseplateTCount  = 0; //Counter variable for baseplate temp calculations
    public int BaseplateTMax  = 0; //Initialize maximum baseplate temp
    public int BaseplateTMin  = 10000; //Initialize minimum baseplate temp
    public int BaseplateTRecent  = 30; //Initialize weighted average of baseplate temp with expected value
    public int BaseplateTAvg  = 0; //Initialize average baseplate temp
    public int PackTCount  = 0; //Counter variable for pack temp calculations
    public int PackTMax  = 0; //Initialize maximum pack temp
    public int PackTMin  = 10000; //Initialize minimum pack temp
    public int PackTRecent  = 30; //Initialize weighted average of pack temp with expected value
    public int PackTAvg  = 0; //Initialize average pack temp
    public int MPPTtCount  = 0; //Counter variable for MPPT temp calculations
    public int MPPTtMax  = 0; //Initialize maximum MPPT temp
    public int MPPTtMin  = 10000; //Initialize minimum MPPT temp
    public int MPPTtRecent  = 30; //Initialize weighted average of MPPT temp with expected value
    public int MPPTtAvg  = 0; //Initialize average MPPT temp
    public int RecentV  = 100; //Initialize weighted average of system voltage with expected value
    public int ShortWeight  = 100; //Determines how many recent samples are given significant weight
    public int MidWeight  = 300; //Determines how many recent samples are given significant weight
    public int LongWeight  = 600; //Determines how many recent samples are given significant weight
    

    public double ModVScale  = 0.001; //Battery module voltage scale
    public double ModTScale  = 1; //Battery module temperature scale
    public double IScale  = 0.01; //Pack current scale
    public double VScale  = 0.1; //Pack voltage scale
    public double pbScale  = 0.01; //Powerboard scale
    public double V5Scale  = 0.1; //5V scale
    public double SystemV; //Main battery pack voltage
    public double PackCurrent;  //Main battery pack current
    public double NoLoadV; //Main pack voltage with low load
    public double PackPower; //Main battery pack power

    public double ArrayVoltage; //Voltage of Array
    public double ArrayCurrent; //Current from Array
    public double ArrayPower; //Solar array power
    public double MotorVoltage;  //Motor Shunt Voltage
    public double MotorCurrent; //Motor Shunt Current
    public double MotorPower; //Motor Shunt power
    public double AuxV; //Aux pack voltage
    public double V12Main; //12v main bus voltage
    public double V12Aux; //12v aux bus voltage
    public double V5; //5v bus voltage
    
    public double SOC;
    public double BatteryCapacity;
    public double Cycles;
    public PrisumSolarCarState solarCarState = new PrisumSolarCarState();
    
    
   
    static SerialPort serialPort;
    
    private void TestValidateCANActionPerformed(java.awt.event.ActionEvent evt) {                                                
        /*String testString = TestArea.getText();
        String[] testStringArray= testString.split("\n");
        String[] tsa;
        int[] results = new int[14];
        for(int i=0; i<testStringArray.length; i++){
            tsa=testStringArray[i].split("\\s+");
            for (int j = 0; j < tsa.length; j++) {
                try {
                    intCANmessage[j] = Integer.parseInt(tsa[j]);
                    stringCANmessage[j]=tsa[j];
                    //CANdataTable.setValueAt(tsa[j],i,j);
                } catch (NumberFormatException nfe) {};
            }
            CANvalidation();
            if(CANvalid){
                CANparse();
            }
            System.out.println(intCANmessage[0]+ " " + intCANmessage[1]+ " " + intCANmessage[2]+ " " + intCANmessage[3]+ " " + intCANmessage[4]+ " " + CANvalid);
        }
        */
    }                                               
     
    public String[] COMSearch(){
       String[] portNames = SerialPortList.getPortNames();
       //COMPorts.setModel(new JComboBox<>());
       return portNames;
    } 
    
    public boolean CheckPort(String comPort){  //will add feature to check if can data present
        if(comPort!= ""){
            return true;
        }else{
            error="unable to find usable com port";
            return false;
        }
    }
    
    private PrisumCanDataListener prisumListener;
    public void RegisterCanDataListener(PrisumCanDataListener listener)
    {
        prisumListener = listener;
    }
    
    public void connect(String comPort) {
        serialPort = new SerialPort(comPort); 
        try {
            serialPort.openPort();
            System.out.println(comPort);
            serialPort.setParams(baudRate, 8, 1, 0);//Set params.
            int mask = SerialPort.MASK_RXCHAR + SerialPort.MASK_CTS + SerialPort.MASK_DSR;//Prepare mask
            serialPort.setEventsMask(mask);//Set mask
            
            
            //FROM THIS ->      canStatus.setText("CAN started, Port open","can_status");\
            
            //TO THIS ->
            CanDataArg dataArg = new CanDataArg(this,solarCarState, "CAN started, Port open",PrisumCanDataType.CanStatus);
            prisumListener.CanDataChanged(dataArg);
            
            
            serialPort.addEventListener(new SerialPortReader());//Add SerialPortEventListener
        }
        catch (SerialPortException ex) {
            System.out.println(ex);
        }
    }
    
    class SerialPortReader implements SerialPortEventListener {

        public void serialEvent(SerialPortEvent event) {
            if(event.isRXCHAR()){//If data is available
                //if(event.getEventValue()!=0){//Check bytes count in the input buffer
                    //Read data, if 10 bytes available 
                    try {
                        int i=0;
                        int j=0;
                        
                        String string= "";
                        int numMessages=event.getEventValue()/14;
                       // System.out.println(numMessages);
                        CANmessages=serialPort.readBytes(14*numMessages);
                        
                        for(j=0; j<numMessages; j++){
                            string= "";
                            CANmessage=Arrays.copyOfRange(CANmessages,14*j,14*(j+1));
                            lastCANmessage = new Date();
                            if(CANmessage.length!=0){
                                for(i=0; i<CANmessage.length; i++){
                                    stringCANmessage[i]= ""+CANmessage[i];
                                    intCANmessage[i]= CANmessage[i];  //TEST THIS
                                }
                                CANvalidation();
                                if(CANvalid){
                                    CANparse();
                                    CanDataArg dataArg = new CanDataArg(this,solarCarState, "Active",PrisumCanDataType.CanStatus);
                                    prisumListener.CanDataChanged(dataArg);
                                    numInvalidCAN=0;
                                }else{
                                    numInvalidCAN++;
                                    if(numInvalidCAN>3){
                                        System.out.println("PURGE-too many invalid");
                                        serialPort.purgePort(8);
                                        serialPort.purgePort(4);
                                    }
                                }

                                
                                CanDataArg dataArg = new CanDataArg(this,solarCarState, stringCANmessage,PrisumCanDataType.NewCanMessage);
                                prisumListener.CanDataChanged(dataArg);
                             
                                //System.out.println(string);
                                for(i=0; i<14; i++){
                                        string= string + intCANmessage[i] + " ";

                                  }
                            }
                            if(CANvalid){
                                string= "valid: " + string;
                            }else{
                                string= "invalid: " + string;
                                System.out.println(string);
                            }
                          //  System.out.println("Checksum: " + CheckSum%256);
                           // System.out.println(string);
                        }
                         
                    }
                    catch (SerialPortException ex) {
                        System.out.println(ex);
                    }
            /*    }else{
                    try {
                        System.out.println("PURGE-no items in buffer");
                        serialPort.purgePort(8);
                        serialPort.purgePort(4);
                    }catch (SerialPortException ex) {
                        System.out.println(ex);
                    }
                }*/
            }
            else if(event.isCTS()){//If CTS line has changed state
                if(event.getEventValue() == 1){//If line is ON
                    System.out.println("CTS - ON");
                }
                else {
                    System.out.println("CTS - OFF");
                }
            }
            else if(event.isDSR()){///If DSR line has changed state
                if(event.getEventValue() == 1){//If line is ON
                    System.out.println("DSR - ON");
                }
                else {
                    System.out.println("DSR - OFF");
                }
            }
        }
    }
    
     
    private void CANvalidation(){  //add extra implementation later
        CANvalid=false;
        CheckSum=0;
        messageSize=0;
        int i=0;
        for(i = 0 ; i < CANdata.length ; i++) {  //reset CANdata array
            CANdata[i] = 0;
        }
        if(intCANmessage[0]==33 && (intCANmessage[3]==1 || intCANmessage[3]==0)){
            ID= intCANmessage[1]*256 + intCANmessage[2];
            if(ID>0 && ID<2047){
                messageSize=intCANmessage[4];
                if(messageSize>0 && messageSize<=8){
                    for(i=0; i<messageSize; i++){
                        CANdata[i]=intCANmessage[i+5];
                        CheckSum+=CANdata[i];
                        if((byte)(CheckSum%256)==intCANmessage[13]){
                            CANvalid=true;
                        }
                    }
                }else if(messageSize==0){
                    CANvalid=true;
                }
            }
        }
    }
  
    
    private void CANparse(){
        if(ID >= bpsLow && ID <= bpsHigh){
            CANtype= "BPS"; //Device is BPS
            bps();
        }else if(ID>= motorLow && ID<= motorHigh){
            CANtype= "Motor"; //Device is Motor
          //  Motor();
        }else if(ID>= vdtsLow && ID<= vdtsHigh){
            CANtype= "VDTS"; //Device is VDTS
        }else if(ID>= mpptLow && ID<= mpptHigh){
            CANtype= "MPPT"; //Device is MPPT
        }else if(ID>= dashLow && ID<= dashHigh){
            CANtype= "Dash"; //Device is Dash
          //  dash();
        }else{
            CANtype= "Unknown"; //Device is Unknown
        }
    }
    
     
    /**
     * converts all non 0 integers to true, 0 to false
     */
    private boolean itob(int i)
    {
    
        if(i == 0)
        {
            return false;
        }
        else
        {
            return true;
        
        }
    }
    private void bps(){
        int sum0=0;
        int sum1=0;
        int counter=0;
        double vRange=0;
        int CAN9=intCANmessage[9];
        int CAN10=intCANmessage[10];
        if(ID>=FirstModule && ID<=LastModule){
            boolean vReadErr  = false; //Voltage read error (bit 6)
            boolean tReadErr  = false; //Temp read error (bit 7)
            boolean otFault  = false; //Over temp fault (bit 0)
            boolean otWarn  = false; //Over temp warning (bit 1)
            boolean utFault  = false; //Under temp fault (bit 2)
            boolean utWarn  = false; //Under temp warning (bit 3)
            boolean ovFault  = false; //Over voltage fault (bit 4)
            boolean ovWarn  = false; //Over voltage warning (bit 5)
            boolean uvFault  = false; //Under voltage fault (bit 6)
            boolean uvWarn  = false; //Under voltage warning (bit 7)
            BatteryModuleError modStatus = BatteryModuleError.None;
            //PowerBoardStatus PowerBoardStatus = PowerBoardStatus.None;
            double modV=(intCANmessage[5]*256+intCANmessage[6])*ModVScale;
            double modT=(intCANmessage[7]*256+intCANmessage[8])*ModTScale;
            int modID=ID-257;
          //  System.out.println(modID);
            PrisumSolarCarState.BatteryModule bm = solarCarState.BPS.BatteryModules.get(modID);
            bm.Temp = modT;
            bm.Voltage = modV;
            bm.Id = modID;
            
            if(CAN9<256 && CAN9>=128){
                CAN9=CAN9-128;
                tReadErr = true;  //Temp read error (bit 7)
                modStatus=BatteryModuleError.None;
                
                bm.bmErrors[modStatus.ordinal()] = true;
               //faultTable.setValueAt("ERROR "+modID, 0, 1);
            }
            if(CAN9<128 && CAN9>=64){
                CAN9=CAN9-64;
                vReadErr  = true;  //Voltage read error (bit 6)
                modStatus=BatteryModuleError.VoltageReadError;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 5, 1);
            }
            
            if(CAN10<256 && CAN10>=128){
                CAN10=CAN10-128; //Under voltage warning (bit 7)
                modStatus = BatteryModuleError.UnderVoltWarning;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 9, 1);
            }
            if(CAN10<128 && CAN10>=64){ 
                CAN10=CAN10-64;
                //Under Voltage Fault (bit 6)
                
                modStatus = BatteryModuleError.UnderVoltFault;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 8, 1);
            }
            if(CAN10<64 && CAN10>=32){
                CAN10=CAN10-32;
               //Over voltage warning (bit 5)
                
                modStatus = BatteryModuleError.OverVoltWarning;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 7, 1);
            }
            if(CAN10<32 && CAN10>=16){
                CAN10=CAN10-16;
                //Over voltage fault (bit 4)
                
                modStatus = BatteryModuleError.OverVoltFault;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 6, 1);
            }
            if(CAN10<16 && CAN10>=8){
                CAN10=CAN10-8;
                //Under temp warning (bit 3)
                
                modStatus = BatteryModuleError.UnderTempWarning;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 4, 1);
            }
            if(CAN10<8 && CAN10>=4){
                CAN10=CAN10-4;
                //Under temp fault (bit 2)
                
                modStatus = BatteryModuleError.UnderTempFault;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 3, 1);
            }
            if(CAN10<4 && CAN10>=2){
                CAN10=CAN10-2;
                //Over temp warning (bit 1)
                
                modStatus = BatteryModuleError.OverTempWarning;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 2, 1);
            }
            if(CAN10==1){
                //Over temp fault (bit 0)
                modStatus = BatteryModuleError.OverTempFault;
                bm.bmErrors[modStatus.ordinal()] = true;
                //faultTable.setValueAt("ERROR "+modID, 1, 1);
            }
          //  String UpdateTime = stringCANmessage[12]; //Time of last update*/
      
 
            
            
            //moduleTable.setValueAt(df.format(modV), modID, 1);
            //moduleTable.setValueAt(modT, modID, 2);
            //moduleTable.setValueAt(modStatus, modID, 3);

             
            if( solarCarState.BPS.highV <= modV){
                solarCarState.BPS.highVmod=modID;
                solarCarState.BPS.highV = modV;
                //BPStable.setValueAt(highV, 0, 1);
            }
//            if(lowVmod!=0){
//                Object objdb2 = moduleTable.getValueAt(lowVmod,1);
//                lowV= Double.parseDouble(objdb2.toString());
//            }
            if( solarCarState.BPS.lowV >= modV || solarCarState.BPS.lowV==0.0){
                solarCarState.BPS.lowVmod=modID;
                solarCarState.BPS.lowV = modV;
                //BPStable.setValueAt(lowV, 1, 1);
            }
//            if(highTmod!=0){
//                Object objdb3 = moduleTable.getValueAt(highTmod,2);
//                highT= Double.parseDouble(objdb3.toString());
//            }
            if( solarCarState.BPS.highT <= modT){
                solarCarState.BPS.highTmod=modID;
                solarCarState.BPS.highT = modT;
                //BPStable.setValueAt(highT, 2, 1);
            }
             if( solarCarState.BPS.lowT >= modT){
                solarCarState.BPS.lowTmod=modID;
                solarCarState.BPS.lowT = modT;
                //BPStable.setValueAt(highT, 2, 1);
            }
            
             //not updating on bps statistics data, only batt mod

            CanDataArg dataArg = new CanDataArg(this,solarCarState, bm,PrisumCanDataType.BatteryModule);
            prisumListener.CanDataChanged(dataArg);
                             
            
            
        }else if(ID==305/*Pack Powersense*/){
            PackError modStatus = PackError.None;
            //NEED TO ADD: POWER RECENT, AVERAGE, COUNT, REVENT V
            SystemV=(((intCANmessage[5]+1)*256)+intCANmessage[6])*VScale;
            PackCurrent = (((intCANmessage[7]+1)*256)+intCANmessage[8])*IScale;
            PackPower = SystemV * PackCurrent; // there is a pack energy mesasge instead
            int Status2=intCANmessage[9];
            solarCarState.BPS.SystemV = SystemV;
            solarCarState.BPS.PackCurrent=PackCurrent;
            solarCarState.BPS.PackPower=PackPower;
            
            if(itob(Status2 & 0b00100000)){
                modStatus = PackError.PackCurrentReadError;
                solarCarState.BPS.PackErrors[modStatus.ordinal()]=true;
              //  faultTable.setValueAt("ERROR", 10, 1); //pack current read error
            }
            if(itob(Status2 & 0b00010000)){
                modStatus = PackError.PackVoltageReadError;
                solarCarState.BPS.PackErrors[modStatus.ordinal()]=true;
              //  faultTable.setValueAt("ERROR", 11, 1); //pack voltage read error
            }
            if(itob(Status2 & 0b00001000)){
                modStatus = PackError.OverDischargeWarning;
                solarCarState.BPS.PackErrors[modStatus.ordinal()]=true;
              //  faultTable.setValueAt("WARNING", 15, 1); //Over Discharge warning
            }
            if(itob(Status2 & 0b00000100)){
                modStatus = PackError.OverDischargeFault;
                solarCarState.BPS.PackErrors[modStatus.ordinal()]=true;
               // faultTable.setValueAt("FAULT", 14, 1); //Over Discharge Fault
            }
            if(itob(Status2 & 0b00000010)){
                modStatus = PackError.OverChargeWarning;
                solarCarState.BPS.PackErrors[modStatus.ordinal()]=true;
              //  faultTable.setValueAt("WARNING", 13, 1); //Over charge Warning
            }
            if(itob(Status2 & 0b00000001)){
                modStatus = PackError.OverChargeFault;
                solarCarState.BPS.PackErrors[modStatus.ordinal()]=true;
            //    faultTable.setValueAt("FAULT", 12, 1); //Over charge Fault
            }
            if(PackPower>0){
                solarCarState.BPS.PackStatus=PrisumSolarCarState.PackStatus.Charging;
            }else if(PackPower<0){
                solarCarState.BPS.PackStatus=PrisumSolarCarState.PackStatus.Draining;
            }else{
                solarCarState.BPS.PackStatus=PrisumSolarCarState.PackStatus.NoNetPower;
            }

            if(solarCarState.BPS.PackPowerMin>solarCarState.BPS.PackPower){
                solarCarState.BPS.PackPowerMin=solarCarState.BPS.PackPower;
                //BPStable.setValueAt(PackPowerMin, 9, 1);
            }
            if(solarCarState.BPS.PackPowerMax<solarCarState.BPS.PackPower){
                solarCarState.BPS.PackPowerMax=solarCarState.BPS.PackPower;
                //BPStable.setValueAt(PackPowerMax, 8, 1);
            }
        
            CanDataArg dataArg = new CanDataArg(this,solarCarState, 0,PrisumCanDataType.BatteryProtectionSystem);
            prisumListener.CanDataChanged(dataArg);
            
        }else if(ID==306 /*Array Shunt*/){
            int Status2=intCANmessage[9];
            PackError modStatus = PackError.None;
            solarCarState.BPS.ArrayVoltage = (((intCANmessage[5]+1)*256)+intCANmessage[6])*VScale;
            solarCarState.BPS.ArrayCurrent = (((intCANmessage[7]+1)*256)+intCANmessage[8])*IScale;
            solarCarState.BPS.ArrayPower=ArrayCurrent*ArrayVoltage;
           /* if(itob(Status2 & 0b00000100)){   // check this?
                modStatus = PackError.ArrayCurrentReadError;
                solarCarState.BPS.PackErrors[7]=true;
                //faultTable.setValueAt("ERROR", 16, 1); //array current read error
            }*/
            //BPStable.setValueAt(ArrayCurrent, 14, 1);
            //BPStable.setValueAt(ArrayPower, 15, 1);
            if(ArrayPowerMin>ArrayPower){
                ArrayPowerMin=ArrayPower;
                solarCarState.BPS.ArrayPowerMin = ArrayPowerMin;
               // BPStable.setValueAt(ArrayPowerMin, 16, 1);
            }
            if(ArrayPowerMax<ArrayPower){
                ArrayPowerMax=ArrayPower;
                solarCarState.BPS.ArrayPowerMax = ArrayPowerMax;
               // BPStable.setValueAt(ArrayPowerMax, 17, 1);
            }
            //do average
            CanDataArg dataArg = new CanDataArg(this,solarCarState, 0,PrisumCanDataType.BatteryProtectionSystem);
            prisumListener.CanDataChanged(dataArg);
            
        }else if(ID==307 /*Motor Shunt*/){
            solarCarState.BPS.MotorVoltage = (((intCANmessage[5]+1)*256)+intCANmessage[6])*VScale;
            solarCarState.BPS.MotorCurrent = (((intCANmessage[7]+1)*256)+intCANmessage[8])*IScale;
            solarCarState.BPS.MotorPower=MotorCurrent*SystemV;
            /*
            int Status2=intCANmessage[9];
            PackError modStatus = PackError.None;
            if(itob(Status2 & 0b0010000)){  //check this
                modStatus = PackError.ArrayCurrentReadError;
                solarCarState.BPS.PackErrors[8]=true;
                //faultTable.setValueAt("ERROR", 17, 1); //Motor current read error
            }*/
            //BPStable.setValueAt(MotorCurrent, 21, 1);
            //BPStable.setValueAt(MotorPower, 22, 1);
            if(MotorPowerMin>MotorPower){
                MotorPowerMin=MotorPower;
                solarCarState.BPS.MotorPowerMin = MotorPowerMin;
                //BPStable.setValueAt(MotorPowerMin, 23, 1);
            }
            if(MotorPowerMax<MotorPower){
                MotorPowerMax=MotorPower;
                solarCarState.BPS.MotorPowerMax = MotorPowerMax;
                //BPStable.setValueAt(MotorPowerMax, 24, 1);
            }  
            CanDataArg dataArg = new CanDataArg(this,solarCarState, 0,PrisumCanDataType.BatteryProtectionSystem);
            prisumListener.CanDataChanged(dataArg);
        }else if(ID==310 /*Power board*/){
            //PowerBoardStatus modStatus = PowerBoardStatus.None;
            int Status=intCANmessage[12];
            solarCarState.BPS.AuxPackVoltage = (((intCANmessage[5]+1)*256)+intCANmessage[6])*IScale;
            solarCarState.BPS.TwelveVoltMainVoltage = (((intCANmessage[7]+1)*256)+intCANmessage[8])*pbScale;
            solarCarState.BPS.TwelveVoltAuxVoltage = (((intCANmessage[9]+1)*256)+intCANmessage[10])*pbScale;
            solarCarState.BPS.FiveVoltVoltage = (intCANmessage[11])*V5Scale;
            //solarCarState.BPS.MotorPower=MotorCurrent*SystemV;
            if(itob(Status & 0b00010000)){
                solarCarState.BPS.PowerBoardStatuses[PowerBoardStatus.AuxPackReadError.ordinal()] = true;
               // solarCarState.BPS.PowerBoardStatus[0]=true;
                //faultTable.setValueAt("ERROR", 18, 1); //Aux Pack Low
            }
            if(itob(Status & 0b00001000)){
                //modStatus = PowerBoardStatus.TwelveVoltMainReadError;
                solarCarState.BPS.PowerBoardStatuses[PowerBoardStatus.TwelveVoltMainReadError.ordinal()]=true;
                //faultTable.setValueAt("ERROR", 20, 1); //5v read error
            }
            if(itob(Status & 0b00000100)){
                //modStatus = PowerBoardStatus.TwelveVoltAuxReadError;
                solarCarState.BPS.PowerBoardStatuses[PowerBoardStatus.TwelveVoltAuxReadError.ordinal()]=true;
                //faultTable.setValueAt("ERROR", 21, 1); //12V aux read error
            }
            if(itob(Status & 0b00000010)){
                //modStatus = PowerBoardStatus.FiveVoltReadError;
                solarCarState.BPS.PowerBoardStatuses[PowerBoardStatus.FiveVoltReadError.ordinal()]=true;
                //faultTable.setValueAt("ERROR", 22, 1); //12V main read error
            }
            if(itob(Status & 0b00000001)){
                //modStatus = PowerBoardStatuses.AuxPackLow;
                solarCarState.BPS.PowerBoardStatuses[PowerBoardStatus.AuxPackLow.ordinal()]=true;
               // faultTable.setValueAt("ERROR", 19, 1); //Aux Pack read error
            }
            /*
            jTable1.setValueAt(df.format(AuxV), 14, 1);
            jTable1.setValueAt(df.format(V12Main), 15, 1);
            jTable1.setValueAt(df.format(V12Aux), 16, 1);
            jTable1.setValueAt(df.format(V5), 17, 1);
            */
        
            
        }else if(ID==323){
            
           /* boolean ArraySw=false;
            boolean ArrayEn=false;
            boolean PackEn=false;
            boolean PreCharge=false;
            */
            PackError modStatus = PackError.None;
            SOC=intCANmessage[7]/100;
            int BPSStatus=intCANmessage[8];
            if(itob(BPSStatus & 0b00010000)){
                solarCarState.BPS.BpsStatuses[BpsStatus.PackPrecharge.ordinal()]=true;
                //PreCharge=true;
                //faultTable.setValueAt("ERROR", 18, 1); //Pack Pre-Charge
            }
            if(itob(BPSStatus & 0b00001000)){
                solarCarState.BPS.BpsStatuses[BpsStatus.PackEnable.ordinal()]=true;
                //PackEn=true;
                //faultTable.setValueAt("ERROR", 20, 1); //Pack Enable
            }
            if(itob(BPSStatus & 0b00000100)){
                solarCarState.BPS.BpsStatuses[BpsStatus.ArraySwitch.ordinal()]=true;
                //ArraySw=true;
                //faultTable.setValueAt("ERROR", 21, 1); //Array Switch
            }
            if(itob(BPSStatus & 0b00000010)){
                solarCarState.BPS.BpsStatuses[BpsStatus.ArrayEnable.ordinal()]=true;
                //ArrayEn=true;
                //faultTable.setValueAt("ERROR", 22, 1); //Array Enable
            }
            if(itob(BPSStatus & 0b00000001)){
                solarCarState.BPS.BpsStatuses[BpsStatus.MpptEnable.ordinal()]=true;
                //faultTable.setValueAt("ERROR", 19, 1); //MPPT Enable
            }
            

            //SOC
            //jTable1.setValueAt(df.format(SOC),8,1);
            
            /*
        }else if(ID==324){
            Cycles = (((intCANmessage[5]+1)*256)+intCANmessage[6]);
            BatteryCapacity = (((intCANmessage[7]+1)*256)+intCANmessage[8]);
            jTable1.setValueAt(Cycles,7,1);
            jTable1.setValueAt(df.format(BatteryCapacity),9,1);
        }   
                       

    }
    private void Motor(){
        if(ID==769){
            byte[] MotorCur = {CANmessage[5], CANmessage[6], CANmessage[7],CANmessage[8] };
            float MotorCurrent = ByteBuffer.wrap(MotorCur).order(ByteOrder.LITTLE_ENDIAN).getFloat();
            byte[] MotorVel = {CANmessage[9], CANmessage[10], CANmessage[11],CANmessage[12] };
            float MotorVelocity = ByteBuffer.wrap(MotorVel).order(ByteOrder.LITTLE_ENDIAN).getFloat();
            MotorTable.setValueAt(MotorCurrent, 0, 1);
            MotorTable.setValueAt(MotorVelocity, 1, 1);
        }
        if(ID==770){
            byte[] bytes1 = {CANmessage[5], CANmessage[6], CANmessage[7],CANmessage[8] };
            float f1 = ByteBuffer.wrap(bytes1).order(ByteOrder.LITTLE_ENDIAN).getFloat();
            MotorTable.setValueAt(f1, 2, 1);
        }
    }
    
    private void dash(){
    //    int CockpitTemp=CANmessage[]
    //    CockpitTempRecent=(CockpitTempRecent * (ShortWeight - 1) + CockpitTemp) / ShortWeight
    }
    
    */
        }}
    }
