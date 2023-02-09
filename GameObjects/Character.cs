using System;
using System.IO;
using System.Collections.Generic;
using Experiences;

namespace Character
{
    class Wizard
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string magic;
        Dictionary<string, int> spells = new Dictionary<string, int>();
        public Dictionary<string, int> Spells
        {
            get
            {
                return spells;
            }
        }
        int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        int maxHealth;
        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        int attack;
        public int Attack
        {
            get { return attack; }
        }
        int defense;
        public int Defense
        {
            get { return defense; }
        }
        int currentExpAmount = 0;
        int expBar = 25;
        int level = 1;
        public Wizard(string Name, string Magic)
        {
            name = Name;
            magic = Magic;
            maxHealth = Experience.RollStats(50, 100);
            health = maxHealth;
            attack = Experience.RollStats(5, 10);
            defense = Experience.RollStats(5, 10);
        }

        public void ReadStats()
        {
            string writeText = @$"Name: {name}
Magic: {magic}
Health: {health}
Attack: {attack}
Defense: {defense}";

            File.WriteAllText("Stats.txt", writeText);

            File.ReadAllText("Stats.txt");
        }

        public void SelectMagic()
        {
            switch (magic)
            {
                case "Fire":
                    magic = "Fire";
                    spells.Add("Ember", 2);
                    break;
                case "Water":
                    magic = "Water";
                    spells.Add("Water Gun", 2);
                    break;
                case "Wind":
                    magic = "Wind";
                    spells.Add("Gust", 2);
                    break;
                case "Earth":
                    magic = "Earth";
                    spells.Add("Rock Sling", 2);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG CHOICE, YOUNG ONE!");
                    Console.ForegroundColor = ConsoleColor.White;
                    magic = "None";
                    spells.Add("Punch", 2);
                    break;
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
            int maxHealthStatIncrease = Experience.RollStats(1, 10);
            int attackStatIncrease = Experience.RollStats(1, 5);
            int defenseStatIncrease = Experience.RollStats(1, 5);

            maxHealth += maxHealthStatIncrease;
            health = maxHealth;
            attack += attackStatIncrease;
            defense += defenseStatIncrease;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You Leveled Up! You are now Level {level}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Health increased by {maxHealthStatIncrease}");
            Console.WriteLine($"Attack increased by {attackStatIncrease}");
            Console.WriteLine($"Defense increased by {defenseStatIncrease}");
            Console.ForegroundColor = ConsoleColor.White;

            LearningNewMagic();

        }
        private void LearningNewMagic()
        {
            if (level == 3)
            {
                switch (magic)
                {
                    case "Fire":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Fire Ball");
                        spells.Add("Fire Ball", 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "Water":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Aqua Tail");
                        spells.Add("Aqua Tail", 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "Earth":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Rock Smash");
                        spells.Add("Rock Smash", 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "Wind":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Air Cutter");
                        spells.Add("Air Cutter", 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "None":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Kick");
                        spells.Add("Kick", 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            if (level == 6)
            {
                switch (magic)
                {
                    case "Fire":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Sacred Fire");
                        spells.Add("Sacred Fire", 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "Water":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Hydro Pump");
                        spells.Add("Hydro Pump", 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "Earth":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Magnitude");
                        spells.Add("Magnitude", 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "Wind":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Whirlwind");
                        spells.Add("Whirlwind", 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "None":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You just learned Haymaker");
                        spells.Add("Haymaker", 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
    }
}