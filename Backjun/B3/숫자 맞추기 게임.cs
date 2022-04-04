using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int testCase = 1;
            while (true)
            {
                int N0 = int.Parse(sr.ReadLine());
                if (N0 == 0) break;
                int N1 = N0 * 3;
                int N2 = (N1 % 2 == 0) ? N1 / 2 : (N1 + 1) / 2;
                int N3 = 3 * N2;
                int N4 = N3 / 9;

                if (N0 % 2 == 0) sw.WriteLine($"{testCase}. even {N4}");
                else sw.WriteLine($"{testCase}. odd {N4}");
                testCase++;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
