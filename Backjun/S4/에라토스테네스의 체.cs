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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int K = inputs[1];

            bool[] eratos = new bool[N + 1];
            eratos[0] = true;
            eratos[1] = true;

            int result = Eratos(eratos, N, K);

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int Eratos(bool[] eratos, int N, int K)
        {
            int cnt = 0;
            int result = 0;
            for (int i = 2; i <= N; i++)
            {
                for (int j = i; j <= N; j += i)
                {
                    if (eratos[j] == true) continue;
                    else
                    {
                        eratos[j] = true;
                        cnt++;
                        if (cnt == K)
                        {
                            result = j;
                            goto end;
                        }
                    }
                }
            }
        end:
            return result;
        }
    }
}