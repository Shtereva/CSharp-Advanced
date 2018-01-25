using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Treasure_Map
{
    public class StartUp
    {
        public static List<Instruction> instructions;
        public class Instruction
        {
            public string Word { get; set; }
            public string Address { get; set; }
            public string Pass { get; set; }

            public Instruction(string word, string address, string pass)
            {
                Word = word;
                Address = address;
                Pass = pass;
            }
        }
        public static void Main()
        {
            instructions = new List<Instruction>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine();
                var temp = new List<Instruction>();

                int indexSharp = line.IndexOf("#");
                int indexMark = line.IndexOf("!");

                int startIndex = indexSharp != -1 && indexMark != -1 ? Math.Min(indexSharp, indexMark)
                    : Math.Max(indexSharp, indexMark);

                if (startIndex == -1)
                {
                    continue;
                }

                startIndex = ExtractInsructions(line, temp, out indexSharp, out indexMark, startIndex);

                if (temp.Count > 0)
                {
                    var result = temp.Skip(temp.Count / 2).Take(1).FirstOrDefault();
                    instructions.Add(result);
                }

            }

            instructions
                .ForEach(x => Console.WriteLine($"Go to str. {x.Word} {x.Address}. Secret pass: {x.Pass}."));
        }

        private static int ExtractInsructions(string line, List<Instruction> temp, out int indexSharp, out int indexMark, int startIndex)
        {
            while (true)
            {
                indexSharp = line.IndexOf("#", startIndex + 1);
                indexMark = line.IndexOf("!", startIndex + 1);

                int endIndex = indexSharp != -1 && indexMark != -1 ? Math.Min(indexSharp, indexMark) : Math.Max(indexSharp, indexMark);


                if (endIndex == -1)
                {
                    break;
                }

                if ((line[startIndex] == '#' && line[endIndex] == '!') || (line[startIndex] == '!' && line[endIndex] == '#'))
                {
                    var tempLine = " " + line.Substring(startIndex + 1, endIndex - (startIndex + 1)) + " ";
                    var word = Regex.Matches(tempLine, @"[^a-zA-z0-9](?<word>[a-zA-z]{4})[^a-zA-z0-9]")
                        .Cast<Match>()
                        .FirstOrDefault();

                    var pass = Regex
                        .Matches(tempLine, @"[^\d](?<address>\d{3})-(?<pass>\d{6}|\d{4})[^\d]")
                        .Cast<Match>()
                        .LastOrDefault();

                    if (word != null && pass != null)
                    {
                        temp
                            .Add(new Instruction(word.Groups["word"].Value, pass.Groups["address"].Value, pass.Groups["pass"].Value));
                    }
                }

                startIndex = endIndex;
            }

            return startIndex;
        }
    }
}
