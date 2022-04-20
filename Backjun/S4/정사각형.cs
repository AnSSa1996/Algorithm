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
                int[] x = new int[4];
                int[] y = new int[4];

                List<double> dist = new List<double>();
                for (int j = 0; j < 4; j++)
                {
                    int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    x[j] = inputs[0]; y[j] = inputs[1];
                }

                for (int a = 0; a < 3; a++)
                {
                    for (int b = a + 1; b < 4; b++)
                    {
                        dist.Add(Math.Sqrt((x[a] - x[b]) * (x[a] - x[b]) + (y[a] - y[b]) * (y[a] - y[b])));
                    }
                }

                dist.Sort();
                if (dist[0] == dist[1] && dist[1] == dist[2] && dist[2] == dist[3] && dist[4] == dist[5])
                    sw.WriteLine(1);
                else sw.WriteLine(0);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
