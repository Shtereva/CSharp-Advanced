using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Cubic_Messages
{
    public class StartUp
    {
        public static void Main()
        {
            string line = String.Empty;
            var verificationCode = new StringBuilder();

            while ((line = Console.ReadLine()) != "Over!")
            {
                int messageLen = int.Parse(Console.ReadLine());

                var match = Regex.Match(line, @"^(?<digits>\d+)(?<message>[a-zA-Z]{" + $"{messageLen}" + @"})(?<afterMsg>.*)");

                if (match.Success && !match.Groups["afterMsg"].Value.Any(char.IsLetter))
                {

                    var digits = match.Groups["digits"].Value.ToArray();
                    var afterDigits = match.Groups["afterMsg"].Value.Where(char.IsDigit).ToArray();

                    string message = match.Groups["message"].Value;
                    verificationCode.Append($"{message} == ");

                    foreach (var digit in digits)
                    {
                        int index = int.Parse(digit.ToString());

                        if (index < 0 || index >= messageLen)
                        {
                            verificationCode.Append(" ");
                            continue;
                        }
                        verificationCode.Append(message[index]);
                    }

                    if (afterDigits.Length > 0)
                    {
                        foreach (var digit in afterDigits)
                        {
                            int index = int.Parse(digit.ToString());

                            if (index < 0 || index >= messageLen)
                            {
                                verificationCode.Append(" ");
                                continue;
                            }

                            verificationCode.Append(message[index]);
                        }
                    }

                    verificationCode.AppendLine();
                }
            }

            Console.Write(verificationCode);
        }
    }
}
