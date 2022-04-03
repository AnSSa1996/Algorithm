using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int K = int.Parse(sr.ReadLine());
                sw.WriteLine($"{string.Concat(Enumerable.Repeat("=",K))}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
