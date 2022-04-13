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

            int cnt = 1;
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                List<int> lst = new List<int>();

                int max = -1;

                lst.AddRange(inputs.Skip(1).Take(inputs[0]));
                lst.Sort();
                for (int j = 0; j < lst.Count() - 1; j++) max = Math.Max(Math.Abs(lst[j + 1] - lst[j]), max);

                sw.WriteLine($"Class {cnt}");
                sw.WriteLine($"Max {lst.Max()}, Min {lst.Min()}, Largest gap {max}");
                cnt++;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
