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

            int red = inputs[0];
            int brown = inputs[1];
            int size = brown + red;

            for (int i = 3; i < size; i++)
            {
                if ((i - 2) * (size / i - 2) == brown && size % i == 0)
                {
                    sw.WriteLine($"{Math.Max(i, size / i)} {Math.Min(i, size / i)}");
                    break;
                }
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}