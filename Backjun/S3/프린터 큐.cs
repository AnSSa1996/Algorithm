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
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int N = inputs[0];
                int index = inputs[1];

                Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 0; j < N; j++) q.Enqueue(new Tuple<int, int>(j, nums[j]));

                int cnt = 1;
                while (true)
                {
                    int max = q.Max(x => x.Item2);
                    var current = q.Dequeue();
                    if (current.Item2 < max) { q.Enqueue(current); continue; }
                    else if (current.Item1 == index) break;
                    cnt++;
                }

                sw.WriteLine(cnt);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}