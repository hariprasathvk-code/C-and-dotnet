using System;
using System.Collections.Generic;

namespace SimpleObserver
{
    // Subscriber Interface
    interface ISubscriber
    {
        void Update(string message);
    }
    // Publisher Class
    class NewsAgency
    {
        private List<ISubscriber> subscribers = new List<ISubscriber>();

        // Add subscriber
        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        // Remove subscriber
        public void Unsubscribe(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        // Notify all subscribers
        public void Notify(string news)
        {
            Console.WriteLine($"\nBreaking News: {news}");
            foreach (var sub in subscribers)
            {
                sub.Update(news);
            }
        }
    }

    // Concrete Subscriber
    class NewsReader : ISubscriber
    {
        private string name;

        public NewsReader(string name)
        {
            this.name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{name} received: {message}");
        }
    }

    // Main Program
    class Program
    {
        static void Main()
        {
            // Create publisher
            NewsAgency agency = new NewsAgency();

            // Create subscribers
            NewsReader reader1 = new NewsReader("Hari");
            NewsReader reader2 = new NewsReader("Prasath");

            // Subscribe readers
            agency.Subscribe(reader1);
            agency.Subscribe(reader2);

            // Send news
            agency.Notify("India won the World Cup!");
            agency.Notify("New iPhone 17 released!");

            // Unsubscribe one reader
            agency.Unsubscribe(reader2);

            // Send another news
            agency.Notify("Stock Market hits record high!");
        }
    }
}
