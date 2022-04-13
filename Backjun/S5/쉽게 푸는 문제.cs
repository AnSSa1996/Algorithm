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

            int[] nums = new int[1002];

            int currentNum = 1;
            for (int i = 0; i <= 1000;)
            {
                for (int j = 1; j <= currentNum; j++)
                {
                    if (i >= 1001) break;
                    nums[i++] = currentNum;
                }
                currentNum++;
            }

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int start = inputs[0];
            int end = inputs[1];

            int total = 0;
            for (int i = start; i <= end; i++) total += nums[i - 1];

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
