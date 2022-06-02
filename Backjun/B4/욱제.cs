using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int A = inputs[0]; int B = inputs[1];

            int BA = B - A;

            float M = (float)BA / 400;

            double div = 1 + Math.Pow(10, M);

            sw.WriteLine(1 / div);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
