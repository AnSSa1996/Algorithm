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

            long N = long.Parse(sr.ReadLine());
            long temp = N;
            while (true)
            {
                if (N == 0) break;
                sb.Append(Math.Abs(N % -2));
                N = (long)Math.Ceiling((double)N / -2);
            }
            if (temp == 0) sw.WriteLine(0);
            else sw.WriteLine(new string(sb.ToString().Reverse().ToArray()));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
