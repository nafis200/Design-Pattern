
using System;

public class Logger
{
    private static Logger _instance = null;

    private Logger()
    {
        Console.WriteLine("Logger create");
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }

        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    public static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("First message");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("Second message");

    }
}