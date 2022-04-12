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

            List<List<int>> lst = new List<List<int>>();

            for (int i = 0; i < 3; i++) lst.Add(new List<int>());

            List<int[]> plst = new List<int[]>();
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                plst.Add(inputs); lst[0].Add(inputs[0]); lst[1].Add(inputs[1]); lst[2].Add(inputs[2]);
            }

            for (int i = 0; i < N; i++)
            {
                int total = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (lst[j].Count(x => x == plst[i][j]) >= 2) continue;
                    total += plst[i][j];
                }
                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}