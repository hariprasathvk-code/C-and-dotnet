using System;

namespace FactoryPatternDemo
{
    public interface IShape
    {
        void Draw();
    }
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }
    }
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Square");
        }
    }
    public class Triangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Triangle");
        }
    }
    public static class ShapeFactory
    {
        public static IShape CreateShape(string shapeType)
        {
            switch (shapeType.ToLower())
            {
                case "circle":
                    return new Circle();
                case "square":
                    return new Square();
                case "triangle":
                    return new Triangle();
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            IShape shape1 = ShapeFactory.CreateShape("Circle");
            shape1.Draw();

            IShape shape2 = ShapeFactory.CreateShape("Square");
            shape2.Draw();

            IShape shape3 = ShapeFactory.CreateShape("Triangle");
            shape3.Draw();
        }
    }
}
