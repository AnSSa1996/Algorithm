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

            int Q1 = 0;
            int Q2 = 0;
            int Q3 = 0;
            int Q4 = 0;
            int Axis = 0;
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (inputs[0] == 0 || inputs[1] == 0) Axis += 1;
                else if (inputs[0] > 0 && inputs[1] > 0) Q1 += 1;
                else if (inputs[0] < 0 && inputs[1] > 0) Q2 += 1;
                else if (inputs[0] < 0 && inputs[1] < 0) Q3 += 1;
                else if (inputs[0] > 0 && inputs[1] < 0) Q4 += 1;
            }

            sw.WriteLine($"Q1: {Q1}");
            sw.WriteLine($"Q2: {Q2}");
            sw.WriteLine($"Q3: {Q3}");
            sw.WriteLine($"Q4: {Q4}");
            sw.WriteLine($"AXIS: {Axis}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
