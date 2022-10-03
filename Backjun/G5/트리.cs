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
            List<List<int>> lines = new List<List<int>>();
            int root = 0;
            int remove = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++) { lines.Add(new List<int>()); }
            for (int index = 0; index < N; index++)
            {
                var num = nums[index];
                if (num == -1) { root = index; continue; }
                if (num == remove) continue;
                if (index == remove) continue;
                lines[num].Add(index);
            }
            int count = 0;

            DFS(root);

            void DFS(int start)
            {
                if (start == remove) return;
                if (lines[start].Count == 0)
                {
                    count++;
                    return;
                }
                foreach (var next in lines[start])
                {
                    DFS(next);
                }
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}