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
            StringBuilder resultSb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int left = inputs[0];
                int right = inputs[1];

                int gcd = GCD(left, right);

                sw.WriteLine($"{left * right / gcd} {gcd}");
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