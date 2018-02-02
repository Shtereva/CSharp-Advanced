using System;

namespace _02._Knight_Game
{
    public class StartUp
    {
        public static char[][] board;
        public static int count;
        public static int hitsPerKnight;
        public static int neededHitsToRemoveKnight;
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            board = new char[size][];
            count = 0;
            neededHitsToRemoveKnight = 8;

            for (int i = 0; i < size; i++)
            {
                board[i] = Console.ReadLine().Trim().ToCharArray();
            }

            while (neededHitsToRemoveKnight > 0)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        hitsPerKnight = 0;

                        if (board[row][col] == 'K')
                        {
                            if (row >= 2 && hitsPerKnight < neededHitsToRemoveKnight)
                            {
                                CheckUp(row, col);
                            }

                            if (row <= size - 3 && hitsPerKnight < neededHitsToRemoveKnight)
                            {
                                CheckDown(row, col);
                            }

                            if (col >= 2 && hitsPerKnight < neededHitsToRemoveKnight)
                            {
                                CheckLeft(row, col);
                            }

                            if (col <= size - 3 && hitsPerKnight < neededHitsToRemoveKnight)
                            {
                                CheckRight(row, col);
                            }

                            if (hitsPerKnight >= neededHitsToRemoveKnight)
                            {
                                board[row][col] = '0';
                                count++;
                            }
                        }
                    }
                }

                neededHitsToRemoveKnight--;
            }

            Console.WriteLine(count);
        }

        public static void CheckUp(int row, int col)
        {
            if (col - 1 >= 0 && board[row - 2][col - 1] == 'K')
            {
                hitsPerKnight++;
            }

            if (col + 1 <= board.Length - 1 && board[row - 2][col + 1] == 'K')
            {
                hitsPerKnight++;
            }
        }

        public static void CheckDown(int row, int col)
        {
            if (col - 1 >= 0 && board[row + 2][col - 1] == 'K')
            {
                hitsPerKnight++;
            }

            if (col + 1 <= board.Length - 1 && board[row + 2][col + 1] == 'K')
            {
                hitsPerKnight++;
            }
        }

        public static void CheckLeft(int row, int col)
        {
            if (row - 1 >= 0 && board[row - 1][col - 2] == 'K')
            {
                hitsPerKnight++;
            }

            if (row + 1 <= board.Length - 1 && board[row + 1][col - 2] == 'K')
            {
                hitsPerKnight++;
            }
        }

        public static void CheckRight(int row, int col)
        {
            if (row - 1 >= 0 && board[row - 1][col + 2] == 'K')
            {
                hitsPerKnight++;
            }

            if (row + 1 <= board.Length - 1 && board[row + 1][col + 2] == 'K')
            {
                hitsPerKnight++;
            }
        }
    }
}
