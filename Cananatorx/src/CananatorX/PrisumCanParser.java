/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


package CananatorX;
import CananatorX.CanDataArg.PrisumCanDataType;
import CananatorX.PrisumSolarCarState.BatteryModuleError;
import CananatorX.PrisumSolarCarState.MpptStatus;
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
import CananatorX.PrisumSolarCarState.BatteryModuleError;
import CananatorX.PrisumSolarCarState.PowerBoardError;
import CananatorX.PrisumSolarCarState.BpsStatus;
import CananatorX.PrisumSolarCarState.MotorBoardIOState;
import CananatorX.PrisumSolarCarState.MotorBoardStatus;

/**
 *
 * @author prisum
 */
public class PrisumCanParser {
    
	private int k=0;
    private boolean[] info = new boolean[20];
    private boolean running = false;
    private String error= "";
    /** CAN MESSAGE IDS **/
    //256-285 modules 1- 30
    //305 PowerSense
    //306 PowerBoard
    //322 BPS Reset
    //323 Pack Energy
    //324 Pack Health
    
    private byte[] CANmessage=new byte[14];
    private byte[] CANmessages= new byte[140];
    private int[] intCANmessage= new int[14];
    private String[] stringCANmessage= new String[14];
    private int[] CANdata=new int[8];
    
    private boolean CANvalid=false;
    private int ID = 0;
    private int numInvalidCAN=0;
    private String CANtype ="";
    private int CheckSum=0;
    private int messageSize=0;
    private int baudRate= 57600;
    private Date lastCANmessage = new Date();
    private DecimalFormat df= new DecimalFormat("#.###");
    
    private int bpsLow = 256; //Lowest BPS CAN ID
    private int bpsHigh = 324; //Highest BPS CAN ID
    private int FirstModule = 257; //Lowest battery module info CAN ID
    private int LastModule = 283; //Highest possible battery module info CAN ID
    private int motorLow = 768; //Lowerst Motor CAN ID
    private int motorHigh = 775; //Highest Motor CAN ID
    private int vdtsLow = 1280; //Lowest VDTS CAN ID
    private int vdtsHigh = 1283; //Highest VDTS CAN ID
    private int mpptLow = 1536; //Lowest MPPT ID
    private int mpptHigh = 1567; //Highest MPPT ID
    private int dashLow = 1920; //Lowest Dash ID
    private int dashHigh = 1920; //Highest Dash ID
        

