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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int Value = inputs[1];
            List<int> coinList = new List<int>();
            for (int i = 0; i < N; i++) coinList.Add(int.Parse(sr.ReadLine()));
            int[] dp = new int[Value + 1];
            dp[0] = 1;

            foreach (var coin in coinList)
            {
                for (int index = 1; index <= Value; index++)
                {
                    if (index - coin >= 0)
                    {
                        dp[index] += dp[index - coin];
                    }
                }
            }

            sw.WriteLine(dp[Value]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}