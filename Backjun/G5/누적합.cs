using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int H = inputs[1];

            int[] UP = new int[H + 1];
            int[] DOWN = new int[H + 1];


            bool check = true;
            for (int i = 0; i < N; i++)
            {
                int h = int.Parse(sr.ReadLine());
                if (check)
                {
                    UP[h] += 1;
                }
                else
                {
                    DOWN[h] += 1;
                }

                check = !check;
            }

            for (int i = H - 1; i >= 0; i--)
            {
                UP[i] += UP[i + 1];
                DOWN[i] += DOWN[i + 1];
            }

            int min = int.MaxValue;
            int count = 0;
            for (int i = 1; i <= H; i++)
            {
                if (min > UP[i] + DOWN[H - i + 1])
                {
                    min = UP[i] + DOWN[H - i + 1];
                    count = 1;
                    continue;
                }
                if (min == UP[i] + DOWN[H - i + 1])
                {
                    count++;
                }
            }

            sw.WriteLine($"{min} {count}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}