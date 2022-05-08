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

            long Sum = 0;
            for (int i = 1; i <= N; i++)
            {
                Sum += (N / i) * i;
            }

            sw.WriteLine(Sum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}