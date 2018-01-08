using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.Maximal_Sum
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int columns = input[1];

            var matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int maxSum = int.MinValue;
            int rowIndex = 0;
            int columnIndex = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                              matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                              matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        rowIndex = row;
                        columnIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine(string.Join(" ", matrix[rowIndex].Skip(columnIndex).Take(3)));
            Console.WriteLine(string.Join(" ", matrix[rowIndex + 1].Skip(columnIndex).Take(3)));
            Console.WriteLine(string.Join(" ", matrix[rowIndex + 2].Skip(columnIndex).Take(3)));
        }
    }
}
