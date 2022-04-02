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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split('/'), int.Parse);

            string result = "gosu";
            if (inputs[0] + inputs[2] <= inputs[1]) result = "hasu";

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
