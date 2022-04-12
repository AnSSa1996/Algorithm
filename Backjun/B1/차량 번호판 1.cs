using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


            string str = sr.ReadLine();
            int total = 0;

            char currentChar = str[0];
            if (currentChar == 'd') total = 10;
            else total = 26;
            for (int i = 1; i < str.Length; i++)
            {
                char nextChar = str[i];
                int next = 0;

                if (nextChar == 'd') next = 10;
                else next = 26;
                if (nextChar == currentChar) next--;
                currentChar = nextChar;
                total *= next;
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}