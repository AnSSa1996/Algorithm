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

            int[,] fraction = new int[2001, 2001];
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int D1 = inputs[0]; int D2 = inputs[1];
            int cnt = 0;
            for (int a = D1; a <= D2; a++)
            {
                for (int b = 1; b <= a; b++)
                {
                    int gcd = GCD(a, b);
                    int tempA = a / gcd; int tempB = b / gcd;
                    if (fraction[tempA, tempB] == 0) { cnt++; fraction[tempA, tempB] = 1; }
                }
            }

            sw.WriteLine(cnt);

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
