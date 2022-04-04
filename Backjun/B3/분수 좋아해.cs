using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
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
                if (inputs[0] == 0 && inputs[1] == 0) break;
                int quo = inputs[0] / inputs[1];
                int remainder = inputs[0] % inputs[1];

                sw.WriteLine($"{quo} {remainder} / {inputs[1]}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
