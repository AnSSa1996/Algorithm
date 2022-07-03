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

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long A = inputs[0]; long B = inputs[1];

            long gcd = GCD(A, B);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < gcd; i++) sb.Append(1);

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static long GCD(long left, long right)
        {
            if (right == 0) return left;
            else return GCD(right, left % right);
        }
    }
}