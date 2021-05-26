using System;
using System.Collections.Generic;

namespace project_andromeda
{


    public class Room
    {
        public static char delimiter = '=';
        public static string[] currentRoom = new string[0];
        public static List<string> roomItems = new List<string>();


        // Check if player can move in given direction
        public static string CanMove(string x)
        {
            //Checks if there is a wall in the chosen direction, changes the player's input if there is a wall.
            foreach (string line in currentRoom)
            {
                if (line.Contains("news="))
                {
                    if ((line.Substring(5, 1) == "0") && ((x == "N") || (x=="n")))
                    {
                        x = "nol";
                    }
                    if ((line.Substring(6, 1) == "0") && ((x == "E") || (x == "e")))
                    {
                        x = "nol";
                    }
                    if ((line.Substring(7, 1) == "0") && ((x == "W") || (x == "w")))
                    {
                        x = "nol";
                    }
                    if ((line.Substring(8, 1) == "0") && ((x == "S") || (x == "s")))
                    {
                        x = "nol";
                    }
                }
            }
            return x;
        }



        public static void Read(int[] player)
        {
            /* This method loads a room into the game from an <x><y>.room file
             * 
             * To see how the .room files are structured look in room/room.skeleton
             * 
             * 
             * 
             */
            int roomx, roomy;

            roomx = player[0];
            roomy = player[1];

            string file = @"..\..\..\room\" + roomx + roomy + ".room";


            // Check amount of lines in room text file and resize array
            int lineCount = 0;
            foreach (string line in System.IO.File.ReadAllLines(file))
            {
                lineCount++;
            }



            // Read room into array
            Array.Resize(ref currentRoom, lineCount);
            currentRoom = System.IO.File.ReadAllLines(file);

        }

        // This method just grabs the text portion of the room file and prints it
        public static void LookRoom()
        {
            List<string> roomText = new List<string>();
            bool found = false;

            foreach (string line in currentRoom)
            {
                if (line.Contains("#")) found = false;
                if (found) roomText.Add(line);
                if (line.Contains("text=")) found = true;
            }

            foreach (string line in roomText)
            {
                Console.WriteLine(line);
            }
            
            Console.ReadLine();
        }


        // This updates the items in the current room. Used for @DEBUG
        public static List<string> GetItemsInRoom()
        {
            bool found = false;

            foreach (string line in currentRoom)
            {
                if (line.Contains("#")) found = false;
                if (found && !(line.Contains(';'))) {
                    int start = line.IndexOf(delimiter) + 1;
                    roomItems.Add(line.Substring(start));
                }
                if (line.Contains("items=")) found = true;
            }

            return roomItems;
        }
    }
}