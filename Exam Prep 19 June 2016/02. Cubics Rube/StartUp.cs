using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Cubics_Rube
{
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int totalUnatackedCells = size * size * size;
            long sumOfAttackedCells = 0;

            string input = String.Empty;


            while ((input = Console.ReadLine()) != "Analyze")
            {
                var integers = input
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                var cells = integers.Take(3).ToArray();
                long particles = integers[3];


                if (cells.Any(x => x < 0 || x >= size) || particles == 0)
                {
                    continue;
                }


                totalUnatackedCells--;
                sumOfAttackedCells += particles;
            }

            Console.WriteLine(sumOfAttackedCells);
            Console.WriteLine(totalUnatackedCells);
        }
    }
}
