using System;
using System.Collections.Generic;
using System.Linq;
using  System.Numerics;

namespace _04.Pascal_Triangle
{
    public class StarUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var jaggedArrow = new BigInteger[lines][];
            jaggedArrow[0] = new BigInteger[1]{ 1 };

            for (int row = 1; row < jaggedArrow.Length; row++)
            {
                jaggedArrow[row] = new BigInteger[row + 1];
                jaggedArrow[row][0] = 1;

                for (int sub = 1; sub < jaggedArrow[row].Length; sub++)
                {
                    BigInteger rowFactoiial = Factorial_Recursion(row);
                    BigInteger columnFactorial = Factorial_Recursion(sub);
                    BigInteger substractFactorial = Factorial_Recursion(row - sub);
                    BigInteger columnResult = rowFactoiial / (columnFactorial * substractFactorial);

                    jaggedArrow[row][sub] = columnResult;
                }
            }

            foreach (var nums in jaggedArrow)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }

        private static BigInteger Factorial_Recursion(BigInteger number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return number * Factorial_Recursion(number - 1);
        }
    }
}
