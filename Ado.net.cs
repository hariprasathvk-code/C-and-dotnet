using System;
using System.Data.SqlClient;

namespace AdoNetCrudD
{
    class Program
    {
        static string connectionString = "Data Source=PSILENL156;Initial Catalog=EmployeeDB;Integrated Security=True";
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n Employee CRUD Menu ");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option (1-5): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        GetAllEmployees();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
        static void AddEmployee()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (Name, Department, Salary) VALUES (@Name, @Department, @Salary)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Department", dept);
                cmd.Parameters.AddWithValue("@Salary", salary);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("\n Employee Added Successfully!");
            }
        }
        static void GetAllEmployees()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n Employee List ");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Dept: {reader["Department"]}, Salary: {reader["Salary"]}");
                }

                con.Close();
            }
        }
        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Department: ");
            string dept = Console.ReadLine();

            Console.Write("Enter New Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Employees SET Name=@Name, Department=@Department, Salary=@Salary WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Department", dept);
                cmd.Parameters.AddWithValue("@Salary", salary);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                if (rows > 0)
                    Console.WriteLine("\n Employee Updated Successfully!");
                else
                    Console.WriteLine("\n Employee ID not found!");
            }
        }
        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                if (rows > 0)
                    Console.WriteLine("\n Employee Deleted Successfully!");
                else
                    Console.WriteLine("\n Employee ID not found!");
            }
        }
    }
}
