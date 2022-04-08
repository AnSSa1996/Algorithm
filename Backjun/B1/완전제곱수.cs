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

            int start = int.Parse(sr.ReadLine());
            int end = int.Parse(sr.ReadLine());

            int[] dp = new int[(int)Math.Sqrt(end) + 1];
            List<int> lst = new List<int>();

            for (int i = 1; i * i <= end; i++) dp[i] = i * i;

            for (int num = start; num <= end; num++) if (dp.Contains(num)) lst.Add(num);

            if (lst.Sum() == 0) sw.WriteLine(-1);
            else
            {
                sw.WriteLine(lst.Sum());
                sw.WriteLine(lst.Min());
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}