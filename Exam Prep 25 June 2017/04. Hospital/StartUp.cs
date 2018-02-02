using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    public class StartUp
    {
        public static Dictionary<string, List<HashSet<string>>> departments;
        public static Dictionary<string, SortedSet<string>> doctorsPatients;

        public static void Main()
        {
            departments = new Dictionary<string, List<HashSet<string>>>();
            doctorsPatients = new Dictionary<string, SortedSet<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Output")
            {

                var args = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string department = args[0];
                string doctor = $"{args[1]} {args[2]}";
                string patient = args[3];

                FillDepartment(department, patient);

                if (!doctorsPatients.ContainsKey(doctor))
                {
                    doctorsPatients[doctor] = new SortedSet<string>();
                }

                doctorsPatients[doctor].Add(patient);
            }

            while ((input = Console.ReadLine().Trim()) != "End")
            {
                if (doctorsPatients.ContainsKey(input))
                {
                    foreach (var patient in doctorsPatients[input])
                    {
                        Console.WriteLine(patient);
                    }
                }

                else
                {
                    var args = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    if (args.Length == 2)
                    {
                        int room = int.Parse(args[1]);

                        foreach (var patient in departments[args[0]][room - 1]
                            .OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }

                    }
                    else
                    {
                        foreach (var room in departments[args[0]])
                        {
                            foreach (var patient in room)
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }

                }
            }
        }

        private static void FillDepartment(string department, string patient)
        {
            if (!departments.ContainsKey(department))
            {
                departments[department] = new List<HashSet<string>>();
                departments[department].Add(new HashSet<string>());
            }

            if (departments[department].All(r => r.Count == 3) && departments[department].Count < 20)
            {
                departments[department].Add(new HashSet<string>());
            }

            foreach (var room in departments[department])
            {
                if (room.Count < 3)
                {
                    room.Add(patient);
                }
            }
        }
    }
}
