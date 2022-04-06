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
            int max = -1;

            for (int i = 0; i < N; i++)
            {
                int[] dices = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                var temp = dices.GroupBy(x => x).OrderByDescending(g => g.Count());
                int count = temp.Count();
                int total = 0;
                if (count == 1)
                {
                    total = 50000 + temp.First().Key * 5000;
                }
                else if (count == 2 && temp.First().Count() == 3)
                {
                    total = 10000 + temp.First().Key * 1000;
                }
                else if (count == 2)
                {
                    int[] twoDices = temp.Select(x => x.Key).Take(2).ToArray();
                    total = 2000 + twoDices[0] * 500 + twoDices[1] * 500;
                }
                else if (count == 3)
                {
                    total = 1000 + temp.First().Key * 100;
                }
                else
                {
                    total = dices.Max() * 100;
                }

                max = Math.Max(total, max);
            }

            sw.WriteLine(max);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}