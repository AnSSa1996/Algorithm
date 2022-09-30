using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int W = inputs[1];
            int[,] dp = new int[N + 1, W + 1];

            List<(int weight, int cost)> objestList = new List<(int weight, int cost)>();
            for (int i = 0; i < N; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                objestList.Add((inputs[0], inputs[1]));
            }

            for (int i = 0; i <= N; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0) continue;
                    else if (objestList[i - 1].weight <= w)
                        dp[i, w] = Math.Max(objestList[i - 1].cost + dp[i - 1, w - objestList[i - 1].weight], dp[i - 1, w]);
                    else
                        dp[i, w] = dp[i - 1, w];
                }
            }

            sw.WriteLine(dp[N, W]);

            sw.Close();
            sr.Close();
        }
    }
}
