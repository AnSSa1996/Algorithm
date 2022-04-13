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

            long N = long.Parse(sr.ReadLine());

            int total = 0;
            int num = 1;
            while (total < N)
            {
                num++;
                total += num;
            }

            sw.WriteLine(num - 1);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
