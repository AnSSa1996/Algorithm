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
            int[] cows = Enumerable.Repeat(-1, 11).ToArray();

            int cnt = 0;
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int cow = inputs[0];
                int road = inputs[1];

                if (cows[cow] == -1)
                {
                    cows[cow] = road;
                    continue;
                }

                if (cows[cow] != road)
                {
                    cows[cow] = road;
                    cnt++;
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
