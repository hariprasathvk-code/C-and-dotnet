using System;
using System.Collections.Generic;

// Step 1: Create a class and implement IComparable<T>
public class Student : IComparable<Student>
{
	public string Name { get; set; }
	public int Age { get; set; }

	// Constructor
	public Student(string name, int age)
	{
		Name = name;
		Age = age;
	}

	// Step 2: Implement CompareTo method
	public int CompareTo(Student other)
	{
		if (other == null) return 1;

		// Custom sorting logic: Alphabetical order by Name
		return this.Name.CompareTo(other.Name);
	}

	// Optional: Override ToString() for easy display
	public override string ToString()
	{
		return $"Name: {Name}, Age: {Age}";
	}
}

// Step 3: Main Program
class Program
{
	static void Main()
	{
		// Create some Student objects
		List<Student> students = new List<Student>()
		{
			new Student("Hari", 22),
			new Student("Prasath", 25),
			new Student("Anu", 20),
			new Student("Vikram", 23)
		};

		Console.WriteLine("Before Sorting:");
		foreach (var s in students)
			Console.WriteLine(s);

		// Sort the list using IComparable
		students.Sort();

		Console.WriteLine("\nAfter Sorting (by Name):");
		foreach (var s in students)
			Console.WriteLine(s);
	}
}
