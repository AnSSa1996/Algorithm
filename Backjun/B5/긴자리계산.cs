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

            BigInteger A = BigInteger.Parse(sr.ReadLine());
            BigInteger B = BigInteger.Parse(sr.ReadLine());

            sw.WriteLine(A + B);
            sw.WriteLine(A - B);
            sw.WriteLine(A * B);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
