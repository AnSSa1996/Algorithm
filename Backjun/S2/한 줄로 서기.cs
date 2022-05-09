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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] orders = new int[N];

            for (int i = 0; i < N; i++)
            {
                int index = nums[i];
                int count = 0;
                for (int j = 0; j < N; j++)
                {
                    if (count == index && orders[j] == 0) { orders[j] = i + 1; break; }
                    else if (orders[j] == 0) count++;
                }
            }

            sw.WriteLine(string.Join(" ", orders));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
