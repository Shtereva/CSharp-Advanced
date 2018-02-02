using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Number_Wars
{
    public class StartUp
    {
        public static Queue<string> firstPlayerCards;
        public static Queue<string> secondPlayerCards;
        public const int offset = 97 - 1;
        public static Func<int, int, int> positionInAlphabet = (c, o) => c - o;
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            firstPlayerCards = new Queue<string>(input);

            input = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            secondPlayerCards = new Queue<string>(input);

            int rounds = 0;

            while (rounds < 1000000)
            {
                rounds++;

                string firstCard = firstPlayerCards.Dequeue();
                string secondCard = secondPlayerCards.Dequeue();

                if (int.Parse(firstCard.Substring(0, firstCard.Length - 1)) > int.Parse(secondCard.Substring(0, secondCard.Length - 1)))
                {
                    firstPlayerCards.Enqueue(firstCard);
                    firstPlayerCards.Enqueue(secondCard);
                }

                else if (int.Parse(firstCard.Substring(0, firstCard.Length - 1))
                         < int.Parse(secondCard.Substring(0, secondCard.Length - 1)))
                {
                    secondPlayerCards.Enqueue(secondCard);
                    secondPlayerCards.Enqueue(firstCard);
                }

                else
                {
                    var allCardsInField = new List<string>();
                    allCardsInField.Add(firstCard);
                    allCardsInField.Add(secondCard);

                    while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
                    {
                        var firstTreeCards = new List<int>();
                        var secondTreeCards = new List<int>();
                        bool haveWinner = CheckCardsLetters(rounds, firstTreeCards, secondTreeCards, allCardsInField);

                        if (haveWinner)
                        {
                            Console.WriteLine(firstPlayerCards.Count == 0 ? $"Second player wins after {rounds} turns" :
                                $"First player wins after {rounds} turns");
                            return;
                        }

                        int firstSum = firstTreeCards.Sum();
                        int secondSum = secondTreeCards.Sum();

                        if (firstSum == secondSum)
                        {
                            continue;
                        }

                        if (firstSum > secondSum)
                        {
                            AddCards(allCardsInField, firstPlayerCards);
                            break;
                        }

                        if (secondSum > firstSum)
                        {
                            AddCards(allCardsInField, secondPlayerCards);
                            break;
                        }
                    }

                    if (firstPlayerCards.Count == 0 && secondPlayerCards.Count == 0)
                    {
                        Console.WriteLine($"Draw after {rounds} turns");
                        return;
                    }
                }

                if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                {
                    Console.WriteLine(firstPlayerCards.Count == 0 ? $"Second player wins after {rounds} turns" :
                        $"First player wins after {rounds} turns");
                    return;
                }
            }

            Console.WriteLine(firstPlayerCards.Count <= secondPlayerCards.Count ? $"Second player wins after {rounds} turns" :
                $"First player wins after {rounds} turns");
        }

        private static void AddCards(List<string> allCardsInField, Queue<string> player)
        {
            var orderedCards = allCardsInField
                .OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1)))
                .ThenByDescending(x => x.Last().ToString());

            foreach (var card in orderedCards)
            {
                player.Enqueue(card);
            }
        }

        private static bool CheckCardsLetters(int rounds, List<int> firstTreeCards, List<int> secondTreeCards, List<string> allCardsInField)
        {
            for (int i = 0; i < 3; i++)
            {
                if (firstPlayerCards.Count > 0)
                {
                    allCardsInField.Add(firstPlayerCards.Peek());

                    int number = firstPlayerCards.Dequeue().Last();
                    firstTreeCards.Add(positionInAlphabet(number, offset));
                }

                else
                {
                    return true;
                }

                if (secondPlayerCards.Count > 0)
                {
                    allCardsInField.Add(secondPlayerCards.Peek());

                    int number = secondPlayerCards.Dequeue().Last();
                    secondTreeCards.Add(positionInAlphabet(number, offset));
                }

                else
                {
                     return true;
                }
            }

            return false;
        }
    }
}
