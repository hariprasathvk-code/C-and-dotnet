using System;
public class MathOperations
{
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
}
public class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal sound");
}
public class Cat : Animal
{
    public override void Speak() => Console.WriteLine("Cat meows");
}
class Program
{
    static void Main()
    {
        MathOperations m = new MathOperations();
        Console.WriteLine(m.Add(2, 3));       
        Console.WriteLine(m.Add(2.5, 3.5));

        Animal a = new Cat();  
        a.Speak();             
    }
}
