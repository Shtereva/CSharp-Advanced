using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05._Filter_By_Age
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string name = line[0];
                int ages = int.Parse(line[1]);

                if (!people.ContainsKey(name))
                {
                    people[name] = 0;
                }

                people[name] = ages;
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine().Split();

            Func<int,int, bool> func;

            if (condition == "older")
            {
                func = (x, y) => x >= y;
            }

            else
            {
                func = (x, y) => x < y;
            }

            if (format.Length == 2)
            {
                people
                    .Where(x => func(x.Value, age))
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x.Key} - {x.Value}"));

            }

            else if (format[0] == "name")
            {
                people
                    .Where(x => func(x.Value, age))
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x.Key}"));
            }

            else
            {
                people
                    .Where(x => func(x.Value, age))
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x.Value}"));
            }
        }
    }
}
