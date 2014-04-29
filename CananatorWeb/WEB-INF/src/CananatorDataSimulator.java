import beans.GraphDataBean;

import org.joda.time.DateTime;
import CananatorX.*;

public class CananatorDataSimulator {

	private Thread t;
	public static volatile boolean runningFlag;
	private PrisumCanParser telemetryData;
	public GraphDataBean graphData;

	public CananatorDataSimulator(PrisumCanParser telemetryData) {
		graphData = new GraphDataBean();
		this.telemetryData = telemetryData;
	}

	public void startThread() {
		runningFlag = true;
		t = new Thread(new CanDataThread());
		t.start();
	}

	public void endThread() {
		runningFlag = false;
	}

	class CanDataThread implements Runnable {
		
		private DateTime dateTime;
		
		@Override
		public void run() {
			dateTime = new DateTime();
			graphData.setTimeStart(dateTime);
			graphData.setInterval(1000); // 1 second
			
			while (runningFlag) {
				try {
					graphData.getTime().add(new DateTime());
					graphData.getPackPowerVsTime().add(telemetryData.solarCarState.getPackPower());
					graphData.getPackCapacityVsTime().add(telemetryData.solarCarState.getMaxCapacityAmpHours() 
							                            * telemetryData.solarCarState.getStateOfCharge() * 0.01);
					graphData.getSystemVoltageVsTime().add(telemetryData.solarCarState.getPackVoltage());
					graphData.getMphVsTime().add(telemetryData.solarCarState.getMPH());
					Thread.sleep(1000);
					// ++counter;
				}
				catch(InterruptedException e) {
					e.printStackTrace();
				}
			}
			graphData.setTimeEnd(dateTime);
		}
	}
}
