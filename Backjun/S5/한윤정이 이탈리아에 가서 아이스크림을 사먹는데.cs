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

            bool[,] check = new bool[count + 1, count + 1];

            for (int i = 0; i < N; i++)
            {
                int[] ip = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                check[ip[0], ip[1]] = true;
                check[ip[1], ip[0]] = true;
            }

            int total = 0;
            for (int a = 1; a <= count - 2; a++)
            {
                for (int b = a + 1; b <= count - 1; b++)
                {
                    for (int c = b + 1; c <= count; c++)
                    {
                        if (!check[a, b] && !check[a, c] && !check[b, c]) total++;
                    }
                }
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
