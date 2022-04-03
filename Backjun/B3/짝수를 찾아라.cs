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

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                var temp = inputs.Where(x => x % 2 == 0);
                int Sum = temp.Sum();
                int min = temp.Min();

                sw.WriteLine($"{Sum} {min}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
