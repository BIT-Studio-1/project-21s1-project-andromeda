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
        public static void PrintInventory()
        {
            ArrayList items = new ArrayList()
                {
                    "Nothing at the moment, try picking up some items!"
                };

            Console.WriteLine();

            foreach (var val in items)
                Console.WriteLine(val);
            Console.ReadLine();
        }

        public static void PickUpItem()
        {
            Console.WriteLine("Which item would you like to pick up?");
            temp = Console.ReadLine();
            Room.roomItems = Room.GetItemsInRoom();

            if (Room.roomItems.Contains(temp))
            {
                Console.WriteLine($"Picked up {temp}.");
                Player.Inventory.Add(temp);
            }
            else
            {
                Console.WriteLine("It looks like that item doesn't exist. Sorry.");
                Console.ReadLine();
            }

        }


    }
}

