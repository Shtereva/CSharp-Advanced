using System;
using System.Linq;

namespace _02.Knights_of_Honor
{
    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> print = (name) => Console.WriteLine("Sir " + name);

            names.ForEach(print);
        }
    }
}
