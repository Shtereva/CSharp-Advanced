using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var stack = new Stack<int>();

            var numbers = new Queue<int>();
            ExtractNumbers(input, stack, numbers);

            string result = String.Empty;
            int sumOfPreviousIndexes = 0;

            while (numbers.Count > 0)
            {
                sumOfPreviousIndexes += numbers.Dequeue();
                result += input[sumOfPreviousIndexes % input.Length];
            }

            Console.WriteLine(result);
        }

        private static void ExtractNumbers(string input, Stack<int> stack, Queue<int> numbers)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[')
                {
                    stack.Push(i);
                }

                if (input[i] == ']' && stack.Count > 0)
                {
                    int startIndex = stack.Pop();
                    string text = input.Substring(startIndex + 1, i - (startIndex + 1));

                    var match = Regex.Match(text, @".+?<(\d+)REGEH(\d+)>.+?");

                    if (match.Success)
                    {
                        numbers.Enqueue(int.Parse(match.Groups[1].Value));
                        numbers.Enqueue(int.Parse(match.Groups[2].Value));
                    }
                }
            }
        }
    }
}
