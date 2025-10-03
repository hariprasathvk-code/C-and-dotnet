using System;
namespace Int
{
	public interface IShape
	{
		double Calculatearea();
	}

	public class Square : IShape
	{
		public double s;
		public Square(double s) {  this.s = s; }
		public double Calculatearea() {  return s*s; }
	}

	public class Triangle : IShape {
		public double b, h;
		public Triangle(double b, double h) { this.b = b; this.h = h; }
		public double Calculatearea() { return 0.5* b * h; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			Square sq = new Square(5);
			Console.WriteLine(sq.Calculatearea());

			Triangle tl = new Triangle(5, 10);
			Console.WriteLine(tl.Calculatearea());
		}

	}
}