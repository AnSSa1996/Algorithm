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
            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            long[] Factorial = new long[N + 20];
            Factorial[0] = 0; Factorial[1] = 1;
            for (int i = 2; i <= N; i++) Factorial[i] = Factorial[i - 1] * i;

            if (inputs[0] == 1)
            {
                List<int> numLst = Enumerable.Range(1, N).ToList();
                List<int> resultlst = new List<int>();

                Recursive(N, inputs[1]);
                sw.WriteLine(string.Join(' ', resultlst));

                void Recursive(long F, long Index)
                {
                    if (numLst.Count() == 0) return;
                    long M = Factorial[F] / F;
                    resultlst.Add(numLst[(int)((Index - 1) / M)]);
                    numLst.RemoveAt((int)((Index - 1) / M));
                    long nextIndex = Index - ((Index - 1) / M) * M;
                    Recursive(F - 1, nextIndex);
                }
            }
            else
            {
                long result = 0;
                List<int> numsLst = Enumerable.Range(1, N).ToList();
                for (int i = 1; i <= N; i++)
                {
                    Recursive2(N - i + 1, inputs[i]);
                }
                sw.WriteLine(result + 1);
                void Recursive2(long F, long index)
                {
                    long M = Factorial[F] / F;
                    int currentIndex = numsLst.IndexOf((int)index);
                    numsLst.RemoveAt(currentIndex);
                    result += M * currentIndex;
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
