using System;
using System.Linq;

namespace _04.Find_Evens_or_Odds
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            Func<int, bool> filterEven = (num) => num % 2 == 0;
            Func<int, bool> filterOdd = (num) => num % 2 != 0;

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (command == "odd")
                {
                    if (filterOdd(i))
                    {
                        Console.Write(i + " ");
                    }
                }

                else
                {
                    if (filterEven(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
