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
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int gcd = GCD(inputs[0], inputs[1]);
                sw.WriteLine(inputs[0] * inputs[1] / gcd);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int GCD(int left, int right)
        {
            if (right == 0) return left;
            else return GCD(right, left % right);
        }
    }
}
