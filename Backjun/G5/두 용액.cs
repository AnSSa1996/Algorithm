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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Array.Sort(nums);
            int left = 0;
            int right = N - 1;

            int result = int.MaxValue;

            int resultLeft = 0;
            int resultRight = 0;

            while (left < right)
            {
                int leftNum = nums[left];
                int rightNum = nums[right];

                int value = rightNum + leftNum;
                int abs = Math.Abs(value);
                if (abs < result)
                {
                    resultLeft = leftNum;
                    resultRight = rightNum;
                    result = abs;
                }

                if (value == 0) break;
                if (value < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            sw.WriteLine($"{resultLeft} {resultRight}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}