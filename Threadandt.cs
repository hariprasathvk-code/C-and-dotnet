using System;
using System.Threading;

class Program
{
    static void PrintNumbers(string threadName)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{threadName}: {i}");
            Thread.Sleep(500); // Simulate work
        }
    }

    static void Main()
    {
        // Create threads
        Thread t1 = new Thread(() => PrintNumbers("Thread 1"));
        Thread t2 = new Thread(() => PrintNumbers("Thread 2"));

        // Start threads
        t1.Start();
        t2.Start();

        // Wait for threads to finish
        t1.Join();
        t2.Join();

        Console.WriteLine("All threads completed!");
    }
}
