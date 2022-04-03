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

            int left = 100;
            int right = 100;

            for (int i = 0; i < N; i++)
            {
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (nums[0] > nums[1]) right -= nums[0];
                else if(nums[0] < nums[1]) left -= nums[1];
            }

            sw.WriteLine(left);
            sw.WriteLine(right);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
