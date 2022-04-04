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

            long N = long.Parse(sr.ReadLine()) / 100 * 100;
            long F = long.Parse(sr.ReadLine());

            int count = 0;
            while (true)
            {
                if ((N + count) % F == 0) break;
                count++;
            }

            sw.WriteLine($"{count:00}");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
