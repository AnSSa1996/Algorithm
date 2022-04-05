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
            char[] charArray = sr.ReadLine().ToArray();

            int A = charArray.Where(x => x == 'A').Count();
            int B = N - A;

            if (A > B) sw.WriteLine("A");
            else if (A < B) sw.WriteLine("B");
            else sw.WriteLine("Tie");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
