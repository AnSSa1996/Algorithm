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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                Array.Sort(nums);

                int max = 0;
                for (int j = 2; j < N; j++)
                {
                    max = Math.Max(max, nums[j] - nums[j - 2]);
                }

                sw.WriteLine(max);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}