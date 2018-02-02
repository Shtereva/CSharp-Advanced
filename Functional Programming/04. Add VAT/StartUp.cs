using System;
using System.Linq;

namespace _04._Add_VAT
{
    public class StartUp
    {
        public static void Main()
        {
            Func<double, double> addVat = (x) => x + (x * 0.2);

            Console.ReadLine()
               .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .Select(addVat)
               .ToList()
               .ForEach(x => Console.WriteLine($"{x:f2}"));

        }
    }
}
