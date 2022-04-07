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

            int A = inputs[0];
            int B = inputs[1];
            int V = inputs[2];

            int count = ((V - B) + (A - B) - 1) / (A - B);

            sw.WriteLine(count);


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}