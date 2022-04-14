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

            int N = inputs[0];
            int S = inputs[1];

            int[] fruits = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Array.Sort(fruits);


            for (int i = 0; i < N; i++)
            {
                if (fruits[i] <= S) S++;
                else break;
            }

            sw.WriteLine(S);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
