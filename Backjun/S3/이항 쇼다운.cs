using System;
using System.IO;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            while (true)
            {
                long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

                if (inputs[0] == 0) break;
                long n = inputs[0]; long r = inputs[1];
                if (r > n - r) r = n - r;
                BigInteger total = 1;
                for (long i = n - r + 1; i <= n; i++) total *= i;
                for (long i = 1; i <= r; i++) total /= i;

                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
