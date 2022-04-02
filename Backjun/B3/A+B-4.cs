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
                string input = sr.ReadLine();
                if (input == null)
                    break;
                int[] inputs = Array.ConvertAll(input.Split(), int.Parse);

                Console.WriteLine($"{inputs.Sum()}");
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
