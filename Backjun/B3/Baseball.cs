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
                int Y = 0;
                int K = 0;
                for (int j = 0; j < 9; j++)
                {
                    int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    Y += nums[0];
                    K += nums[1];
                }
                if (Y > K) sw.WriteLine("Yonsei");
                else if (Y < K) sw.WriteLine("Korea");
                else sw.WriteLine("Draw");
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
