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

            string[] str = sr.ReadLine().Split('0');

            int left = str[0].ToArray().Sum(x => x == '@' ? 1 : 0);
            int right = str[1].ToArray().Sum(x => x == '@' ? 1 : 0);

            sw.WriteLine($"{left} {right}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}