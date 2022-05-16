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

            while (true)
            {
                string str = sr.ReadLine();
                if (string.IsNullOrEmpty(str)) break;
                int[] inputs = Array.ConvertAll(str.Split(), int.Parse);
                int left = inputs[1] - inputs[0];
                int right = inputs[2] - inputs[1];
                int max = left > right ? left : right;

                sw.WriteLine(max - 1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}