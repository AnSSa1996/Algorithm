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

            BigInteger input = BigInteger.Parse(sr.ReadLine());

            BigInteger A = input;


            sw.WriteLine($"{((A+4)/5)}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
