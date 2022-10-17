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

            BigInteger[] inputs = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);
            BigInteger N = inputs[0]; BigInteger M = inputs[1];

            List<BigInteger> judges = new List<BigInteger>();
            for (BigInteger i = 0; i < N; i++) judges.Add(BigInteger.Parse(sr.ReadLine()));

            BigInteger start = 0;
            BigInteger end = judges.Max() * M;

            while (start <= end)
            {
                BigInteger mid = (start + end) / 2;
                BigInteger count = 0;
                foreach (var judge in judges)
                {
                    count += mid / judge;
                }

                if (count < M)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            sw.WriteLine(start);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
