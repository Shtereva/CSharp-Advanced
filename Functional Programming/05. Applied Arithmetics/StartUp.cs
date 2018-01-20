using System;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                Func<long, long> manipulate = null;

                switch (command)
                {
                    case "add":
                        manipulate = (n) => n + 1;
                        break;
                    case "multiply":
                        manipulate = (n) => n * 2;
                        break;
                    case "subtract":
                        manipulate = (n) => n - 1;
                        break;
                    case "print":
                        numbers.ForEach(n => Console.Write(n + " "));
                        Console.WriteLine();
                        continue;
                }

                numbers = numbers
                    .Select(manipulate)
                    .ToList();
            }
        }
    }
}
