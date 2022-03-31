using System;
using System.IO;
using System.Numerics;
using System.Text;

namespace ProgrammersLv1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            string[] input = sr.ReadLine().Split(' ');
            BigInteger quotient = BigInteger.Parse(input[0]);
            BigInteger remainder = BigInteger.Parse(input[1]);

            BigInteger cost = quotient / remainder;
            BigInteger remainedCost = quotient % remainder;

            sw.WriteLine(cost);
            sw.WriteLine(remainedCost);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
