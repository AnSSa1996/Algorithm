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
            int nums = sr.ReadLine().ToArray().Sum(x => x - '0');

            sw.WriteLine(nums);

            sw.Close();
            sr.Close();
        }
    }
}
