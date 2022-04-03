using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = inputs[0];
            int H = inputs[1];
            int W = inputs[2];

            int result = H * H + W * W;

            for (int i = 0; i < N; i++)
            {
                int currentN = int.Parse(sr.ReadLine());
                if (currentN * currentN <= result) sw.WriteLine("DA");
                else sw.WriteLine("NE");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
