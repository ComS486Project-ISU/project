import beans.GraphDataBean;

import org.joda.time.DateTime;
import CananatorX.*;

public class CananatorDataSimulator {

	private Thread t;
	public static volatile boolean runningFlag;
	private PrisumCanParser telemetryData;
	private int sleepInterval;
	public GraphDataBean graphData;

	public CananatorDataSimulator(PrisumCanParser telemetryData) {
		sleepInterval = 5000; // 5000ms = 5s
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
			
			while (runningFlag) {
				try {
					dateTime = new DateTime();
					graphData.getTime().add("\"" + dateTime.hourOfDay().get() + ":" + 
											dateTime.minuteOfHour().get() + ":" + 
											dateTime.secondOfMinute().get() + "\"");
					graphData.getPackPowerVsTime().add(telemetryData.solarCarState.getPackPower());
					graphData.getPackCapacityVsTime().add(telemetryData.solarCarState.getMaxCapacityAmpHours() 
							                            * telemetryData.solarCarState.getStateOfCharge() * 0.01);
					graphData.getSystemVoltageVsTime().add(telemetryData.solarCarState.getPackVoltage());
					graphData.getMphVsTime().add(telemetryData.solarCarState.getMPH());
					Thread.sleep(sleepInterval);
					// ++counter;
				}
				catch(InterruptedException e) {
					e.printStackTrace();
				}
			}
		}
	}
}
