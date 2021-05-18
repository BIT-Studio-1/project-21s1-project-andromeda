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
            for (int i = 0; i < xaxis.Length; i++)
            {
                xaxis[i] = i;
                yaxis[i] = i;
            }
        }
    }
}
