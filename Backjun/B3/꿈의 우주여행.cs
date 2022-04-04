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
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int spaceNum = inputs[0];
                int distance = inputs[1];

                int count = 0;
                for (int j = 0; j < spaceNum; j++)
                {
                    double[] nextInputs = Array.ConvertAll(sr.ReadLine().Split(), double.Parse);
                    double result = nextInputs[0] * nextInputs[1] / nextInputs[2];
                    if (result >= distance) count++;
                }
                sw.WriteLine(count);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
