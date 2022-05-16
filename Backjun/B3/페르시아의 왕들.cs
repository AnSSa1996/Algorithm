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

            while (true)
            {
                int[] years = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (years[0] == 0 && years[1] == 0 && years[2] == 0 && years[3] == 0) break;

                int max = 0;
                int min = int.MaxValue;

                for (int start = 0; start < 2; start++)
                {
                    for (int end = 2; end < 4; end++)
                    {
                        int current = years[end] - years[start];
                        if (max < current) max = current;
                        if (min > current) min = current;
                    }
                }

                sw.WriteLine($"{min} {max}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}