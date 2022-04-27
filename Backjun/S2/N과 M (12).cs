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
            int N = inputs[0]; int K = inputs[1];

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Array.Sort(nums);

            int[] answer = new int[K];
            DFS(0, 0);

            void DFS(int n, int current)
            {
                if (n == K) sw.WriteLine(string.Join(" ", answer));
                else
                {
                    int temp = 0;
                    for (int i = 0; i < N; i++)
                    {
                        if (temp != nums[i] && current <= nums[i])
                        {
                            temp = nums[i];
                            answer[n] = nums[i];
                            DFS(n + 1, nums[i]);
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