using System;
using System.Linq;

namespace _01.Action_Print
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
