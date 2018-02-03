using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Word_Count
{
    public class StartUp
    {
        public static void Main()
        {
            var text = File.ReadAllText(@"..\files\text.txt");
            var splittedText = Regex.Split(text, @"\W");

            var wordsCount = new Dictionary<string, int>();

            using (var reader = new StreamReader(@"..\files\words.txt"))
            {
                string word;
                while ((word = reader.ReadLine()) != null)
                {
                    word = word.Trim();
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount[word] = splittedText.Count(x => x.Equals(word, StringComparison.CurrentCultureIgnoreCase));
                    }
                }
            }

            using (var writer = new StreamWriter(@"..\files\result.txt"))
            {
                foreach (var word in wordsCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
