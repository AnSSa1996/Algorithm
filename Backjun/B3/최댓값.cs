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

            int Y = 0;
            int X = 0;
            int max = 0;
            for (int i = 0; i < 9; i++)
            {
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int currentMax = nums.Max();

                if (max < currentMax)
                {
                    Y = i + 1;
                    X = Array.IndexOf(nums, nums.Max()) + 1;
                    max = currentMax;
                }
            }

            sw.WriteLine(max);
            sw.WriteLine($"{Y} {X}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
