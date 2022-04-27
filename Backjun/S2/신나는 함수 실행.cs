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

            long[,,] dp = new long[21, 21, 21];
            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int a = inputs[0]; int b = inputs[1]; int c = inputs[2];
                if (a == -1 && b == -1 && c == -1) break;

                sw.WriteLine($"w({a}, {b}, {c}) = {recursive(a, b, c)}");
            }

            long recursive(int a, int b, int c)
            {
                if (a <= 0 || b <= 0 || c <= 0) return 1;
                else if (a > 20 || b > 20 || c > 20) return recursive(20, 20, 20);
                else if (dp[a, b, c] != 0) return dp[a, b, c];
                else if (a < b && b < c) dp[a, b, c] = recursive(a, b, c - 1) + recursive(a, b - 1, c - 1) - recursive(a, b - 1, c);
                else dp[a, b, c] = recursive(a - 1, b, c) + recursive(a - 1, b - 1, c) + recursive(a - 1, b, c - 1) - recursive(a - 1, b - 1, c - 1);
                return dp[a, b, c];
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}