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

            double[] inputs = Array.ConvertAll(sr.ReadLine().Split(), double.Parse);

            double result = inputs[0] * inputs[1] / inputs[2];
            double result2 = inputs[0] / inputs[1] * inputs[2];

            if (result < result2) result = result2;

            sw.WriteLine((int)Math.Truncate((result)));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
