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
                int T = int.Parse(sr.ReadLine());
                int total = 0;
                for (int j = 0; j < T; j++)
                {
                    int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    if (inputs.Max() > 0) total += inputs.Max();
                }

                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
