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

            double[] inputs = Array.ConvertAll(sr.ReadLine().Split(), double.Parse);
            double[] inputs2 = Array.ConvertAll(sr.ReadLine().Split(), double.Parse);

            double A = inputs[0]; double B = inputs[1]; double C = inputs2[0]; double D = inputs2[1];

            double max = A / C + B / D;
            int turnCount = 0;

            for (int i = 1; i < 4; i++)
            {
                double temp = A;
                A = C;
                C = D;
                D = B;
                B = temp;

                double result = A / C + B / D;
                if (max < result)
                {
                    max = result;
                    turnCount = i;
                }
            }

            sw.WriteLine(turnCount);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
