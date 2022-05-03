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

            List<int> sosu = new List<int>();
            Eratos(sosu);
            int first = 0; int last = sosu.Count() - 1;

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                int answer = Solution(first, last, sosu, num);
                sw.WriteLine(answer);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int Solution(int first, int last, List<int> sosu, int answer)
        {
            int cnt = 0;

            while (first <= last)
            {
                int sum = sosu[first] + sosu[last];
                if (sum == answer) { cnt++; last--; }
                else if (sum < answer) first++;
                else if (sum > answer) last--;
            }
            return cnt;
        }


        public static void Eratos(List<int> sosu)
        {
            bool[] visited = new bool[1000001];
            for (int i = 2; i <= 1000000; i++)
            {
                if (visited[i] == false)
                {
                    sosu.Add(i);
                    for (int j = i * 2; j <= 1000000; j += i)
                    {
                        visited[j] = true;
                    }
                }
            }
        }
    }
}