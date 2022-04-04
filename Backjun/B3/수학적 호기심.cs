using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int n = inputs[0];
                int m = inputs[1];
                int count = 0;
                for (int a = 1; a < n; a++)
                {
                    for (int b = a + 1; b < n; b++)
                    {
                        if ((a * a + b * b + m) % (a * b) == 0) count++;
                    }
                }
                sw.WriteLine(count);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
