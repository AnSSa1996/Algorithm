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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            List<int> dices = Enumerable.Repeat(0, inputs.Sum() + 1).ToList();

            for (int i = 1; i <= inputs[0]; i++)
            {
                for (int j = 1; j <= inputs[1]; j++)
                {
                    for (int k = 1; k <= inputs[2]; k++)
                    {
                        dices[i + j + k]++;
                    }
                }
            }

            int result = dices.IndexOf(dices.Max());

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}