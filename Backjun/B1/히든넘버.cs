using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            string str = sr.ReadLine();

            long total = 0;
            long sum = 0;
            for (int i = 0; i < N; i++)
            {
                char c = str[i];
                if (c >= 'A' && c <= 'z')
                {
                    total += sum;
                    sum = 0;
                }
                else
                {
                    sum *= 10;
                    sum += c - '0';
                }

                if (i == N - 1) total += sum;
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}