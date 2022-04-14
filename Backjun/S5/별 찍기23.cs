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
            StringBuilder resultSb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());

            resultSb.Append(string.Concat(Enumerable.Repeat("*", N)));
            resultSb.Append(string.Concat(Enumerable.Repeat(" ", (N - 1) * 2 - 1)));
            resultSb.AppendLine(string.Concat(Enumerable.Repeat("*", N)));

            for (int i = 1; i < (N - 1); i++)
            {
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", i)));
                resultSb.Append("*");
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - 2)));
                resultSb.Append("*");
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", (N - 1 - i) * 2 - 1)));
                resultSb.Append("*");
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - 2)));
                resultSb.AppendLine("*");
            }
            resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - 1)));
            resultSb.Append("*");
            resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - 2)));
            resultSb.Append("*");
            resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - 2)));
            resultSb.AppendLine("*");

            for (int i = N - 2; i >= 1; i--)
            {
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", i)));
                resultSb.Append("*");
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - 2)));
                resultSb.Append("*");
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", (N - 1 - i) * 2 - 1)));
                resultSb.Append("*");
                resultSb.Append(string.Concat(Enumerable.Repeat(" ", N - 2)));
                resultSb.AppendLine("*");
            }

            resultSb.Append(string.Concat(Enumerable.Repeat("*", N)));
            resultSb.Append(string.Concat(Enumerable.Repeat(" ", (N - 1) * 2 - 1)));
            resultSb.AppendLine(string.Concat(Enumerable.Repeat("*", N)));

            sw.Write(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
