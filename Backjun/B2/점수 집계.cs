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
                List<int> inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                inputs.Sort();
                if (inputs[3] - inputs[1] >= 4) sw.WriteLine("KIN");
                else sw.WriteLine(inputs.GetRange(1, 3).Sum());
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}