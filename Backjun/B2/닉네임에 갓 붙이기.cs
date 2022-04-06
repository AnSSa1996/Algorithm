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

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                List<string> strLst = sr.ReadLine().Split().ToList();
                strLst.RemoveAt(0);

                sw.WriteLine($"god{string.Join("", strLst)}");
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}