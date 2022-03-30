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


            BigInteger result = 0;
            for (int i=0; i<5; i++)
            {
                result += BigInteger.Parse(sr.ReadLine());
            }

            sw.WriteLine(result);
            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
