using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryUnitOfWorkDemo
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Salary { get; set; }
	}

	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Add(T entity);
		void Update(T entity);
		void Delete(int id);
	}

	public class EmployeeRepository : IRepository<Employee>
	{
		private readonly List<Employee> _employees = new List<Employee>();

		public IEnumerable<Employee> GetAll() => _employees;

		public Employee GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

		public void Add(Employee employee)
		{
			_employees.Add(employee);
			Console.WriteLine($"Added: {employee.Name}");
		}

		public void Update(Employee employee)
		{
			var existing = GetById(employee.Id);
			if (existing != null)
			{
				existing.Name = employee.Name;
				existing.Salary = employee.Salary;
				Console.WriteLine($"Updated: {employee.Name}");
			}
		}

		public void Delete(int id)
		{
			var emp = GetById(id);
			if (emp != null)
			{
				_employees.Remove(emp);
				Console.WriteLine($"Deleted Employee ID: {id}");
			}
		}
	}

	public class UnitOfWork
	{
		public IRepository<Employee> Employees { get; }

		public UnitOfWork()
		{
			Employees = new EmployeeRepository();
		}

		// Mimic SaveChanges (like EF)
		public void Commit()
		{
			Console.WriteLine("All changes committed successfully!\n");
		}
	}
	
	class Program
	{
		static void Main()
		{
			UnitOfWork uow = new UnitOfWork();

			Console.WriteLine("=== Repository + Unit of Work Pattern ===");

			// Add employees
			uow.Employees.Add(new Employee { Id = 1, Name = "Hari", Salary = 25000 });
			uow.Employees.Add(new Employee { Id = 2, Name = "Prasath", Salary = 30000 });
			uow.Commit();

			// View all employees
			Console.WriteLine("\nEmployees:");
			foreach (var emp in uow.Employees.GetAll())
				Console.WriteLine($"{emp.Id} - {emp.Name} - ₹{emp.Salary}");

			// Update employee
			uow.Employees.Update(new Employee { Id = 1, Name = "Hari V K", Salary = 28000 });
			uow.Commit();

			// Delete employee
			uow.Employees.Delete(2);
			uow.Commit();
		}
	}
}
