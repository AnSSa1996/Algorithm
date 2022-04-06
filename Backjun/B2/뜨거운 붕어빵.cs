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
            int N = inputs[0];

            for (int i = 0; i < N; i++) sw.WriteLine(new string(sr.ReadLine().Reverse().ToArray()));


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}