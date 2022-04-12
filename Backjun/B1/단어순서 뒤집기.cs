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

            for (int i = 1; i <= N; i++)
            {
                string[] strs = sr.ReadLine().Split();
                Array.Reverse(strs);

                sw.WriteLine($"Case #{i}: {string.Join(" ", strs)}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}