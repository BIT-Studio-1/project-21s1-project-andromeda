using System;
using System.Collections.Generic;

namespace project_andromeda
{


    public class Room
    {
        public static char delimiter = '=';
        public static string[] currentRoom = new string[0];


        // Check if player can move in given direction
        public static int CanMove(string[] player, int news)
        {
            int result = 0;



            return result;
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


        // This lists the items in the current room. Used for @DEBUG
        public static void ListItemsInRoom()
        {
            List<string> items = andromeda.GetAllData(currentRoom, "item");

            foreach (string item in items)
            {
                Console.WriteLine(item);
            }

        }
    }
}