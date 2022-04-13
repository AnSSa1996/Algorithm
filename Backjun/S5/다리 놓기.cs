using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

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
                BigInteger[] inputs = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);
                BigInteger result = Factorial(inputs[1]) / Factorial(inputs[1] - inputs[0]) / Factorial(inputs[0]);

                sw.WriteLine(result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static BigInteger Factorial(BigInteger num)
        {
            if (num == 0) return 1;
            if (num == 1) return num;
            else return Factorial(num - 1) * num;
        }
    }
}
