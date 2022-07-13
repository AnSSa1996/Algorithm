using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int d = inputs[1]; int k = inputs[2]; int c = inputs[3];

            int[] chobabs = new int[N];
            for (int i = 0; i < N; i++) { chobabs[i] = int.Parse(sr.ReadLine()); }

            int max = 0;
            for (int index = 0; index < N; index++)
            {
                int lp = index;
                int rp = index + k;
                int[] chobabArray = new int[d + 1];
                for (int i = lp; i < rp; i++)
                {
                    int num = i % N;
                    if (chobabArray[chobabs[num]] == 0) chobabArray[chobabs[num]] = 1;
                }
                chobabArray[c] = 1;
                max = Math.Max(max, chobabArray.Sum());
            }

            sw.WriteLine(max);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}