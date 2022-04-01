using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            List<int> A = new List<int>();
            List<int> B = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                A.Add(int.Parse(sr.ReadLine()));
            }
            for (int i = 0; i < 2; i++)
            {
                B.Add(int.Parse(sr.ReadLine()));
            }

            int a = A.OrderByDescending(x => x).Take(3).Sum();
            int b = B.Max();

            sw.Write($"{a + b}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
