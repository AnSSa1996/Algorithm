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
            int answer = int.Parse(sr.ReadLine());

            Array.Sort(nums);

            int start = 0;
            int end = nums.Length - 1;
            int cnt = 0;
            while (start != end)
            {
                int sum = nums[start] + nums[end];
                if (sum == answer) cnt++;
                if (sum < answer) start++;
                else if (sum >= answer) end--;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}