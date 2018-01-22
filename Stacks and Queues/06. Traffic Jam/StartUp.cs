using System;
using System.Collections.Generic;

namespace _06.Traffic_Jam
{
    public class StartUp
    {
        public static void Main()
        {
            int passing = int.Parse(Console.ReadLine());

            string cars = string.Empty;
            var traffic = new Queue<string>();
            int passedCars = 0;

            while ((cars = Console.ReadLine()) != "end")
            {
                if (cars == "green")
                {
                    for (int i = 0; i < passing; i++)
                    {
                        if (traffic.Count > 0)
                        {
                            Console.WriteLine($"{traffic.Peek()} passed!");
                            traffic.Dequeue();
                            passedCars++;
                        }
                    }

                    continue;
                }
                traffic.Enqueue(cars);
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
