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
            int K = inputs[1];

            List<int> nums = Enumerable.Range(1, N).ToList();
            Perm(0, new bool[N], new int[K]);

            sw.Flush();
            sw.Close();
            sr.Close();

            void Perm(int n, bool[] visited, int[] numArray)
            {
                if (n == K) { sw.WriteLine(string.Join(" ", numArray)); return; }
                else
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (visited[i] == false)
                        {
                            numArray[n] = i + 1;
                            visited[i] = true;
                            Perm(n + 1, visited, numArray);
                            visited[i] = false;
                        }
                    }
                }
            }
        }
    }
}