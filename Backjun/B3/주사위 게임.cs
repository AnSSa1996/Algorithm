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
            int MaxNum = 0;
            for (int i = 0; i < N; i++)
            {
                int results = 0;

                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                var threeNums = nums.GroupBy(x => x).Where(g => g.Count() == 3).Select(g => g.Key);
                var twoNums = nums.GroupBy(x => x).Where(g => g.Count() == 2).Select(g => g.Key);
                var oneNums = nums.GroupBy(x => x).Where(g => g.Count() == 1).Select(g => g.Key);

                if (threeNums.Count() > 0)
                {
                    results += 10000 + threeNums.First() * 1000;
                }
                else if (twoNums.Count() > 0)
                {
                    results += 1000 + twoNums.First() * 100;
                }
                else if (oneNums.Count() > 0)
                {
                    results += oneNums.Max() * 100;
                }
                MaxNum = Math.Max(MaxNum, results);
            }
            sw.WriteLine(MaxNum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}