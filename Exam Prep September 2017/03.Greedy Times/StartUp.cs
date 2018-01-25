using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Greedy_Times
{
    public class Wealth
    {
        public Wealth()
        {
            this.Items = new Dictionary<string, decimal>();
        }
        public string Type { get; set; }

        public Dictionary<string, decimal> Items { get; set; }

    }
    public class StartUp
    {
        public static List<Wealth> wealth;
        public static Func<Dictionary<string, decimal>, decimal> totalSum;
        public static void Main()
        {
            ulong bagCapacity = ulong.Parse(Console.ReadLine());
            wealth = new List<Wealth>();
            var gold = new Wealth();
            var gem = new Wealth();
            var cash = new Wealth();

            totalSum = (c) => c.Sum(x => x.Value);

            string items = Console.ReadLine();
            var matches = Regex.Matches(items, @"\b(?<item>\w+)\b\s+(?<quantity>\d+)\b", RegexOptions.IgnoreCase);

            decimal currentAmount = 0;

            foreach (Match match in matches)
            {
                string item = match.Groups["item"].Value;
                decimal quantity = decimal.Parse(match.Groups["quantity"].Value);

                if (Regex.IsMatch(match.Value, @"\bGold\b\s+\d+\b", RegexOptions.IgnoreCase))
                {
                    if (currentAmount + quantity > bagCapacity)
                    {
                        break;
                    }

                    currentAmount += quantity;
                    ExtractWealth(match, "Gold", gold);
                }
                else if (Regex.IsMatch(match.Value, @"\b\w+gem\b\s+\d+\b", RegexOptions.IgnoreCase))
                {
                    if (currentAmount + quantity > bagCapacity)
                    {
                        break;
                    }

                    if (totalSum(gem.Items) + quantity <= totalSum(gold.Items))
                    {
                        currentAmount += quantity;
                        ExtractWealth(match, "Gem", gem);
                    }
                }

                else if (Regex.IsMatch(match.Value, @"\b\w{3}\b\s+\d+\b", RegexOptions.IgnoreCase))
                {
                    if (currentAmount + quantity > bagCapacity)
                    {
                        break;
                    }

                    if (totalSum(cash.Items) + quantity <= totalSum(gem.Items))
                    {
                        currentAmount += quantity;
                        ExtractWealth(match, "Cash", cash);
                    }
                }
            }

            if (gold.Items.Count > 0) wealth.Add(gold);
            if (gem.Items.Count > 0) wealth.Add(gem);
            if (cash.Items.Count > 0) wealth.Add(cash);

            foreach (var item in wealth.OrderByDescending(x => x.Type))
            {
                Console.WriteLine($"<{item.Type}> ${totalSum(item.Items)}");
                item.Items
                    .OrderByDescending(x => x.Key)
                    .ThenBy(x => x.Value)
                    .ToList()
                    .ForEach(x => Console.WriteLine($"##{x.Key} - {x.Value}"));
            }
        }



        private static void ExtractWealth(Match match, string typeName, Wealth type)
        {
            type.Type = typeName;

            if (!type.Items.ContainsKey(match.Groups["item"].Value))
            {
                type.Items[match.Groups["item"].Value] = 0;
            }

            type.Items[match.Groups["item"].Value] += decimal.Parse(match.Groups["quantity"].Value);

        }
    }
}
