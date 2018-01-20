using System;
using System.Linq;

namespace _06.Reverse_And_Exclude
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            numbers = numbers
                .Where(x => !Divide(x, n => x % divider == 0))
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }

        public static bool Divide(int number, Func<int, bool> isDevisible)
        {
            return isDevisible(number);
        }
    }
}
