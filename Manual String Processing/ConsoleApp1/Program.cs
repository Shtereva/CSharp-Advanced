using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace _04.Palindromes
{
    class Palindromes
    {
        static void Main()
        {
            var text = Console.ReadLine().Split(",?!. ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var palindromes = new List<string>();

            foreach (var word in text)
            {
                bool isPalindrome = true;
                for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word[i] != word[word.Length - 1 - i])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome)
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ", palindromes.Distinct().OrderBy(x => x))}]");
        }
    }
}
