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
            int N = inputs[0]; int M = inputs[1];

            List<int> cost = new List<int>();
            for (int i = 0; i < N; i++) cost.Add(int.Parse(sr.ReadLine()));

            int start = cost.Max(); int end = cost.Sum();

            while (start <= end)
            {
                int mid = (start + end) / 2;
                int havedMoney = mid;
                int cnt = 1;
                for (int i = 0; i < N; i++)
                {
                    if (cost[i] > havedMoney)
                    {
                        havedMoney = mid;
                        cnt++;
                    }
                    havedMoney -= cost[i];
                }

                if (cnt > M) { start = mid + 1; }
                else { end = mid - 1; }
            }

            sw.WriteLine(start);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}