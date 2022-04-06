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
            int num = inputs[0];
            int count = inputs[1];

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            bool[] checks = new bool[num + 1];

            for (int i = 0; i < count; i++)
            {
                for (int j = nums[i]; j <= num; j += nums[i])
                {
                    checks[j] = true;
                }
            }

            int total = 0;
            for (int i = 1; i <= num; i++) if (checks[i]) total += i;

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}