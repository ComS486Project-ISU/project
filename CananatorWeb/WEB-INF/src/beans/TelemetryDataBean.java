package beans;

public class TelemetryDataBean
{
  /**
   * Speed in MPH
   */
  private float drivingSpeed;
  
  /**
   * Rate of energy consumption in MPGe (miles per gallon equivalent)
   */
  private float energyConsumption;
  
  /**
   * Maximum Power Point Tracking Efficiency
   */
  private float mpptEfficiency;
  
  /*
   * Power amounts, in Watts of:
   * 1) Battery
   * 2) Solar
   * 3) Motor
   * 4) Electronics
   */
  private float batteryPower;
  private float solarPower;
  private float motorPower;
  private float elecPower;
  
  /*
   * Temperature, in degrees Celsius of:
   * 1) Cockpit
   * 2) Motor
   * 3) Controller
   * 4) Baseplate
   * 5) Battery
   * 6) MPPT
   */
  private float cockpitTemp;
  private float motorTemp;
  private float controlTemp;
  private float baseplateTemp;
  private float batteryTemp;
  private float mpptTemp;
    
  public float getDrivingSpeed()
  {
    return drivingSpeed;
  }
  public void setDrivingSpeed(float drivingSpeed)
  {
    this.drivingSpeed = drivingSpeed;
  }
  public float getEnergyConsumption()
  {
    return energyConsumption;
  }
  public void setEnergyConsumption(float energyConsumption)
  {
    this.energyConsumption = energyConsumption;
  }
  public float getMpptEfficiency()
  {
    return mpptEfficiency;
  }
  public void setMpptEfficiency(float mpptEfficiency)
  {
    this.mpptEfficiency = mpptEfficiency;
  }
  public float getBatteryPower()
  {
    return batteryPower;
  }
  public void setBatteryPower(float batteryPower)
  {
    this.batteryPower = batteryPower;
  }
  public float getSolarPower()
  {
    return solarPower;
  }
  public void setSolarPower(float solarPower)
  {
    this.solarPower = solarPower;
  }
  public float getMotorPower()
  {
    return motorPower;
  }
  public void setMotorPower(float motorPower)
  {
    this.motorPower = motorPower;
  }
  public float getElecPower()
  {
    return elecPower;
  }
  public void setElecPower(float elecPower)
  {
    this.elecPower = elecPower;
  }
  public float getCockpitTemp()
  {
    return cockpitTemp;
  }
  public void setCockpitTemp(float cockpitTemp)
  {
    this.cockpitTemp = cockpitTemp;
  }
  public float getMotorTemp()
  {
    return motorTemp;
  }
  public void setMotorTemp(float motorTemp)
  {
    this.motorTemp = motorTemp;
  }
  public float getControlTemp()
  {
    return controlTemp;
  }
  public void setControlTemp(float controlTemp)
  {
    this.controlTemp = controlTemp;
  }
  public float getBaseplateTemp()
  {
    return baseplateTemp;
  }
  public void setBaseplateTemp(float baseplateTemp)
  {
    this.baseplateTemp = baseplateTemp;
  }
  public float getBatteryTemp()
  {
    return batteryTemp;
  }
  public void setBatteryTemp(float batteryTemp)
  {
    this.batteryTemp = batteryTemp;
  }
  public float getMpptTemp()
  {
    return mpptTemp;
  }
  public void setMpptTemp(float mpptTemp)
  {
    this.mpptTemp = mpptTemp;
  }
}
