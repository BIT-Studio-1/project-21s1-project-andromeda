using System;

namespace project_andromeda
{

    public class Room
    {
        /* This method loads a room into the game from an <x><y>.room file
         * 
         * To see how the .room files are structured look in room/room.skeleton
         * 
         * 
         * 
         */

        public static void Read(int[] player)
        {
            int roomx, roomy;

            roomx = player[0];
            roomy = player[1];

            string file = @"..\..\..\room\" + roomx + roomy + ".room";

            Console.WriteLine($"Will now attempt to read file {file}");
            Console.ReadLine();


            // Definitely not stolen from the Microsoft example docs

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            //try
            //{
            string[] lines = System.IO.File.ReadAllLines(file);


            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of 22.room = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            Console.ReadLine();

            //}
            //catch (System.IO.DirectoryNotFoundException)
            //{
            //    Console.WriteLine("Houston we have a problem!" +
            //        "Unable to read file.");
            //}
        }
    }
}