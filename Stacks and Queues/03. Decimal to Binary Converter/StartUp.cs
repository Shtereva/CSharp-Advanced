using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.Decimal_to_Binary_Converter
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.Write(0);
            }
            var stack = new Stack<int>();

            while (number > 0)
            {
                var reminder  = number % 2;

                stack.Push(reminder);

                number = number / 2;
            }

            foreach (var num in stack.ToArray())
            {
                Console.Write(num);
            }

            Console.WriteLine();
        }
    }
}
