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

            int a = sr.ReadLine().Length;
            int b = sr.ReadLine().Length;

            if (a < b) sw.WriteLine("no");
            else sw.WriteLine("go");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
