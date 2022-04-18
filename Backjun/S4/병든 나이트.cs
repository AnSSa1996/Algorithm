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

            int Y = inputs[0]; int X = inputs[1] - 1;

            int cnt = 1;
            if (Y == 1 || X == 0) cnt = 1;
            else if (Y == 2) cnt = Math.Min(X / 2 + 1, 4);
            else if (Y >= 3)
            {
                int cnt_1 = Math.Min(X + 1, 4);
                int cnt_2 = Math.Max(X - 2, 0) + 1;
                cnt = Math.Max(cnt_1, cnt_2);
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
