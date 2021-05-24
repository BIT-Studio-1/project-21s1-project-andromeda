using System;

namespace project_andromeda
{


    public class Room
    {
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

        public static void ListItemsInRoom()
        {
            //andromeda.ReadData(item);
            foreach (string line in currentRoom)
            {
                // Once a line with the item= key has been found, extract the data without the key
                if (line.Contains("item="))
                {
                    int delimiter = line.IndexOf('=');
                    Console.WriteLine(line.Substring(delimiter + 1));
                }
            }
        }
    }
}