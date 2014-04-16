/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package CananatorX;
import java.util.ArrayList;
/**
 *
 * @author prisum
 */
public class PrisumSolarCarState {
    
    //inner properties
    public BatteryProtectionSystem BPS = new BatteryProtectionSystem();
    
    public BatteryProtectionSystem GetBPS(){ return BPS;};
    public Motor Motor = new Motor();
    //inner types
    public enum BatteryModuleError
    {
        None,
        
        TempReadError,
        OverTempFault,
        OverTempWarning,
        UnderTempFault,
        UnderTempWarning,
        VoltageReadError,
        OverVoltFault,
        OverVoltWarning,
        UnderVoltFault,
        UnderVoltWarning;
    }
    public class BatteryModule {

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
    
    public enum PackError
    {
        None,
        PackCurrentReadError,
        PackVoltageReadError,
        OverDischargeWarning,
        OverDischargeFault,
        OverChargeWarning,
        OverChargeFault,
        ArrayCurrentReadError,
        MotorCurrentReadError;
    }

    public enum PowerBoardStatus
    {
       AuxPackReadError,
       TwelveVoltMainReadError,
       TwelveVoltAuxReadError,
       FiveVoltReadError,
       AuxPackLow
    }
    
    public enum PackStatus
    {
        Charging,
        Draining,
        NoNetPower
    }

    public enum BpsStatus
    {
        MpptEnable,
        ArrayEnable,    //bps state
        ArraySwitch,   //array switch
        PackEnable,
        PackPrecharge
        
    }

    public class BatteryProtectionSystem
    {

        public double highV;
        public int highVmod;
        public double lowV;
        public int lowVmod;
        public double highT;
        public int highTmod;
        public double lowT;
        public int lowTmod;
        public double SystemV;
        public double PackPowerMin;
        public double PackPowerMax;
        public double PackCurrent;
        public double PackPower;  
        public boolean[] PackErrors;
        public boolean[] PowerBoardStatuses;
        public PackStatus PackStatus;
        
        public double ArrayVoltage;
        public double ArrayCurrent;
        public double ArrayPower;
        public double ArrayPowerMin;
        public double ArrayPowerMax;
        public double ArrayPowerAvg;
        public double MotorVoltage;
        public double MotorCurrent;
        public double MotorPower;
        public double MotorPowerMin;
        public double MotorPowerMax;
        public double AuxPackVoltage;
        public double TwelveVoltMainVoltage;
        public double TwelveVoltAuxVoltage;
        public double FiveVoltVoltage;
        
        //Pack Energy and BPS Status
        
        public boolean[] BpsStatuses;
        public double StateOfCharge; //0.0 = 1.0
        
        //Pack Health
        public int Cycle;
        public int CurrentCapAmpHours;
        
        
        
        /**
         * each enumeration of PackInfoError corresponds to a flag state in PackErrors
         */
        


        
        public ArrayList<BatteryModule> BatteryModules;

        
        
        public BatteryProtectionSystem()
        {
            PackErrors = new boolean[PackError.values().length];
            BpsStatuses = new boolean[BpsStatus.values().length];
            PowerBoardStatuses = new boolean[PowerBoardStatus.values().length];
            BatteryModules  = new ArrayList<BatteryModule>(PrisumSolarCarConstants.NumModules);
            
            //initialize with default values
            for(int i = 0; i< PrisumSolarCarConstants.NumModules; i++)
            {
                BatteryModule bm = new BatteryModule();
                bm.Id = 1;
                bm.Temp = 0;
                bm.Voltage = 0;
                bm.bmErrors = new boolean[8];
                       
                BatteryModules.add(bm);
            }
        }
    }
    
    public class Motor
    {
        public float RPM;
        
        
    }
        
    
}
