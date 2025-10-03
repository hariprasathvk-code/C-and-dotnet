using System;
public class Parent
{
	public void Show()
	{
		Console.WriteLine("Parent");
	}
}
public class Child : Parent
{
	public new void Show()  // new key word hides parent
	{
		Console.WriteLine("Child");
	}
}
class Program
{
	static void Main()
	{
		Parent p = new Parent();
		p.Show(); 

		Child c = new Child();
		c.Show(); 

		Parent pc = new Child();
		pc.Show(); 
	}
}
