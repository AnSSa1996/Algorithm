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

            int train = inputs[0];
            int fly = inputs[1];
            int distance = inputs[2];

            int result = fly * distance / (train * 2);

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
