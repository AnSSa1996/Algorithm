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

            while (true)
            {
                int N = int.Parse(sr.ReadLine());
                if (N == 0) break;
                int total = 0;
                for (int i = 1; i <= N; i++) total += i * i;
                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}