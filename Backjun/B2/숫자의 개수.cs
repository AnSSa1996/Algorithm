using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int A = int.Parse(sr.ReadLine());
            int B = int.Parse(sr.ReadLine());
            int C = int.Parse(sr.ReadLine());
            int result = A * B * C;
            var resultArray = result.ToString().ToArray();

            int[] numberArray = new int[10];

            foreach (var c in resultArray)
            {
                numberArray[c - '0'] += 1;
            }

            for (int i = 0; i < 10; i++)
            {
                sw.WriteLine(numberArray[i]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
