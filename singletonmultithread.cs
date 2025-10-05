using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class Logger
    {
        private static Logger _instance = null;
        private static readonly object _lock = new object();

        private Logger()
        {
            Console.WriteLine("Logger Instance Created!");
        }
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
            }
            return _instance;
        }
        public void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - {message} - Instance Hash: {this.GetHashCode()}");
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Using Threads");
            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                int num = i + 1;
                threads[i] = new Thread(() =>
                {
                    Logger logger = Logger.GetInstance();
                    logger.Log($"Thread {num} logging");
                });
                threads[i].Start();
            }

            foreach (var t in threads) t.Join();

            Console.WriteLine("\nUsing Tasks");
            Task[] tasks = new Task[5];

            for (int i = 0; i < 5; i++)
            {
                int num = i + 1;
                tasks[i] = Task.Run(() =>
                {
                    Logger logger = Logger.GetInstance();
                    logger.Log($"Task {num} logging");
                });
            }

            Task.WaitAll(tasks);

            Console.WriteLine("\nAll threads and tasks used the same Logger instance.");
        }
    }
}
