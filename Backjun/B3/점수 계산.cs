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

            int sum = 0;
            int tempSum = 0;

            for (int i = 0; i < N; i++)
            {
                if (inputs[i] == 0) tempSum = 0;
                else tempSum += 1;
                sum += tempSum;
            }

            sw.WriteLine(sum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
