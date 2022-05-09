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
            int[] house = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            Array.Sort(house);
            if (N % 2 == 0) sw.WriteLine(house[N / 2 - 1]);
            else sw.WriteLine(house[N / 2]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
