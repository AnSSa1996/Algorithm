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
                string str = sr.ReadLine();
                int num = str[str.Length - 1] - '0';
                if (num % 2 == 0) sw.WriteLine("even");
                else sw.WriteLine("odd");
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
