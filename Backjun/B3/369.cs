using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            int count = 0;

            for (int num = 1; num <= N; num++)
            {
                var numArray = num.ToString().ToArray();
                foreach (var c in numArray)
                {
                    if (c == '3' || c == '6' || c == '9')
                    {
                        count++;
                    }
                }
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
