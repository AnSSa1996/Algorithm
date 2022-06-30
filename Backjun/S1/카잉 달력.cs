using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJun
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
                int M = inputs[0]; int N = inputs[1]; int x = inputs[2]; int y = inputs[3];

                bool check = false;
                while (x <= M * N)
                {
                    if ((x - y) % N == 0) { check = true; break; }
                    x += M;
                }
                if (check) sw.WriteLine(x);
                else sw.WriteLine(-1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