    public double ModVScale  = 0.001; //Battery module voltage scale
    public double ModTScale  = 1; //Battery module temperature scale
    public double IScale  = 0.01; //Pack current scale
    public double VScale  = 0.1; //Pack voltage scale
    public double pbScale  = 0.01; //Powerboard scale
    public double V5Scale  = 0.1; //5V scale
    
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
    private void NotifyDataChanged(CanDataArg e)
    {
    	if(prisumListener != null)
    	{
    		prisumListener.CanDataChanged(e);
    	}
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
            NotifyDataChanged(dataArg);
            
            
            
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
                                    NotifyDataChanged(dataArg);
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
                                NotifyDataChanged(dataArg);
                             
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
            Motor();
        }else if(ID>= vdtsLow && ID<= vdtsHigh){
            CANtype= "VDTS"; //Device is VDTS
        }else if(ID>= mpptLow && ID<= mpptHigh){
            CANtype= "MPPT"; //Device is MPPT
        }else if(ID>= dashLow && ID<= dashHigh){
            CANtype= "Dash"; //Device is Dash
            Dash();
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

            //PowerBoardStatus PowerBoardStatus = PowerBoardStatus.None;
            double modV=(intCANmessage[5]<<8+intCANmessage[6])*ModVScale;
            double modT=(intCANmessage[7]<<8+intCANmessage[8])*ModTScale;
            int modID=ID-257;
            
            solarCarState.setBatteryModuleTemp(modID, modT);
            solarCarState.setBatteryModuleVoltage(modID, modV);
            
            
            //Status 1
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.UnderVoltWarning,  itob(CAN9 & 10000000));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.UnderVoltFault, 	 itob(CAN9 & 01000000));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.OverVoltWarning,	 itob(CAN9 & 00100000));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.OverVoltFault,	 itob(CAN9 & 00010000));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.UnderTempWarning,  itob(CAN9 & 00001000));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.UnderTempFault,    itob(CAN9 & 00000100));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.OverTempWarning,   itob(CAN9 & 00000010));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.OverTempFault,     itob(CAN9 & 00000001));
      
           
            //status 2
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.VoltageReadError,          itob(CAN10 & 0b0000001));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.TempReadError,             itob(CAN10 & 0b0000010));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.TempCalibrationRangeError, itob(CAN10 & 0b0000100));
            solarCarState.setBatteryModuleError(modID, BatteryModuleError.ModuleDisconnectedFault, 	 itob(CAN10 & 0b0001000));
            
            CanDataArg dataArg = new CanDataArg(this,solarCarState, modID,PrisumCanDataType.BatteryModule);
            NotifyDataChanged(dataArg);
            
        }else if(ID==305/*Pack Powersense*/){
           
        	//NEED TO ADD: POWER RECENT, AVERAGE, COUNT, REVENT V
            
        	double PackCurrent = (((intCANmessage[5])<<8)+intCANmessage[6])*IScale;
        	double ArrayCurrent = (((intCANmessage[7])<<8)+intCANmessage[8])*IScale;
        	double MotorCurrent = (((intCANmessage[9])<<8)+intCANmessage[10])*IScale;
        	
            int Status1=intCANmessage[11];
            int Status2=intCANmessage[12];
            
            solarCarState.setPackCurrent(PackCurrent);
            solarCarState.setArrayCurrent(ArrayCurrent);
            solarCarState.setMotorPower(MotorCurrent);
            
            //status 1
            solarCarState.setPackError(PackError.PackCalibrationRangeError, itob(Status1 & 0b10000000));
            solarCarState.setPackError(PackError.ArrayCurrentReadError, itob(Status1 & 0b01000000));
            solarCarState.setPackError(PackError.MotorCurrentReadError, itob(Status1 & 0b00100000));
            solarCarState.setPackError(PackError.PackCurrentReadError,  itob(Status1 & 0b00010000));
            solarCarState.setPackError(PackError.OverDischargeWarning,  itob(Status1 & 0b00001000));
            solarCarState.setPackError(PackError.OverDischargeFault,    itob(Status1 & 0b00000100));
            solarCarState.setPackError(PackError.OverChargeWarning,     itob(Status1 & 0b00000010));
            solarCarState.setPackError(PackError.OverChargeFault,       itob(Status1 & 0b00000001));
            
            //status 2
            solarCarState.setPackError(PackError.MotorCurrentCalibrationError, itob(Status2 & 0b00000001));
            solarCarState.setPackError(PackError.MotorCurrentCalibrationError, itob(Status2 & 0b00000010));
            solarCarState.setPackError(PackError.MotorCurrentCalibrationError, itob(Status2 & 0b00000100));

        
            CanDataArg dataArg = new CanDataArg(this,solarCarState, 0,PrisumCanDataType.BatteryProtectionSystem);
            NotifyDataChanged(dataArg);
            
        }   else if(ID==306 /*Power board*/){
        	
        	
            //PowerBoardStatus modStatus = PowerBoardStatus.None;
            int Status1=intCANmessage[11];
            int Status2=intCANmessage[12];
        	solarCarState.setAuxPackVoltage(((intCANmessage[5]<<8)+intCANmessage[6])*IScale);
            solarCarState.setTwelveVoltMainVoltage(((intCANmessage[7]<<8)+intCANmessage[8])*pbScale);
            solarCarState.setTwelveVoltAuxVoltage( ((intCANmessage[9]<<8)+intCANmessage[10])*pbScale); 
            
            //status 1
            solarCarState.setPowerBoardError(PowerBoardError.AuxPackReadError, 			 itob(Status1 & 0b00000001));
            solarCarState.setPowerBoardError(PowerBoardError.TwelveVoltMainReadError, 	 itob(Status1 & 0b00000010));
            solarCarState.setPowerBoardError(PowerBoardError.TwelveVoltMainOffError, 	 itob(Status1 & 0b00000100));            
            solarCarState.setPowerBoardError(PowerBoardError.TwelveVoltAuxReadError, 	 itob(Status1 & 0b00001000));
            solarCarState.setPowerBoardError(PowerBoardError.MainPackReadError, 		 itob(Status1 & 0b00010000));
            solarCarState.setPowerBoardError(PowerBoardError.AuxPackLow, 		  		 itob(Status1 & 0b00100000));
            solarCarState.setPowerBoardError(PowerBoardError.PowerBoardDisconnectedFault,itob(Status1 & 0b01000000));
          
        }else if(ID==322 /*BPS Reset Data Format*/){
        	
        	//Nothing used in this message At the moment
        
    	}else if(ID==323 /*Pack Enery and BPS status Data Format*/){
           
    		solarCarState.setPackPower(intCANmessage[5]<<8 +intCANmessage[6]);
    		solarCarState.setPackVoltage((intCANmessage[7]<<8 +intCANmessage[8])/10);
    		//votage sum not yet implemented in solar car state
    		//solarCarState.setPackVoltageSum(intCANmessage[9]<<8 +intCANmessage[10]);
    		
    		solarCarState.setStateOfCharge(intCANmessage[11]);
    		
    		int Status1 = intCANmessage[12];
			solarCarState.setBpsStatus(BpsStatus.ArrayEnable, 			itob(Status1 & 0b00000001));
			solarCarState.setBpsStatus(BpsStatus.ArraySwitch, 			itob(Status1 & 0b00000010));
			solarCarState.setBpsStatus(BpsStatus.PackEnable, 			itob(Status1 & 0b00000100));
			solarCarState.setBpsStatus(BpsStatus.PackPrecharge,			itob(Status1 & 0b00001000));
			solarCarState.setBpsStatus(BpsStatus.PackPrechargeTimeout,	itob(Status1 & 0b00010000));
			solarCarState.setBpsStatus(BpsStatus.ChargingMode,			itob(Status1 & 0b00100000));
			solarCarState.setBpsStatus(BpsStatus.ManualChargingMode,	itob(Status1 & 0b01000000));
			solarCarState.setBpsStatus(BpsStatus.SubarrayControlEnable,	itob(Status1 & 0b10000000));
    		  
        }else if(ID==324 /*Pack Health*/){
        	
        	int currentCap  = intCANmessage[5] << 8 + intCANmessage[6];
        	int cycles      = intCANmessage[7] << 8 + intCANmessage[8];
        	int mpptStatus1 = intCANmessage[9];
        	int mpptStatus2 = intCANmessage[10];
        	
        	solarCarState.setCurrentCapAmpHours(currentCap);
        	solarCarState.setPackCycles(cycles);

        	solarCarState.setMpptStatus(MpptStatus.MpptZeroEnable, 		itob(mpptStatus1 & 0b00000001));
        	solarCarState.setMpptStatus(MpptStatus.MpptOneEnable, 		itob(mpptStatus1 & 0b00000010));
        	solarCarState.setMpptStatus(MpptStatus.MpptTwoEnable, 		itob(mpptStatus1 & 0b00000100));
        	solarCarState.setMpptStatus(MpptStatus.MpptThreeEnable, 	itob(mpptStatus1 & 0b00001000));
        	solarCarState.setMpptStatus(MpptStatus.MpptFourEnable, 		itob(mpptStatus1 & 0b00010000));
        	solarCarState.setMpptStatus(MpptStatus.MpptFiveEnable, 		itob(mpptStatus1 & 0b00100000));
        	solarCarState.setMpptStatus(MpptStatus.MpptSixEnable, 		itob(mpptStatus1 & 0b01000000));
        	solarCarState.setMpptStatus(MpptStatus.MpptSevenEnable, 	itob(mpptStatus1 & 0b10000000));
        	
        	solarCarState.setMpptStatus(MpptStatus.MpptEightEnable, 	itob(mpptStatus2 & 0b00000001));
        	solarCarState.setMpptStatus(MpptStatus.MpptNineEnable, 		itob(mpptStatus2 & 0b00000010));
        	solarCarState.setMpptStatus(MpptStatus.MpptTenEnable, 		itob(mpptStatus2 & 0b00000100));
        	solarCarState.setMpptStatus(MpptStatus.MpptElevenEnable, 	itob(mpptStatus2 & 0b00001000));
        	solarCarState.setMpptStatus(MpptStatus.MpptTwelveEnable, 	itob(mpptStatus2 & 0b00010000));
        	solarCarState.setMpptStatus(MpptStatus.MpptThirteenEnable, 	itob(mpptStatus2 & 0b00100000));
        	solarCarState.setMpptStatus(MpptStatus.MpptFourteenEnable, 	itob(mpptStatus2 & 0b01000000));
        	solarCarState.setMpptStatus(MpptStatus.MpptFifteenEnable, 	itob(mpptStatus2 & 0b10000000));
      
        	
        }   
                       

    }
    private void Motor(){
        if(ID==768 /* MotorBoard Status Data Format */){
        	
        	int speedMPH = 		intCANmessage[5];
        	
        	int throttlePos = 	intCANmessage[7];
        	int regenPos = 		intCANmessage[8];
        	int throttleLimit = intCANmessage[9];
        	int regenLimit = 	intCANmessage[10];
        	int status = 		intCANmessage[11];
        	int IOState = 		intCANmessage[12];
        	
        	
        	solarCarState.setMPH(speedMPH);
        	solarCarState.setThrottlePositionPercent(throttlePos);
        	
        	solarCarState.setMotorBoardRegenLimit(regenLimit);
        	

        	solarCarState.setMotorBoardStatus(MotorBoardStatus.Regen,					itob(status & 0b00000001));
        	solarCarState.setMotorBoardStatus(MotorBoardStatus.Throttle,				itob(status & 0b00000010));
        	solarCarState.setMotorBoardStatus(MotorBoardStatus.Reverse,					itob(status & 0b00000100));
        	solarCarState.setMotorBoardStatus(MotorBoardStatus.MotorEnable,				itob(status & 0b00001000));
        	solarCarState.setMotorBoardStatus(MotorBoardStatus.WavesculptorConected,	itob(status & 0b00010000));
        	solarCarState.setMotorBoardStatus(MotorBoardStatus.RegenEnable,				itob(status & 0b00100000));
        	solarCarState.setMotorBoardStatus(MotorBoardStatus.ThrottleEnable,			itob(status & 0b01000000));
        	
        	
        
        	solarCarState.setMotorBoardIOState(MotorBoardIOState.NotThrottleEnable, itob(status & 0b00000001));
        	solarCarState.setMotorBoardIOState(MotorBoardIOState.MotorEnable, 		itob(status & 0b00000010));
        	solarCarState.setMotorBoardIOState(MotorBoardIOState.NotRegenEnable, 	itob(status & 0b00000100));
        	solarCarState.setMotorBoardIOState(MotorBoardIOState.Reverse, 			itob(status & 0b00001000));
        	solarCarState.setMotorBoardIOState(MotorBoardIOState.RegenPin, 			itob(status & 0b00010000));
        	solarCarState.setMotorBoardIOState(MotorBoardIOState.FansPin, 			itob(status & 0b00100000));
        	
        	
        }
        
    }
    
    private void Dash(){
    //    int CockpitTemp=CANmessage[]
    //    CockpitTempRecent=(CockpitTempRecent * (ShortWeight - 1) + CockpitTemp) / ShortWeight
    
    	solarCarState.setCockpitTemp(intCANmessage[5] << 8 + intCANmessage[6] );
    }
    
    
        
    }
