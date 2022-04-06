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
            int N = inputs[1];

            List<int> nums = Array.ConvertAll(sr.ReadLine().Split(','), int.Parse).ToList();

            for (int i = 0; i < N; i++)
            {
                List<int> tempList = new List<int>();
                for (int j = 0; j < nums.Count - 1; j++)
                {
                    tempList.Add(nums[j + 1] - nums[j]);
                }
                nums = tempList;
            }

            sw.WriteLine(string.Join(",", nums));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}