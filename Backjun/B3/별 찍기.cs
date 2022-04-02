using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder resultSb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());

            resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - 1)));
            resultSb.AppendLine("*");

            for (int i = 2; i < N; i++)
            {
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - i)));
                resultSb.Append("*");
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", i * 2 - 3)));
                resultSb.Append("*").AppendLine();
            }
            if (N != 1)
                resultSb.AppendLine(string.Concat(Enumerable.Repeat("*", N * 2 - 1)));

            sw.Write(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
