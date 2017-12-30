using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.Matching_Brackets
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            var stack = new Stack<int>();

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int currentIndex = i;

                    int len = (currentIndex - startIndex) + 1;
                    var result = input.Skip(startIndex).Take(len).ToArray();

                    Console.WriteLine(string.Join("", result));
                }
            }
        }
    }
}
