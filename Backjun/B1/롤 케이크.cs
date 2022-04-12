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

            int Cake = int.Parse(sr.ReadLine());
            int[] cakes = Enumerable.Repeat(1, Cake + 1).ToArray();

            int N = int.Parse(sr.ReadLine());
            int max = -1;
            int realMax = -1;

            int maxCount = 1;
            int realMaxCount = 1;
            for (int i = 1; i <= N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int cnt = 0;
                int preCnt = inputs[1] - inputs[0] + 1;

                for (int j = inputs[0]; j <= inputs[1]; j++)
                {
                    cnt += cakes[j];
                    cakes[j] = 0;
                }

                if (realMax < cnt)
                {
                    realMax = cnt;
                    realMaxCount = i;
                }

                if (preCnt > max)
                {
                    max = preCnt;
                    maxCount = i;
                }
            }

            sw.WriteLine(maxCount);
            sw.WriteLine(realMaxCount);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}