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

            while (true)
            {
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int sum = nums.Sum();
                if (sum == 0) break;
                sw.WriteLine(sum);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
