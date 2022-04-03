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

            int Sum = 0;
            for (int i = 0; i < N; i++) Sum += int.Parse(sr.ReadLine());
            Sum -= N - 1;

            sw.WriteLine(Sum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
