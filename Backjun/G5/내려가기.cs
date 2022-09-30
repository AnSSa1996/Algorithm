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

            int[] MAX_DP = new int[3];
            int[] MIN_DP = new int[3];

            int[] MAX_TEMP = new int[3];
            int[] MIN_TEMP = new int[3];

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            MAX_DP[0] = inputs[0]; MAX_DP[1] = inputs[1]; MAX_DP[2] = inputs[2];
            MIN_DP[0] = inputs[0]; MIN_DP[1] = inputs[1]; MIN_DP[2] = inputs[2];

            for (int i = 1; i < N; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                MAX_TEMP[0] = Math.Max(MAX_DP[0], MAX_DP[1]) + inputs[0];
                MAX_TEMP[1] = Math.Max(MAX_DP[0], Math.Max(MAX_DP[1], MAX_DP[2])) + inputs[1];
                MAX_TEMP[2] = Math.Max(MAX_DP[1], MAX_DP[2]) + inputs[2];

                MAX_DP[0] = MAX_TEMP[0];
                MAX_DP[1] = MAX_TEMP[1];
                MAX_DP[2] = MAX_TEMP[2];


                MIN_TEMP[0] = Math.Min(MIN_DP[0], MIN_DP[1]) + inputs[0];
                MIN_TEMP[1] = Math.Min(MIN_DP[0], Math.Min(MIN_DP[1], MIN_DP[2])) + inputs[1];
                MIN_TEMP[2] = Math.Min(MIN_DP[1], MIN_DP[2]) + inputs[2];


                MIN_DP[0] = MIN_TEMP[0];
                MIN_DP[1] = MIN_TEMP[1];
                MIN_DP[2] = MIN_TEMP[2];
            }

            int max = Math.Max(MAX_DP[0], Math.Max(MAX_DP[1], MAX_DP[2]));
            int min = Math.Min(MIN_DP[0], Math.Min(MIN_DP[1], MIN_DP[2]));

            sw.WriteLine($"{max} {min}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}