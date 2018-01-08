using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.Diagonal_Difference
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var matrix = new int[rows][];
            int firstSquareSum = 0;
            int secondSquareSum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                firstSquareSum += matrix[i][i];
                secondSquareSum += matrix[i][matrix[i].Length - 1 - i];
            }

            Console.WriteLine(Math.Abs(firstSquareSum - secondSquareSum));
        }
    }
}
