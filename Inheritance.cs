using System;
namespace Automobiles
{
    public class Vehicle
    {
        public string Brand;
        public void Start()
        {
            Console.WriteLine("Vehicle starting");
        }
    }

    public class Car : Vehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving car");
        }
    }

    public class Bike : Vehicle
    {
        public void Ride()
        {
            Console.WriteLine("Riding bike");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Brand = "Dodge";
            car.Start();
            car.Drive();

            Bike bike = new Bike();
            bike.Brand = "RE";
            bike.Start();
            bike.Ride();
        }
    }
}