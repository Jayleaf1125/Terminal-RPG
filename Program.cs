using System;
using System.IO;
using System.Collections.Generic;
using Gameplay;

class Program
{
    static void Main()
    {
        Game.StartGame();
    }
}

// Theres a bug with ending the game after death, makes sure it ends with one "end" command & not two "end" commands