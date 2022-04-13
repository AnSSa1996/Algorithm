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

            List<Tuple<int, string>> lst = new List<Tuple<int, string>>();

            for (int i = 0; i < N; i++)
            {
                string[] strs = sr.ReadLine().Split();
                int age = int.Parse(strs[0]);
                string name = strs[1];

                lst.Add(new Tuple<int, string>(age, name));
            }

            var sortedLst = from a in lst
                            orderby a.Item1
                            select a;

            foreach (var tup in sortedLst) sw.WriteLine($"{tup.Item1} {tup.Item2}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
