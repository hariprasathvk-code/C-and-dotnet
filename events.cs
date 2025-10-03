using System;
using System.Threading;

namespace EventD
{
    public delegate void AlarmHandler();
    class AlarmClock
    {
        public event AlarmHandler Ring;
        public void Start()
        {
            Console.WriteLine("Alarm set");
            Thread.Sleep(3000);
            OnRing();
        }
        protected virtual void OnRing()
        {
            if (Ring!= null)
                Ring();
        }
    }
    class Program
    {
        static void Main()
        {
            AlarmClock alarmClock = new AlarmClock();
            alarmClock.Ring += () => Console.WriteLine("Wake up!");
            alarmClock.Ring += () => Console.WriteLine("Alarm ringing!");

            alarmClock.Start();
        }
    }
}