using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Custom_Min_Function
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int> result = (num) =>
            {

                foreach (var number in numbers)
                {
                    if (number < num)
                    {
                        num = number;
                    }
                }
                return num;
            };

            Console.WriteLine(result(Int32.MaxValue));
        }
    }
}
