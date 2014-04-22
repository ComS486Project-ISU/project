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
    private CanProtocol protocol= new HyperionCanProtocol();
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

    private int CheckSum=0;
    private int messageSize=0;
    private int baudRate= 57600;
    private Date lastCANmessage = new Date();
    private DecimalFormat df= new DecimalFormat("#.###");
    

        


    
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
        protocol.RegisterCanDataListener(listener);
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
            
            
            protocol.SetSolarCarStateReference(solarCarState);
            
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
                                	protocol.CANparse(intCANmessage);
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
  
    

    
        
    }
