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

            BigInteger[] inputs = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);
            BigInteger left = inputs.Min();
            BigInteger right = inputs.Max();
            BigInteger length = right - left - 1;

            for (BigInteger i = left + 1; i < right; i++)
            {
                if (i == right - 1) sb.Append(i);
                else sb.Append($"{i} ");
            }

            if (length == -1) length = 0;
            sw.WriteLine(length);
            sw.WriteLine(sb);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
