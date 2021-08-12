using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace project_andromeda
{
    public class UserInterface
    {
        public static int ReadLength(string x)
        {
            int count = 0;
            bool complete = false;
            StreamReader sr = new StreamReader(@"..\..\..\data\textdata.txt");
            do
            {
                string line = sr.ReadLine();
                if (line == x)
                {
                    while (line != "<stop>")
                    {
                        line = sr.ReadLine();
                        count++;
                    }
                    complete = true;
                }
            } while (complete == false);
            sr.Close();
            return count;
        }
        public static string[] ReadData(string x)
        {
            string[] textBody = new string[ReadLength(x) - 1];
            bool complete = false;
            StreamReader sr = new StreamReader(@"..\..\..\data\textdata.txt");
            do
            {
                string line = sr.ReadLine();
                if (line == x)
                {
                    for (int i = 0; i < textBody.Length; i++)
                    {
                        textBody[i] = sr.ReadLine();
                    }
                    complete = true;
                }
            } while (complete == false);
            sr.Close();
            return textBody;
        }
        public static void FormatMargin(ref string[] textBody, int MARGINSIZE)
        {
            Array.Resize(ref textBody, textBody.Length + (MARGINSIZE * 2));
            for (int i = textBody.Length - MARGINSIZE; i >= MARGINSIZE; i--)
            {
                textBody[i] = textBody[i - MARGINSIZE];
            }
            for (int i = 0; i < MARGINSIZE; i++)
            {
                textBody[i] = "";
                textBody[i + textBody.Length - MARGINSIZE] = "";
            }
        }
        public static void FormatBorder(ref string[] textBody, int MARGINSIZE)
        {
            string horizon = "";
            int max = GetArrayWidth(textBody);
            for (int i = 0; i < max + MARGINSIZE; i++)
            {
                horizon += "_";
            }
            textBody[0] = " " + horizon;
            for (int i = 1; i < textBody.Length; i++)
            {
                textBody[i] = "| " + textBody[i].PadRight(max) + " |";
            }
            textBody[textBody.Length - 1] = "|" + horizon + "|";
        }
        public static int GetArrayWidth(string[] x)
        {
            int max = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i].Length > max)
                {
                    max = x[i].Length;
                }
            }
            return max;
        }
        public static void MainDisplay(string x)
        {
            const int MARGINSIZE = 2;
            Console.Clear();
            if (x != "null")
            {
                string[] textBody = ReadData(x);
                FormatMargin(ref textBody, MARGINSIZE);
                FormatBorder(ref textBody, MARGINSIZE);
                for (int i = 0; i < textBody.Length; i++)
                {
                    Console.WriteLine(textBody[i]);
                }
            }
        }
    }
}
