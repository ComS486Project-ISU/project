package numbercounter;

public class NumberCounter implements Runnable
{
  private static int counter;
  
  @Override
  public void run()
  {
    counter = 0;
    while(true) {
      ++counter;
      try {
        Thread.sleep(1000);
      }
      catch (InterruptedException e) {
        e.printStackTrace();
      }
    }
  }
  
  public int getCounter()
  {
    return counter;
  }
  
  public void setCounter(int count)
  {
    counter = count;
  }

}
