using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            List<int> inputNums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            int a = inputNums[0];
            int b = inputNums[1];

            if (a < b) sw.WriteLine(-1);
            else
            {
                int left = (a + b) / 2;
                int right = (a - b) / 2;
                if (left + right == a && left - right == b)
                {
                    sw.WriteLine($"{left} {right}");
                }
                else
                {
                    sw.WriteLine(-1);
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
