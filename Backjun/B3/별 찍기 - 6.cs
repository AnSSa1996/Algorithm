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

            for (int i = 0; i < N; i++)
            {
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", i)));
                resultSb.Append(string.Concat(Enumerable.Repeat("*", (N - i) * 2 - 1))).AppendLine();
            }
            sw.Write(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
