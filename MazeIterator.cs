using System;
using System.Collections.Generic;
using System.Text;

namespace project_andromeda
{
    class MazeIterator
    {
        public static string[,][] ReadAllRoomFiles()
        {
            string[,] AllRoomFiles = new string[10, 10];
            string[,][] AllRoomFilesData = new string[10, 10][];
            string filePath = "";

            // Iterate through all the rooms and generate paths for the stream reader
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    AllRoomFiles[x,y] = @"..\..\..\room\" + x + y + ".room";
                }
            }

            // Iterate through all the room paths and store the data
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    filePath = AllRoomFiles[x, y];
                    AllRoomFilesData[x,y] = System.IO.File.ReadAllLines(filePath);  
                }
            }

            return AllRoomFilesData;
        }

        public static string[] ReadNewsFile()
        {
            //string[,] AllRoomFiles = new string[10, 10];
            //string[,][] AllRoomFilesData = new string[10, 10][];
            //string filePath = "";

            //// Iterate through all the rooms and generate paths for the stream reader
            //for (int y = 0; y < 10; y++)
            //{
            //    for (int x = 0; x < 10; x++)
            //    {
            //        AllRoomFiles[x, y] = @"..\..\..\room\" + x + y + ".room";
            //    }
            //}

            string[] NewsFileData = System.IO.File.ReadAllLines(@"..\..\..\room\news.file");

            return NewsFileData;
        }

        public static void WriteNewsToRoom(string[,][] AllRoomFilesData, string[] NewsFileData)
        {
            int lineNumber = 0;
            string[,] AllRoomFiles = new string[10, 10];
            string filePath = "";
            string[] fileData;

            // Iterate through all the rooms and write news= string
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    AllRoomFilesData[x, y][19] = NewsFileData[lineNumber];
                    lineNumber++;
                }
            }


            // Iterate through all the rooms and generate paths for the stream reader
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    AllRoomFiles[x, y] = @"..\..\..\newrooms\" + x + y + ".room";
                }
            }


            // Iterate through all the room strings and write to file
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    fileData = AllRoomFilesData[x, y];
                    System.IO.File.WriteAllLines(filePath, fileData);
                }
            }

        }

        // 18
        //   public static void LookRoom()
        //   {
        //       List<string> roomText = new List<string>();
        //       bool found = false;

        //       /* Iterate over the currentRoom string array
        //        * and locate the text= token.
        //        * Once the token is found store every subsequent
        //        * line in the roomText string array, until the # token is found.
        //        * At which point it stops reading.
        //        */
        //       foreach (string line in currentRoom)
        //       {
        //           if (line.Contains("#")) found = false;
        //           if (found) roomText.Add(line);
        //           if (line.Contains("text=")) found = true;
        //       }

        //       /* Print every line in roomText to the screen
        //        * At the current cursor position
        //        */
        //       foreach (string line in roomText)
        //       {
        //           Console.WriteLine(line);
        //       }
        //   }

        //   foreach (var Room in roomArray)
        //{

        //}

    }
}
