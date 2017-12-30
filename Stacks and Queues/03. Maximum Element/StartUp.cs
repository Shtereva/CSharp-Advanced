using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_Element
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxNumbers = new Stack<int>();

            int maxElement = 0;

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Trim();

                switch (input[0])
                {
                    case '1':
                        var num = input
                            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .Select(int.Parse)
                            .ToArray();

                        stack.Push(num[0]);


                        if (maxElement <= num[0])
                        {
                            maxElement = num[0];

                            maxNumbers.Push(maxElement);
                        }

                        break;
                    case '2':
                        int elementAtTop = stack.Pop();
                        int currentMaxNumber = maxNumbers.Peek();

                        if (elementAtTop == currentMaxNumber)
                        {
                            maxNumbers.Pop();

                            if (maxNumbers.Count > 0)
                            {
                                maxElement = maxNumbers.Peek();
                            }

                            else
                            {
                                maxElement = 0;
                            }
                        }
                        break;
                    case '3':
                        Console.WriteLine(maxElement);
                        break;
                }
            }
        }
    }
}
