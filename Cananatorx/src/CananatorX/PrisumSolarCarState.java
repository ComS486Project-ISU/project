/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package CananatorX;
import java.util.ArrayList;
import java.util.Deque;
import java.util.Collections;
import java.util.List;
/**
 *
 * @author prisum
 */
public class PrisumSolarCarState {

    
	/*** Miles Per Hour PROPERTIES ***/
	private TrackedValue MPH = new TrackedValue();    
    
    //automatically updates averages when set
    public synchronized void setMPH(int amount)
    {
    	MPH.setNewValue(amount);
    }
	public synchronized int getMPHmax(){return (int) MPH.getMax();}
	public synchronized int getMPHmin(){return (int) MPH.getMin();}
	public synchronized double getMPHrecent(){return MPH.getMovingAverage();}
	public synchronized double getMPHavg(){return MPH.getTotalAverage();}
	public synchronized int getMPH(){return (int) MPH.getValue(); }
	
	private int throttlePositionPercent = 0;
	/*** Throttle Percentage ***/
	public void setThrottlePositionPercent(int amount)
	{
		throttlePositionPercent = amount;
	}
	public int getThrottlePositionPercent()
	{
		return throttlePositionPercent;
	}
	
	private int regenLimit = 0;
	enum MotorBoardStatus
	{
		//The following statuses are used for WaveSculptor
		Regen,
		Throttle,
		Reverse,
		MotorEnable,
		WavesculptorConected,
		RegenEnable,
		ThrottleEnable,
		
		//Below are supported for NGM motor board only
		NGM_Initialized,
		NGM_Charging,
		NGM_MotorNotReady,
		NGM_Interlock,
		NGM_Active,
		NGM_Standby,
		NGM_Transition,
		NGM_INdisable,
		NGM_Limiting,
		NGM_SpeedControl
		
		
	}
	enum MotorBoardIOState
	{
		NotThrottleEnable,
		MotorEnable,
		NotRegenEnable,
		Reverse,
		RegenPin,
		FansPin,
		
	}
	
	boolean MotorBoardStatuses[];
	boolean MotorBoardIOStates[];
	
	void setMotorBoardRegenLimit(int amount){
		this.regenLimit = amount;
	}
	
	void setMotorBoardStatus(MotorBoardStatus status, boolean value)
	{
		MotorBoardStatuses[status.ordinal()] = value;
	}
	
	void setMotorBoardIOState(MotorBoardIOState state, boolean value)
	{
		MotorBoardIOStates[state.ordinal()] = value;
	}
	boolean getMotorBoardStatus(MotorBoardStatus status)
	{
		return (MotorBoardStatuses[status.ordinal()]);
	}
	public String getMotorBoardStatusString()
	{
		 if(getMotorBoardStatus(MotorBoardStatus.NGM_Interlock)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.NGM_Limiting)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.NGM_MotorNotReady)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.NGM_INdisable)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.NGM_Transition)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.NGM_Charging)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.Regen)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.MotorEnable)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.NGM_Active)) return MotorBoardStatus.MotorEnable.toString();
		 if(getMotorBoardStatus(MotorBoardStatus.NGM_Initialized)) return MotorBoardStatus.MotorEnable.toString();
		 
		 //look at power data
		 double power = getMotorPower();
		 if( power > 0 )
		 {
			 return "Active";
		 } 
		 if( power < 0 )
		 {
			 return "Regen";
		 }
		 if(!getMotorBoardStatus(MotorBoardStatus.MotorEnable))
		 {
			 return "Disabled";
		 }
		 else
		 {
			 return "NoNetPower";
		 }
	
	}

	
	/*** Maximum Power Point Tracker Properties ***/
    private int MPPTeffCount  = 0; //Counter variable for MPPT efficiency calculations
    private int MPPTeffMax  = 0; //Initialize maximum MPPT efficiency
    private int MPPTeffMin  = 100; //Initialize minimum MPPT efficiency
    private int MPPTeffRecent  = 1; //Initialize weighted average of MPPT efficiency with expected value
    private int MPPTeffAvg  = 0; //Initialize average MPPT efficiency
    private int MPPTtCount  = 0; //Counter variable for MPPT temp calculations
    private int MPPTtMax  = 0; //Initialize maximum MPPT temp
    private int MPPTtMin  = 10000; //Initialize minimum MPPT temp
    private int MPPTtRecent  = 30; //Initialize weighted average of MPPT temp with expected value
    private int MPPTtAvg  = 0; //Initialize average MPPT temp

    /*** Overall Electronics Properties ***/
    private int ElectronicsPowerCount  = 0; //Counter variable for electronics calculations
    private int ElectronicsPowerMax  = 0; //Initialize maximum electronics power
    public synchronized void setElectronicsPowerMax(int amount){ElectronicsPowerMax = amount;}
	public synchronized int getElectronicsPowerMax(){return ElectronicsPowerMax;}
	
    private int ElectronicsPowerMin  = 10000; //Initialize minimum electronics power
    public synchronized void setElectronicsPowerMin(int amount){ElectronicsPowerMin = amount;}
	public synchronized int getElectronicsPowerMin(){return ElectronicsPowerMin;}
	
    
    private int ElectronicsPowerRecent  = 25; //Initialize weighted average of electronics power with expected value
    public synchronized void setElectronicsPowerRecent(int amount){ElectronicsPowerRecent = amount;}
	public synchronized int getElectronicsPowerRecent(){return ElectronicsPowerRecent;}
	
    
    private int ElectronicsPowerAvg  = 0; //Initialize average electronics power
    public synchronized void setElectronicsPowerAvg(int amount){ElectronicsPowerAvg = amount;}
	public synchronized int getElectronicsPowerAvg(){return ElectronicsPowerAvg;}
	
    
