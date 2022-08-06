using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int D = inputs[0]; int N = inputs[1];
            int[] dp = new int[D + 2];
            dp[0] = 1; dp[1] = 1;

            for (int i = 2; i <= D; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }


            int x = dp[D - 3]; int y = dp[D - 2];
            int A = 1; int B = 1;

            while (true)
            {
                if (A * x + B * y == N) break;
                B++;
                if (A * x + B * y > N)
                {
                    A++; B = 1;
                }
            }

            sw.WriteLine(A);
            sw.WriteLine(B);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}