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

            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (inputs.Sum() == 0) break;
                Array.Sort(inputs);
                if (inputs[0] + inputs[1] <= inputs[2])
                {
                    sw.WriteLine("Invalid");
                    continue;
                }

                int count = inputs.GroupBy(x => x).Count();

                if (count == 3) sw.WriteLine("Scalene");
                else if (count == 2) sw.WriteLine("Isosceles");
                else sw.WriteLine("Equilateral");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
