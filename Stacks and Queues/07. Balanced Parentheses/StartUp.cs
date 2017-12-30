using System;
using System.Collections.Generic;

namespace _07.Balanced_Parentheses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim().ToCharArray();

            if (input.Length % 2 != 0 && input[input.Length / 2] != ' ')
            {
                Console.WriteLine("NO");
                return;
            }

            var stack = new Stack<char>(input);
            var queue = new Queue<char>(input);

            for (int i = 0; i < input.Length / 2; i++)
            {
                switch (queue.Peek())
                {
                    case '{':
                        if (queue.ToArray()[1] == '}')
                        {
                            queue.Dequeue();
                            queue.Dequeue();
                            break;
                        }

                        if (stack.Peek() != '}')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case '[':
                        if (queue.ToArray()[1] == ']')
                        {
                            queue.Dequeue();
                            queue.Dequeue();
                            break;
                        }

                        if (stack.Peek() != ']')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case '(':
                        if (queue.ToArray()[1] == ')')
                        {
                            queue.Dequeue();
                            queue.Dequeue();
                            break;
                        }

                        if (stack.Peek() != ')')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ' ':
                        if (stack.Peek() != ' ')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                }

                queue.Dequeue();
                stack.Pop();
            }

            Console.WriteLine("YES");
        }
    }
}
