using System;
using System.Linq;

namespace _07.Predicate_For_Names
{
    public class StartUp
    {
        public static void Main()
        {
            int len = int.Parse(Console.ReadLine());

            Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(x => Filter(x, n => x.Length <= len))
                .ToList()
                .ForEach(Console.WriteLine);


        }

        private static bool Filter(string s, Func<string, bool> func)
        {
            return func(s);
        }
    }
}
