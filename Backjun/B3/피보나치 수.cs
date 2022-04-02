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

            int N = int.Parse(sr.ReadLine());

            long[] Dp = new long[60];
            Dp[0] = 0;
            Dp[1] = 1;
            Dp[2] = 1;

            for (int i = 3; i < N + 1; i++)
            {
                Dp[i] = Dp[i - 1] + Dp[i - 2];
            }

            sw.WriteLine(Dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
