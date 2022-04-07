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

            int N = int.Parse(sr.ReadLine());
            if (N % 2 == 0) sw.WriteLine("I LOVE CBNU");
            else
            {
                sb.AppendLine(string.Concat(Enumerable.Repeat("*", N)));
                sb.Append(string.Concat(Enumerable.Repeat(" ", N / 2)));
                sb.AppendLine("*");
                for (int i = 1; i <= N / 2; i++)
                {
                    sb.Append(string.Concat(Enumerable.Repeat(" ", N / 2 - i)));
                    sb.Append("*");
                    sb.Append(string.Concat(Enumerable.Repeat(" ", i * 2 - 1)));
                    sb.AppendLine("*");
                }
                sw.Write(sb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}