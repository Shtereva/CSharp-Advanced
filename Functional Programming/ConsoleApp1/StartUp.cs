using System;
using System.Linq;

namespace ConsoleApp1
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> print = (name) => Console.WriteLine(name);

            names.ForEach(print);
        }
    }
}
