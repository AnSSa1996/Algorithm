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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int count = inputs[0];
            int N = inputs[1];

            List<int> lst = new List<int>();
            for (int i = 0; i < N; i++) lst.Add(int.Parse(sr.ReadLine()));

            lst.Sort();

            List<int> maxNum = new List<int>();
            for (int i = 0; i < N; i++)
            {
                maxNum.Add(lst[i] * Math.Min(count, N - i));
            }

            int index = maxNum.IndexOf(maxNum.Max());

            sw.WriteLine($"{lst[index]} {maxNum[index]}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
