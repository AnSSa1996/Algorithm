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

            int[] first = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int fc = first[0]; int fp = first[1];

            int[] second = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int sc = second[0]; int sp = second[1];

            long gcd = GCD(fp, sp);
            long lcm = fp * sp / gcd;

            long child = fc * lcm / fp + sc * lcm / sp;
            long parent = lcm;

            long answerGcd = GCD(child, parent);
            sw.WriteLine($"{child / answerGcd} {parent / answerGcd}");

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