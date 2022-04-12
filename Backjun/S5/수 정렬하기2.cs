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

            List<int> lst = new List<int>();
            for (int i = 0; i < N; i++) lst.Add(int.Parse(sr.ReadLine()));
            lst.Sort();

            sw.WriteLine(string.Join("\n", lst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}