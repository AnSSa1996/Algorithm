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
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);


            int maxCount = 0;
            int count = 0;
            int current = inputs[0];
            for (int i = 1; i < N; i++)
            {
                if (inputs[i] <= current)
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else
                {
                    count = 0;
                    current = inputs[i];
                }
            }

            sw.WriteLine(maxCount);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}