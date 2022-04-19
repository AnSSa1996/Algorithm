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
            int M = int.Parse(sr.ReadLine());

            int[] costs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Array.Sort(costs);
            int cnt = 0;

            int start = 0;
            int end = costs.Length - 1;

            while (start != end)
            {
                if (costs[start] + costs[end] == M)
                {
                    cnt++;
                    end--;
                }
                else if (costs[start] + costs[end] < M) start++;
                else end--;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

