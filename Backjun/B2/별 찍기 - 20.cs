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

            StringBuilder firstSb = new StringBuilder();
            StringBuilder secondSb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());

            firstSb.Append(string.Concat(Enumerable.Repeat("* ", N)));
            secondSb.Append(string.Concat(Enumerable.Repeat(" *", N)));

            StringBuilder resultSb = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                if (i % 2 == 0) resultSb.AppendLine(firstSb.ToString());
                else resultSb.AppendLine(secondSb.ToString());
            }

            sw.Write(resultSb);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
