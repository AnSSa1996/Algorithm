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
                string upString = sr.ReadLine();
                string downString = sr.ReadLine();

                int count = 0;
                for (int j = 0; j < upString.Length; j++) if (upString[j] != downString[j]) count++;

                sw.WriteLine($"Hamming distance is {count}.");
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}