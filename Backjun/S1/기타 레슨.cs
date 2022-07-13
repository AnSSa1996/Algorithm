using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long N = inputs[0]; long L = inputs[1];
            long[] nums = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            long start = nums.Max();
            long end = nums.Sum();

            while (start <= end)
            {
                long mid = (start + end) / 2;
                long count = Calculate(mid);

                if (count <= L) end = mid - 1;
                else start = mid + 1;
            }

            sw.WriteLine(start);

            long Calculate(long size)
            {
                long empty = 0;
                long count = 0;
                for (long index = 0; index < N; index++)
                {
                    if (empty + nums[index] > size)
                    {
                        count++;
                        empty = 0;
                    }

                    empty += nums[index];
                }

                if (empty > 0) count++;
                return count;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}