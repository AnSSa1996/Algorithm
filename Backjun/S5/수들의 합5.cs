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

            int[] num = Enumerable.Range(1, N).ToArray();
            int sum = 0;
            int end = 0;

            int count = 0;
            for (int start = 0; start < N; start++)
            {
                while (sum < N && end < N)
                {
                    sum += num[end];
                    end++;
                }
                if (sum == N) count++;
                sum -= num[start];
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
