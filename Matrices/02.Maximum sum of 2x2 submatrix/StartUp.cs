using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.Maximum_sum_of_2x2_submatrix
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int columns = input[1];

            var matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int rowIndex = -1;
            int columnIndex = -1;
            int maxSum = int.MinValue;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1];

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        rowIndex = row;
                        columnIndex = col;
                    }
                }
            }

            var resultMatrix = new int[][]
            {
                new[] { matrix[rowIndex][columnIndex], matrix[rowIndex][columnIndex + 1]},
                new[] { matrix[rowIndex + 1][columnIndex], matrix[rowIndex + 1][columnIndex + 1]},
            };

            foreach (var nums in resultMatrix)
            {
                Console.WriteLine(string.Join(" ", nums));
            }

            Console.WriteLine(maxSum);
        }
    }
}
