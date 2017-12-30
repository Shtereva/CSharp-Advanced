using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Simple_Calculator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Reverse();

            var stack = new Stack<string>(input);

            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string command = stack.Pop();
                int secondDigit = int.Parse(stack.Pop());

                if (command == "+")
                {
                    result += secondDigit;
                }

                if (command == "-")
                {
                    result -= secondDigit;
                }
            }

            Console.WriteLine(result);
        }
    }
}
