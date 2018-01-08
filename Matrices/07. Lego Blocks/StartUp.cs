using System;
using System.Collections.Generic;
using System.Linq;
namespace _07.Lego_Blocks
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var firstBlock = new int[rows][];
            var secondBlock = new int[rows][];
            int count = 0;
            count = FillBlocks(rows, firstBlock, secondBlock, count);

            var resultBlock = new int[rows][];

            for (var i = 0; i < resultBlock.Length; i++)
            {
                resultBlock[i] = firstBlock[i].Concat(secondBlock[i]).ToArray();

                if (i > 0 && resultBlock[i].Length != resultBlock[i - 1].Length)
                {
                    Console.WriteLine($"The total number of cells is: {count}");
                    return;
                }
            }

            foreach (var el in resultBlock)
            {
                Console.WriteLine($"[{string.Join(", ", el)}]");
            }
        }

        private static int FillBlocks(int rows, int[][] firstBlock, int[][] secondBlock, int count)
        {
            for (int i = 0; i < rows * 2; i++)
            {
                var arr = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                count += arr.Length;

                if (i <= rows - 1)
                {
                    firstBlock[i] = arr;
                }

                else
                {
                    secondBlock[i % rows] = arr.Reverse().ToArray();
                }
            }

            return count;
        }
    }
}
