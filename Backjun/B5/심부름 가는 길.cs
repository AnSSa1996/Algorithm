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

            int total = 0;
            for (int i = 0; i < 4; i++)
            {
                total += int.Parse(sr.ReadLine());
            }

            sw.WriteLine($"{total / 60}");
            sw.WriteLine($"{total % 60}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}