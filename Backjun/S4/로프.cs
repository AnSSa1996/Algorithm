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
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StreamReader sr = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(sr.ReadLine());
            List<int> lst = new List<int>();

            for (int i = 0; i < N; i++) lst.Add(int.Parse(sr.ReadLine()));
            lst.Sort();

            int resultMax = -1;
            for (int i = 0; i < N; i++) resultMax = Math.Max(resultMax, (N - i) * lst[i]);

            sw.WriteLine(resultMax);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
