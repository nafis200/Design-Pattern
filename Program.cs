
using System;

public class Logger
{

    public Logger()
    {
        Console.WriteLine("Logger create ");
    }
    public void log(string message)
    {
        Console.WriteLine(message);
    }
}
class Program
{
    public static void Main()
    {
      Logger logger = new Logger();

      logger.log("heelo world");   
    }
}