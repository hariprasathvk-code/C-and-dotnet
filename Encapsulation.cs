using System;
namespace Bank
{
	public class Bankaccount

	{
		private double balance;
		public Bankaccount(double amount)
		{
			balance = amount;
		}
		public void deposit(double amount)
		{
			if (amount > 0)
			{
				balance += amount;
			}
		}
		public void withdraw(double amount)
		{
			if (amount > 0 && amount <= balance)
			{
				balance -= amount;
			}
		}
		public double Balance
		{
			get { return balance; }
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Bankaccount acc = new Bankaccount(1000);
			acc.deposit(500);
			acc.withdraw(300);

			Console.WriteLine(acc.Balance);
		}
	}
}