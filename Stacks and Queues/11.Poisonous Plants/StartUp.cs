using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Poisonous_Plants
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int plants = int.Parse(Console.ReadLine());

            var amountPesticides = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();
            stack.Push(0);

            var countDays = new int[plants];

            for (int i = 1; i < amountPesticides.Length; i++)
            {
                int maxDays = 0;
                while (stack.Count > 0 && amountPesticides[stack.Peek()] >= amountPesticides[i])
                {
                    maxDays = Math.Max(maxDays, countDays[stack.Pop()]);
                }

                if (stack.Count > 0)
                {
                    countDays[i] = maxDays + 1;
                }

                stack.Push(i);
            }


            Console.WriteLine(countDays.Max());
        }
    }
}
