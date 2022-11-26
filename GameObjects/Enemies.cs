using System;
using System.IO;
using System.Collections.Generic;
using Experiences;

namespace Enemies
{
    class Enemy
    {
        string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public Dictionary<int, int> attacks = new Dictionary<int, int>();
        int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        int attack;
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        int defense;
        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

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
                    // Scratch
                    attacks.Add(0, 2);
                    // Bite
                    attacks.Add(1, 3);
                    break;
                case "spider":
                    health = Experience.RollStats(10, 50);
                    attack = Experience.RollStats(5, 20);
                    defense = Experience.RollStats(5, 20);
                    // Crunch
                    attacks.Add(0, 3);
                    // String Shot
                    attacks.Add(1, 4);
                    break;
                case "golem":
                    health = Experience.RollStats(50, 100);
                    attack = Experience.RollStats(10, 30);
                    defense = Experience.RollStats(10, 15);
                    // Punch
                    attacks.Add(0, 5);
                    // Slam
                    attacks.Add(1, 7);
                    break;
            }
        }
    }
}