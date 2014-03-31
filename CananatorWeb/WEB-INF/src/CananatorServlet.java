import javax.servlet.http.*;
import javax.servlet.*;

import beans.StringBean;

import java.io.*;

public class CananatorServlet extends HttpServlet {

<<<<<<< HEAD
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
		
		//context based sharing
		synchronized(this){
			getServletContext().setAttribute("key", sBean);
		}
		
		RequestDispatcher dispatcher = 
				req.getRequestDispatcher(address);
		dispatcher.forward(req, res);
		
	}
=======
  private static final long serialVersionUID = 1L;
  
  public void doGet(HttpServletRequest req,HttpServletResponse res)
  throws ServletException,IOException
  {
  	res.setContentType("text/html"); // setting the content type
  	PrintWriter pw=res.getWriter(); // get the stream to write the data
  		
  	// writing html in the stream
  	pw.println("<html><body>");
  	pw.println("Welcome to CananatorWeb!");
  	pw.println("</body></html>");
  	
  	pw.close(); // closing the stream
  }
>>>>>>> e60ab2d30463d8d84d955bbbd3740edaf3bdca51
}

