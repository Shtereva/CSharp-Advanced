using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Inferno_III
{
    public class StartUp
    {
        public static  Stack<int> excludedNumbers;
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();

            string input = string.Empty;
            excludedNumbers = new Stack<int>();

            while ((input = Console.ReadLine()) != "Forge")
            {
                var args = input.Split(';');

                string command = args[0];
                string filter = args[1];
                long param = long.Parse(args[2]);

                if (command == "Exclude")
                {
                    switch (filter)
                    {
                        case "Sum Left":
                            SumLeft(numbers, excludedNumbers, param);
                            break;
                        case "Sum Right":
                            SumRight(numbers, excludedNumbers, param);
                            break;
                        case "Sum Left Right":
                            SumLeftRight(numbers, excludedNumbers, param);
                            break;
                    }

                }

                else
                {
                    if (excludedNumbers.Count > 0)
                    {
                        excludedNumbers.Pop();
                    }
                }
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                if (!excludedNumbers.Contains(i))
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            Console.WriteLine();
        }

        private static void SumLeftRight(List<long> numbers, Stack<int> excluded, long param)
        {
            long currentIndex = 0;
            long previousIndex = 0;
            long nextIndex = 0;

            Func<long, bool> check = (n) => currentIndex + previousIndex + nextIndex == param;

            for (var i = 0; i < numbers.Count; i++)
            {
                currentIndex = numbers[i];
                previousIndex = i - 1 < 0 ? 0 : numbers[i - 1];
                nextIndex = i + 1 >= numbers.Count ? 0 : numbers[i + 1];

                if (check(currentIndex))
                {
                    excluded.Push(i);
                }
            }
        }
        private static void SumRight(List<long> numbers, Stack<int> excluded, long param)
        {
            long currentIndex = 0;
            long nextIndex = 0;

            Func<long, bool> func = (n) => currentIndex + nextIndex == param;

            for (var i = 0; i < numbers.Count; i++)
            {
                currentIndex = numbers[i];
                nextIndex = i + 1 >= numbers.Count ? 0 : numbers[i + 1];

                if (func(currentIndex))
                {
                    excluded.Push(i);
                }
            }
        }

        private static void SumLeft(List<long> numbers, Stack<int> excluded, long param)
        {
            long currentIndex = 0;
            long previousIndex = 0;

            Func<long, bool> check = (n) => currentIndex + previousIndex == param;

            for (var i = 0; i < numbers.Count; i++)
            {
                currentIndex = numbers[i];
                previousIndex = i - 1 < 0 ? 0 : numbers[i - 1];

                if (check(currentIndex))
                {
                    excluded.Push(i);
                }
            }
        }
    }
}
