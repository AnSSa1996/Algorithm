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

            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (inputs.Sum() == 0)
                    break;
                sw.WriteLine(inputs.Sum());
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}