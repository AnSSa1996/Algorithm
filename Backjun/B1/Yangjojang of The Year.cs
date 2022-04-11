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

            for (int i = 0; i < N; i++)
            {
                int count = int.Parse(sr.ReadLine());
                List<Tuple<string, int>> lst = new List<Tuple<string, int>>();

                for (int j = 0; j < count; j++)
                {
                    string[] strs = sr.ReadLine().Split();
                    string name = strs[0];
                    int score = int.Parse(strs[1]);

                    lst.Add(new Tuple<string, int>(name, score));
                }
                lst.Sort((a, b) => a.Item2.CompareTo(b.Item2));
                sw.WriteLine(lst[lst.Count() - 1].Item1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}