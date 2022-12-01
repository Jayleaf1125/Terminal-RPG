using System;
using System.IO;
using System.Collections.Generic;
namespace Experiences
{
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
} 