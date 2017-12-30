using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Stack_Operations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int amountToPush = numbers[0];
            int amountToPop = numbers[1];
            int numExist = numbers[2];

            var integers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < amountToPush; i++)
            {
                stack.Push(integers[i]);
            }

            for (int i = 0; i < amountToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numExist))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(stack.Count > 0 ? stack.ToArray().Min() : 0);
            }
        }
    }
}
