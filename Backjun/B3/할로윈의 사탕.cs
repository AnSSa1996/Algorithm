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
            for (int i = 1; i <= N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                sw.WriteLine($"You get {inputs[0] / inputs[1]} piece(s) and your dad gets {inputs[0] % inputs[1]} piece(s).");
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
