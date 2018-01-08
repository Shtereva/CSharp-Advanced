using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _12.String_Matrix_Rotation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Where(char.IsDigit).ToArray();

            int rotation = int.Parse(string.Join("", input));

            int longestColumn = int.MinValue;

            var text = new List<string>();
            longestColumn = ReadLines(longestColumn, text);

            var matrix = new char[text.Count][];
            var sb = new StringBuilder();


            for (var i = 0; i < text.Count; i++)
            {
                matrix[i] = text[i].PadRight(text[i].Length + Math.Abs(text[i].Length - longestColumn)).ToCharArray();
            }

            int moves = 0;

            if (rotation > 0)
            {
                moves = rotation / 90 >= 4 ? (rotation / 90) % 4 : rotation / 90;
            }

            Rotate(longestColumn, matrix, sb, moves);

            Console.WriteLine(sb.ToString());
        }

        private static void Rotate(int longestColumn, char[][] matrix, StringBuilder sb, int moves)
        {
            if (moves == 1)
            {
                RotateByOne(longestColumn, matrix, sb);
            }

            else if (moves == 2)
            {
                matrix = matrix
                    .Reverse()
                    .Select(x => x.Reverse().ToArray())
                    .ToArray();

                AddText(matrix, sb);
            }

            else if (moves == 3)
            {

                for (int i = 0; i < longestColumn; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        sb.Append(matrix[j][longestColumn - 1 - i]);
                    }

                    if (i < longestColumn - 1)
                    {
                        sb.Append(Environment.NewLine);
                    }
                }
            }

            else
            {
                AddText(matrix, sb);
            }
        }

        private static void AddText(char[][] matrix, StringBuilder sb)
        {
            foreach (var el in matrix)
            {
                sb.AppendLine(string.Join("", el));
            }
        }

        private static void RotateByOne(int longestColumn, char[][] matrix, StringBuilder sb)
        {
            for (int i = 0; i < longestColumn; i++)
            {
                for (int j = matrix.Length - 1; j >= 0; j--)
                {
                    sb.Append(matrix[j][i]);
                }

                if (i < longestColumn - 1)
                {
                    sb.Append(Environment.NewLine);
                }
            }
        }

        private static int ReadLines(int longestColumn, List<string> text)
        {
            string lines;

            while ((lines = Console.ReadLine()) != "END")
            {
                if (lines.Length > longestColumn)
                {
                    longestColumn = lines.Length;
                }

                text.Add(lines);
            }

            return longestColumn;
        }
    }
}
