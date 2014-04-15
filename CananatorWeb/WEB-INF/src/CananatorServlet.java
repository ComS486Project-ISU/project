import javax.servlet.http.*;
import javax.servlet.*;

import beans.StringBean;
import beans.TelemetryDataBean;
import CananatorX.*;

import java.io.*;

public class CananatorServlet extends HttpServlet {
 
  private static final long serialVersionUID = 1L;
  private PrisumCanParser telemetryReceiver;
  private TelemetryDataBean tdBean;
  
  public void init()
{
	telemetryReceiver = new PrisumCanParser();
	tdBean = new TelemetryDataBean();
	
	//set arbituary values until testing with batterybox
	SetTestData();
	
	//connect
	//telemetryReceiver.connect("COM3");
	
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
		this.UpdateTelemetryData();
		
		//context based sharing
		synchronized(this){
			getServletContext().setAttribute("key", sBean);
			getServletContext().setAttribute("telemetryData", tdBean);
		}
		
		RequestDispatcher dispatcher = 
				req.getRequestDispatcher(address);
		dispatcher.forward(req, res);
		
	}

	private void UpdateTelemetryData()
	{
		tdBean.setEnergyConsumption((float)telemetryReceiver.solarCarState.BPS.PackPower);
		tdBean.setSolarPower((float)telemetryReceiver.solarCarState.BPS.ArrayPower);
		tdBean.setMotorPower((float)telemetryReceiver.solarCarState.BPS.MotorPower);
		
	}
	
	private void SetTestData()
	{
		telemetryReceiver.solarCarState.BPS.PackPower = 2000;
		telemetryReceiver.solarCarState.BPS.ArrayPower = 2000;
		telemetryReceiver.solarCarState.BPS.MotorPower = -3000;
		
	}
  
}

