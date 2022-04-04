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

            List<int> nums = new List<int>();

            for (int i = 0; i < 10; i++) nums.Add(int.Parse(sr.ReadLine()));

            sw.WriteLine(nums.Sum() / 10);
            sw.WriteLine(nums.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
