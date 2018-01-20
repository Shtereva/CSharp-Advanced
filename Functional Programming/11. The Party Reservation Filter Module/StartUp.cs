using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Predicate_Party
{
    public static class Functions
    {
        public static void StartsWith(List<string> guests, string criteria, string condition, string command, HashSet<int> indexes)
        {
            Func<string, bool> filter = (n) => n.StartsWith(condition);

            foreach (var guest in guests)
            {
                if (filter(guest))
                {
                    int index = guests.IndexOf(guest);

                    if (command == "Remove filter")
                    {

                        indexes.Remove(index);
                    }

                    if (command == "Add filter")
                    {
                        indexes.Add(index);
                    }
                }
            }
        }

        public static void EndsWith(List<string> guests, string criteria, string condition, string command, HashSet<int> indexes)
        {
            Func<string, bool> filter = (n) => n.EndsWith(condition);

            foreach (var guest in guests)
            {
                if (filter(guest))
                {
                    int index = guests.IndexOf(guest);

                    if (command == "Remove filter")
                    {

                        indexes.Remove(index);
                    }

                    if (command == "Add filter")
                    {
                        indexes.Add(index);
                    }
                }
            }
        }

        public static void HasLen(List<string> guests, string criteria, string condition, string command, HashSet<int> indexes)
        {
            Func<string, bool> filter = (n) => n.Length == int.Parse(condition);

            foreach (var guest in guests)
            {
                if (filter(guest))
                {
                    int index = guests.IndexOf(guest);

                    if (command == "Remove filter")
                    {

                        indexes.Remove(index);
                    }

                    if (command == "Add filter")
                    {
                        indexes.Add(index);
                    }
                }
            }
        }

        public static void Contains(List<string> guests, string criteria, string condition, string command, HashSet<int> indexes)
        {

            Func<string, bool> filter = (n) => n.Contains(condition);

            foreach (var guest in guests)
            {
                if (filter(guest))
                {
                    int index = guests.IndexOf(guest);

                    if (command == "Remove filter")
                    {

                        indexes.Remove(index);
                    }

                    if (command == "Add filter")
                    {
                        indexes.Add(index);
                    }
                }
            }
        }
    }
    public class StartUp
    {
        public static string command;
        public static string criteria;
        public static HashSet<int> indexes;


        public static void Main()
        {
            indexes = new HashSet<int>();
            var guests = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            string commands;

            while ((commands = Console.ReadLine()) != "Print")
            {
                var arguments = commands.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                command = arguments[0];
                criteria = arguments[1];
                string condition = arguments[2];

                switch (criteria)
                {
                    case "Starts with":
                        Functions.StartsWith(guests, criteria, condition, command, indexes);
                        break;
                    case "Ends with":
                        Functions.EndsWith(guests, criteria, condition, command, indexes);
                        break;
                    case "Length":
                        Functions.HasLen(guests, criteria, condition, command, indexes);
                        break;
                    case "Contains":
                        Functions.Contains(guests, criteria, condition, command, indexes);
                        break;
                }
            }

            for (var i = 0; i < guests.Count; i++)
            {
                if (!indexes.Contains(i))
                {
                    Console.Write(guests[i] + " ");
                }
            }

            Console.WriteLine();
        }

    }
}
