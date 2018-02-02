using System;

namespace _01._Regeh
{
    public class StartUp
    {
        public static void Main()
        {
            string text = @"[atdSd[asdasd<4REGEH22>asdosy]   ***oopprefs[ew<16REGEH30>rdtr]pppp555b";

            for (var i = 0; i < text.Length; i++)
            {
                Console.Write($"{ i} - {text[i]} |");
            }

            Console.WriteLine();
            Console.WriteLine(text.Length);
        }
    }
}
