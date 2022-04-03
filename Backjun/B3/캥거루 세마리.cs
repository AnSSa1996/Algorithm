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

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int a = nums[1] - nums[0];
            int b = nums[2] - nums[1];

            int result = Math.Max(a, b) - 1;
            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
