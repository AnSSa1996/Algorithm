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

            int fry = inputs[0];
            int se = inputs[1];
            int ban = inputs[2];
            int fryCount = inputs[3];
            int seCount = inputs[4];

            int result = 0;

            if (fry + se <= ban * 2) result += fry * fryCount + se * seCount;
            else
            {
                int smaller = Math.Min(fryCount, seCount);
                result += (ban * 2 * smaller) + Math.Max(0, fryCount - smaller) * Math.Min(fry, ban * 2) + Math.Max(0, seCount - smaller) * Math.Min(se, ban * 2);
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
