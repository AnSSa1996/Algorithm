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
                List<string> strArray = sr.ReadLine().Split().ToList();
                sw.Write(string.Join(" ", strArray.Skip(2).ToArray()));
                sw.WriteLine($" {strArray[0]} {strArray[1]}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
