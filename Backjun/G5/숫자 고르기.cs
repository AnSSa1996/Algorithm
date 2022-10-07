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
            List<int> nums = new List<int>();
            nums.Add(0);
            for (int i = 0; i < N; i++) nums.Add(int.Parse(sr.ReadLine()));
            List<int> resultList = new List<int>();
            List<int> firstList = new List<int>();
            List<int> secondList = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                firstList.Clear(); secondList.Clear();
                if (resultList.Contains(i)) continue;
                DFS(i, new List<int>());
            }

            resultList.Sort();
            sw.WriteLine(resultList.Count());
            for (int i = 0; i < resultList.Count(); i++)
            {
                sw.WriteLine(resultList[i]);
            }

            void DFS(int pos, List<int> lst)
            {
                int next = nums[pos];
                firstList.Add(pos);
                secondList.Add(next);

                if (firstList.Contains(next))
                {
                    if (firstList.Except(secondList).Count() == 0)
                    {
                        resultList.AddRange(firstList);
                        return;
                    }
                    return;
                }
                DFS(next, lst);
                return;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}