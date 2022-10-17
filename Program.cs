using System.IO;
using System.Collections.Generic;

// Player Class
class Wizard
{
    string name;
    string magic;
    Dictionary<string, int> spells = new Dictionary<string, int>();
    int health;
    int attack;
    int defense;
    int currentExpAmount = 0;
    int expBar = 25;
    int level = 1;
    public Wizard(string Name)
    {
        name = Name;
        health = Experience.RollStats(1, 100);
        attack = Experience.RollStats(1, 10);
        defense = Experience.RollStats(1, 10);
    }

    public void ReadStats()
    {
        string writeText = @$"Name: {name}
Health: {health}
Attack: {attack}
Defense: {defense}";

        File.WriteAllText("Stats.txt", writeText);

        File.ReadAllText("Stats.txt");
    }

    public void SelectMagic()
    {
        bool selection = true;

        while (selection)
        {
            Console.WriteLine("Choose your magic: Fire or Water?");
            string magic = Console.ReadLine();
            switch (magic)
            {
                case "Fire":
                    magic = "Fire";
                    spells.Add("Ember", 2);
                    selection = false;
                    break;
                case "Water":
                    magic = "Water";
                    spells.Add("Water Gun", 2);
                    selection = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG CHOICE, YOUNG ONE!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }

    public void SpellBook()
    {
        foreach (KeyValuePair<string, int> spell in spells)
        {
            Console.WriteLine(@$"Spell: {spell.Key}
Damage: {spell.Value}");
        }
    }

    public void ViewExpBar()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{currentExpAmount} / {expBar}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void AddExpToBar()
    {
        int exp = Experience.ExpGain();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You have gained {exp} experience points");
        Console.ForegroundColor = ConsoleColor.White;

        if (currentExpAmount < expBar && (exp + currentExpAmount) < expBar)
        {
            currentExpAmount += exp;
            return;
        }

        LevelUp();
    }


    public void LevelUp()
    {
        int leftOverExp = (currentExpAmount - expBar) * -1;
        level++;
        currentExpAmount = 0;
        currentExpAmount += leftOverExp;
        expBar += 25;

        // Increasing Stats
        int healthStatIncrease = Experience.RollStats(1, 10);
        int attackStatIncrease = Experience.RollStats(1, 5);
        int defenseStatIncrease = Experience.RollStats(1, 5);

        health += healthStatIncrease;
        attack += attackStatIncrease;
        defense += defenseStatIncrease;


        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"You Leveled Up! You are now Level {level}");
        Console.WriteLine($"Health increased by {healthStatIncrease}");
        Console.WriteLine($"Attack increased by {attackStatIncrease}");
        Console.WriteLine($"Defense increased by {defenseStatIncrease}");
        Console.ForegroundColor = ConsoleColor.White;

    }

    private void LearningNewMagic()
    {
        // Fire Spells
        if (magic == "Fire" && level == 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You just learned Fire Ball");
            spells.Add("Fire Ball", 3);
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        if (magic == "Fire" && level == 6)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You just learned Sacred Fire");
            spells.Add("Sacred Fire", 5);
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        // Water Spells
        if (magic == "Water" && level == 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You just learned Aqua Tail");
            spells.Add("Aqua Tail", 3);
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        if (magic == "Water" && level == 6)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You just learned Hydro Pump");
            spells.Add("Hydro Pump", 5);
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
        Console.WriteLine("Not enough levels");
    }
}

// Experience
static class Experience
{
    public static int ExpGain()
    {
        Random rnd = new Random();
        int experience = rnd.Next(1, 15);
        return experience;
    }

    public static int RollStats(int minNumber, int maxNumber)
    {
        Random rnd = new Random();
        int num = rnd.Next(minNumber, maxNumber);
        return num;
    }
}
// Game Class
static class Game
{
    public static void StartGame()
    {
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Wizard wiz = new Wizard(name);
        wiz.SelectMagic();
        wiz.ReadStats();

        bool gamePlay = true;

        while (gamePlay)
        {
            Console.WriteLine("What do you want to do?");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "read":
                    wiz.ReadStats();
                    break;
                case "spellbook":
                    wiz.SpellBook();
                    break;
                // Admin Command (Delete once Exp is completed)
                case "gain":
                    wiz.AddExpToBar();
                    break;
                case "view exp":
                    wiz.ViewExpBar();
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

// Litt

// Enemy Class
class Enemy
{
    string type;
    public Dictionary<string, int> attacks = new Dictionary<string, int>();
    int health;
    int attack;
    int defense;

    public Enemy(string Type)
    {
        type = Type;

        // Selects enemy stats & attacks based off type of enemy
        switch (type)
        {
            case "rat":
                health = Experience.RollStats(1, 25);
                attack = Experience.RollStats(1, 10);
                defense = Experience.RollStats(1, 10);
                attacks.Add("Scratch", 2);
                attacks.Add("Bite", 3);
                break;
            case "spider":
                health = Experience.RollStats(10, 50);
                attack = Experience.RollStats(7, 20);
                defense = Experience.RollStats(1, 10);
                attacks.Add("Crunch", 3);
                attacks.Add("String Shot", 4);
                break;
            case "golem":
                health = Experience.RollStats(50, 100);
                attack = Experience.RollStats(10, 25);
                defense = Experience.RollStats(1, 15);
                attacks.Add("Punch", 5);
                attacks.Add("Slam", 7);
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        Game.StartGame();
    }
}