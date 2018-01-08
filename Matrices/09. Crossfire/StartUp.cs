using System;
using System.Collections.Generic;
using System.Linq;
namespace _09.Crossfire
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];

            var matrix = new int[rows][];

            FillMatrix(columns, matrix);

            string command;

            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                var arg = command
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long targetRow = arg[0];
                long targetColumn = arg[1];
                long radius = arg[2];

                int maxColLen = matrix.Max(x => x.Length);
                long cycles = radius > Math.Max(matrix.Length, maxColLen) ? Math.Max(matrix.Length, maxColLen) % radius : radius;

                if ((targetRow < 0 || targetRow > matrix.Length - 1)
                    && (targetColumn < 0 || targetColumn > maxColLen))
                {
                    continue;
                }

                bool down = false;
                bool right = false;

                CalculateOutsidedRows(matrix, ref targetRow, targetColumn, radius, ref cycles, maxColLen, ref down);

                CalculateOutsidedColumns(matrix, targetRow, ref targetColumn, radius, ref cycles, ref right);

                Nuke(matrix, targetRow, targetColumn, cycles, down, right);

                matrix = matrix
                    .Select(x => x.Where(e => e != 0).ToArray())
                    .Where(x => x.Length > 0)
                    .ToArray();

            }

            foreach (var element in matrix)
            {
                Console.WriteLine(string.Join(" ", element));
            }
        }

        private static void CalculateOutsidedColumns(int[][] matrix, long targetRow, ref long targetColumn, long radius, ref long cycles, ref bool right)
        {
            if ((targetRow >= 0 && targetRow <= matrix.Length - 1)
                                && (targetColumn < 0 || targetColumn > matrix[targetRow].Length - 1))
            {
                long damage = long.MinValue;

                if (targetColumn < 0)
                {
                    damage = targetColumn + radius;

                    if (damage >= 0)
                    {
                        targetColumn = 0;
                        cycles = Math.Min(damage, matrix[targetRow].Length - 1);
                    }

                    else
                    {
                        cycles = -1;
                    }
                }

                else
                {
                    damage = targetColumn - radius;

                    if (damage <= matrix[targetRow].Length - 1)
                    {
                        targetColumn = Math.Max(0, damage);
                        cycles = matrix[targetRow].Length - targetColumn;
                    }

                    else
                    {
                        cycles = -1;
                    }
                }

                right = true;
            }
        }

        private static void CalculateOutsidedRows(int[][] matrix, ref long targetRow,
            long targetColumn, long radius, ref long cycles, int maxColLen, ref bool down)
        {
            if ((targetRow < 0 || targetRow > matrix.Length - 1)
                                && (targetColumn >= 0 && targetColumn <= maxColLen))
            {
                long damage = long.MinValue;

                if (targetRow < 0)
                {
                    damage = targetRow + radius;

                    if (damage >= 0)
                    {
                        targetRow = 0;
                        cycles = Math.Min(damage, matrix.Length - 1);
                    }

                    else
                    {
                        cycles = -1;
                    }
                }

                else
                {
                    damage = targetRow - radius;

                    if (damage <= matrix.Length - 1)
                    {
                        targetRow = Math.Max(0, damage);
                        cycles = matrix.Length - targetRow;
                    }

                    else
                    {
                        cycles = -1;
                    }
                }

                down = true;
            }
        }

        private static void Nuke(int[][] matrix, long targetRow, long targetColumn, long cycles, bool down, bool right)
        {
            

            for (int i = 0; i <= cycles; i++)
            {

                if (targetRow - i >= 0 && matrix[targetRow - i].Length - 1 >= targetColumn && !down && !right)
                {
                    matrix[targetRow - i][targetColumn] = 0;
                }

                if (targetRow + i <= matrix.Length - 1 && matrix[targetRow + i].Length - 1 >= targetColumn && !right)
                {
                    matrix[targetRow + i][targetColumn] = 0;
                }

                if (targetColumn - i >= 0 && !down && !right)
                {
                    matrix[targetRow][targetColumn - i] = 0;
                }

                if (targetColumn + i <= matrix[targetRow].Length - 1 && !down)
                {
                    matrix[targetRow][targetColumn + i] = 0;
                }
            }
        }

        private static void FillMatrix(int columns, int[][] matrix)
        {
            int numberToFill = 1;

            for (var row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[columns];

                for (var col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = numberToFill;
                    numberToFill++;
                }
            }
        }

    }
}
