using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._2x2_Squares_in_Matrix
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

            var matrix = new char[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            int equalSquares = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    char letter = matrix[row][col];

                    if (matrix[row][col] == letter && matrix[row][col + 1] == letter
                        && matrix[row + 1][col] == letter && matrix[row + 1][col + 1] == letter)
                    {
                        equalSquares++;
                    }
                }
            }

            Console.WriteLine(equalSquares);
        }
    }
}
