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
                int subjects = int.Parse(sr.ReadLine());
                int credit = 0;
                double score = 0;
                for (int j = 0; j < subjects; j++)
                {
                    double[] nums = Array.ConvertAll(sr.ReadLine().Split(), double.Parse);
                    credit += (int)nums[0];
                    score += nums[1] * nums[0];
                }
                score = Math.Round(score / credit, 1);
                sw.WriteLine($"{credit} {score:0.0}");
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
