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

            string[] str = sr.ReadLine().Split();
            long A = str[0].ToArray().Sum(x => x - '0');
            long B = str[1].ToArray().Sum(x => x - '0');

            sw.WriteLine(A * B);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}