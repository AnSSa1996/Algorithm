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
            int sum = 0;

            for (int i = 1; i <= N; i++)
            {
                if (N % i == 0) sum += i;
            }

            sw.WriteLine(sum * 5 - 24);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
