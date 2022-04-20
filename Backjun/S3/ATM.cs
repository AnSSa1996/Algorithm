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
            int[] pfSum = new int[N + 1];

            List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            lst.Sort();

            int total = 0;

            for (int i = 0; i < N; i++)
            {
                if (i == 0) { pfSum[0] = lst[0]; total += lst[0]; continue; }
                pfSum[i] = pfSum[i - 1] + lst[i];
                total += pfSum[i];
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
