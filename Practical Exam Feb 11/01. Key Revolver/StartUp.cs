using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolver
{
    public class StartUp
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int intelligence = int.Parse(Console.ReadLine());

            int usedBullets = 0;

            int counter = 0;

            while (true)
            {
                counter++;
                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }

                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                usedBullets++;

                if (counter == barrelSize)
                {
                    if (bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        counter = 0;
                    }
                }

                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (usedBullets * bulletPrice)}");
                    break;
                }


                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}
