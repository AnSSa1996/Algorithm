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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                bool[] visited = new bool[N];

                int cnt = 0;
                for (int index = 0; index < N; index++)
                {
                    if (visited[index] == false)
                    {
                        DFS(index, visited, nums);
                        cnt++;
                    }
                }
                sw.WriteLine(cnt);
            }

            void DFS(int next, bool[] visited, int[] nums)
            {
                if (visited[next] == true) return;
                visited[next] = true;
                int num = nums[next] - 1;
                DFS(num, visited, nums);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}