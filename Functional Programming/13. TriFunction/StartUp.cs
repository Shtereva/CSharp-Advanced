using System;
using System.Linq;

namespace _13.TriFunction
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split();

            Func<string, int> sum = (n) => n.ToCharArray().Sum(x => (int)x);
            Func<string, int, bool> isEqual = (name, calc) => sum(name) >= number;

            string result = names
                .Where(isEqual)
                .FirstOrDefault();

            Console.WriteLine(result);
        }
    }
}
