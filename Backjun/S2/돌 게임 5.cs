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

            long N = long.Parse(sr.ReadLine());
            if (N % 2 == 0) sw.WriteLine("CY");
            else sw.WriteLine("SK");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}