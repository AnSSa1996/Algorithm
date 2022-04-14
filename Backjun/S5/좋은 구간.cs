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

            long N = int.Parse(sr.ReadLine());
            List<long> inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse).ToList();
            inputs.Add(0);
            long num = int.Parse(sr.ReadLine());
            inputs.Sort();

            long left = 1;
            long right = 1;

            for (int i = 0; i < N; i++)
            {
                if (inputs[i] < num && inputs[i + 1] > num)
                {
                    left = num - inputs[i];
                    right = inputs[i + 1] - num;
                    break;
                }
            }

            sw.WriteLine(left * right - 1);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
