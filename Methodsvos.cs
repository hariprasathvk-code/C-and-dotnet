using System;
namespace Poly
{
    public class Football
    {
        public virtual void Game()
        {
            Console.WriteLine("Playing Football");
        }
    }
    public class Teams : Football
    {
        public override void Game()
        {
            Console.WriteLine("there are 5 teams");
        }
    }
    public class Players : Football {
        public sealed override void Game()
        {
            Console.WriteLine("In a team there are 11 players + 7 subs");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Football myobj = new Football();
            myobj.Game();

            Teams myobj2 = new Teams();
            myobj2.Game();

            Players myobj3 = new Players();
            myobj3.Game();
        }
    }
}