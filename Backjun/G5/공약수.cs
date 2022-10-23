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

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long gcd = inputs[0]; long lcm = inputs[1];

            long last = lcm / gcd;

            long A = 1; long B = last;

            for (int i = 1; i <= last / 2 + 1; i++)
            {
                long C = 0;
                long D = 0;
                if (last % i == 0)
                {
                    C = i;
                    D = last / C;

                    if (GCD(C, D) != 1) continue;
                    if (A + B > C + D)
                    {
                        A = C;
                        B = D;
                    }
                }
            }

            sw.WriteLine($"{A * gcd} {B * gcd}");
            sw.Flush();
            sw.Close();
            sr.Close();
            long GCD(long left, long right)
            {
                if (left % right == 0) return right;
                else return GCD(right, left % right);
            }
        }
    }
}
