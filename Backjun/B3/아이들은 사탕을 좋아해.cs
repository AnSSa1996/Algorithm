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
                int[] firstInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int[] secondInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int count = 0;

                int amount = firstInputs[0];
                int candy = firstInputs[1];
                for (int j = 0; j < amount; j++)
                {
                    count += secondInputs[j] / candy;
                }

                sw.WriteLine(count);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
