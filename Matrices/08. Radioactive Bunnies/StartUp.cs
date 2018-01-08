using System;
using System.Collections.Generic;
using System.Linq;
namespace _08.Radioactive_Bunnies
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];

            var playGround = new char[rows][];
            int playerRow = 0;
            int playerColumn = 0;

            var lastPoppedBunnies = new Queue<int>[rows];

            FillPlayGround(rows, playGround, ref playerRow, ref playerColumn, lastPoppedBunnies);

            var commands = Console.ReadLine();

            string outcome = string.Empty;

            foreach (var command in commands)
            {
                lastPoppedBunnies = ReplicateTheBunnies(rows, columns, playGround, lastPoppedBunnies);

                Move(playGround, command, ref playerRow, ref playerColumn, ref outcome, columns, rows);

                if (outcome != string.Empty)
                {
                    foreach (var c in playGround)
                    {
                        Console.WriteLine(string.Join("", c));
                    }

                    Console.WriteLine($"{outcome}: {playerRow} {playerColumn}");
                    break;
                }
            }
        }

        private static void Move(char[][] playGround, char command, ref int playerRow, ref int playerColumn, ref string outcome
            , int columns, int rows)
        {
            switch (command)
            {
                case 'L':
                    if (playerColumn - 1 < 0)
                    {
                        outcome = "won";
                        return;
                    }

                    playerColumn -= 1;

                    if (playGround[playerRow][playerColumn] == 'B')
                    {
                        outcome = "dead";
                    }
                    break;
                case 'R':
                    if (playerColumn + 1 > columns - 1)
                    {
                        outcome = "won";
                        return;
                    }

                    playerColumn += 1;

                    if (playGround[playerRow][playerColumn] == 'B')
                    {
                        outcome = "dead";
                    }
                    break;
                case 'U':
                    if (playerRow - 1 < 0)
                    {
                        outcome = "won";
                        return;
                    }

                    playerRow -= 1;

                    if (playGround[playerRow][playerColumn] == 'B')
                    {
                        outcome = "dead";
                    }
                    break;
                case 'D':
                    if (playerRow + 1 > rows - 1)
                    {
                        outcome = "won";
                        return;
                    }

                    playerRow += 1;

                    if (playGround[playerRow][playerColumn] == 'B')
                    {
                        outcome = "dead";
                    }
                    break;
            }
        }
        private static Queue<int>[] ReplicateTheBunnies(int rows, int columns, char[][] playGround, Queue<int>[] lastPoppedBunnies)
        {
            var temp = new Queue<int>[rows];
            temp = temp.Select(x => new Queue<int>()).ToArray();

            for (var row = 0; row < lastPoppedBunnies.Length; row++)
            {

                while (lastPoppedBunnies[row].Count > 0)
                {
                    int currentIndex = lastPoppedBunnies[row].Dequeue();

                    if (row - 1 >= 0 && playGround[row - 1][currentIndex] == '.')
                    {
                        playGround[row - 1][currentIndex] = 'B';

                        temp[row - 1].Enqueue(currentIndex);
                    }

                    if (row + 1 <= rows - 1 && playGround[row + 1][currentIndex] == '.')
                    {
                        playGround[row + 1][currentIndex] = 'B';

                        temp[row + 1].Enqueue(currentIndex);
                    }

                    if (currentIndex - 1 >= 0 && playGround[row][currentIndex - 1] == '.')
                    {
                        playGround[row][currentIndex - 1] = 'B';
                        temp[row].Enqueue(currentIndex - 1);
                    }

                    if (currentIndex + 1 <= columns - 1 && playGround[row][currentIndex + 1] == '.')
                    {
                        playGround[row][currentIndex + 1] = 'B';
                        temp[row].Enqueue(currentIndex + 1);
                    }
                }
            }

            lastPoppedBunnies = temp;
            return lastPoppedBunnies;
        }

        private static void Print(char[][] playGround)
        {
            foreach (var c in playGround)
            {
                Console.WriteLine(string.Join("", c));
            }
        }

        private static void FillPlayGround(int rows, char[][] playGround, ref int playerRow, ref int playerColumn, Queue<int>[] lastPopped)
        {
            for (int i = 0; i < rows; i++)
            {
                playGround[i] = Console.ReadLine().ToCharArray();
                lastPopped[i] = new Queue<int>();

                for (var col = 0; col < playGround[i].Length; col++)
                {
                    if (playGround[i][col] == 'P')
                    {
                        playGround[i][col] = '.';
                        playerRow = i;
                        playerColumn = col;
                        continue;
                    }

                    if (playGround[i][col] == 'B')
                    {
                        lastPopped[i].Enqueue(col);
                    }
                }


            }
        }
    }
}
