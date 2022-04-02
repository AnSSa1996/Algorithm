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
            int InitN = N;

            while (N > 0)
            {
                StringBuilder tempSb = new StringBuilder();
                for (int i = N; i < InitN; i++)
                {
                    tempSb.Append(" ");
                }
                for (int i = 0; i < N; i++)
                {
                    tempSb.Append("*");
                }
                sb.Append(tempSb.ToString()).AppendLine();
                N--;
            }

            sw.Write(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}