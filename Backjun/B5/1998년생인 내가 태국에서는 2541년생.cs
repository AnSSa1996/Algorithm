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

            BigInteger inputA = BigInteger.Parse(sr.ReadLine());

            BigInteger A = (inputA - 543);

            sw.WriteLine(A);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
