using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            List<int> bars = new List<int>();
            for (int i = 0; i < N; i++) bars.Add(int.Parse(sr.ReadLine()));
            bars.Reverse();

            int currentBar = bars[0];
            int canSee = 1;

            for (int i = 1; i < N; i++)
            {
                if (currentBar < bars[i])
                {
                    canSee++;
                    currentBar = bars[i];
                }
            }

            sw.WriteLine(canSee);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
