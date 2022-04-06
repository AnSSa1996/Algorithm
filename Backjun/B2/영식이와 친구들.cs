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

            int N = inputs[0];
            int M = inputs[1];
            int L = inputs[2];

            int[] ballCount = new int[N];

            int count = 0;
            int Index = 0;
            while (true)
            {
                ballCount[Index]++;
                if (ballCount[Index] == M)
                {
                    break;
                }

                if (ballCount[Index] % 2 == 1)
                {
                    Index = Index + L < N ? Index + L : Index + L - N;
                }
                else
                {
                    Index = Index - L >= 0 ? Index - L : Index - L + N;
                }
                count++;
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}