using Enemies;
using Character;
using Experiences;
using System.Collections.Generic;
using Gameplay;

namespace Adventures
{
    static class Adventure
    {
        static public void Plains(Wizard player)
        {
            Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>()
            {
                { "mob1", new Enemy("rat") },
                { "mob2", new Enemy("rat") },
                { "mob3", new Enemy("rat") },
                { "boss", new Enemy("spider") },
            };

            foreach (var enemy in enemies)
            {
                Adventure.Combat(player, enemy.Key, enemy.Value);
            }
        }

        static public void Caves(Wizard player)
        {
            Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>()
            {
                { "mob1", new Enemy("spider") },
                { "mob2", new Enemy("spider") },
                { "mob3", new Enemy("spider") },
                { "mob4", new Enemy("spider") },
                { "boss", new Enemy("golem") },
            };

            foreach (var enemy in enemies)
            {
                Adventure.Combat(player, enemy.Key, enemy.Value);
            }
        }

        static public void BoilingPoint(Wizard player)
        {
            Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>()
            {
                { "mob1", new Enemy("golem") },
                { "mob2", new Enemy("golem") },
                { "mob3", new Enemy("golem") },
                { "mob4", new Enemy("golem") },
                { "boss", new Enemy("demon") },
            };

            foreach (var enemy in enemies)
            {
                Adventure.Combat(player, enemy.Key, enemy.Value);
            }
        }

        static private int EscapeAdventure(Wizard player)
        {
            // Prompt to escape
            Console.WriteLine("---------------");
            Console.WriteLine("Do you want to escape?");
            string escapeDecision = Console.ReadLine();

            if (escapeDecision == "No")
                return 3;
            // Chance Rolls
            int isRollingSuccessful = Experience.RollStats(0, 2);
            return isRollingSuccessful;
        }

        static private void Combat(Wizard player, string enemy_name, Enemy enemy)
        {
            bool inCombat = true;

            while (inCombat)
            {
                // Display
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(
                    @$"COMBAT =|>
            
{enemy.Type}: {enemy.Health} hp             
{player.Name}: {player.Health} hp"
                );

                Console.WriteLine();
                Console.Write("Select a move: ");
                foreach (KeyValuePair<string, int> spell in player.Spells)
                {
                    Console.Write($"{spell.Key} or ");
                }
                Console.WriteLine();

                // Choosen a move
                string selectingSpell = Console.ReadLine();
                int random_enemy_move = Experience.RollStats(0, 2);

                if (selectingSpell == "end")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                // Calculate damage taken & given
                if (player.Spells.ContainsKey(selectingSpell))
                {
                    int player_damage = Math.Abs(
                        (player.Spells[selectingSpell] + player.Attack) - enemy.Defense
                    );

                    enemy.Health -= player_damage;
                    Console.WriteLine($"You have dealt {player_damage} to the {enemy.Type}");

                    if (enemy.Health <= 0 && enemy_name == "boss")
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have completed the Adventure!");
                        player.AddExpToBar();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        return;
                    }
                    // If eneemy is dead, prompt escape feature
                    // if (enemy.Health <= 0)
                    // {
                    //     Console.WriteLine();
                    //     Console.WriteLine("Another enemy is approaching");
                    //     int isSuccessFul = Adventure.EscapeAdventure(player);

                    //     System.Console.WriteLine($"Roll: {isSuccessFul}");

                    //     if (isSuccessFul == 1)
                    //     {
                    //         Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    //         inCombat = false;
                    //         Console.WriteLine($"{player.Name} has escaped");
                    //         Console.BackgroundColor = ConsoleColor.Black;
                    //         Console.ForegroundColor = ConsoleColor.White;
                    //         break;
                    //     }
                    //     else
                    //     {
                    //         System.Console.WriteLine($"{player.Name} has failed to escape");
                    //     }
                    //     return;
                    // }
                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Another enemy is approaching");
                        return;
                    }
                    // Computer randomly selects enemy's moves

                    switch (random_enemy_move)
                    {
                        case 0:
                            int enemy_damage = Math.Abs(
                                (enemy.attacks[0] + enemy.Attack) - player.Defense
                            );

                            player.Health -= enemy_damage;
                            Console.WriteLine($"{enemy.Type} have dealt {enemy_damage} to the you");
                            break;
                        case 1:
                            int enemy_damage1 = Math.Abs(
                                (enemy.attacks[1] + enemy.Attack) - player.Defense
                            );

                            player.Health -= enemy_damage1;
                            Console.WriteLine(
                                $"{enemy.Type} have dealt {enemy_damage1} to the you"
                            );
                            break;
                        default:
                            Console.WriteLine($"{enemy.Type} has missed!");
                            break;
                    }
                }

                // if (enemy.Health <= 0 && enemy_name == "boss")
                // {
                //     Console.WriteLine();
                //     Console.WriteLine("You have completed the Adventure!");
                //     player.AddExpToBar();
                //     Console.BackgroundColor = ConsoleColor.Black;
                //     Console.ForegroundColor = ConsoleColor.White;
                //     Console.WriteLine();
                //     return;
                // }

                if (player.Health <= 0)
                {
                    // End the adventure when you die
                    inCombat = false;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You have died");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Do you want to start over? Yes or No");
                    string restartGame = Console.ReadLine();

                    if (restartGame == "Yes")
                    {
                        Game.StartGame();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
