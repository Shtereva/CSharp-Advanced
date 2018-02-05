using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01._Cubic_Artillery
{
    public class StartUp
    {
        public class Weapon
        {
            public string Bunker { get; set; }
            public Queue<int> WeaponCapacity { get; set; }

            public Weapon(string bunker)
            {
                Bunker = bunker;
                WeaponCapacity = new Queue<int>();
            }
        }

        public static Queue<Weapon> weapons;
        public static void Main()
        {
            int bunkerCapacity = int.Parse(Console.ReadLine());

            weapons = new Queue<Weapon>();
            int currentCapacity = bunkerCapacity;

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var line = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < line.Length; i++)
                {
                    string bunker = line[i];

                    int weaponCapacity = 0;
                    bool hasParsed = int.TryParse(bunker, out weaponCapacity);

                    if (!hasParsed)
                    {
                        var weapon = new Weapon(bunker);
                        if (!weapons.Contains(weapon))
                        {
                            weapons.Enqueue(weapon);
                            continue;
                        }
                    }


                    if (weapons.Count > 0 && currentCapacity - weaponCapacity >= 0)
                    {
                        weapons.Peek().WeaponCapacity.Enqueue(weaponCapacity);
                        currentCapacity -= weaponCapacity;
                    }

                    else
                    {
                        if (weapons.Count == 1)
                        {
                            if (weaponCapacity <= bunkerCapacity)
                            {
                                weapons.Peek().WeaponCapacity.Enqueue(weaponCapacity);
                                currentCapacity -= weaponCapacity;

                                while (currentCapacity < 0)
                                {
                                    currentCapacity += weapons.Peek().WeaponCapacity.Dequeue();
                                }
                            }
                        }

                        else
                        {
                            var weapon = weapons.Dequeue();

                            if (weapon.WeaponCapacity.Count == 0)
                            {
                                Console.WriteLine($"{weapon.Bunker} -> Empty");
                            }

                            else
                            {
                                Console.WriteLine($"{weapon.Bunker} -> {string.Join(", ", weapon.WeaponCapacity)}");
                            }

                            i--;
                            currentCapacity = bunkerCapacity;
                        }
                    }
                }
            }
        }
    }
}
