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

            int N = (int.Parse(sr.ReadLine()) + 56) % 60;

            int alpha = N % 12;
            int ten = N % 10;

            sw.WriteLine($"{(char)('A' + alpha)}{ten}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}