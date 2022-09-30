using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int T = int.Parse(sr.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int start = inputs[0]; int end = inputs[1];
                int distance = end - start;

                int max = (int)Math.Sqrt(distance);

                if (max == Math.Sqrt(distance))
                    sw.WriteLine(max * 2 - 1);
                else if (distance <= max * max + max)
                    sw.WriteLine(max * 2);
                else
                    sw.WriteLine(max * 2 + 1);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
