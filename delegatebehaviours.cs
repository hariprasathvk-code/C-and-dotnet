using System;
namespace behaviour
{
	public delegate void gdel(string name);
	class G
	{
		public static void eg(string name)
		{
			Console.WriteLine("hi "+name);
		}
		public static void tg(string name)
		{
			Console.WriteLine("hi all "+name);
		}
		static void Main(string[] args)
		{
			gdel GG;
			GG = G.eg;
			GG("hari");

			GG = G.tg;
			GG("Good morning");
		}
	}
}