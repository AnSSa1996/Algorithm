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
                if (inputs.Sum() == 0) break;
                Array.Sort(inputs);
                int x = inputs[0] * inputs[0];
                int y = inputs[1] * inputs[1];
                int z = inputs[2] * inputs[2];
                string result = "wrong";
                if (x + y == z) result = "right";

                sw.WriteLine(result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
