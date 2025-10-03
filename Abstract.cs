using System;
namespace Abs
{
	public abstract class Shape{
		public abstract double CalculateArea();
	}

	public class Circle : Shape
	{
		public double r;
		public Circle(double r)
		{
			this.r = r;
		} 
		public override double CalculateArea()
		{
			return Math.PI * r * r;
		}
	}

	public class Rectangle : Shape
	{
		public double W, H;
		public Rectangle(double w, double h)
		{
			this.W = w;
			this.H = h;
		}
		public override double CalculateArea()
		{
			return W * H;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Circle c=new Circle(5);
			Console.WriteLine(c.CalculateArea());

			Rectangle re=new Rectangle(5,5); 
			Console.WriteLine(re.CalculateArea());
		}
	}
}