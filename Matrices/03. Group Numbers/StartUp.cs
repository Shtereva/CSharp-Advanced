using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.Group_Numbers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var jaggedArray = new int[3][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = numbers.Where(n => Math.Abs(n) % 3 == row).ToArray();
            }

            foreach (var arr in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
