using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            BigInteger[] inputs = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);
            BigInteger a = inputs[0]; BigInteger b = inputs[1]; BigInteger c = inputs[2];
            BigInteger recursive(BigInteger number, BigInteger N)
            {
                if (N == 1) return number % c;
                else
                {
                    BigInteger temp = recursive(number, N / 2);
                    if (N % 2 == 0) { return (temp * temp) % c; }
                    else return (temp * temp * number) % c;
                }
            }

            sw.WriteLine(recursive(a, b));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
