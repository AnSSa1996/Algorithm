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

            int A = 0;
            int B = 0;

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (inputs[0] > inputs[1]) A++;
                else if(inputs[0] < inputs[1]) B++;
            }

            sw.WriteLine($"{A} {B}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
