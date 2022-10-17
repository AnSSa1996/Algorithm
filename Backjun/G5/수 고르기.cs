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

            int N = inputs[0]; int M = inputs[1];
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++) nums.Add(int.Parse(sr.ReadLine()));
            nums.Sort();

            int startIndex = 0;
            int endIndex = 0;
            int min = int.MaxValue;
            while (startIndex < N && endIndex < N)
            {
                int dif = nums[endIndex] - nums[startIndex];
                if (dif >= M)
                {
                    min = Math.Min(dif, min);
                    startIndex++;
                }
                else
                {
                    endIndex++;
                }
            }

            sw.WriteLine(min);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
