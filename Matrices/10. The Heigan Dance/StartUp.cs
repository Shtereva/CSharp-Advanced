using System;
using System.Collections.Generic;
using System.Linq;
namespace _10.The_Heigan_Dance
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double playerDamage = double.Parse(Console.ReadLine());

            var chamber = new string[15][];
            chamber = chamber
                .Select(x => new string[15])
                .Select(x => x.Select(e => ".").ToArray())
                .ToArray();

            double playerLife = 18500;
            double enemyLife = 3000000;
            double nextTurnDamage = 0;
            string killedBy = string.Empty;

            int startRow = 7;
            int startColumn = 7;

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string spell = input[0];
                int targetRow = int.Parse(input[1]);
                int targetColumn = int.Parse(input[2]);

                enemyLife -= playerDamage;

                if (nextTurnDamage > 0)
                {
                    playerLife -= nextTurnDamage;
                    nextTurnDamage = 0;
                }

                if (playerLife <= 0)
                {
                    killedBy = "Plague Cloud";
                    break;
                }

                if (enemyLife <= 0)
                {
                    break;
                }

                var temp = new List<CloudRange>();

                Hit(temp, targetRow, targetColumn);

                if (temp.Any(x => x.Row == startRow && x.Column == startColumn))
                {
                    bool tryToMove = TryToMove(ref startRow, ref startColumn, temp);

                    if (!tryToMove)
                    {
                        if (spell == "Cloud")
                        {
                            playerLife -= 3500;
                            nextTurnDamage = 3500;
                        }

                        else
                        {
                            playerLife -= 6000;
                        }

                        if (playerLife <= 0)
                        {
                            killedBy = spell == "Cloud" ? "Plague " + spell : spell;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(enemyLife <= 0 ? "Heigan: Defeated!" : $"Heigan: {enemyLife:f2}");
            Console.WriteLine(playerLife <= 0 ? $"Player: Killed by {killedBy}" : $"Player: {playerLife}");
            Console.WriteLine($"Final position: {startRow}, {startColumn}");
        }

        private static bool TryToMove(ref int startRow, ref int startColumn, List<CloudRange> temp)
        {
            int row = startRow;
            int col = startColumn;

            if (!temp.Any(x => x.Row == row - 1 && x.Column == col) && startRow - 1 >= 0)
            {
                startRow -= 1;
                return true;

            }

            if (!temp.Any(x => x.Row == row && x.Column == col + 1) && startColumn + 1 <= 14)
            {
                startColumn += 1;
                return true;
            }

            if (!temp.Any(x => x.Row == row + 1 && x.Column == col) && startRow + 1 <= 14)
            {
                startRow += 1;
                return true;
            }

            if (!temp.Any(x => x.Row == row && x.Column == col - 1) && startColumn - 1 >= 0)
            {
                startColumn -= 1;
                return true;
            }

            return false;
        }

        private static void Hit(List<CloudRange> temp, int targetRow, int targetColumn)
        {

            temp.Add(new CloudRange(targetRow, targetColumn));

            if (targetRow - 1 >= 0)
            {
                MoveUp(targetRow, targetColumn, temp);
            }

            if (targetRow + 1 <= 14)
            {
                MoveDown(targetRow, targetColumn, temp);
            }
        }
        private static void MoveDown(int targetRow, int targetColumn, List<CloudRange> temp)
        {
            temp.Add(new CloudRange(targetRow + 1, targetColumn));

            if (targetColumn - 1 >= 0)
            {
                temp.Add(new CloudRange(targetRow + 1, targetColumn - 1));

                if (!temp.Any(x => x.Column == targetColumn - 1 && x.Row == targetRow))
                {
                    temp.Add(new CloudRange(targetRow, targetColumn - 1));
                }
            }

            if (targetColumn + 1 <= 14)
            {
                temp.Add(new CloudRange(targetRow + 1, targetColumn + 1));

                if (!temp.Any(x => x.Column == targetColumn + 1 && x.Row == targetRow))
                {
                    temp.Add(new CloudRange(targetRow, targetColumn + 1));
                }
            }
        }

        private static void MoveUp(int targetRow, int targetColumn, List<CloudRange> temp)
        {
            temp.Add(new CloudRange(targetRow - 1, targetColumn));

            if (targetColumn - 1 >= 0)
            {
                temp.Add(new CloudRange(targetRow - 1, targetColumn - 1));

                temp.Add(new CloudRange(targetRow, targetColumn - 1));
            }

            if (targetColumn + 1 <= 14)
            {
                temp.Add(new CloudRange(targetRow - 1, targetColumn + 1));

                temp.Add(new CloudRange(targetRow, targetColumn + 1));
            }
        }

        public class CloudRange
        {
            public int Row { get; set; }
            public int Column { get; set; }

            public CloudRange(int row, int column)
            {
                this.Row = row;
                this.Column = column;
            }
        }
    }
}
