using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqd
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Department { get; set; }
		public double Salary { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Employee> emp = new List<Employee>()
			{
				new Employee{Id=1, Name="Hari", Department="Backend", Salary=60000},
				new Employee{Id=2, Name="Prasath", Department="Database/WMS", Salary=80000}
			};

			var bemp = from e in emp where e.Department == "Backend" select e;

			var ordered = from e in emp orderby e.Salary descending select e;

			var grouped = from e in emp group e by e.Department into deptGroup select deptGroup;

			var names = from e in emp select e.Name;

			Console.WriteLine("Backend Employees:");
			foreach (var e in bemp)	Console.WriteLine($"{e.Name} - {e.Salary}");

			Console.WriteLine("\nEmployees Ordered by Salary:");
			foreach (var e in ordered) Console.WriteLine($"{e.Name} - {e.Salary}");

			Console.WriteLine("\nEmployees Grouped by Department:");
			foreach (var group in grouped)
			{
				Console.WriteLine($"Department: {group.Key}");
				foreach (var e in group) Console.WriteLine($"  {e.Name}");
			}
		}
	}
}
