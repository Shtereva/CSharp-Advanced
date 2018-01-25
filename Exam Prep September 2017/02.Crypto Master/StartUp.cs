using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Crypto_Master
{
    public class StartUp
    {
        public static List<int> sequence = new List<int>();

        public static int nextIndex;
        public static int currentIndex;

        public static int longestSequence;
        public static int sequenceCount;
        public static void Main()
        {
             sequence = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            longestSequence = 1;
            sequenceCount = sequence.Count;

            int tolalLoopCount = 0;
            currentIndex = 0;

            for (int i = 1; i <= sequenceCount; i++)
            {
                currentIndex = tolalLoopCount;

                nextIndex = i;
                FindLongestLen(nextIndex);

                if (i == sequenceCount)
                {
                    i = 0;

                    tolalLoopCount++;

                    if (tolalLoopCount == sequenceCount)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(longestSequence);
        }

        private static void FindLongestLen(int i)
        {
            int currentLen = 1;

            while (sequence[currentIndex] < sequence[(currentIndex + i) % sequenceCount])
            {
                currentLen++;
                currentIndex = (currentIndex + i) % sequenceCount;

                if (currentLen > longestSequence)
                {
                    longestSequence = currentLen;
                }
            }
        }
    }
}
