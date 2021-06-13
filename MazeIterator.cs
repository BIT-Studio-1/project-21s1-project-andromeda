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
           
            string[] NewsFileData = System.IO.File.ReadAllLines(@"..\..\..\room\news.file");

            return NewsFileData;
        }

        public static void WriteNewsToRoom(string[,][] AllRoomFilesData, string[] NewsFileData)
        {
            int lineNumber = 0;
            string[,] AllRoomFiles = new string[10, 10];
            string filePath = "";
            string[] fileData;
            int newsIndex = 18;

            // Iterate through all the rooms and write news= string
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    // Why does this have to be backwards? Coordinates are difficult.
                    AllRoomFilesData[y, x][newsIndex] = NewsFileData[lineNumber];
                    lineNumber++;
                }
            }


            // Iterate through all the rooms and generate paths for the stream reader
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    AllRoomFiles[y, x] = @"..\..\..\newrooms\" + x + y + ".room";
                }
            }


            // Iterate through all the room strings and write to file
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    fileData = AllRoomFilesData[x, y];
                    filePath = AllRoomFiles[y, x];
                    System.IO.File.WriteAllLines(filePath, fileData);
                }
            }

        }

        public static string[,][] ReadAllNewRoomFiles()
        {
            string[,] AllNewRoomFiles = new string[10, 10];
            string[,][] AllNewRoomFilesData = new string[10, 10][];
            string filePath = "";

            // Iterate through all the rooms and generate paths for the stream reader
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    AllNewRoomFiles[x, y] = @"..\..\..\newrooms\" + x + y + ".room";
                }
            }

            // Iterate through all the room paths and store the data
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    filePath = AllNewRoomFiles[x, y];
                    AllNewRoomFilesData[x, y] = System.IO.File.ReadAllLines(filePath);
                }
            }

            return AllNewRoomFilesData;
        }

        public static void WriteNewsFromRoomFiles(string[,][] AllNewRoomFilesData)
        {
            int lineNumber = 0;
            string[,] AllRoomFiles = new string[10, 10];
            string filePath = @"..\..\..\newrooms\output.txt";
            string[] fileData = new string[100];
            int newsIndex = 18;

            // Iterate through all the rooms and grab news= string
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    // Why does this have to be backwards? Coordinates are difficult.
                    fileData[lineNumber] = AllNewRoomFilesData[y, x][newsIndex];
                    lineNumber++;
                }
            }


            
            // Write the fileData string array to file
                System.IO.File.WriteAllLines(filePath, fileData);
        }
    }

        

}

