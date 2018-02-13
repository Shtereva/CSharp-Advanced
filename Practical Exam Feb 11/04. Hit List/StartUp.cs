using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hit_List
{
    public class StartUp
    {
        public static Dictionary<string, Dictionary<string, string>> people;
        public static void Main()
        {
            int targenInfoIndex = int.Parse(Console.ReadLine());

            people = new Dictionary<string, Dictionary<string, string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                FillPeopleInfo(input);
            }


            var finalLine = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string nameToKill = finalLine[1];

            int infoIndex = people[nameToKill].Sum(p => p.Key.Length) + people[nameToKill].Sum(p => p.Value.Length);

            Console.WriteLine($"Info on {nameToKill}:");

            people[nameToKill]
                .OrderBy(p => p.Key)
                .ToList()
                .ForEach(x => Console.WriteLine($"---{x.Key}: {x.Value}"));

            Console.WriteLine($"Info index: {infoIndex}");
            Console.WriteLine(infoIndex >= targenInfoIndex ? "Proceed" : $"Need {targenInfoIndex - infoIndex} more info.");
        }

        private static void FillPeopleInfo(string input)
        {
            var args = input.Split("=;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string name = args[0];

            if (!people.ContainsKey(name))
            {
                people[name] = new Dictionary<string, string>();
            }

            foreach (var item in args.Skip(1))
            {
                var pair = item.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (!people[name].ContainsKey(pair[0]))
                {
                    people[name][pair[0]] = string.Empty;
                }

                people[name][pair[0]] = pair[1];
            }
        }
    }
}
