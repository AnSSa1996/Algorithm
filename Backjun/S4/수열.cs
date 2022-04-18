using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            int[] IncreaseDp = new int[N + 1];
            int[] DecreaseDp = new int[N + 1];

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            IncreaseDp[0] = 1;
            DecreaseDp[0] = 1;
            for (int i = 1; i < N; i++)
            {
                if (nums[i] >= nums[i - 1]) IncreaseDp[i] = IncreaseDp[i - 1] + 1;
                else IncreaseDp[i] = 1;

                if (nums[i] <= nums[i - 1]) DecreaseDp[i] = DecreaseDp[i - 1] + 1;
                else DecreaseDp[i] = 1;
            }

            sw.WriteLine(Math.Max(IncreaseDp.Max(), DecreaseDp.Max()));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
