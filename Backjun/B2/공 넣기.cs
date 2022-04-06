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

            int[] balls = Enumerable.Repeat(0, inputs[0]).ToArray();

            for (int i = 0; i < inputs[1]; i++)
            {
                int[] puts = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int start = puts[0];
                int end = puts[1];

                for (int j = start - 1; j < end; j++)
                {
                    balls[j] = puts[2];
                }
            }

            sw.WriteLine(string.Join(" ", balls));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}