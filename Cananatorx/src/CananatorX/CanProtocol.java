package CananatorX;

public interface CanProtocol {

	public abstract void CANparse(int[] intCANmessage); //must be size 14

	public abstract void SetSolarCarStateReference(PrisumSolarCarState state);
    public abstract void RegisterCanDataListener(PrisumCanDataListener listener);
  
	
}
