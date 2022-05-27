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

            for (int i = 0; i < N; i++)
            {
                int[] nums = sr.ReadLine().Select(x => x - '0').ToArray();
                int total = 0;

                for (int j = 0; j < nums.Length; j++)
                {

                    if ((j + 1) % 2 != 0)
                    {
                        int temp = nums[j] * 2;
                        if (temp >= 10)
                        {
                            total += temp / 10 + temp % 10;
                        }
                        else
                        {
                            total += temp;
                        }
                    }
                    else
                    {
                        total += nums[j];
                    }
                }

                if (total % 10 == 0) sw.WriteLine("T");
                else sw.WriteLine("F");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
