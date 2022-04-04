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

            int N = int.Parse(sr.ReadLine()) - 1;

            int n = 1;
            while (true)
            {
                if (n * n + n == N) break;
                n++;
            }

            sw.WriteLine(n);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
