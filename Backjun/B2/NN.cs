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

            string str = string.Concat(Enumerable.Repeat(inputs[0], inputs[0]));

            if (str.Length >= inputs[1]) sw.WriteLine(str.Substring(0, inputs[1]));
            else sw.WriteLine(str);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}