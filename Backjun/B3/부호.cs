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

            for (int i = 0; i < 3; i++)
            {
                int N = int.Parse(sr.ReadLine());
                BigInteger sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += BigInteger.Parse(sr.ReadLine());
                }
                if (sum > 0) sw.WriteLine("+");
                else if (sum < 0) sw.WriteLine("-");
                else sw.WriteLine("0");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
