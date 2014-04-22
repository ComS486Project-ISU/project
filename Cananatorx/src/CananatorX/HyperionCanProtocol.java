package CananatorX;

import CananatorX.CanDataArg.PrisumCanDataType;
import CananatorX.PrisumSolarCarState.BatteryModuleError;
import CananatorX.PrisumSolarCarState.BpsStatus;
import CananatorX.PrisumSolarCarState.MotorBoardIOState;
import CananatorX.PrisumSolarCarState.MotorBoardStatus;
import CananatorX.PrisumSolarCarState.MpptStatus;
import CananatorX.PrisumSolarCarState.PackError;
import CananatorX.PrisumSolarCarState.PowerBoardError;



public class HyperionCanProtocol implements CanProtocol {
	
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
	
    private PrisumCanDataListener prisumListener;
    @Override
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
    
    private PrisumSolarCarState solarCarState;
    @Override
    public  void SetSolarCarStateReference(PrisumSolarCarState state)
    {
    	solarCarState = state;
    }
    
	@Override
    public void CANparse(int[] intCANmessage){
		int ID= intCANmessage[1]*256 + intCANmessage[2];
	    String CANtype ="";
	    
        if(ID >= bpsLow && ID <= bpsHigh){
            CANtype= "BPS"; //Device is BPS
            bps(intCANmessage);
        }else if(ID>= motorLow && ID<= motorHigh){
            CANtype= "Motor"; //Device is Motor
            Motor(intCANmessage);
        }else if(ID>= vdtsLow && ID<= vdtsHigh){
            CANtype= "VDTS"; //Device is VDTS
        }else if(ID>= mpptLow && ID<= mpptHigh){
            CANtype= "MPPT"; //Device is MPPT
        }else if(ID>= dashLow && ID<= dashHigh){
            CANtype= "Dash"; //Device is Dash
            Dash(intCANmessage);
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
    
    private void updateLocalStatistics()
    {
    	//some things aren't available in the Hyperion parser and must be calculated manually
    	//update Pack Power
    	double packVoltage = 0;
    	
    	for(double volt : solarCarState.getBatteryModuleVoltages())
    	{
    		packVoltage += volt;
    	}
    	
    	solarCarState.setPackVoltage(packVoltage);
    }
    
    private void bps(int[] intCANmessage){

		int ID= intCANmessage[1]*256 + intCANmessage[2];
        int sum0=0;
        int sum1=0;
        int counter=0;
        double vRange=0;
        int CAN9=intCANmessage[9];
        int CAN10=intCANmessage[10];
        if(ID>=FirstModule && ID<=LastModule){

            //PowerBoardStatus PowerBoardStatus = PowerBoardStatus.None;
            double modV=(((intCANmessage[5]+1)<<8)+intCANmessage[6])*ModVScale;
            double modT=(((intCANmessage[7])<<8)+intCANmessage[8])*ModTScale;
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
            
            
            updateLocalStatistics();
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
            
        
            CanDataArg dataArg = new CanDataArg(this,solarCarState, 0,PrisumCanDataType.BatteryProtectionSystem);
            NotifyDataChanged(dataArg);
            
        }   else if(ID==310 /*Power board*/){
        	
        	
            //PowerBoardStatus modStatus = PowerBoardStatus.None;
            int Status1=intCANmessage[11];
            int Status2=intCANmessage[12];
        	solarCarState.setAuxPackVoltage(((intCANmessage[5]<<8)+intCANmessage[6])*IScale);
            solarCarState.setTwelveVoltMainVoltage(((intCANmessage[7]<<8)+intCANmessage[8])*pbScale);
            solarCarState.setTwelveVoltAuxVoltage( ((intCANmessage[9]<<8)+intCANmessage[10])*pbScale); 
            solarCarState.setFiveVoltVoltage(intCANmessage[10]);
            
            //status 1
            solarCarState.setPowerBoardError(PowerBoardError.AuxPackReadError, 			 itob(Status1 & 0b00000001));
            solarCarState.setPowerBoardError(PowerBoardError.TwelveVoltMainReadError, 	 itob(Status1 & 0b00000010));           
            solarCarState.setPowerBoardError(PowerBoardError.TwelveVoltAuxReadError, 	 itob(Status1 & 0b00000100));
            //solarCarState.setPowerBoardError(PowerBoardError.5VreadError (not implemented), 		 itob(Status1 & 0b00010000));
            solarCarState.setPowerBoardError(PowerBoardError.AuxPackLow, 		  		 itob(Status1 & 0b00010000));
          
        } else if(ID==305 /*Pack Shunt*/)
        {
        	solarCarState.setPackVoltage(((intCANmessage[5]<<8)+intCANmessage[6]) * VScale);
        	solarCarState.setPackCurrent(((intCANmessage[7]<<8)+intCANmessage[8]) * IScale);
        
        } else if(ID==306 /*Array Shunt*/)
        {
        	solarCarState.setArrayVoltage(((intCANmessage[5]<<8)+intCANmessage[6]) * VScale);
        	solarCarState.setPackCurrent(((intCANmessage[7]<<8)+intCANmessage[8]) * IScale);
        	
        } else if(ID==307 /*Motor Shunt*/)
        {
        	solarCarState.setMotorVoltage(((intCANmessage[5]<<8)+intCANmessage[6]) * VScale);
        	solarCarState.setMotorCurrent(((intCANmessage[7]<<8)+intCANmessage[8]) * IScale);
            
        }
        else if(ID==322 /*BPS Reset Data Format*/){
        	
        	//Nothing used in this message At the moment
        
    	}else if(ID==323 /*Pack Enery and BPS status Data Format*/){
           
    		solarCarState.setPackPower((intCANmessage[5]<<8) +intCANmessage[6]);
    		
    		solarCarState.setStateOfCharge(intCANmessage[7]);
    		
    		int Status1 = intCANmessage[12];
    		
    		boolean mpptEnable =itob(Status1 & 0b00000010);
    		solarCarState.setMpptStatus(MpptStatus.MpptZeroEnable, mpptEnable);
    		solarCarState.setMpptStatus(MpptStatus.MpptOneEnable, mpptEnable);
    		solarCarState.setMpptStatus(MpptStatus.MpptTwoEnable, mpptEnable);
    		solarCarState.setMpptStatus(MpptStatus.MpptThreeEnable, mpptEnable);
    		
			solarCarState.setBpsStatus(BpsStatus.ArrayEnable, 			itob(Status1 & 0b00000010));
			solarCarState.setBpsStatus(BpsStatus.ArraySwitch, 			itob(Status1 & 0b00000100));
			solarCarState.setBpsStatus(BpsStatus.PackEnable, 			itob(Status1 & 0b00001000));
			solarCarState.setBpsStatus(BpsStatus.PackPrecharge,			itob(Status1 & 0b00010000));
    		  
        }else if(ID==324 /*Pack Health*/){
        	
        	int currentCap  = (intCANmessage[7] << 8) + intCANmessage[8];
        	int cycles      = (intCANmessage[5] << 8) + intCANmessage[6];
        	
        	solarCarState.setMaxCapacityAmpHours(currentCap);
        	solarCarState.setPackCycles(cycles);

        	
        }   
                       

    }
    private void Motor(int[] intCANmessage){

		int ID= intCANmessage[1]*256 + intCANmessage[2];
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
    
    private void Dash(int[] intCANmessage){
    //    int CockpitTemp=CANmessage[]
    //    CockpitTempRecent=(CockpitTempRecent * (ShortWeight - 1) + CockpitTemp) / ShortWeight
    
    	solarCarState.setCockpitTemp(intCANmessage[5] << 8 + intCANmessage[6] );
    }
    
}
