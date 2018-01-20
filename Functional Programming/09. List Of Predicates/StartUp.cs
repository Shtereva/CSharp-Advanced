using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.List_Of_Predicates
{
    public class StartUp
    {
        public static int currentNum;
        public static void Main()
        {
            int range = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = new List<int>();
            int startRange = dividers.Max();

            for (int i = startRange; i <= range; i++)
            {
                currentNum = i;
                bool areDivisable = Check(dividers, (n) => currentNum % n == 0);

                if (areDivisable)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static bool Check(int[] dividers, Func<int, bool> func)
        {

            foreach (var divider in dividers)
            {
                if (!func(divider))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
