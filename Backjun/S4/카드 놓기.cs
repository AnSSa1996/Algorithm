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
            int K = int.Parse(sr.ReadLine());

            List<int> lst = new List<int>();
            List<long> allLst = new List<long>();

            for (int i = 0; i < N; i++) lst.Add(int.Parse(sr.ReadLine()));

            Perm(lst, 0, K, new List<int>(), allLst);

            allLst = allLst.Distinct().ToList();

            sw.WriteLine(allLst.Count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Perm(List<int> lst, int num, int K, List<int> answerLst, List<long> allLst)
        {
            if (num == K)
            {
                allLst.Add(long.Parse(string.Join("", answerLst)));
            }
            else
            {
                for (int i = num; i < lst.Count; i++)
                {
                    int temp = lst[i];
                    lst[i] = lst[num];
                    lst[num] = temp;
                    answerLst.Add(temp);
                    Perm(lst, num + 1, K, answerLst, allLst);
                    answerLst.RemoveAt(answerLst.Count - 1);
                    temp = lst[i];
                    lst[i] = lst[num];
                    lst[num] = temp;
                }
            }
        }
    }
}

