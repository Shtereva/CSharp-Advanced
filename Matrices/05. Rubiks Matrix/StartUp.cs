using System;
using System.Collections.Generic;
using System.Linq;
namespace _05.Rubiks_Matrix
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

            FillMatrix(columns, matrix);

            RotateMatrix(rows, matrix);

            RearangeMatrix(rows, columns, matrix);

        }

        private static void RearangeMatrix(int rows, int columns, int[][] matrix)
        {
            int row = 0;
            int col = 0;

            for (int i = 1; i <= rows * columns; i++)
            {
                int currentNum = matrix[row][col];

                if (currentNum == i)
                {
                    Console.WriteLine("No swap required");
                }

                else
                {
                    int swapIndexColumn = 0;
                    int swapIndexRow = 0;
                    FindIndexToSwap(matrix, i, ref swapIndexColumn, ref swapIndexRow);

                    matrix[row][col] = matrix[swapIndexRow][swapIndexColumn];
                    matrix[swapIndexRow][swapIndexColumn] = currentNum;

                    Console.WriteLine($"Swap ({row}, {col}) with ({swapIndexRow}, {swapIndexColumn})");
                }

                if (matrix[row].Length - 1 == col)
                {
                    col = 0;

                    if (matrix.Length - 1 == row)
                    {
                        row = 0;
                    }
                    else
                    {
                        row++;

                    }

                    continue;
                }

                col++;
            }
        }

        private static void FindIndexToSwap(int[][] matrix, int i, ref int swapIndexColumn, ref int swapIndexRow)
        {
            foreach (var element in matrix)
            {
                int index = Array.IndexOf(element, i);

                if (index != -1)
                {
                    swapIndexColumn = index;
                    break;
                }

                swapIndexRow++;
            }

        }

        private static void RotateMatrix(int rows, int[][] matrix)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var lines = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                int indexToMove = int.Parse(lines[0]);
                string direction = lines[1];
                int moves = int.Parse(lines[2]);

                var temp = new int[matrix[0].Length];
                var temp1 = new int[matrix.Length];

                switch (direction)
                {
                    case "up":
                        if (moves == 0)
                        {
                            continue;
                        }

                        for (var row = 0; row < matrix.Length; row++)
                        {
                            int currentNumber = matrix[row][indexToMove];
                            long index = ((long)row - moves) % matrix.Length;

                            if (index < 0)
                            {
                                index = matrix.Length + index;
                            }

                            temp1[index] = currentNumber;
                        }

                        for (var row = 0; row < matrix.Length; row++)
                        {
                            matrix[row][indexToMove] = temp1[row];
                        }
                        break;
                    case "down":
                        if (moves == 0)
                        {
                            continue;
                        }

                        for (var row = 0; row < matrix.Length; row++)
                        {
                            int currentNumber = matrix[row][indexToMove];
                            long index = ((long)row + moves) % matrix.Length;

                            temp1[index] = currentNumber;
                        }

                        for (var row = 0; row < matrix.Length; row++)
                        {
                            matrix[row][indexToMove] = temp1[row];
                        }
                        break;
                    case "left":
                        if (moves == 0)
                        {
                            continue;
                        }

                        for (var col = 0; col < matrix[indexToMove].Length; col++)
                        {
                            int currentNumber = matrix[indexToMove][col];
                            long index = ((long)col - moves) % matrix.Length;

                            if (index < 0)
                            {
                                index = matrix[0].Length + index;
                            }
                            temp[index] = currentNumber;
                        }

                        matrix[indexToMove] = temp;
                        break;
                    case "right":
                        if (moves == 0)
                        {
                            continue;
                        }

                        for (var col = 0; col < matrix[indexToMove].Length; col++)
                        {
                            int currentNumber = matrix[indexToMove][col];
                            long index = ((long)col + moves) % matrix.Length;

                            temp[index] = currentNumber;
                        }

                        matrix[indexToMove] = temp;
                        break;
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
