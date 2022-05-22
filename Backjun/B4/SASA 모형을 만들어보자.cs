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
            int left = inputs[0]; int right = inputs[1];
            left /= 2; right /= 2;
            sw.WriteLine(Math.Min(left, right));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
