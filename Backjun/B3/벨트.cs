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
            BigInteger currentDir = 0;
            BigInteger turn = 1;
            for (int i = 0; i < N; i++)
            {
                BigInteger[] inputs = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);
                BigInteger a = inputs[0];
                BigInteger b = inputs[1];
                BigInteger dir = inputs[2];

                turn = turn * b / a;
                currentDir = (currentDir + dir) % 2 == 0 ? 0 : 1;
            }

            sw.WriteLine($"{currentDir} {turn}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
