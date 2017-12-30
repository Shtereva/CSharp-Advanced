using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Basic_Queue_Operations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int amountToEnqueue = numbers[0];
            int amountToDequeue = numbers[1];
            int numExist = numbers[2];

            var integers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < amountToEnqueue; i++)
            {
                queue.Enqueue(integers[i]);
            }

            for (int i = 0; i < amountToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numExist))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(queue.Count > 0 ? queue.ToArray().Min() : 0);
            }
        }
    }
}
