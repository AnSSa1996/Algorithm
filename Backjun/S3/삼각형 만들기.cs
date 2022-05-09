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
            List<int> lst = new List<int>();

            for (int i = 0; i < N; i++) lst.Add(int.Parse(sr.ReadLine()));
            var sortedLst = lst.OrderByDescending(x => x).ToList();

            bool check = true;
            int index = 0;
            for (int i = 0; i < N; i++)
            {
                if (i + 2 == N) { check = false; break; }
                if (sortedLst[i] < sortedLst[i + 1] + sortedLst[i + 2])
                {
                    index = i; break;
                }
            }

            if (check) sw.WriteLine(sortedLst[index] + sortedLst[index + 1] + sortedLst[index + 2]);
            else sw.WriteLine(-1);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
