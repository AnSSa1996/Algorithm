using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

            int max = 0;

            DFS(nums.ToList(), nums.Length, 0);

            void DFS(List<int> lst, int L, int value)
            {
                if (L == 2)
                {
                    max = Math.Max(max, value);
                    return;
                }

                for (int i = 1; i < lst.Count - 1; i++)
                {
                    var current = lst[i];
                    lst.RemoveAt(i);
                    DFS(lst.ToList(), L - 1, value + lst[i - 1] * lst[i]);
                    lst.Insert(i, current);
                }
            }

            sw.WriteLine(max);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}