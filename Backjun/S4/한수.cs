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

            int cnt = 0;
            for (int i = 1; i <= N; i++)
            {
                if (i <= 99) { cnt++; continue; }
                else
                {
                    List<int> lst = i.ToString().Select(x => x - '0').ToList();
                    int a = lst[0] - lst[1];
                    int b = lst[1] - lst[2];
                    if (a == b) cnt++;
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
