using System;

namespace project_andromeda
{
    class andromeda
    {
        static void Main()
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
            //Sets ghost position to be same as player before player input
            ghost[0] = player[0];
            ghost[1] = player[1];
            do
            {
                Console.WriteLine($"Your position is x {player[0]}, y {player[1]}.");
                Console.WriteLine("Choose a direction. N/E/S/W\n\n");
                temp = Console.ReadLine();
                do
                {
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
                        default:
                            input = 1;
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                } while (input == 1);
                foreach (int value in player)
                {
                    //Tests if the player has entered an input that puts them out of bounds, and resets their position to their previous known location
                    if ((value < 0) || (value > xaxis[xaxis.Length]) || (value > yaxis[yaxis.Length]))
                    {
                        Console.WriteLine("Out of bounds.");
                        player[0] = ghost[0];
                        player[1] = ghost[1];
                    }
                }
            } while (temp = );
        }
    }
}
