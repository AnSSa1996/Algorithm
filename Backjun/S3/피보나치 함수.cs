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
            int[] zeroDp = new int[41];
            int[] oneDp = new int[41];

            zeroDp[0] = 1; zeroDp[1] = 0;
            oneDp[0] = 0; oneDp[1] = 1;

            for (int i = 2; i <= 40; i++)
            {
                zeroDp[i] = zeroDp[i - 1] + zeroDp[i - 2];
                oneDp[i] = oneDp[i - 1] + oneDp[i - 2];
            }
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                sw.WriteLine($"{zeroDp[num]} {oneDp[num]}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
