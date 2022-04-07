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
            List<int> inputs = Enumerable.Range(1, N).ToList();

            while (true)
            {
                if (inputs.Count == 1) break;
                int count = inputs.Count();
                for (int i = 0; i < (count + 1) / 2; i++)
                {
                    inputs.RemoveAt(i);
                }
            }

            sw.WriteLine(inputs[0]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}