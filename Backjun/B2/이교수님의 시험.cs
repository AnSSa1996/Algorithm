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

            for (int i = 1; i <= N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 0; j < inputs.Length; j++)
                {
                    if (inputs[j] != j % 5 + 1) goto end;
                }
                sw.WriteLine(i);
            end:;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}