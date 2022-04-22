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
            int budget = int.Parse(sr.ReadLine());

            int start = 0; int end = nums.Max();

            while (start <= end)
            {
                int mid = (start + end) / 2;

                int total = 0;
                for (int i = 0; i < N; i++) total += Math.Min(nums[i], mid);

                if (total > budget) { end = mid - 1; }
                else { start = mid + 1; }
            }

            sw.WriteLine(end);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}