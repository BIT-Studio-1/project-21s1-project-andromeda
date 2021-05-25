﻿using System;
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


            public string name;
            private bool useable;
            private bool needsItem;
            private string description;

            public Item(string _name, bool canUse, string _description) //item name, is this item usable? yes or no, item description
            {
                name = _name; //name string 
                useable = canUse; //is the item usable?
                description = _description; //description of item
            }

            public string Name
            {
                get { return name; } //return (display) item name
                set { name = value; }
            }

            public bool Useable
            {
                get { return Useable; } //return (display) usable (True or False)
                set { Useable = value; }
            }

            public string Description
            {
                get { return Description; } //return (display) item description
                set { Description = value; }
            }
        }
    }
}

