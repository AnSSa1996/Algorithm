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
            int N = inputs[0]; int M = inputs[1];

            char[] hams = sr.ReadLine().ToArray();

            int cnt = 0;
            for (int i = 0; i < N; i++)
            {
                if (hams[i] != 'P') continue;
                for (int index = i - M; index <= i + M; index++)
                {
                    if (index < 0) continue;
                    if (index >= N) break;


                    if (hams[index] == 'H')
                    {
                        cnt++;
                        hams[index] = 'X';
                        break;
                    }
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
