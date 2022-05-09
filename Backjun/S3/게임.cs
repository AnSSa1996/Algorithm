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

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            double X = inputs[0]; double Y = inputs[1];

            int rate = (int)(Y * 100 / X);

            int start = 1;
            int end = (int)X;

            if (rate >= 99) goto end;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                int currentRate = (int)((Y + mid) * 100 / (X + mid));

                if (currentRate > rate) end = mid - 1;
                else start = mid + 1;
            }
        end:
            if (rate >= 99) sw.WriteLine(-1);
            else sw.WriteLine(start);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
