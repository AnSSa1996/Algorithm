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

            for (int i = 1; i <= N; i++)
            {
                StringBuilder tempSb = new StringBuilder();
                tempSb.Append(string.Concat(Enumerable.Repeat("*", i)));
                tempSb.Append(string.Concat(Enumerable.Repeat(" ", (N - i) * 2)));
                tempSb.Append(string.Concat(Enumerable.Repeat("*", i)));
                resultSb.Append(tempSb).AppendLine();
            }

            for (int i = N-1; i > 0; i--)
            {
                StringBuilder tempSb = new StringBuilder();
                tempSb.Append(string.Concat(Enumerable.Repeat("*", i)));
                tempSb.Append(string.Concat(Enumerable.Repeat(" ", (N - i) * 2)));
                tempSb.Append(string.Concat(Enumerable.Repeat("*", i)));
                resultSb.Append(tempSb).AppendLine();
            }

            sw.Write(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
