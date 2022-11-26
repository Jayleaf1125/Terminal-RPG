using Enemies;
using Character;
using Experiences;
using Gameplay;

namespace Adventures
{
    static class Adventure
    {
        static public void Plains(Wizard player)
        {
            // Create enemies
            Enemy mob1 = new Enemy("rat");
            Enemy mob2 = new Enemy("rat");
            Enemy mob3 = new Enemy("rat");
            Enemy boss = new Enemy("spider");

            Enemy currentEnemy = mob1;

            while (player.Health > 0)
            {
                // Display
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(@$"Combat: _____
            
{currentEnemy.Type}: {currentEnemy.Health} hp             

{player.Name}: {player.Health} hp");

                Console.WriteLine();
                Console.Write("Select a move: ");
                foreach (KeyValuePair<string, int> spell in player.Spells)
                {
                    Console.Write($"{spell.Key}, ");
                }
                Console.WriteLine();
                // Choosen a move
                string selectingSpell = Console.ReadLine();

                if (selectingSpell == "end")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                // Calculate damage taken & given
                if (player.Spells.ContainsKey(selectingSpell))
                {
                    // player & currentEnemy
                    int player_damage = Math.Abs((player.Spells[selectingSpell] + player.Attack) - currentEnemy.Defense);

                    currentEnemy.Health -= player_damage;
                    Console.WriteLine($"You have dealt {player_damage} to the {currentEnemy.Type}");

                    // Computer randomly selects enemy's moves
                    int random_enemy_move = Experience.RollStats(1, 2);

                    switch (random_enemy_move)
                    {
                        case 0:
                            int enemy_damage = Math.Abs((currentEnemy.attacks[0] + currentEnemy.Attack) - player.Defense);

                            player.Health -= enemy_damage;
                            Console.WriteLine($"{currentEnemy.Type} have dealt {enemy_damage} to the you");
                            break;
                        case 1:
                            int enemy_damage1 = (currentEnemy.attacks[1] + currentEnemy.Attack) - player.Defense;

                            player.Health -= enemy_damage1;
                            Console.WriteLine($"{currentEnemy.Type} have dealt {enemy_damage1} to the you");
                            break;
                    }
                }
                // Replace defeated enemy with no enemy
                if (currentEnemy.Health <= 0 && currentEnemy == mob1)
                {
                    player.AddExpToBar();
                    Console.WriteLine("Another rat has come to fight");
                    currentEnemy = mob2;
                }

                if (currentEnemy.Health <= 0 && currentEnemy == mob2)
                {
                    player.AddExpToBar();
                    Console.WriteLine("Another rat has come to fight");
                    currentEnemy = mob3;
                }

                if (currentEnemy.Health <= 0 && currentEnemy == mob3)
                {
                    player.AddExpToBar();
                    Console.WriteLine("The boss is coming");
                    currentEnemy = boss;
                }

                if (currentEnemy.Health <= 0 && currentEnemy == boss)
                {
                    Console.WriteLine("You have completed the Plains!");
                    player.AddExpToBar();
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                // End the adventure when you die
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You have died");
            Game.StartGame();
        }

        static public void Caves(Wizard player)
        {
            // Create enemies
            Enemy mob1 = new Enemy("spider");
            Enemy mob2 = new Enemy("spider");
            Enemy mob3 = new Enemy("spider");
            Enemy mob4 = new Enemy("spider");
            Enemy boss = new Enemy("golem");
            Console.WriteLine("You have choosen Caves");
            return;
        }
    }
}