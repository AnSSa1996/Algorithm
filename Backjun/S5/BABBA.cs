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

            List<Tuple<int, int>> dp = new List<Tuple<int, int>>();

            dp.Add(new Tuple<int, int>(0, 1));
            dp.Add(new Tuple<int, int>(1, 1));
            dp.Add(new Tuple<int, int>(1, 2));

            int N = int.Parse(sr.ReadLine()) - 1;
            for (int i = 3; i <= N; i++)
            {
                dp.Add(new Tuple<int, int>(dp[i - 2].Item1 + dp[i - 1].Item1, dp[i - 2].Item2 + dp[i - 1].Item2));
            }

            sw.WriteLine($"{dp[N].Item1} {dp[N].Item2}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
