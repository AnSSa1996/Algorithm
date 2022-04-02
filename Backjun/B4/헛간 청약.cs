using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int y = inputs[1] / inputs[3];
            int x = inputs[2] / inputs[3];

            int maxNum = Math.Min(inputs[0], x * y);

            sw.WriteLine(maxNum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
