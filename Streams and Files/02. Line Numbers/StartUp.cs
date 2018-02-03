using System;
using System.IO;

namespace _02._Line_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            using (var reader = new StreamReader(@"..\files\text.txt"))
            {
                using (var writer = new StreamWriter(@"..\files\mytext.txt"))
                {
                    int lineNumber = 1;
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {

                        writer.WriteLine($"Line {lineNumber}: {line}");

                        lineNumber++;
                    }
                }
            }
        }
    }
}
