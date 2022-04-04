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

            List<int> remainder = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                int N = int.Parse(sr.ReadLine());
                remainder.Add(N % 42);
            }

            int count = remainder.GroupBy(x => x).Count();

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
