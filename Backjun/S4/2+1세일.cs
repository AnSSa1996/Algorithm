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

            int total = 0;
            for (int i = 0; i < N; i++)
            {
                if ((i+1) % 3 == 0 && (i / 3) < (N / 3)) continue;
                total += lst[i];
            }
            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}