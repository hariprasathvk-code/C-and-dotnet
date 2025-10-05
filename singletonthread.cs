using System;

public class Logger
{
    private static Logger instance;
    private Logger()
    {
        Console.WriteLine("Logger created!");
    }
    private static readonly object _lock = new object();
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            lock (_lock)
            {
                if (instance == null) // double-check
                {
                    instance = new Logger();
                }
            }
        }
        return instance;
    }
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}
class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("First message");
        logger2.Log("Second message");

        Console.WriteLine(object.ReferenceEquals(logger1, logger2));
    }
}
