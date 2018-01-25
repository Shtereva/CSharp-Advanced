using System;
using System.Linq;

namespace _01.Dangerous_Floor
{
    public class StartUp
    {
        public const int rows = 8;
        public static char[][] board;
        public static void Main()
        {
            board = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                board[i] = Console.ReadLine().ToCharArray().Where(x => x != ',').ToArray();
            }

            string moves = string.Empty;

            while ((moves = Console.ReadLine()) != "END")
            {
                char piece = moves[0];
                int startRow = int.Parse(moves[1].ToString());
                int startColumn = int.Parse(moves[2].ToString());

                int finalRow = int.Parse(moves[4].ToString());
                int finalColumn = int.Parse(moves[5].ToString());

                if (board[startRow][startColumn] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                bool isMoveValid = false;
                bool isOutOfBoard = (finalRow < 0 || finalRow >= rows) || (finalColumn < 0 || finalColumn >= rows);

                bool checkFirstDiagonal = startRow - startColumn == finalRow - finalColumn;
                bool checkSecondDiagonal = startRow + startColumn == finalRow + finalColumn;

                switch (piece)
                {
                    case 'K':
                        if (Math.Abs(startRow - finalRow) <= 1 && Math.Abs(startColumn - finalColumn) <= 1)
                        {
                            isMoveValid = true;
                        }
                        break;
                    case 'R':
                        if (finalRow == startRow || finalColumn == startColumn)
                        {
                            isMoveValid = true;
                        }
                        break;
                    case 'B':
                        if (checkFirstDiagonal || checkSecondDiagonal)
                        {
                            isMoveValid = true;
                        }
                        break;
                    case 'Q':
                        if (finalRow == startRow || finalColumn == startColumn || checkFirstDiagonal || checkSecondDiagonal)
                        {
                            isMoveValid = true;
                        }
                        break;
                    case 'P':
                        if (finalColumn == startColumn && finalRow == startRow - 1)
                        {
                            isMoveValid = true;
                        }
                        break;
                }

                if (!isMoveValid)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (isOutOfBoard)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                board[startRow][startColumn] = 'x';
                board[finalRow][finalColumn] = piece;
            }

            Console.WriteLine();
        }
    }
}
