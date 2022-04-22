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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int nation = inputs[0];
                int planes = inputs[1];

                for (int j = 0; j < planes; j++) { sr.ReadLine(); }

                sw.WriteLine(nation - 1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}