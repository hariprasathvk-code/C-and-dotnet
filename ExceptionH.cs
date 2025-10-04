using System;
namespace ExceptionD
{
	public class InsufficientException : Exception
	{
		public InsufficientException(string message) : base(message) { }
	}
	class BankAccount
	{
		private double balance;
		public BankAccount(double initialBalance)
		{
			balance = initialBalance;
		}
		public void Withdraw(double amount)
		{
			try
			{
				if (amount > balance)
					throw new InsufficientException("Withdrawal amount exceeds balance!");

				balance -= amount;
				Console.WriteLine($"Withdrawal successful. New balance: {balance}");
			}
			catch (InsufficientException ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			finally
			{
				Console.WriteLine("Thank you for banking with us!\n");
			}
		}
	}
	class Program
	{
		static void Main()
		{
			BankAccount account = new BankAccount(1000);

			account.Withdraw(9100);  
		}
	}
}
