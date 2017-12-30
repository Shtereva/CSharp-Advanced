using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Reverse_Strings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<string>();

            foreach (var letter in input)
            {
                stack.Push(letter.ToString());
            }

            Console.WriteLine(string.Join("", stack));
        }
    }
}
