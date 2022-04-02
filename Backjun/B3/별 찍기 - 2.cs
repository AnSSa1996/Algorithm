using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
            int InitN = N;

            while (N > 0)
            {
                StringBuilder tempSb = new StringBuilder();
                for (int i = 1; i < N; i++)
                {
                    tempSb.Append(" ");
                }
                for (int i = N-1; i < InitN; i++)
                {
                    tempSb.Append("*");
                }
                resultSb.Append(tempSb.ToString()).AppendLine();
                N--;
            }

            sw.Write(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
