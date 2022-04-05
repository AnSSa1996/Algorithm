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
                sw.WriteLine($"{str.First().ToString().ToUpper()}{str.Substring(1)}");
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
	