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
            List<(int X, int Y)> point = new List<(int X, int Y)>();
            for (int i = 0; i < 3; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                point.Add((inputs[0], inputs[1]));
            }

            int CCW()
            {
                var P1 = point[0];
                var P2 = point[1];
                var P3 = point[2];

                return (P1.X * P2.Y + P2.X * P3.Y + P3.X * P1.Y) - (P1.Y * P2.X + P2.Y * P3.X + P3.Y * P1.X);
            }

            int result = CCW();
            if (result > 0)
            {
                sw.WriteLine(1);
            }
            else if (result == 0)
            {
                sw.WriteLine(0);
            }
            else
            {
                sw.WriteLine(-1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}