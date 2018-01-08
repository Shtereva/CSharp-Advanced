using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06.Target_Practice
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

            var matrix = new char[rows][];
            FillMatrix(rows, columns, matrix);

            var shotParams = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Shoot(matrix, shotParams);
            RearangeMatrix(rows, columns, matrix);

            Print(matrix);
        }

        private static void RearangeMatrix(int rows, int columns, char[][] matrix)
        {
            var temp = new string[columns];

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    temp[col] += matrix[row][col];
                }
            }

            temp = temp
                .Select(x => x.Replace(" ", string.Empty))
                .Select(x => x + new string(' ', Math.Abs(rows - x.Length)))
                .ToArray();

            for (var i = 0; i < temp.Length; i++)
            {
                for (var row = 0; row < matrix.Length; row++)
                {
                    matrix[row][i] = temp[i][temp[i].Length - 1 - row];
                }
            }
        }

        private static void Shoot(char[][] matrix, int[] shotParams)
        {
            int impactRow = shotParams[0];
            int impactColumn = shotParams[1];
            int damageRadius = shotParams[2];


            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var distance = Math.Sqrt(((row - impactRow) * (row - impactRow)) + ((col - impactColumn) * (col - impactColumn)));

                    if (distance <= damageRadius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void Print(char[][] matrix)
        {
            foreach (var c in matrix)
            {
                Console.WriteLine(string.Join("", c));
            }
        }

        private static void FillMatrix(int rows, int columns, char[][] matrix)
        {
            string snake = Console.ReadLine();
            bool moveBackwords = true;

            int snakeIndex = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                matrix[row] = new char[columns];

                if (moveBackwords)
                {
                    for (int col = columns - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake[snakeIndex];
                        snakeIndex++;

                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }

                    moveBackwords = false;
                }

                else
                {
                    for (int col = 0; col < columns; col++)
                    {
                        matrix[row][col] = snake[snakeIndex];
                        snakeIndex++;

                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }

                    moveBackwords = true;
                }

            }
        }
    }
}
