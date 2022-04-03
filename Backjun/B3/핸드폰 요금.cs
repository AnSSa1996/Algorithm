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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int Y = 0;
            int M = 0;

            for (int i = 0; i < N; i++)
            {
                int CurrentTime = nums[i];
                Y += ((CurrentTime + 30) / 30) * 10;
                M += ((CurrentTime + 60) / 60) * 15;
            }

            if (Y > M) sw.WriteLine($"M {M}");
            else if (Y == M) sw.WriteLine($"Y M {Y}");
            else sw.WriteLine($"Y {Y}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
