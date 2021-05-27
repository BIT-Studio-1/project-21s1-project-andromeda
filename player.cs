using System;
using System.Collections;
using System.Collections.Generic;

namespace project_andromeda
{
    class Player
    {
        static string temp;
        public static List<string> Inventory = new List<string>();

        public static void die()
        {
            Console.WriteLine("You died.");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public static void inventory() { Console.WriteLine("This is the inventory"); }

        public class Item
        {
            public string Name
            {
                get { return Name; } //get name
                set { Name = value; } //set name 
            }
            public bool Useable 
            {
                get { return Useable; } //get useable
                set { Useable = value; } //set useable
            }
            public string Description
            {
                get { return Description; } //get description
                set { Description = value; } //set description
            }
        }
    }
}

