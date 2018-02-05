using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cubic_Assault
{
    public class StartUp
    {
        public const long oneMillion = 1000000;
        public static void Main()
        {
            var statistics = new Dictionary<string, Dictionary<string, long>>();

            string input = String.Empty;

            while ((input = Console.ReadLine().Trim()) != "Count em all")
            {
                var arg = input.Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string region = arg[0].Trim();
                string meteor = arg[1].Trim();
                long count = long.Parse(arg[2].Trim());

                if (!statistics.ContainsKey(region))
                {
                    statistics[region] = new Dictionary<string, long>()
                    {
                        { "Black", 0 },
                        { "Red", 0 },
                        { "Green", 0 }
                    };
                }

                switch (meteor)
                {
                    case "Black":
                        statistics[region]["Black"] += count;
                        break;
                    case "Red":
                        statistics[region]["Red"] += count;
                        if (statistics[region]["Red"] >= oneMillion)
                        {
                            statistics[region]["Black"] += (statistics[region]["Red"] / oneMillion);
                            statistics[region]["Red"] %= oneMillion;
                        }
                        break;
                    case "Green":
                        statistics[region]["Green"] += count;
                        if (statistics[region]["Green"] >= oneMillion)
                        {
                            statistics[region]["Red"] += (statistics[region]["Green"] / oneMillion);
                            statistics[region]["Green"] %= oneMillion;
                        }

                        if (statistics[region]["Red"] >= oneMillion)
                        {
                            statistics[region]["Black"] += (statistics[region]["Red"] / oneMillion);
                            statistics[region]["Red"] %= oneMillion;
                        }
                        break;
                }
            }

            foreach (var region in statistics
                                    .OrderByDescending(x => x.Value["Black"])
                                    .ThenBy(x => x.Key.Length)
                                    .ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);

                region.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToList()
                    .ForEach(x => Console.WriteLine($"-> {x.Key} : {x.Value}"));
            }
        }
    }
}
