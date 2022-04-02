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

            int x = inputs[0];
            int y = inputs[1];
            int w = inputs[2];
            int h = inputs[3];

            List<int> lst = new List<int>();
            lst.Add(x);
            lst.Add(y);
            lst.Add(Math.Abs(w - x));
            lst.Add(Math.Abs(h - y));
            int result = lst.Min();

            sw.WriteLine(result);
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}