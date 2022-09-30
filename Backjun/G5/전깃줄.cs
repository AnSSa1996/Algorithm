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

            int L = int.Parse(sr.ReadLine());
            List<(int L, int R)> Lines = new List<(int L, int R)>();
            int max = 0;
            int[] dp = new int[L];
            for (int i = 0; i < L; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                Lines.Add((inputs[0], inputs[1]));
            }
            Lines.Sort((a, b) => a.L.CompareTo(b.L));

            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (Lines[i].R > Lines[j].R && dp[j] > dp[i])
                        dp[i] = dp[j];
                }
                dp[i] += 1;
            }

            sw.WriteLine(L - dp.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}