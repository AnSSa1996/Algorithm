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
            int K = int.Parse(sr.ReadLine());
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            Array.Sort(nums);
            List<int> dif = new List<int>();
            for (int i = 1; i < nums.Length; i++) { dif.Add(nums[i] - nums[i - 1]); }
            dif.Sort();
            while (true)
            {
                if (K <= 1) break;
                if (dif.Count() == 0) break;
                K--;
                dif.RemoveAt(dif.Count() - 1);
            }
            sw.WriteLine(dif.Sum());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
