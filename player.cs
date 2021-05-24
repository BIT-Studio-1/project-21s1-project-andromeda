using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_andromeda
{
    public class Player
    {
        public static void die()
        {
            Console.WriteLine("You died."); //displays game over text
            Console.ReadLine();
            Environment.Exit(0); //exits application
        }
        public static void inventory (){ Console.WriteLine("This is the inventory"); }
        
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
                get { return useable; } //return (display) usable (True or False)
            }

            public string Description
            {
                get { return description; } //return (display) item description
            }
        }
    }
}
           

           
            
        
 

 

