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

            int numCount = inputs[0]; int cnt = inputs[1];
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int[] sum = new int[numCount - cnt + 1];

            int numSum = nums.Take(cnt).Sum();
            sum[0] = numSum;
            for (int i = 1; i <= (numCount - cnt); i++) { sum[i] = sum[i - 1] + nums[cnt + i - 1] - nums[i - 1]; }

            sw.WriteLine(sum.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
