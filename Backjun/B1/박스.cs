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
            for (int c = 0; c < N; c++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int Y = inputs[0];
                int X = inputs[1];

                List<List<int>> lst = new List<List<int>>();

                for (int i = 0; i < Y; i++) lst.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());

                int total = 0;
                for (int x = 0; x < X; x++)
                {
                    int t = 0;
                    int cnt = 0;
                    for (int y = 0; y < Y; y++)
                    {
                        if (lst[y][x] == 1) cnt += 1;
                        else t += cnt;
                    }
                    total += t;
                }
                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}