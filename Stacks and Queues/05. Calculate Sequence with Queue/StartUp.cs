using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _05.Calculate_Sequence_with_Queue
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var result = new Queue<long>();

            long number = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(number);

            while (result.Count < 50)
            {
                long calc = queue.Peek() + 1;
                queue.Enqueue(calc);

                calc = (2 * queue.Peek()) + 1;
                queue.Enqueue(calc);

                calc = queue.Peek() + 2;
                queue.Enqueue(calc);

                result.Enqueue(queue.Dequeue());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
