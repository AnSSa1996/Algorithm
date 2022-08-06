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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                long[] nums = new long[10];
                for (int j = 0; j < 10; j++) nums[j] = 1;

                int N = int.Parse(sr.ReadLine());

                for (int index = 1; index < N; index++)
                {
                    for (int a = 0; a < 10; a++)
                    {
                        for (int b = 0; b < a; b++)
                        {
                            nums[b] += nums[a];
                        }
                    }
                }

                sw.WriteLine(nums.Sum());
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}