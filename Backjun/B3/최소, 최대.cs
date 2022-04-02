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

            int N = int.Parse(sr.ReadLine());
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            sw.WriteLine($"{inputs.Min()} {inputs.Max()}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
