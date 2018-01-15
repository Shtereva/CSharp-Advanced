using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Formatting_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(" \t\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int num1 = int.Parse(input[0]);
            decimal num2 = decimal.Parse(input[1]);
            decimal num3 = decimal.Parse(input[2]);

            string hex = $"{num1:X}";
            string binary = Convert.ToString(num1, 2);
            string precision = $"{num2:f2}";
            string precision2 = $"{num3:f3}";

            if (precision.Length > 10)
            {
                precision = precision.Substring(0, 10);
            }

            if (precision2.Length > 10)
            {
                precision2 = precision2.Substring(0, 10);
            }

            if (binary.Length > 10)
            {
                binary = binary.Substring(0, 10);
            }

            Console.WriteLine($"|{hex.PadRight(10)}|{binary.PadLeft(10, '0')}|{precision.PadLeft(10)}|{precision2.PadRight(10)}|");
        }
    }
}
