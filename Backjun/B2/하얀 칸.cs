using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            List<string> chess = new List<string>();

            for (int i = 0; i < 8; i++) chess.Add(sr.ReadLine());


            int count = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (chess[y][x] != 'F') continue;
                    if ((y + x) % 2 == 0) count++;
                }
            }

            sw.WriteLine(count);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}