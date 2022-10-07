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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int result = 0;

            for (int current = 1; current < nums.Length - 1; current++)
            {
                int left = nums[..current].Max();
                int right = nums[(current + 1)..].Max();

                int height = Math.Min(left, right);

                if (nums[current] < height)
                {
                    result += height - nums[current];
                }
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();

        }
    }
}