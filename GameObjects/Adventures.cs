using Enemies;

namespace Adventures
{
    static class Adventure
    {
        static public void Plains()
        {
            // Create enemies
            Enemy mob1 = new Enemy("rat");
            Enemy mob2 = new Enemy("rat");
            Enemy mob3 = new Enemy("rat");
            Enemy boss = new Enemy("spider");

            // Create combat loop/turn based system
            // make it look pretty
            Console.WriteLine("You have choosen Plains");
            return;
        }

        static public void Caves()
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