//    private int MPGeCount  = 0; //Counter variable for MPGe
//    private int MPGeMax  = 0; //Initialize maximum MPGe
//    private int MPGeMin  = 10000; //Initialize minimum MPGe
//    private int MPGeRecent  = 0; //Initialize weighted average of MPGe with expected value
//    private int MPGeAvg  = 0; //Initialize average MPGe

	/*** Pack Properties ***/
	TrackedValue PackPower = new TrackedValue();
	
  public synchronized void setPackPower(double amount)
    {
	
	  if(this.getBpsStatus(BpsStatus.PackPrecharge))
	  {
		  this.PackStatus = PackStatusEnum.PackPrecharge;
	  }
	  else if(this.getBpsStatus(BpsStatus.PackPrechargeTimeout))
	  {
		  this.PackStatus = PackStatusEnum.PackPrechargeTimeout;
	  }
	  if(this.getBpsStatus(BpsStatus.PackEnable))
		  		
	  {
	    	//update status
	    	if(amount>0){
	            this.PackStatus = PackStatusEnum.Charging;
	        }else if(amount<0){
	            this.PackStatus = PackStatusEnum.Draining;
	        }else{
	        	this.PackStatus = PackStatusEnum.NoNetPower;
	        }
	  }
	  else
	  {
		  this.PackStatus = PackStatusEnum.Disabled;
	  }
	  
    	
    	PackPower.setNewValue(amount);	
    }
	public synchronized double getPackPowerRecent(){return PackPower.getMovingAverage();}
	public synchronized double getPackPowerAvg(){return PackPower.getTotalAverage();}
    public synchronized double getPackPowerMax(){return PackPower.getMax();}
    public synchronized double getPackPowerMin(){return PackPower.getMin();}
    public synchronized double getPackPower() {return PackPower.getValue();}
	
	private int PackTCount  = 0; //Counter variable for pack temp calculations
    private int PackTMax  = 0; //Initialize maximum pack temp
    private int PackTMin  = 10000; //Initialize minimum pack temp
    private int PackTRecent  = 30; //Initialize weighted average of pack temp with expected value
    private int PackTAvg  = 0; //Initialize average pack temp
    
    private TrackedValue PackCurrent = new TrackedValue();
    public synchronized void setPackCurrent(double packCurrent) 
    {
    	PackCurrent.setNewValue(packCurrent);
    }
    public synchronized double getPackCurrent() {return PackCurrent.getValue();}
    public synchronized double getPackCurrentRecent() {return PackCurrent.getMovingAverage();}
    public synchronized double getPackCurrentAvg() {return PackCurrent.getTotalAverage();}
    public synchronized double getPackCurrentMax() {return PackCurrent.getMax();}
    public synchronized double getPackCurrentMin() {return PackCurrent.getMin();}
    
    
    
	
    private double noLoadVoltage;
    private TrackedValue PackVoltage = new TrackedValue();
    public synchronized void setPackVoltage(double packVoltage) 
    {
    	PackVoltage.setNewValue(packVoltage);
    }
    
    public synchronized double getPackVoltage() 
    {
    	return PackVoltage.getValue();
    }
    
    public synchronized double getPackVoltageRecent()
    {
    	return PackVoltage.getMovingAverage();
    }
    
	public synchronized double getNoLoadVoltage()
	{
		//no load voltage is the voltage of the pack when motor and array are 0
		return noLoadVoltage;
	}

	/*** ARRAY PROPERTIES ***/
	//custom staus attributes generated from other results
	 private enum ArrayStatusEnum
    {
    	Disabled,
    	Switched_On_BPS_Disabled,
    	Enabled
    }

	private double ArrayVoltage = 0 ;
	public synchronized void setArrayVoltage(double amount){ArrayVoltage = amount;}
	public synchronized double getArrayVoltage(){return ArrayVoltage;}
	
	private double ArrayCurrent = 0;
	public synchronized void setArrayPower(double amount){
    	if(getBpsStatusArrayEnable())
    	{
    		this.ArrayStatus = ArrayStatusEnum.Enabled;
    	}
    	if(getBpsStatusArraySwitch())
    	{
    		this.ArrayStatus = ArrayStatusEnum.Switched_On_BPS_Disabled;
    	}
    	else
    	{
    		this.ArrayStatus = ArrayStatusEnum.Disabled;
    	}
    	
    	ArrayPower.setNewValue(amount);
    	
    }
    public String getArrayStatus()
    {
    	return this.ArrayStatus.toString();
    }
	
	public synchronized void setArrayCurrent(double amount){ArrayCurrent = amount;}
	
    public synchronized double getArrayCurrent(){return ArrayCurrent;}
	private ArrayStatusEnum ArrayStatus = ArrayStatusEnum.Disabled;
    private TrackedValue ArrayPower = new TrackedValue();
 
	public synchronized double getArrayPower(){return ArrayPower.getValue();}
	public synchronized double getArrayPowerMin(){return ArrayPower.getMin();}
	public synchronized double getArrayPowerMax(){return ArrayPower.getMax();}
	public synchronized double getArrayPowerRecent(){return ArrayPower.getMovingAverage();}
	public synchronized double getArrayPowerAvg(){return ArrayPower.getTotalAverage();}

	   
    
	
	/*** MOTOR PROPERTIES ***/
	
	//custom mutually exclusive status values (generated from other data)

	
	private TrackedValue MotorPower = new TrackedValue();
	private void updateNoLoadVoltage()
	{
		if(MotorPower.getValue() < 0.1 && MotorPower.getValue() > 0.1)
		{
			if(ArrayPower.getValue() < 0.1 && ArrayPower.getValue() >0.1)
			{
				this.noLoadVoltage = this.PackVoltage.getValue();
			}
		}
	}
    public synchronized void setMotorPower(double amount){
    	

    	
    	MotorPower.setNewValue(amount);
    	
    }
	public synchronized double getMotorPower(){return MotorPower.getValue();}
	public synchronized double getMotorPowerMin(){return MotorPower.getMin();}
	public synchronized double getMotorPowerMax(){return MotorPower.getMax();}
	public synchronized double getMotorPowerRecent(){return MotorPower.getMovingAverage();}
	public synchronized double getMotorPowerAvg(){return MotorPower.getTotalAverage();}

	
	private int MotorTCount  = 0; //Counter variable for motor temp calculations
    private int MotorTMax  = 0; //Initialize maximum motor temp
    private int MotorTMin  = 10000; //Initialize minimum motor temp
    private int MotorTRecent  = 30; //Initialize weighted average of motor temp with expected value
    private  int MotorTAvg  = 0; //Initialize average motor temp
    private double MotorVoltage;
    private double MotorCurrent;
    private double MotorPowerMin;
    private double MotorPowerMax;

    public synchronized void setMotorCurrent(double amount){MotorCurrent = amount;}
    public synchronized double getMotorCurrent(){return MotorCurrent;}
    public synchronized void setMotorVoltage(double amount){MotorVoltage = amount;}
    public synchronized double getMotorVoltage(){return MotorVoltage;}

    
    /*** MOTOR CONTROLLER PROPERTIES ***/
    private int ControllerTCount  = 0; //Counter variable for controller temp calculations
    private int ControllerTMax  = 0; //Initialize maximum controller temp
    private int ControllerTMin  = 10000; //Initialize minimum controller temp
    private int ControllerTRecent  = 30; //Initialize weighted average of controller temp with expected value
    private int ControllerTAvg  = 0; //Initialize average controller temp
    private int BaseplateTCount  = 0; //Counter variable for baseplate temp calculations
    private int BaseplateTMax  = 0; //Initialize maximum baseplate temp
    private int BaseplateTMin  = 10000; //Initialize minimum baseplate temp
    private int BaseplateTRecent  = 30; //Initialize weighted average of baseplate temp with expected value
    private int BaseplateTAvg  = 0; //Initialize average baseplate temp
    
    /*** COCKPIT PROPERTIES ***/
    private int CockpitTCount  = 0; //Counter variable for cockpit temp calculations
    private double CockpitTempMax  = 0; //Initialize maximum cockpit temp
    private double CockpitTempMin  = 10000; //Initialize minimum cockpit temp
    private double CockpitTempRecent  = 30; //Initialize weighted average of cockpit temp with expected value
    private double CockpitTempAvg  = 0; //Initialize average cockpit temp
    private double CockpitTemp  = 0; //Initialize average cockpit temp
    
   public synchronized void setCockpitTemp(double amount)
   {
	   CockpitTemp = amount;
   }
   public synchronized double getCockpitTemp()
   {
	   return CockpitTemp;
   }
   
   public synchronized double getCockpitTempMax(){return CockpitTempMax;}
   public synchronized double getCockpitTempMin(){return CockpitTempMin;}
   public synchronized double getCockpitTempRecent(){return CockpitTempRecent;}
   public synchronized double getCockpitTempAvg(){return CockpitTempAvg;}
   
    private int RecentV  = 100; //Initialize weighted average of system voltage with expected value
    private int ShortWeight  = 100; //Determines how many recent samples are given significant weight
    private int MidWeight  = 300; //Determines how many recent samples are given significant weight
    private int LongWeight  = 600; //Determines how many recent samples are given significant weight
    

	/*** BPS PROPERTIES ***/
    private double highV = 0.0;
    private int highVmod;
    private double lowV = Integer.MAX_VALUE ;
    private int lowVmod ;
    private double highT = 0.0;
    private int highTmod;
    private double lowT = Integer.MAX_VALUE;
    private int lowTmod; 

    
    private boolean[] PackErrors;
    private  boolean[] PowerBoardErrors;
    private boolean[] BpsStatuses;

    
    private enum PackStatusEnum
    {
    	Disabled,
    	Charging,
    	Draining,
    	NoNetPower,
    	PackPrecharge,
    	PackPrechargeTimeout,
    	
    }
   
    private PackStatusEnum PackStatus = PackStatusEnum.Disabled;
    
    public String getPackStatus()
    {
    	
    	return this.PackStatus.toString();
    }

    public double getAuxPackVoltage() {
		return AuxPackVoltage;
	}
	public void setAuxPackVoltage(double auxPackVoltage) {
		AuxPackVoltage = auxPackVoltage;
	}
	
	
	public String getAuxPackLevel()
	{
		if(this.getPowerBoardAuxPackLow())
		{
			return "Aux Pack Low";
		}
		else
		{
			return "Normal";
		}
	}
	public double getTwelveVoltMainVoltage() {
		return TwelveVoltMainVoltage;
	}
	public void setTwelveVoltMainVoltage(double twelveVoltMainVoltage) {
		TwelveVoltMainVoltage = twelveVoltMainVoltage;
	}
	public double getTwelveVoltAuxVoltage() {
		return TwelveVoltAuxVoltage;
	}
	public void setTwelveVoltAuxVoltage(double twelveVoltAuxVoltage) {
		TwelveVoltAuxVoltage = twelveVoltAuxVoltage;
	}
	public double getFiveVoltVoltage() {
		return FiveVoltVoltage;
	}
	public void setFiveVoltVoltage(double fiveVoltVoltage) {
		FiveVoltVoltage = fiveVoltVoltage;
	}

	private double AuxPackVoltage;
    private double TwelveVoltMainVoltage;
    private double TwelveVoltAuxVoltage;
    private double FiveVoltVoltage;
   
    //Pack Energy and BPS Status
    
    private double StateOfCharge; //0.0 = 1.0
    
    //Pack Health
    private int Cycles;
    public void setPackCycles(int cycles) {
		Cycles = cycles;
	}
    
    private int CurrentCapAmpHours;
    public void setMaxCapacityAmpHours(int currentCapAmpHours)
    {
    	CurrentCapAmpHours = currentCapAmpHours;
    }
    public int getMaxCapacityAmpHours()
    {
    	return CurrentCapAmpHours;
    }
    
    boolean[] MpptStatuses;
    //internal
    void setMpptStatus(MpptStatus status, boolean value)
    {
    	MpptStatuses[status.ordinal()] = value;
    }
    
    public boolean getMpptStatus(MpptStatus status)
    {
    	return MpptStatuses[status.ordinal()];
    }
    
    
    
    enum MpptStatus
    {
    	MpptZeroEnable,
    	MpptOneEnable,
    	MpptTwoEnable,
    	MpptThreeEnable,
    	MpptFourEnable,
    	MpptFiveEnable,
    	MpptSixEnable,
    	MpptSevenEnable,
    	MpptEightEnable,
    	MpptNineEnable,
    	MpptTenEnable,
    	MpptElevenEnable,
    	MpptTwelveEnable,
    	MpptThirteenEnable,
    	MpptFourteenEnable,
    	MpptFifteenEnable,
    }

    /***BATERY MODULES ***/
    private ArrayList<BatteryModule> BatteryModules;        

    //inner battery module class
    private class BatteryModule {

    	//track when a battery module actually exists
    	
    	public boolean Exists;
        public double Temp;
        public double Voltage;
        //public BatteryModuleError moduleError;
        
        /**
         * each enumeration of BatteryModuleError corresponds to a flag state in bmErrors
         */
        public boolean[] bmErrors;
        public int Id;
        
        public BatteryModule()
        {
            bmErrors = new boolean[BatteryModuleError.values().length];
        }
    }
            
    public synchronized void setBatteryModuleTemp(int num, double amount)
    {
    	BatteryModule bm = BatteryModules.get(num);
    	bm.Temp = amount;
    	bm.Exists = true;
    	
    	//update temperature statistics
    	if(amount >= highT){
    	    highTmod = num;
    	    highT = amount;
    	}
	    if(amount <= lowT){
	    	lowTmod = num;
	    	lowT = amount;
	    }
    }
    
    public List<Double> getBatteryModuleTemperatures()
    {
    	ArrayList<Double> modTemps =  new ArrayList<Double>();// = new double[PrisumSolarCarConstants.NumModules];
	
    	for(BatteryModule bm : BatteryModules)
    	{
    		if(bm.Exists)
    		{
    			modTemps.add(bm.Temp);
    		}
    	}
    	return  modTemps;
    }
    
    public List<Double> getBatteryModuleVoltages()
    {
    	ArrayList<Double> modVoltages = new ArrayList<Double>();
	
    	for(BatteryModule bm : BatteryModules)
    	{
    		if(bm.Exists)
    		{
    			modVoltages.add(bm.Voltage);
    		}
    	}
    	return modVoltages;
    }
    
	public synchronized double getBatteryModuleTemp(int num)
	{
		BatteryModule bm = BatteryModules.get(num);
    	return bm.Temp;
    }
	public synchronized double getBatteryModuleTempHigh()
	{
		return highT;
	}
	public synchronized int getBatteryModuleTempHighMod()
	{
		return highTmod;
	}
	public synchronized double getBatteryModuleTempLow()
	{
		return lowT;
	}
	public synchronized int getBatteryModuleTempLowMod()
	{
		return lowTmod;
	}
	
	public synchronized double getBatteryModuleVoltageRange()
	{
		return highVmod - lowVmod;
	}
     //not updating on bps statistics data, only batt mod

	public synchronized void setBatteryModuleVoltage(int num, double amount)
    {
    	BatteryModule bm = BatteryModules.get(num);
    	bm.Voltage = amount;
    	bm.Exists = true;
    	
    	
    	//update voltage statistics
    	if(amount >= highV){
    	    highVmod = num;
    	    highV = amount;
    	}
	    if(amount <= lowV){
	    	lowVmod = num;
	    	lowV = amount;
	    }
    }
    
	
	public synchronized double getBatteryModuleVoltage(int num)
	{
		BatteryModule bm = BatteryModules.get(num);
    	return bm.Voltage;
    }
	
	public synchronized double getBatteryModuleVoltageHigh()
	{
		return highV;
	}
	public synchronized int getBatteryModuleVoltageHighMod()
	{
		return highVmod;
	}
	public synchronized double getBatteryModuleVoltageLow()
	{
		return lowV;
	}
	public synchronized int getBatteryModuleVoltageLowMod()
	{
		return lowVmod;
	}
	
	
	//internal
    public enum BatteryModuleError
    {
        None,   
        OverTempFault,
        OverTempWarning,
        UnderTempFault,
        
        OverVoltFault,
        OverVoltWarning,
        UnderTempWarning,
        UnderVoltWarning,
        UnderVoltFault,
        VoltageReadError,
        TempReadError,
        TempCalibrationRangeError,
        ModuleDisconnectedFault,
        
    }
    
    //internal only
    public void setBatteryModuleError(int num, BatteryModuleError error, boolean value )
    {
    	BatteryModule bm = BatteryModules.get(num);
    	bm.Exists = true;
    	bm.bmErrors[error.ordinal()] = value;
    }
    
    //internal only
    boolean getBatteryModuleError(int num, BatteryModuleError error)
    {
    	BatteryModule bm = BatteryModules.get(num);
    	return bm.bmErrors[error.ordinal()];
    }
	
    private List<Boolean> collectBatModErrors(BatteryModuleError error)
    {
    	ArrayList<Boolean> errors = new ArrayList<Boolean>();
    	
    	for(BatteryModule bm : BatteryModules)
    	{
    		if(bm.Exists)
    		{
    			errors.add(bm.bmErrors[error.ordinal()]);
    		}
    	}
    	
    	return errors;
    }
    public List<Boolean> getBatteryModuleTempReadErrors()    { 	return collectBatModErrors(BatteryModuleError.TempReadError); };
    
    public synchronized boolean getBatteryModuleTempReadError(int num)
	{
    	return getBatteryModuleError(num,BatteryModuleError.TempReadError);	
	}
    

    public List<Boolean> getBatteryModuleOverTempFaults()  { 	return collectBatModErrors(BatteryModuleError.OverTempFault); };
    public synchronized boolean getBatteryModuleOverTempFault(int num)
	{
    	return getBatteryModuleError(num,BatteryModuleError.OverTempFault);	
	}
    
    public List<Boolean> getBatteryModuleOverTempWarnings()  { 	return collectBatModErrors(BatteryModuleError.OverTempWarning); };
    
	public synchronized boolean getBatteryModuleOverTempWarning(int num)
	{
    	return getBatteryModuleError(num,BatteryModuleError.OverTempWarning);
	}
	
	public List<Boolean> getBatteryModuleUnderTempFaults()  { 	return collectBatModErrors(BatteryModuleError.UnderTempFault); };
	public List<Boolean> getBatteryModuleUnderTempWarnings()  { 	return collectBatModErrors(BatteryModuleError.UnderTempWarning); };
    
	public synchronized boolean getBatteryModuleUnderTempFault(int num)
	{
    	return getBatteryModuleError(num,BatteryModuleError.UnderTempFault);
	}
	
	public List<Boolean> getBatteryModuleVoltageReadErrors()  { 	return collectBatModErrors(BatteryModuleError.VoltageReadError); };
    
	public synchronized boolean getBatteryModuleVoltageReadError(int num)
	{
    	return getBatteryModuleError(num,BatteryModuleError.VoltageReadError);		
	}
	
	public List<Boolean> getBatteryModuleOverVoltFaults()  { 	return collectBatModErrors(BatteryModuleError.OverVoltFault); };
	public List<Boolean> getBatteryModuleOverVoltWarnings()  { 	return collectBatModErrors(BatteryModuleError.OverVoltWarning); };
    
	public synchronized boolean getBatteryModuleOverVoltFault(int num)
	{
    	return getBatteryModuleError(num,BatteryModuleError.OverVoltFault);
	}
	
	public List<Boolean> getBatteryModuleUnderVoltFaults()  { 	return collectBatModErrors(BatteryModuleError.UnderVoltFault); };
    
	public synchronized boolean getBatteryModuleUnderVoltFault(int num)
	{
    	return getBatteryModuleError(num,BatteryModuleError.UnderVoltFault);
	}

	public List<Boolean> getBatteryModuleUnderVoltWarnings()  { 	return collectBatModErrors(BatteryModuleError.UnderVoltWarning); };

	public synchronized boolean getBatteryModuleUnderVoltWarning(int num)
	{
    	return getBatteryModuleError(num,BatteryModuleError.UnderVoltWarning);
	}	
	
	public List<Boolean> getBatteryModuleDisconnectedFaults() { return collectBatModErrors(BatteryModuleError.ModuleDisconnectedFault); };

	public List<Boolean> getBatteryModuleTempCalibrationRangeErrors() { return collectBatModErrors(BatteryModuleError.TempCalibrationRangeError); };

	public synchronized List<Integer> getBatteryModuleIds()
	{
    	ArrayList<Integer> ids = new ArrayList<Integer>();
    	
    	for(BatteryModule bm : BatteryModules)
    	{
    		
    		if(bm.Exists)
    		{
    			ids.add(bm.Id);
    		}
    	}
    	
    	return ids;		
	}
	/*** PACK ERROR ***/
    public enum PackError
    {
        PackCurrentReadError,
        ArrayCurrentReadError,
        MotorCurrentReadError,
        
        PackCalibrationRangeError,
        OverDischargeWarning,
        OverDischargeFault,
        OverChargeWarning,
        OverChargeFault,
        MotorCurrentCalibrationError,
        ArrayCurrentCalibrationError,
        PowersenseDisconnectedFault;
    }
    //internal only
    void setPackError(PackError error, boolean value )
    {
    	PackErrors[error.ordinal()] = value;
    }
    
    //internal only
    boolean getPackError(PackError error)
    {
    	return PackErrors[error.ordinal()];
    }
    
    public synchronized boolean getPackCurrentReadError()
    {
    	return getPackError(PackError.PackCurrentReadError);
    }
    
    public synchronized boolean getPackOverDischargeWarning()
    {
    	return getPackError(PackError.OverDischargeWarning);
    }
    public synchronized boolean getPackOverDischargeFault()
    {
    	return getPackError(PackError.OverDischargeFault);
    }
    public synchronized boolean getPackOverChargeWarning()
    {
    	return getPackError(PackError.OverChargeWarning);
    }
    public synchronized boolean getPackOverChargeFault()
    {
    	return getPackError(PackError.OverDischargeFault);
    }
    public synchronized boolean getArrayCurrentReadError()
    {
    	return getPackError(PackError.ArrayCurrentReadError);
    }
    public synchronized boolean getMotorCurrentReadError()
    {
    	return getPackError(PackError.MotorCurrentReadError);
    }
    
    /*** POWER BOARD ERROR ***/
    public enum PowerBoardError
    {
       AuxPackReadError,
       TwelveVoltMainReadError,
       TwelveVoltMainOffError,
       TwelveVoltAuxReadError,
       FiveVoltReadError,
       MainPackReadError,
       AuxPackLow,
       PowerBoardDisconnectedFault
    }
    //internal only
    void setPowerBoardError(PowerBoardError error, boolean value )
    {
    	PowerBoardErrors[error.ordinal()] = value;
    }
    
    //internal only
    boolean getPowerBoardError(PowerBoardError error)
    {
    	return PowerBoardErrors[error.ordinal()];
    }
    
    public synchronized boolean getPowerBoardAuxPackReadError()
    {
    	return getPowerBoardError(PowerBoardError.AuxPackReadError);
    }
    public synchronized boolean getPowerBoardTwelveVoltMainReadError()
    {
    	return getPowerBoardError(PowerBoardError.TwelveVoltMainReadError);
    }
    public synchronized boolean getPowerBoardTwelveVoltAuxReadError()
    {
    	return getPowerBoardError(PowerBoardError.TwelveVoltAuxReadError);
    }
    public synchronized boolean getPowerBoardFiveVoltReadError()
    {
    	return getPowerBoardError(PowerBoardError.FiveVoltReadError);
    }
    public synchronized boolean getPowerBoardAuxPackLow()
    {
    	return getPowerBoardError(PowerBoardError.AuxPackLow);
    }
    
    /*** PACK STATUS ***/
  

    //also array based
    public enum BpsStatus
    {
    	ArrayEnable,
    	ArraySwitch,
    	PackEnable,
    	PackPrecharge,
    	PackPrechargeTimeout,
    	ChargingMode,
    	ManualChargingMode,
    	SubarrayControlEnable
    }
    

    //internal only
    synchronized void setBpsStatus(BpsStatus status, boolean value )
    {
    	BpsStatuses[status.ordinal()] = value;
    	
    	
    	//update Array Status
    	
    }    
    
    synchronized boolean getBpsStatus(BpsStatus status)
    {
    	return BpsStatuses[status.ordinal()];
    }
    
    public synchronized boolean getMpptEnableStatus(int num)
    {
    	return this.MpptStatuses[num];
    }
    public synchronized boolean getBpsStatusArrayEnable()
    {
    	return getBpsStatus(BpsStatus.ArrayEnable);
    }
    public synchronized boolean getBpsStatusArraySwitch()
    {
    	return getBpsStatus(BpsStatus.ArraySwitch);
    }
    
    public synchronized boolean getBpsStatusPackEnable()
    {
    	return getBpsStatus(BpsStatus.PackEnable);
    }
    public synchronized boolean getBpsPackPrecharge()
    {
    	return getBpsStatus(BpsStatus.PackPrecharge);
    }
    
public	PrisumSolarCarState()
	{
	    PackErrors = new boolean[PackError.values().length];
	    BpsStatuses = new boolean[BpsStatus.values().length];
	    PowerBoardErrors = new boolean[PowerBoardError.values().length];
	    BatteryModules  = new ArrayList<BatteryModule>(PrisumSolarCarConstants.NumModules+1);
	    MpptStatuses = new boolean[MpptStatus.values().length];	
		MotorBoardStatuses = new boolean[MotorBoardStatus.values().length];
		MotorBoardIOStates = new boolean[MotorBoardIOState.values().length];
		
	    //initialize with default values
	    for(int i = 0; i< PrisumSolarCarConstants.NumModules+1; i++)
	    {
	        BatteryModule bm = new BatteryModule();
	        bm.Id = i;
	        bm.Temp = 0;
	        bm.Voltage = 0;
	        bm.bmErrors = new boolean[BatteryModuleError.values().length];
	               
	        BatteryModules.add(bm);
	    }
	}
public double getStateOfCharge() {
	return StateOfCharge;
}
public void setStateOfCharge(double stateOfCharge) {
	StateOfCharge = stateOfCharge;
}   
}
