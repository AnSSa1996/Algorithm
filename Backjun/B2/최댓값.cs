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

            int count = 0;
            int max = -1;
            for (int i = 1; i <= 9; i++)
            {
                int N = int.Parse(sr.ReadLine());
                if (N > max)
                {
                    max = N;
                    count = i;
                }
            }

            sw.WriteLine(max);
            sw.WriteLine(count);

            sw.Close();
            sr.Close();
        }
    }
}
