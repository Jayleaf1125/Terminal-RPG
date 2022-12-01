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

            Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>(){
                {"mob1", new Enemy("rat")},
                {"mob2", new Enemy("rat")},
                {"mob3", new Enemy("rat")},
                {"boss", new Enemy("spider")},
            };

            foreach (var enemy in enemies)
            {
                Adventure.Combat(player, enemy.Key, enemy.Value);
            }

        }

        static public void Caves(Wizard player)
        {
            Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>(){
                {"mob1", new Enemy("spider")},
                {"mob2", new Enemy("spider")},
                {"mob3", new Enemy("spider")},
                {"mob4", new Enemy("spider")},
                {"boss", new Enemy("golem")},
            };

            foreach (var enemy in enemies)
            {
                Adventure.Combat(player, enemy.Key, enemy.Value);
            }
        }

        static private void Combat(Wizard player, string enemy_name, Enemy enemy)
        {

            while (player.Health >= 0)
            {
                // Display
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@$"Combat: _____
            
{enemy.Type}: {enemy.Health} hp             
{player.Name}: {player.Health} hp");

                Console.WriteLine();
                Console.Write("Select a move: ");
                foreach (KeyValuePair<string, int> spell in player.Spells)
                {
                    Console.Write($"{spell.Key}, ");
                }
                Console.WriteLine();
                Console.WriteLine();

                // Choosen a move
                string selectingSpell = Console.ReadLine();
                int random_enemy_move = Experience.RollStats(1, 2);

                if (selectingSpell == "end")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                // Calculate damage taken & given
                if (player.Spells.ContainsKey(selectingSpell))
                {
                    int player_damage = Math.Abs((player.Spells[selectingSpell] + player.Attack) - enemy.Defense);

                    enemy.Health -= player_damage;
                    Console.WriteLine($"You have dealt {player_damage} to the {enemy.Type}");

                    // Computer randomly selects enemy's moves

                    switch (random_enemy_move)
                    {
                        case 0:
                            int enemy_damage = Math.Abs((enemy.attacks[0] + enemy.Attack) - player.Defense);

                            player.Health -= enemy_damage;
                            Console.WriteLine($"{enemy.Type} have dealt {enemy_damage} to the you");
                            break;
                        case 1:
                            int enemy_damage1 = Math.Abs((enemy.attacks[1] + enemy.Attack) - player.Defense);

                            player.Health -= enemy_damage1;
                            Console.WriteLine($"{enemy.Type} have dealt {enemy_damage1} to the you");
                            break;
                    }
                }

                if (enemy.Health <= 0 && enemy_name == "boss")
                {
                    Console.WriteLine();
                    Console.WriteLine("You have completed the Plains!");
                    player.AddExpToBar();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                if (enemy.Health <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Another enemy is approaching");
                    return;
                }
            }

            // End the adventure when you die
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