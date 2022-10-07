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

            string left = sr.ReadLine();
            string right = sr.ReadLine();

            int L_length = left.Length;
            int R_length = right.Length;

            int[,] dp = new int[L_length + 1, R_length + 1];
            int result = 0;

            for (int L = 1; L <= L_length; L++)
            {
                for (int R = 1; R <= R_length; R++)
                {
                    if (left[L - 1] == right[R - 1])
                    {
                        dp[L, R] = dp[L - 1, R - 1] + 1;
                        if (result < dp[L, R]) result = dp[L, R];
                    }
                }
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();

        }
    }
}