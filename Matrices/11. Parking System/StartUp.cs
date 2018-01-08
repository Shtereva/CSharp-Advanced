using System;
using System.Collections.Generic;
using System.Linq;
namespace _11.Parking_System
{
    public class StartUp
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];

            var parking = new int[rows][];

            int moves = 0;
            var countFreeCells = new Dictionary<int, int>();

            string lines;

            while ((lines = Console.ReadLine()) != "stop")
            {
                var args = lines
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int entryRow = args[0];

                int spotRow = args[1];
                int spotColumn = args[2];

                if (!countFreeCells.ContainsKey(spotRow))
                {
                    countFreeCells[spotRow] = columns - 1;
                }

                if (countFreeCells[spotRow] <= 0)
                {
                    Console.WriteLine($"Row {spotRow} full");
                    continue;
                }

                if (parking[spotRow] == null)
                {
                    parking[spotRow] = new int[columns].ToArray();
                }

                bool isFree = parking[spotRow][spotColumn] == 0;

                if (isFree)
                {
                    moves = Math.Abs(entryRow - spotRow) + spotColumn + 1;
                    parking[spotRow][spotColumn] = 1;

                    countFreeCells[spotRow]--;
                    Console.WriteLine(moves);
                    continue;
                }

                int leftIndex = 0;

                for (var i = spotColumn; i > 1; i--)
                {
                    if (parking[spotRow][i - 1] == 0)
                    {
                        leftIndex = i - 1;
                        break;
                    }
                }

                int rightIndex = 0;

                for (var i = spotColumn; i < parking[spotRow].Length - 1; i++)
                {
                    if (parking[spotRow][i + 1] == 0)
                    {
                        rightIndex = i + 1;
                        break;
                    }
                }

                if (Math.Abs(leftIndex - spotColumn) <= Math.Abs(rightIndex - spotColumn))
                {
                    if (leftIndex > 0)
                    {
                        parking[spotRow][leftIndex] = 1;
                        countFreeCells[spotRow]--;
                        moves = Math.Abs(entryRow - spotRow) + leftIndex + 1;
                        isFree = true;
                    }


                    if (leftIndex <= 0 && rightIndex > 0)
                    {
                        parking[spotRow][rightIndex] = 1;
                        countFreeCells[spotRow]--;
                        moves = Math.Abs(entryRow - spotRow) + rightIndex + 1;
                        isFree = true;
                    }
                }

                else
                {
                    if (rightIndex > 0)
                    {
                        parking[spotRow][rightIndex] = 1;
                        moves = Math.Abs(entryRow - spotRow) + rightIndex + 1;
                        isFree = true;
                    }
                }


                Console.WriteLine(isFree ? moves.ToString() : $"Row {spotRow} full");
            }
        }
    }
}
