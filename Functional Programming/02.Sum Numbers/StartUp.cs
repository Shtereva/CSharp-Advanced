using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _02.Sum_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int, int> sum = (x, y) => x + y;

            int result = 0;

            foreach (var number in numbers)
            {
                result = sum(number, result);
            }

            Console.WriteLine(numbers.Count);
            Console.WriteLine(result);
        }
    }
}
