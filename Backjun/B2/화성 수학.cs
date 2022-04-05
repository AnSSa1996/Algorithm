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
                string[] str = sr.ReadLine().Split();
                double num = double.Parse(str[0]);

                for (int j = 1; j < str.Length; j++)
                {
                    if (str[j] == "@") num *= 3;
                    else if (str[j] == "%") num += 5;
                    else num -= 7;
                }

                sw.WriteLine($"{num:f2}");
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
