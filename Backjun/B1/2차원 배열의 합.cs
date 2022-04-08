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

            List<List<int>> lst = new List<List<int>>();
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            for (int i = 0; i < inputs[0]; i++) lst.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int[] temps = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int startY = temps[0] - 1;
                int startX = temps[1] - 1;
                int endY = temps[2] - 1;
                int endX = temps[3] - 1;

                int total = 0;

                for (int y = startY; y <= endY; y++)
                {
                    for (int x = startX; x <= endX; x++)
                    {
                        total += lst[y][x];
                    }
                }

                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}