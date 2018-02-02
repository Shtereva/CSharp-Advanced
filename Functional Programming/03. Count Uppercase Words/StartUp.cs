using System;

namespace _03._Count_Uppercase_Words
{
    public class StartUp
    {
        public static void Main()
        {
            Func<string, bool> upperLetters = (x) => char.IsUpper(x[0]);

            var words = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (upperLetters(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
