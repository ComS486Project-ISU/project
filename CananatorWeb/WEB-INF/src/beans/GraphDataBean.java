package beans;

import java.util.*;

import org.joda.time.DateTime;

public class GraphDataBean {
	
	private List<String> time; // time stamps
	
	private List<Double> packPowerVsTime; // Watts vs. seconds
	
	private List<Double> packCapacityVsTime; // Amp hrs vs. seconds
	
	private List<Double> systemVoltageVsTime; // Volts vs. seconds
	
	private List<Integer> mphVsTime; // mph vs. seconds
	
	/**
	 * Constructor
	 */
	public GraphDataBean() {
		time = new ArrayList<String>();
		packPowerVsTime = new ArrayList<Double>();
		packCapacityVsTime = new ArrayList<Double>();
		mphVsTime = new ArrayList<Integer>();
		systemVoltageVsTime = new ArrayList<Double>();

	}
	
	public List<String> getTime() {
		return time;
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
	
}
