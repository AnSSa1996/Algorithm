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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int firstY = (inputs[0] + 3) / 4;
            int firstX = inputs[0] % 4 == 0 ? 4 : inputs[0] % 4;

            int secondY = (inputs[1] + 3) / 4;
            int secondX = inputs[1] % 4 == 0 ? 4 : inputs[1] % 4;

            int distance = Math.Abs(firstY - secondY) + Math.Abs(firstX - secondX);

            sw.WriteLine(distance);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
