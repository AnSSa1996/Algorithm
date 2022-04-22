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

            int a = nums.Length - 2;
            while (a >= 0) if (nums[a] >= nums[a + 1]) { a--; } else { break; }
            if (a == -1) goto end;

            int b = nums.Length - 1;
            while (nums[a] > nums[b]) b--;
            swap(nums, a, b);
            a += 1; b = nums.Length - 1;
            while (a < b) swap(nums, a++, b--);

            end:

            if (a == -1) sw.WriteLine(-1);
            else sw.WriteLine(string.Join(" ", nums));
            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void swap(int[] nums, int a, int b)
        {
            int temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }
    }
}