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
            while (true)
            {
                int currentNum = int.Parse(sr.ReadLine());
                if (currentNum == 0) break;
                if (currentNum % N == 0) sw.WriteLine($"{currentNum} is a multiple of {N}.");
                else sw.WriteLine($"{currentNum} is NOT a multiple of {N}.");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
