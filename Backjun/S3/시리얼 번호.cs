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

            List<string> lst = new List<string>();
            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++) lst.Add(sr.ReadLine());

            var sortedLst = lst.OrderBy(a => a.Length).
                ThenBy(b => b.Sum(c => c >= '1' && c <= '9' ? c - '0' : 0)).
                ThenBy(d => d);

            sw.WriteLine(string.Join("\n", sortedLst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}