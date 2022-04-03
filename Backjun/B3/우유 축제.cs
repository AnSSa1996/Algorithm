using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

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

            int current = 0;
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                if (inputs[i] == current)
                {
                    count++;
                    current = current + 1 == 3 ? 0 : current + 1;
                }
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
