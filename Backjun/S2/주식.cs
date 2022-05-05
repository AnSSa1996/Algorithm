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

            int T = int.Parse(sr.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                long total = 0;
                long max = 0;

                for (int index = (N - 1); index >= 0; index--)
                {
                    if (nums[index] > max) max = nums[index];
                    else total += max - nums[index];
                }

                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}