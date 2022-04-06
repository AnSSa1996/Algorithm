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

            int sum = Enumerable.Range('A', 26).Sum();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int tempSum = sr.ReadLine().ToArray().Distinct().Sum(x => (int)x);
                sw.WriteLine(sum - tempSum);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}