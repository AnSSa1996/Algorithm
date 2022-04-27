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
            List<char> charLst = sr.ReadLine().Split(' ').Select(x => x[0]).ToList();
            bool[] visited = new bool[10];

            List<string> answerLst = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                int[] tempNums = new int[N + 1];
                tempNums[0] = i;
                visited[i] = true;
                DFS(i, 1, tempNums);
                visited[i] = false;
            }
            answerLst.Sort();
            sw.WriteLine(answerLst.Last());
            sw.WriteLine(answerLst.First());


            void DFS(int current, int K, int[] nums)
            {
                if (K == N + 1) { answerLst.Add(string.Join("", nums)); return; }
                else
                {
                    char c = charLst[K - 1];
                    if (c == '<')
                    {
                        for (int next = 0; next < 10; next++)
                        {
                            if (visited[next] == false && current < next)
                            {
                                visited[next] = true;
                                nums[K] = next;
                                DFS(next, K + 1, nums);
                                visited[next] = false;
                            }
                        }
                    }
                    else
                    {
                        for (int next = 0; next < 10; next++)
                        {
                            if (visited[next] == false && current > next)
                            {
                                visited[next] = true;
                                nums[K] = next;
                                DFS(next, K + 1, nums);
                                visited[next] = false;
                            }
                        }
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}