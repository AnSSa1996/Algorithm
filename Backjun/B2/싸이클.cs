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

            List<int> nums = new List<int>();
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0];
            int P = inputs[1];

            nums.Add(N);

            int index = 0;
            int temp = N;
            while (true)
            {
                temp = temp * N % P;
                if (nums.Contains(temp))
                {
                    index = nums.IndexOf(temp);
                    break;
                }
                else
                {
                    nums.Add(temp);
                }
            }

            sw.WriteLine(nums.Count() - index);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}