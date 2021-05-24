using System;
using System.Collections.Generic;
using System.Threading;

namespace project_andromeda
{
    class andromeda
    {
        static void NewGame()
        {
            //Create a new save file with default player variables and then start the game
            Game();
        }
        static void Load()
        {
            //Load player variables from a save file then start the game
            Game();
        }
        static void Game()
        {
            

            string temp;
            int input;
            Random rand = new Random();
            //Generates a two dimensional grid. NOTE: If you change the array size, make sure x is equal to y.
            int[] xaxis = new int[5], yaxis = new int[5];

            // Populate array coordinates
            for (int i = 0; i < xaxis.Length; i++)
            {
                xaxis[i] = i;
                yaxis[i] = i;
            }

            //Player position, 0 = x axis, 1 = y axis, starting position is x2 y2.
            int[] player = new int[2];
            player[0] = 2;
            player[1] = 2;

            // Read room data into currentRoom
            Room.Read(player);


            //Takes a user input to move player position
            /*
             * This will eventually need to take input as `<verb> <noun>` so you can actually interact with the environment.
             * E.G. `use hammer`
             * And if we have time you would have a context you want to do previous commands in too. So you could input `nail` after
             * to instruct the hammer to be used on the nail.
             * 
             * */


            // Main game loop
            /*
             * Eventually this should maybe read a room text file? E.G. 22.room would be loaded at the start since player is at 
             * position[0] = 2;
             * position[1] = 2;
             * 
             * This room file would have information about what can be done in the room and the contextual information about what is in the room
             * 
             */

            //Remembers your last location, if you go out of bounds uses 'ghost' to set your position to your last known actual coordinates.
            int[] ghost = new int[2];
            do
            {
                Console.Clear();
                Room.Read(player);

                
                //Sets ghost position to be same as player before player input
                ghost[0] = player[0];
                ghost[1] = player[1];
                Console.WriteLine($"Your position is x {player[0]}, y {player[1]}.");
                Console.WriteLine("Input a direction to travel N/E/S/W.\n" +
                    "Input [I]nventory to list your currently held items\n" +
                    "Input [P]ick up to grab an item\n" +
                    "Input [L]ook to get a description of the confines of your being.\n" +
                    "Or input [Q] to quit.\n\n");
                do
                {
                    temp = Console.ReadLine();
                    input = 0;
                    switch (temp)
                    {
                        case "n":
                        case "N":
                            player[1]++;
                            break;
                        case "s":
                        case "S":
                            player[1]--;
                            break;
                        case "e":
                        case "E":
                            player[0]++;
                            break;
                        case "w":
                        case "W":
                            player[0]--;
                            break;
                        case "q":
                        case "Q":
                            break;
                        case "l":
                        case "L":
                            Room.LookRoom();
                            break;
                        case "i":
                        case "I":
                            Player.PrintInventory();
                            break;
                        case "p":
                        case "P":
                            Player.PickUpItem();
                            break;


                        // @DEBUG
                        case "d":
                        case "D":
                            Room.GetItemsInRoom();
                            break;

                        default:
                            input = 1;
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                } while (input == 1);
                foreach (int value in player)
                {
                    //Tests if the player has entered an input that puts them out of bounds, and resets their position to their previous known location
                    if ((value < 0) || (value > xaxis[xaxis.Length - 1]) || (value > yaxis[yaxis.Length - 1]))
                    {
                        Console.WriteLine("Out of bounds.");
                        player[0] = ghost[0];
                        player[1] = ghost[1];
                    }
                }

            } while ((temp != "q")&&(temp != "Q"));
        }

        // This makes a list with all of the items in it
        public static List<string> GetAllData(string[] dataString, string dataType)
        {
            List<string> allData = new List<string>();
            foreach (string line in dataString)
            {        
                int delimiter = line.IndexOf('=');
                allData.Add(line.Substring(delimiter + 1));
            }
            return allData;
        }

        // This returns a single item once you know it exists
        public static string GetData(string[] dataString, string dataType, string name)
        {
            string data = "\0";
            foreach (string line in dataString)
            {
                // Once a line with the item= key has been found and it has the correct name,
                // extract the data without the key
                if (line.Contains(dataType) && line.Contains(name))
                {
                    int delimiterIndex = line.IndexOf(Room.delimiter);
                    data = line.Substring(delimiterIndex + 1);
                }
            }
            return data;
        }


        static void Main()
        {
            
            string temp;
            int start=1;
            do
            {
                Console.Clear();
                Console.WriteLine("ANDROMEDA\nMain Menu\n\n1. New Game\n2. Load Game\n3. Exit");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        NewGame();
                        break;
                    case "2":
                        Load();
                        break;
                    case "3":
                        start = 0;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input");
                        Thread.Sleep(1500);
                        break;
                }
            } while (start == 1);
        }
    }
}
