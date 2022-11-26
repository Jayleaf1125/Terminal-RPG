using System;
using System.IO;
using System.Collections.Generic;
using Character;
using Adventures;

namespace Gameplay
{
    static class Game
    {
        public static void StartGame()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Choose your magic: Fire, Water, Wind, and Earth?");
            string magic = Console.ReadLine();
            Wizard player = new Wizard(name, magic);
            player.SelectMagic();
            player.ReadStats();

            bool gamePlay = true;

            while (gamePlay)
            {
                Console.WriteLine("What do you want to do?");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "read":
                        player.ReadStats();
                        break;
                    case "spellbook":
                        player.SpellBook();
                        break;
                    // Admin Command (Delete once Exp is completed)
                    case "gain":
                        player.AddExpToBar();
                        break;
                    case "view exp":
                        player.ViewExpBar();
                        break;
                    case "help":
                        Game.Help();
                        break;
                    case "adventure":
                        Game.EnterAdventureWorld(player);
                        break;
                    case "end":
                        gamePlay = false;
                        break;
                }
            }
        }

        static void Help()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@$"read command - Displays your stats
spellbook command - Displays your spells
end command - Ends current play session");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void EnterAdventureWorld(Wizard player)
        {
            // Select your world
            Console.WriteLine("Select your adventure: Plains, Caves, or Unknown");
            string world = Console.ReadLine();

            switch (world)
            {
                case ("Plains"):
                    Adventure.Plains(player);
                    break;
                case "Caves":
                    Adventure.Caves(player);
                    break;
            }
            // Depending on user's input, run the world
        }
    }
}