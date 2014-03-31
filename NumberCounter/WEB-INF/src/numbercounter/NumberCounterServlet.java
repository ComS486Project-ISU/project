package numbercounter;

import java.io.*;

import javax.servlet.http.*;
import javax.servlet.*;

public class NumberCounterServlet extends HttpServlet
{
  private static final long serialVersionUID = 1L;
  private NumberCounter cntr= null;
  
  public void doGet(HttpServletRequest req, HttpServletResponse res)
  throws ServletException, IOException
  {
    if(cntr == null) {
      cntr = new NumberCounter();
      new Thread(cntr).start();
    }
    
    res.setContentType("text/html"); // setting the content type
    PrintWriter pw=res.getWriter(); // get the stream to write the data
    
    // writing html in the stream
    pw.println("<html><body>");
    pw.println("Hello!");
    pw.println("Counter: " + cntr.getCounter());
    pw.println("</body></html>");
    
    pw.close(); // closing the stream
  }
}
