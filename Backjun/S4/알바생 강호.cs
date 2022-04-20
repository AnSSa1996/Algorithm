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

            List<int> lst = new List<int>();

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++) lst.Add(int.Parse(sr.ReadLine()));

            lst = lst.OrderByDescending(x => x).ToList();

            long total = 0;
            for (int i = 0; i < lst.Count(); i++)
            {
                if (lst[i] - i <= 0) break;
                total += lst[i] - i;
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}