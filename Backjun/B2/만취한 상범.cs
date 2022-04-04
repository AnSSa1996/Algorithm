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

            for (int i = 0; i < N; i++)
            {
                int rooms = int.Parse(sr.ReadLine());
                int totalCount = 0;
                for (int j = 1; j <= rooms; j++)
                {
                    if (div(j) % 2 == 1) totalCount++;
                }
                sw.WriteLine(totalCount);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        public static int div(int n)
        {
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) count++;
            }
            return count;
        }
    }
}
