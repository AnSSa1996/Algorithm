using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            var N = long.Parse(sr.ReadLine());

            while (N > 0)
            {
                long num = N % 2;
                N /= 2;
                sb.Append(num);
            }

            sw.WriteLine($"{new string(sb.ToString().Reverse().ToArray())}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}