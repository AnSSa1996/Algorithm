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
            int C = inputs[0];
            int K = inputs[1];
            double multiply = Math.Pow(10, K);

            int cost = 0;

            if (C.ToString().Length == K)
            {

                if (C.ToString()[0] >= '5')
                {
                    cost = (int)multiply;
                }
            }
            else
            {
                cost = (int)(Math.Round(C / multiply) * multiply);
            }

            sw.WriteLine(cost);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}