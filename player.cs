using System;
using System.Collections;

namespace project_andromeda
{
    class Player
    {
        public static void die()
        {
            Console.WriteLine("You died.");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public static void inventory()
        {
            ArrayList items = new ArrayList()
                {
                    "Chucky Tailors",
                    "Creel",
                    "Key",
                    "Shoes"
                };


            foreach (var val in items)
                Console.WriteLine(val);
            Console.ReadLine();
        }
    }
}

