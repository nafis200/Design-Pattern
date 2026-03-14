<!-- logger -->
<!-- there is wrong -->

<!-- codeforces  blogger and user work parallel but our project work single-->

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


<!-- again problem two class use -->


using System;
using System.Threading;
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
        Thread thread1 = new Thread(() =>
        {
            Logger log1 = Logger.GetInstance();
        });

        Thread thread2 = new Thread(() =>
        {
            Logger log2 = Logger.GetInstance(); 
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}


<!-- Just one object created -->


using System;
using System.Threading;
public class Logger
{
    private static Logger _instance = null;

    public static readonly object _lock = new object();

    private Logger()
    {
        Console.WriteLine("Logger create");
    }

    public static Logger GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
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
        Thread thread1 = new Thread(() =>
        {
            Logger log1 = Logger.GetInstance();
        });

        Thread thread2 = new Thread(() =>
        {
            Logger log2 = Logger.GetInstance();
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}