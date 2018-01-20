using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Predicate_Party
{
    public static class Functions
    {
        public static List<string> StartsWith(List<string> guests, string criteria, string condition)
        {
            var list = new List<string>();

            Func<string, bool> filter = (n) => n.StartsWith(condition);

            list = guests.Where(filter).ToList();

            return list;
        }

        public static List<string> EndsWith(List<string> guests, string criteria, string condition)
        {
            var list = new List<string>();

            Func<string, bool> filter = (n) => n.EndsWith(condition);

            list = guests.Where(filter).ToList();

            return list;
        }

        public static List<string> HasLen(List<string> guests, string criteria, string condition)
        {
            var list = new List<string>();

            Func<string, bool> filter = (n) => n.Length == int.Parse(condition);

            list = guests.Where(filter).ToList();

            return list;
        }
    }
    public class StartUp
    {
        public static string command;
        public static string criteria;

        
        public static void Main()
        {
            var guests = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            string commands;

            while ((commands = Console.ReadLine()) != "Party!")
            {
                var arguments = commands.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                command = arguments[0];
                criteria = arguments[1];
                string condition = arguments[2];

                if (command == "Double")
                {
                    Double(guests, condition);
                }

                else
                {
                    Remove(guests, condition);
                }
            }

            Console.WriteLine(guests.Count > 0 ? $"{string.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }

        private static void Remove(List<string> guests, string condition)
        {
            var temp = new List<string>();

            switch (criteria)
            {
                case "StartsWith":
                    temp = Functions.StartsWith(guests, criteria, condition);

                    foreach (var el in temp)
                    {
                        guests.Remove(el);
                    }
                    break;
                case "EndsWith":
                    temp = Functions.EndsWith(guests, criteria, condition);

                    foreach (var el in temp)
                    {
                        guests.Remove(el);
                    }
                    break;
                case "Length":
                    temp = Functions.HasLen(guests, criteria, condition);

                    foreach (var el in temp)
                    {
                        guests.Remove(el);
                    }
                    break;
            }
        }

        private static void Double(List<string> guests, string condition)
        {
            switch (criteria)
            {
                case "StartsWith":
                    guests.InsertRange(0, Functions.StartsWith(guests, criteria, condition));
                    break;
                case "EndsWith":
                    guests.InsertRange(0, Functions.EndsWith(guests, criteria, condition));
                    break;
                case "Length":
                    guests.InsertRange(0, Functions.HasLen(guests, criteria, condition));
                    break;
            }
        }
    }
}
