using System;
using System.IO;

namespace _01_Odd_Lines
{
    public class StartUp
    {
        public static void Main()
        {
            using (var reader = new StreamReader(@"..\files\text.txt"))
            {
                int lineNumber = 0;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;
                }
            }
        }
    }
}
