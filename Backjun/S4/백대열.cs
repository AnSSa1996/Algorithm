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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(':'), int.Parse);
            int A = inputs[0];
            int B = inputs[1];
            int gcd = GCD(A, B);

            sw.WriteLine($"{A / gcd}:{B / gcd}");

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

