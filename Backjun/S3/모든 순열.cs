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

            List<int> nums = Enumerable.Range(1, N).ToList();
            Perm(0, 0, new bool[N], new int[N]);

            sw.Flush();
            sw.Close();
            sr.Close();

            void Perm(int n, int currentNum, bool[] visited, int[] numArray)
            {
                if (n == N) { sw.WriteLine(string.Join(" ", numArray)); return; }
                else
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (visited[i] == false)
                        {
                            numArray[n] = i + 1;
                            visited[i] = true;
                            Perm(n + 1, i, visited, numArray);
                            visited[i] = false;
                        }
                    }
                }
            }
        }
    }
}