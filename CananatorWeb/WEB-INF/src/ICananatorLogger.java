
public interface ICananatorLogger {
	
	/**
	 * Outputs data to a CSV file - easy to read from a computer's perspective
	 */
	public void outputCSV();
	
	/**
	 * Outputs data to a .log file - easy to read from a human's perspective
	 */
	public void outputLog();
}
