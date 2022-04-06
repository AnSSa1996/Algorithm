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

            int a = inputs[0]; int b = inputs[1]; int c = inputs[2];
            int d = inputs[3]; int e = inputs[4]; int f = inputs[5];

            int y = 0;
            if ((b * d - e * a) != 0) y = (c * d - f * a) / (b * d - e * a);
            else if (c != 0) y = a + b / c;
            int x = 0;
            if (a != 0) x = (c - b * y) / a;
            else if (d != 0) x = (f - e * y) / d;

            sw.WriteLine($"{x} {y}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}