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
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            long[] psum = new long[N];

            psum[0] = inputs.Sum();
            for (int i = 1; i < inputs.Length; i++) psum[i] = psum[i - 1] - inputs[i - 1];


            long total = 0;
            for (int i = 0; i < inputs.Length - 1; i++) total += inputs[i] * psum[i + 1];

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
