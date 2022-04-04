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
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(sr.ReadLine());

            sb.AppendLine(string.Concat(Enumerable.Repeat("* ", (N + 1) / 2)));
            sb.AppendLine(string.Concat(Enumerable.Repeat(" *", N / 2)));

            for (int i = 0; i < N; i++)
            {
                sw.Write(sb);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
 