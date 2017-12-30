using System;
using System.Collections.Generic;
using System.Linq;
namespace _05.Hot_Potato
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var kids = Console.ReadLine().Split();
            int toss = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(kids);

            while (queue.Count > 1)
            {
                for (int i = 0; i < toss - 1; i++)
                {
                    var currentKid = queue.Dequeue();
                    queue.Enqueue(currentKid);
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
