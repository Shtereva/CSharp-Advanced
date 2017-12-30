using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Stack_Fibonacci
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(1);
            queue.Enqueue(1);

            for (int i = 1; i <= number - 2; i++)
            {
                long firsNum = queue.Dequeue();
                long secNum = queue.Peek();
                long sum = firsNum + secNum;

                queue.Enqueue(sum);
            }

            Console.WriteLine(queue.Last());
        }
    }
}
