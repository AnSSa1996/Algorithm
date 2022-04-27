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

            int N = int.Parse(sr.ReadLine());
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] distinctNums = nums.OrderBy(x => x).Distinct().ToArray();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < distinctNums.Count(); i++) { dict.Add(distinctNums[i], i); }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++) sb.Append($"{dict[nums[i]]} ");
            sb.Remove(sb.Length - 1, 1);
            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}