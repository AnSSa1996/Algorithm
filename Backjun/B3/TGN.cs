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

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

                long justCost = inputs[0];
                long advertise = inputs[1] - inputs[2];

                string result = "advertise";
                if (justCost > advertise) result = "do not advertise";
                else if (justCost == advertise) result = "does not matter";

                sw.WriteLine(result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
