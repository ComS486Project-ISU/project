package CananatorX;

import java.util.ArrayDeque;
import java.util.Deque;

public class TrackedValue {

	private int runningAvgSize = 10;
	
	private int count = 0;
	private double val;
	private double sum = 0;
	private double min = 0;
	private double max = 0;
	private double avg = 0; // total average
	private double movAvg = 0; // moving average
	private Deque<Double> deque = new ArrayDeque<Double>();
	/**
	 * Automatically updates averages
	 * @param val
	 */
	public void setNewValue(double val)
	{
		this.val = val;
		count ++;
		sum += val;
		
		avg = sum / count;
		deque.add(val);
		
		if(deque.size() > runningAvgSize)
		{
			deque.removeLast();
		}
		
		double movSum = 0;
		
		//compute moving average
		for(double v : deque)
		{
			movSum += v;
		}
		
		movAvg = movSum/runningAvgSize;
		
		//check min/max
		
		if(val > max || count == 1)
		{
			max = val;
		}
		if(val < min || count == 1)
		{
			min = val;
		}
	}
	
	public double getMovingAverage()
	{
		return movAvg;
	}
	
	public double getTotalAverage()
	{
		return movAvg;
	}
	public double getMin()
	{
		return min;
	}
	public double getMax()
	{
		return max;
	}
	public double getValue()
	{
		return val;
	}

}
