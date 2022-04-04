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

            sr.ReadLine();
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            sw.WriteLine(inputs.Max() - inputs.Min());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
