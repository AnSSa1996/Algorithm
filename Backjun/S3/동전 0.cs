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
            int N = inputs[0];
            int cost = inputs[1];

            List<int> coin = new List<int>();
            for (int i = 0; i < N; i++) coin.Add(int.Parse(sr.ReadLine()));
            coin.Reverse();

            int cnt = 0;
            for (int i = 0; i < N; i++)
            {
                cnt += cost / coin[i];
                cost %= coin[i];
                if (cost == 0) break;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}