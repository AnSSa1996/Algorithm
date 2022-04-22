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
                int X1 = inputs[0];
                int Y1 = inputs[1];
                int X2 = inputs[2];
                int Y2 = inputs[3];

                int cnt = 0;
                int N = int.Parse(sr.ReadLine());

                for (int j = 0; j < N; j++)
                {
                    int[] circle = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    int CX = circle[0];
                    int CY = circle[1];
                    int R = circle[2];

                    double dist_1 = Math.Sqrt((CX - X1) * (CX - X1) + (CY - Y1) * (CY - Y1));
                    double dist_2 = Math.Sqrt((CX - X2) * (CX - X2) + (CY - Y2) * (CY - Y2));
                    if (dist_1 < R && dist_2 < R) continue;
                    else if (dist_1 < R || dist_2 < R) cnt++;
                }

                sw.WriteLine(cnt);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}