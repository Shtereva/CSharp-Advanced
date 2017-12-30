using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Truck_Tour
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<Pump>();

            int pumps = int.Parse(Console.ReadLine());
            int index = -1;

            for (int i = 0; i < pumps; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long amountPetrol = input[0];
                long distance = input[1];

                queue.Enqueue(new Pump(amountPetrol, distance));
            }

            var originalQueue = queue.ToArray();


            foreach (var pump in queue.ToArray())
            {
                if (pump.AmountPetrol >= pump.Distance)
                {
                    bool completedCircle = true;

                    var startPoint = pump;
                    long liters = 0;

                    foreach (var pomp in queue)
                    {
                        liters += pomp.AmountPetrol;

                        if (liters < pomp.Distance)
                        {
                            completedCircle = false;
                            break;
                        }

                        liters -= pomp.Distance;
                    }

                    if (completedCircle)
                    {
                        index = Array.IndexOf(originalQueue, startPoint);
                        break;
                    }
                }

                var currentPump = queue.Dequeue();
                queue.Enqueue(currentPump);
            }

            Console.WriteLine(index);
        }
    }
}
