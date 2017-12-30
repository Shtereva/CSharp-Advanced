using System;
using System.Collections.Generic;
using System.Linq;
namespace _10.Simple_Text_Editor
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();
            string currentText = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                switch (input[0])
                {

                    case "1":
                        currentText += string.Join(" ", input.Skip(1));
                        stack.Push(currentText);
                        break;
                    case "2":
                        currentText = currentText.Substring(0, Math.Max(0, currentText.Length - int.Parse(input[1])));
                        stack.Push(currentText);
                        break;

                    case "3":
                        Console.WriteLine(currentText.Length < int.Parse(input[1])
                            ? ""
                            : currentText[int.Parse(input[1]) - 1].ToString());
                        break;
                    case "4":
                        stack.Pop();
                        currentText = stack.Count == 0 ? "" : stack.Peek();
                        break;
                }
            }
        }
    }
}
