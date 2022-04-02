using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            double r = double.Parse(sr.ReadLine());

            double uR = r * r * Math.PI;
            double tR = r * r * 2;

            uR = Math.Round(uR, 6);
            tR = Math.Round(tR, 6);

            sw.WriteLine($"{uR:0.000000}");
            sw.WriteLine($"{tR:0.000000}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
