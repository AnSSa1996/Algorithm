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
                int[] A = new int[101];
                int[] B = new int[101];
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 1; j < nums.Length; j++) A[nums[j]]++;
                nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 1; j < nums.Length; j++) B[nums[j]]++;

                for (int j = 100; j >= 0; j--)
                {
                    if (A[j] > B[j]) { sw.WriteLine("A"); break; }
                    else if (A[j] < B[j]) { sw.WriteLine("B"); break; }
                    else if (j == 0) sw.WriteLine("D");
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}