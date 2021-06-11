using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace project_andromeda
{
    class andromeda
    {
        //Create a new save file with default player variables and then start the game
        static void NewGame()
        {
            // This just checks if it is a debug build or a release and changes the pathing
#if DEBUG
            StreamWriter sw = new StreamWriter(@"Save.txt");
#else
            StreamWriter sw = new StreamWriter(@".\save\Save.txt");
#endif
            sw.WriteLine("player[0] =2;\nplayer[1] =2;");
            sw.Close();
            Game();
        }
       
        //Saves the players position
        static void Save(ref int[] player)
        {
#if DEBUG
            StreamWriter sw = new StreamWriter(@"..\..\..\save\Save.txt");
#else
            StreamReader sr = new StreamReader(@".\save\Save.txt");
#endif
            sw.WriteLine($"player[0] ={player[0]};\nplayer[1] ={player[1]};");
            sw.Close();
        }
        //Load player variables from a save file then start the game
        static void Load(ref int[] player)
        {
            string line, temp;
            int index;
#if DEBUG
            StreamReader sr = new StreamReader(@"Save.txt");
#else
            StreamReader sr = new StreamReader(@".\save\Save.txt");
#endif
            line = sr.ReadLine();
            //Gets the player's position from the save file.
            if (line.Contains($"player[0]"))
            {
                index = line.IndexOf("=");
                temp = line.Substring(index + 1, 1);
                player[0] = Convert.ToInt32(temp);
            }
            line = sr.ReadLine();
            if (line.Contains("player[1]"))
            {
                index = line.IndexOf("=");
                temp = line.Substring(index + 1, 1);
                player[1] = Convert.ToInt32(temp);
            }
            sr.Close();
        }
        static void Game()
        {
            string temp, wall;
            int[] player = new int[2];
            int input;
            Random rand = new Random();
            Load(ref player);
            // Read room data into currentRoom
            Room.ReadRoomFile(player);
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
            do
            {
                Console.Clear();
                //Read room data
                Room.ReadRoomFile(player);
                Console.WriteLine($"Your position is x {player[0]}, y {player[1]}.");
                Console.WriteLine("Input a direction to travel N/E/S/W.\n");
                Room.LookRoom();
                Console.WriteLine("Or input [Q] to quit.\n\n");
                do
                {
                    temp = Console.ReadLine();
                    //Checks if there is a wall in the direction the player wants to move
                    wall = Room.CanMove(temp);
                    temp = wall;
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
                        case "nol":
                            input = 1;
                            Console.WriteLine("There is a wall in the way!!");
                            break;
                        default:
                            input = 1;
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                } while (input == 1);                
            } while ((temp != "q")&&(temp != "Q"));
            //Saves the player's position when player leaves the game loop
            Save(ref player);
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
                        Game();
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
