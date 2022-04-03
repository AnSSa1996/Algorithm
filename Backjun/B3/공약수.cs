using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int totalGCD = inputs[0];
            for (int i = 1; i < N; i++) totalGCD = GCD(totalGCD, inputs[i]);

            for (int i = 1; i <= totalGCD; i++) if (totalGCD % i == 0) sw.WriteLine(i);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int GCD(int left, int right)
        {
            if (right == 0) return left;
            return GCD(right, left % right);
        }
    }
}
