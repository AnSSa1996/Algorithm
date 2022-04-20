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

            int N = int.Parse(sr.ReadLine()) - 1;

            var answer = sr.ReadLine().ToList();

            int cnt = 0;
            for (int i = 0; i < N; i++)
            {
                var left = answer.ToList();
                var right = sr.ReadLine().ToList();

                for (int j = 0; j < right.Count(); j++)
                {
                    if (left.Contains(right[j]))
                    {
                        left.Remove(right[j]);
                        right.RemoveAt(j);
                        j--;
                    }
                }

                if (left.Count() <= 1 && right.Count() <= 1) cnt++;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

