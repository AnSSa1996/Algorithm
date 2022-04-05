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

            int count = 0;
            int natural = 1;
            while (N > 0)
            {
                if (N < natural) natural = 1;
                N -= natural;
                natural++;
                count++;
            }

            sw.WriteLine(count);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
