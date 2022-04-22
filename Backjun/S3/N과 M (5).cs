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

            bool[] check = new bool[N];
            DFS(0, K, new List<int>());

            void DFS(int n, int k, List<int> lst)
            {
                if (n == k) sw.WriteLine(string.Join(" ", lst));
                else
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (check[i] == false)
                        {
                            check[i] = true;
                            lst.Add(nums[i]);
                            DFS(n + 1, k, lst);
                            lst.RemoveAt(lst.Count() - 1);
                            check[i] = false;
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