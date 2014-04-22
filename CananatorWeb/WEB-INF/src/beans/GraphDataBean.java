package beans;

import java.util.*;

import org.joda.time.DateTime;

public class GraphDataBean {
	
	private List<Double> packPowerVsTime; // Watts vs. seconds
	
	private List<Double> packCapacityVsTime; // Amp hrs vs. seconds
	
	private List<Double> systemVoltageVsTime; // Volts vs. seconds
	
	private List<Integer> mphVsTime; // mph vs. seconds
	
	private DateTime timeStart;
	private DateTime timeEnd;
	private int interval; // in milliseconds
	
	/**
	 * Constructor
	 */
	public GraphDataBean() {
		packPowerVsTime = new ArrayList<Double>();
		packCapacityVsTime = new ArrayList<Double>();
		mphVsTime = new ArrayList<Integer>();
		
		timeStart = new DateTime();
		timeEnd = new DateTime();
		interval = 0;
	}
	
	public void setTimeStart(DateTime dt) {
		timeStart = dt;
	}
	
	public void setTimeEnd(DateTime dt) {
		timeEnd = dt;
	}
	
	public void setInterval(int interval) {
		this.interval = interval;
	}
	
	public List<Double> getPackPowerVsTime() {
		return packPowerVsTime;
	}
	
	public List<Double> getPackCapacityVsTime() {
		return packCapacityVsTime;
	}
	
	public List<Double> getSystemVoltageVsTime() {
		return systemVoltageVsTime;
	}
	
	public List<Integer> getMphVsTime() {
		return mphVsTime;
	}
	
	public DateTime getTimeStart() {
		return timeStart;
	}
	
	public DateTime getTimeEnd() {
		return timeEnd;
	}
	
	public int getInterval() {
		return interval;
	}
}
