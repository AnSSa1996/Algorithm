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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            List<int> answerLst = new List<int>();
            DFS(0);
            sw.WriteLine(answerLst.Max());
            void DFS(int K)
            {
                if (K == N)
                {
                    int temp = 0;
                    for (int i = 0; i < N - 1; i++) { temp += Math.Abs(nums[i] - nums[i + 1]); }
                    answerLst.Add(temp);
                    return;
                }
                else
                {
                    for (int i = K; i < N; i++)
                    {
                        int temp = nums[i];
                        nums[i] = nums[K];
                        nums[K] = temp;
                        DFS(K + 1);
                        temp = nums[i];
                        nums[i] = nums[K];
                        nums[K] = temp;
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}