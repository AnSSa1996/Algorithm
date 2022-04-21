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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            sw.WriteLine($"{1 - inputs[0]} {1 - inputs[1]} {2 - inputs[2]} {2 - inputs[3]} {2 - inputs[4]} {8 - inputs[5]}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}