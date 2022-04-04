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

            sr.ReadLine();
            int[] hel = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] vest = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int max = hel.Max() + vest.Max();

            sw.WriteLine(max);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
