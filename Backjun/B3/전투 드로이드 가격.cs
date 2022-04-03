using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                decimal d = 350.34m * inputs[0] + 230.90m * inputs[1] + 190.55m * inputs[2] +
                    125.30m * inputs[3] + 180.90m * inputs[4];
                sw.WriteLine($"${d:f2}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
