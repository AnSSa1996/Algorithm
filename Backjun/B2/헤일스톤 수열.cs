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

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                int max = num;
                while (true)
                {
                    if (num == 1) break;
                    if (num % 2 == 0) num /= 2;
                    else
                    {
                        num = num * 3 + 1;
                        max = Math.Max(max, num);
                    }
                }
                sw.WriteLine(max);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}