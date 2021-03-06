using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace project_andromeda
{
    class andromeda
    {
        static readonly string PLAYERICON = "()";
        const int XSTEP = 3;
        const int YSTEP = 2;
        const int ALIGN = 1;

        static String[] originalMiniMapFromFile;
        static int miniMapX;
        static int miniMapY;


        //Saves the players position
        static void Save(ref int[] player)
        {
#if DEBUG
            StreamWriter sw = new StreamWriter(@"..\..\..\Save.txt");
#else
            StreamWriter sw = new StreamWriter(@".\save\Save.txt");
#endif
            sw.WriteLine($"player[0] ={player[0]};\nplayer[1] ={player[1]};");
            sw.Close();
        }
        //Load player variables from a save file
        static int[] Load()
        {
            int[] player = new int[2];
            string line, temp;
            int index;
#if DEBUG
            StreamReader sr = new StreamReader(@"..\..\..\Save.txt");
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
            return player;
        }
        static void Game(int[] player)
        {
            readMiniMapFromFile();
            int start = 1;
            do
            {
                // Check if player is in room 49.room and end game.
                if ((player[0] == 4) && (player[1] == 9))
                {
                    DisplayGameUI(ref player);
                    Console.WriteLine("Congratulations you won!");
                    //Player.Win();
                    Console.ReadLine();
                }
                DisplayGameUI(ref player);
                //Takes a user input to move player position
                GameUserInput(ref player, ref start);
            } while (start == 1);
            //Saves the player's position when player leaves the game loop
            Save(ref player);
        }
        static void DisplayGameUI(ref int[] player)
        {
            Console.Clear();
            //Read room data
            Room.ReadRoomFile(player);
            Console.WriteLine($"Your position is x {player[0]}, y {player[1]}.");
            Console.WriteLine("Input a direction to travel N/E/S/W.\n");
            Room.LookRoom();
            Console.WriteLine("Or input [Q] to quit.\n\n");

            //@DEBUG Draw the map to screen, this can safely be deleted
            drawMiniMap(generateMiniMap(player, originalMiniMapFromFile));
            
        }
        //Takes a user input to decide what to do next.
        static void GameUserInput(ref int[] player, ref int start)
        {
            int input;
            do
            {
                string temp = Console.ReadLine();
                //Checks if there is a wall in the direction the player wants to move
                string wall = Room.CanMove(temp);
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
                        start = 0;
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
        }
        
        static void Main()
        {
            string temp;
            int start = 1;
            do
            {
                UserInterface.MainDisplay("<MainMenu>");
                //Console.WriteLine("ANDROMEDA\nMain Menu\n\n1. New Game\n2. Load Game\n3. Exit");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        int[] player = { 2, 2 };
                        Game(player);
                        break;
                    case "2":
                        try
                        {
                            Game(Load());
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            Console.WriteLine("Error, Save file not found.");
                        }
                        Console.ReadLine();
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

        // @DEBUG this can safely be deleted
        static void drawMiniMap(string[] map)
        {
            foreach (string line in map)
            {
                Console.WriteLine(line);
            }
        }


        // This loads the minimap text file into a string array, if it doesn't exist it does nothing
        static private void readMiniMapFromFile()
        {
            miniMapX = 0;
            miniMapY = 0;
#if DEBUG
            string file = @"..\..\..\room\map.txt";
#else
            string file = @"..\..\..\room\map.txt";
#endif
            if (System.IO.File.Exists(file))
            {
                // Count how many lines are in the file
                foreach (string line in System.IO.File.ReadAllLines(file))
                {
                    miniMapY++;
                }

                // Create the array the right size for the file
                originalMiniMapFromFile = new string[miniMapY];

                // Load lines into array
                int lineCounter = 0;
                foreach (string line in System.IO.File.ReadAllLines(file))
                {
                    originalMiniMapFromFile[lineCounter] = line;
                    lineCounter++;
                }

                // Load map X from array
                miniMapX = originalMiniMapFromFile[0].Length;
            }
        }

        static private string[] generateMiniMap(int[] playerpos, string[] inputMap)
        {
            // The string array to return
            string[] generatedMap = new string[miniMapY];

            // Temporary character array for drawing player character
            char[] lineWithPlayerCharacter;

            // Positional variables required for drawing player character
            int[] pos = convertToMapCoordinate(playerpos);

            // Check if the minimap has been loaded
            if (miniMapY != 0)
            {
                // Put each line in a separate array item
                for (int i = 0; i < miniMapY; i++)
                {
                    // This discovers which line the player character is on
                    if (i == pos[1])
                    {
                        // Extract line as character array to do character manipulation
                        lineWithPlayerCharacter = inputMap[i].ToCharArray();
                        lineWithPlayerCharacter[pos[0]] = PLAYERICON[0];
                        lineWithPlayerCharacter[pos[0]+1] = PLAYERICON[1];

                        // Convert array back to string and put it in the string array
                        generatedMap[i] = new string(lineWithPlayerCharacter);
                        
                    }
                    // Else copy the lines to the array
                    else
                    {
                        generatedMap[i] = inputMap[i];
                    } 
                }

            }
            
            return generatedMap;
        }
            // Convert playerpos to mapPos
            static int[] convertToMapCoordinate(int[] playerpos)
            {
                int[] mapPos;
                int mapPosX = 0;
                int mapPosY = 0;

                // Convert X pos
                mapPosX = playerpos[0];
                // Move over to correct position
                mapPosX *= XSTEP;
                // Step over first wall
                mapPosX += ALIGN;

                // Convert Y pos
                mapPosY = playerpos[1];
                // Step over first wall
                mapPosY += ALIGN;
                // Move over to correct position
                mapPosY *= YSTEP;
                // Reverse coordinate space
                mapPosY = Math.Abs(mapPosY - miniMapY);

                // Package it up into an array
                mapPos = new int[] { mapPosX, mapPosY };

                return mapPos;
            }

         // This makes a list with all of the items in it
        //public static List<string> GetAllData(string[] dataString, string dataType)
        //{
        //    List<string> allData = new List<string>();
        //    foreach (string line in dataString)
        //    {        
        //        int delimiter = line.IndexOf('=');
        //        allData.Add(line.Substring(delimiter + 1));
        //    }
        //    return allData;
        //}

        //// This returns a single item once you know it exists
        //public static string GetData(string[] dataString, string dataType, string name)
        //{
        //    string data = "\0";
        //    foreach (string line in dataString)
        //    {
        //        // Once a line with the item= key has been found and it has the correct name,
        //        // extract the data without the key
        //        if (line.Contains(dataType) && line.Contains(name))
        //        {
        //            int delimiterIndex = line.IndexOf(Room.delimiter);
        //            data = line.Substring(delimiterIndex + 1);
        //        }
        //    }
        //    return data;
        //}
    }
}
