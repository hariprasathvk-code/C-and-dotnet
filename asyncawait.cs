using System;
using System.Threading.Tasks;
namespace AsyncD
{
    class Program
    {
        static async Task<string> FetchDataAsync()
        {
            Console.WriteLine("Fetchin data");
            await Task.Delay(3000);
            return "Data retrived";
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program started");
            string result = await FetchDataAsync();
            Console.WriteLine(result);

            Console.WriteLine("Program finished.");
        }
    }
}