using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Matrix_of_Palindromes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var alphabet = new List<char>();

            for (int i = 97; i <= 122; i++)
            {
                alphabet.Add((char)i);
            }

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int columns = input[1];

            var matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[columns];

                for (int col = 0; col < columns; col++)
                {
                    matrix[row][col] = $"{alphabet[row]}{alphabet[row + col]}{alphabet[row]}";
                }
            }

            foreach (var strings in matrix)
            {
                Console.WriteLine(string.Join(" ", strings));
            }
        }
    }
}
