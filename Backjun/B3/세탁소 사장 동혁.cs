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
                int Cost = int.Parse(sr.ReadLine());
                int Q = Cost / 25;
                Cost %= 25;
                int D = Cost / 10;
                Cost %= 10;
                int Ni = Cost / 5;
                Cost %= 5;
                int P = Cost;

                sw.WriteLine($"{Q} {D} {Ni} {P}");
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
