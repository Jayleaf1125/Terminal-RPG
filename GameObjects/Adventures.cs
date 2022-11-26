using Enemies;
using Character;

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
                // Calculate damage taken & given
                if(selectingSpell == "end")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                if(player.Spells.ContainsKey(selectingSpell))
                {
                    Console.WriteLine($"You did {player.Spells[selectingSpell]} damage");
                }
                // Replace defeated enemy with no enemy
                // End the adventure when you die
            }
            Console.ForegroundColor = ConsoleColor.White;
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