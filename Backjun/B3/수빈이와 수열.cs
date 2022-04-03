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

            long[] Dp = new long[N];
            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            Dp[0] = inputs[0];
            sb.Append($"{Dp[0]} ");
            for (int i = 1; i < N; i++)
            {
                Dp[i] = (i + 1) * inputs[i] - Dp.Sum();
                sb.Append($"{Dp[i]} ");
            }
            sb.Remove(sb.Length - 1, 1);

            sw.WriteLine(sb);
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
