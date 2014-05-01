import javax.servlet.http.*;
import javax.servlet.*;

import beans.GraphDataBean;
import beans.StringBean;
import beans.TelemetryDataBean;
import CananatorX.*;

import java.io.*;

public class CananatorServlet extends HttpServlet {
 
  private static final long serialVersionUID = 1L;
  private PrisumCanParser telemetryReceiver;
  private CananatorDataSimulator graphDataPolling;
  
  public void init()
{
	 
	telemetryReceiver = new PrisumCanParser();
	graphDataPolling = new CananatorDataSimulator(telemetryReceiver);
	graphDataPolling.startThread();
	
	//set arbituary values until testing with batterybox
	//SetTestData();
	
	//connect
	telemetryReceiver.connect("COM3");
	
	//telemetry has a lot of unused properties atm
	// only use .PrisumSolarCarState
}
public void doGet(HttpServletRequest req,HttpServletResponse res)
throws ServletException,IOException
	{
//		res.setContentType("text/html");//setting the content type
//		PrintWriter pw=res.getWriter();//get the stream to write the data
//		
//		//writing html in the stream
//		pw.println("<html><body>");
//		pw.println("Welcome to CananatorWeb!");
//		pw.println("</body></html>");
//		
//		pw.close();//closing the stream
//		
//		
//		//do business logic and get data
//		String operation = req.getParameter("operation");
//		if(operation == null)
//		{
//			operation = "unknown";
//		}
		String address = "/JSP/Cananator.jsp";
//		if(operation.equals("order"))
//		{
//			address = "/JSP/Order.jsp";
//		}
//		else if(operation.equals("cancel"))
//		{
//			address = "/JSP/Cancel.jsp";
//		}
//		else 
//		{
//			address = "/JSP/UnknownOperation.jsp";
//		}
//		
		
		// JSP 2.0 -> ${key.someProperty}
		
		StringBean sBean = new StringBean();
		sBean.setMesage("Data1, Data2, Data3");
		
		//session based sharing
		//HttpSession session = req.getSession();
		//session.setAttribute("key", sBean);
		
		//update telemetry data
		
		//context based sharing
		synchronized(this){
			getServletContext().setAttribute("key", sBean);
			getServletContext().setAttribute("telemetryData", telemetryReceiver.solarCarState);
			getServletContext().setAttribute("graphData", graphDataPolling.graphData);
		}
		
		RequestDispatcher dispatcher = 
				req.getRequestDispatcher(address);
		dispatcher.forward(req, res);
		
	}

	private void SetTestData()
	{
		telemetryReceiver.solarCarState.setPackPower(1000);
		telemetryReceiver.solarCarState.setMPH(50);
		telemetryReceiver.solarCarState.setArrayPower(2000);
		telemetryReceiver.solarCarState.setMotorPower(3000);
		telemetryReceiver.solarCarState.setCockpitTemp(70);
		telemetryReceiver.solarCarState.setStateOfCharge(50);
		telemetryReceiver.solarCarState.setPackCurrent(100);
		telemetryReceiver.solarCarState.setArrayCurrent(200);
		telemetryReceiver.solarCarState.setMotorCurrent(300);
		telemetryReceiver.solarCarState.setAuxPackVoltage(40);
		telemetryReceiver.solarCarState.setTwelveVoltAuxVoltage(30);
		telemetryReceiver.solarCarState.setTwelveVoltMainVoltage(40);
		telemetryReceiver.solarCarState.setFiveVoltVoltage(20);
		telemetryReceiver.solarCarState.setBatteryModuleVoltage(1, 32.3);
		telemetryReceiver.solarCarState.setBatteryModuleError(0, PrisumSolarCarState.BatteryModuleError.ModuleDisconnectedFault, true);
	

	}
  
}

