using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Crypto_Blockchain
{
    public class StartUp
    {
        public static void Main()
        {
            var blockchain = new StringBuilder();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                blockchain.Append(Console.ReadLine());
            }

            var matches = Regex.Matches(blockchain.ToString(), @"{.+?}|\[.+?\]");

            var result = new StringBuilder();

            foreach (Match match in matches)
            {
                var findDigits = Regex.Matches(match.Value, @"\d{3,}");
                if (findDigits.Count > 1)
                {
                    continue;
                }

                var digits = findDigits[0].Value;


                if (digits.Length % 3 == 0)
                {
                    int blockLen = match.Length;

                    int startIndex = 0;

                    while (startIndex < digits.Length)
                    {
                        result.Append((char)Math.Abs(int.Parse(digits.Substring(startIndex, 3)) - blockLen));
                        startIndex += 3;
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
