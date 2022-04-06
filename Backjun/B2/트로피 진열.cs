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

            List<int> tros = new List<int>();

            for (int i = 0; i < N; i++) tros.Add(int.Parse(sr.ReadLine()));

            int count = 1;
            int current = tros[0];

            for (int i = 1; i < N; i++)
            {
                if (tros[i] > current)
                {
                    count++;
                    current = tros[i];
                }
            }

            sw.WriteLine(count);

            tros.Reverse();
            count = 1;
            current = tros[0];

            for (int i = 1; i < N; i++)
            {
                if (tros[i] > current)
                {
                    count++;
                    current = tros[i];
                }
            }
            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}