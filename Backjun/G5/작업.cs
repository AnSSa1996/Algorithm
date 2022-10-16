using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            int[] nums = new int[N + 1];
            int[] dp = new int[N + 1];
            List<List<int>> Priority_Lst = new List<List<int>>();
            Priority_Lst.Add(new List<int>());
            for (int i = 1; i <= N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int W = inputs[0];
                nums[i] = W;
                int P_Count = inputs[1];

                List<int> currentClearLst = new List<int>();
                currentClearLst.Add(i);

                for (int j = 0; j < P_Count; j++)
                {
                    int p = inputs[2 + j];
                    currentClearLst.Add(p);
                }
                Priority_Lst.Add(currentClearLst);
            }

            for (int i = 1; i <= N; i++)
            {
                var time = 0;
                foreach (var current in Priority_Lst[i])
                {
                    time = Math.Max(time, dp[current]);
                }
                dp[i] = time + nums[i];
            }

            sw.WriteLine(dp.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}