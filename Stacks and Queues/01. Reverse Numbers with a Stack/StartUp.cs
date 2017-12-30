using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Numbers_with_a_Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            var reversedNumbers = string.Join(" ", stack);
            Console.WriteLine(reversedNumbers);
        }
    }
}
