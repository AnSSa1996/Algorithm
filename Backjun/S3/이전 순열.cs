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

            int a = nums.Length - 1;
            int b = nums.Length - 1;
            for (int i = a - 1; i >= 0; i--) if (nums[i] <= nums[i + 1]) a--; else break;
            a -= 1;
            if (a == -1) goto end;


            for (int i = nums.Length - 1; i >= 0; i--) if (nums[a] <= nums[i]) b--; else break;
            swap(nums, a, b);
            int start = a + 1; int end = N - 1;
            while (start < end) swap(nums, start++, end--);

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
