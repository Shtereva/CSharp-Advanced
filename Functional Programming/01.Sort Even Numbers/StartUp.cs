using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var result = new List<int>();

            Func<int, bool> evenNumbers = (x) => x % 2 == 0;

            foreach (var number in numbers)
            {
                if (evenNumbers(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(", ", result.OrderBy(x => x)));
        }
    }
}
