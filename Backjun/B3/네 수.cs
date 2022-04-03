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

            string[] inputs = sr.ReadLine().Split();

            long left = long.Parse(string.Concat(inputs[0], inputs[1]));
            long right = long.Parse(string.Concat(inputs[2], inputs[3]));

            sw.WriteLine(left + right);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
