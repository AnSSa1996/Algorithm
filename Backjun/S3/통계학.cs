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
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++) nums.Add(int.Parse(sr.ReadLine()));

            nums.Sort();
            int avg = (int)Math.Round(nums.Average(x => x));
            int mid = nums[(nums.Count() - 1) / 2];
            int mode = 0;
            int range = nums[nums.Count() - 1] - nums[0];

            var temp = nums.GroupBy(x => x).Select(a => new { num = a.Key, count = a.Count() });
            int modeMax = temp.Max(x => x.count);
            var tempMode = temp.Where(a => a.count == modeMax);
            if (tempMode.Count() > 1) mode = tempMode.Skip(1).First().num;
            else mode = tempMode.First().num;


            sw.WriteLine(avg);
            sw.WriteLine(mid);
            sw.WriteLine(mode);
            sw.WriteLine(range);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}	