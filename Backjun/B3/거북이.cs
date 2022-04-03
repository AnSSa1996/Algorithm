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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int Height = inputs.OrderBy(x => x).ToArray()[2];
            int Width = inputs.OrderBy(x => x).ToArray()[0];

            sw.WriteLine(Height*Width);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
