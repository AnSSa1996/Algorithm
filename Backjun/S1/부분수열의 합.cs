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

            int N = int.Parse(sr.ReadLine());
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            Array.Sort(nums);

            int count = 0;
            foreach (int num in nums)
            {
                if (count + 1 < num) break;
                else
                {
                    count += num;
                }
            }

            sw.WriteLine(count + 1);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}