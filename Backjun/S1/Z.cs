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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int R = inputs[1]; int C = inputs[2];

            int recursive(int n, int r, int c)
            {
                if (n == 0) return 0;
                return 2 * (r % 2) + (c % 2) + 4 * (recursive(n - 1, r / 2, c / 2));
            }

            sw.WriteLine(recursive(N, R, C));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
