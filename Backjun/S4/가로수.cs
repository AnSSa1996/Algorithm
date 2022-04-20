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

            List<int> lst = new List<int>();

            int N = int.Parse(sr.ReadLine());
            int currentNum = int.Parse(sr.ReadLine());

            int gcd = 0;
            for (int i = 1; i < N; i++)
            {
                int nextNum = int.Parse(sr.ReadLine());
                int dif = nextNum - currentNum;
                lst.Add(dif);
                currentNum = nextNum;
                if (i == 1) gcd = dif;
                else gcd = GCD(gcd, dif);
            }

            int total = 0;
            lst.ForEach(x => total += x / gcd - 1);

            sw.WriteLine(total);

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