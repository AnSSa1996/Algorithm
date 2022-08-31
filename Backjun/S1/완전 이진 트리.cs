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
            int length = nums.Length;

            List<List<int>> lst = new List<List<int>>();
            for (int i = 0; i < N; i++)
            {
                lst.Add(new List<int>());
            }

            DFS(0, length / 2, length, 0);

            void DFS(int index, int mid, int L, int count)
            {
                if (L == 1) { lst[count].Add(nums[index]); return; }
                lst[count].Add(nums[mid]);
                var left = index;
                var nextL = L / 2;
                var nextMid = nextL / 2;
                DFS(left, left + nextMid, nextL, count + 1);
                var right = mid + 1;
                DFS(right, right + nextMid, nextL, count + 1);

            }

            for (int i = 0; i < N; i++)
            {
                sw.WriteLine(string.Join(" ", lst[i]));
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}