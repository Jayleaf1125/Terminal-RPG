﻿using System;
using System.IO;
using System.Collections.Generic;
using Character;
using Experiences;
using Enemies;

static class Game
{
    public static void StartGame()
    {
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine("Choose your magic: Fire or Water?");
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
}

class Program
{
    static void Main()
    {
        Game.StartGame();
    }
}