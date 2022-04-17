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
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            int N = int.Parse(sr.ReadLine());

            int[] A = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] B = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            Array.Sort(A);
            Array.Sort(B);
            B = B.Reverse().ToArray();

            int total = 0;
            for (int i = 0; i < N; i++) total += A[i] * B[i];

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
