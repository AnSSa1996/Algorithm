using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            string str = sr.ReadLine();
            BigInteger num = 0;
            BigInteger r = 1;
            foreach (char c in str)
            {
                num += (c - 'a' + 1) * r;
                num %= 1234567891;
                r *= 31;
                r %= 1234567891;
            }

            sw.WriteLine(num);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
