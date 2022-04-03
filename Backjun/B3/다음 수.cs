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
                if (inputs[0] == 0 && inputs[1] == 0 && inputs[2] == 0) break;

                int dif = inputs[1] - inputs[0];
                int ratio = 1;
                if (inputs[0] != 0) ratio = inputs[1] / inputs[0];

                if (inputs[1] + dif == inputs[2]) sw.WriteLine($"AP {inputs[2] + dif}");
                else sw.WriteLine($"GP {inputs[2] * ratio}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
