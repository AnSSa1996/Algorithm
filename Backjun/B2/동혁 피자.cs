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

            int count = 1;
            while (true)
            {
                string str = sr.ReadLine();
                if (str == "0") break;
                double[] d_Array = Array.ConvertAll(str.Split(), double.Parse);
                double r = d_Array[0];
                double w = d_Array[1];
                double h = d_Array[2];

                double sqR = Math.Sqrt(Math.Pow(w / 2, 2) + Math.Pow(h / 2, 2));

                if (r >= sqR) sw.WriteLine($"Pizza {count} fits on the table.");
                else sw.WriteLine($"Pizza {count} does not fit on the table.");
                count++;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}