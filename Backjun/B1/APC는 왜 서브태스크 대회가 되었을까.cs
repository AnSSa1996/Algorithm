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

            int N = inputs[0];
            int L = inputs[1];
            int K = inputs[2];

            int[] subTasks = new int[3];
            for (int i = 0; i < N; i++)
            {
                int[] costs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int count = 0;
                if (costs[0] <= L) count++; if (costs[1] <= L) count++;

                if (count == 0) continue;
                subTasks[count]++;
            }

            int result = 0;

            result += Math.Min(subTasks[2], K) * 140;
            result += Math.Min(subTasks[1], K - subTasks[2]) * 100;

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}