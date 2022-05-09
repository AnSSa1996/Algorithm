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
            int[] nums = new int[4] { 1, 5, 10, 50 };
            bool[] check = new bool[4];

            List<int> lst = new List<int>();
            var sortedLst = lst.OrderBy(x => x).Distinct();

            DFS(0, 0, 0);

            sw.WriteLine(sortedLst.Count());
            void DFS(int K, int current, int num)
            {
                if (K == N) { lst.Add(num); return; }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (check[i] == false && current <= i)
                        {
                            DFS(K + 1, i, num + nums[i]);
                            check[i] = true;
                        }
                        check[i] = false;
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
