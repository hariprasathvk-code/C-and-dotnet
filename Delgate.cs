using System;
namespace Delegates
{
    class program
    {
        public delegate int DeleName(int x, int y);

        public static int add(int a, int b) => a + b;
        public static int sub(int a, int b) => a - b;
        public static int mul(int a, int b) => a * b;


        static void Main(string[] args)
        {
            DeleName d1 = add;
            DeleName d2 = sub;
            DeleName d3 = mul;
            Console.WriteLine(d1(5, 5));
            Console.WriteLine(d2(5, 5));
            Console.WriteLine(d3(5, 5));

        }
    }
}
