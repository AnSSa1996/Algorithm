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

            BigInteger[] inputs = Array.ConvertAll(sr.ReadLine().Split(' '), BigInteger.Parse);

            BigInteger A = inputs[0];
            BigInteger B = inputs[1];
            BigInteger C = inputs[2];


            sw.WriteLine($"{A + B + C}");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
