using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] cards = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0];
            int M = inputs[1];

            int max = -1;

            for (int i = 0; i < N - 2; i++)
            {
                for (int j = i + 1; j < N - 1; j++)
                {
                    for (int k = j + 1; k < N; k++)
                    {
                        int sum = cards[i] + cards[j] + cards[k];

                        if (sum > M) continue;
                        if (sum == M)
                        {
                            max = sum;
                            goto end;
                        }
                        if (sum > max)
                        {
                            max = sum;
                        }
                    }
                }
            }
        end:

            sw.WriteLine(max);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
