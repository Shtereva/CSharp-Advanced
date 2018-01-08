using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Sum_Matrix_Elements
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

            Console.WriteLine(rows);
            Console.WriteLine(columns);

            int sum = matrix
                .Select(x => x.Sum())
                .Sum();

            Console.WriteLine(sum);
        }
    }
}
