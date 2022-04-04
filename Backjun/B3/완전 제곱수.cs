using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            int count = 0;
            for (int i = 1; i < N; i++)
            {
                if (i * i - (i - 1) * (i - 1) > N) break;
                for (int j = 1; j < i; j++)
                {
                    if (i * i - j * j == N) count++;
                }
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
