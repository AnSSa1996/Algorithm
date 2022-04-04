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

            int[] time1 = Array.ConvertAll(sr.ReadLine().Split(':'), int.Parse);
            int[] time2 = Array.ConvertAll(sr.ReadLine().Split(':'), int.Parse);

            int time1S = time1[0] * 3600 + time1[1] * 60 + time1[2];
            int time2S = time2[0] * 3600 + time2[1] * 60 + time2[2];

            if (time1S >= time2S) time2S += 3600 * 24;

            int total = time2S - time1S;

            int h = total / 3600;
            total %= 3600;
            int m = total / 60;
            total %= 60;
            int s = total;

            sw.WriteLine($"{h:00}:{m:00}:{s:00}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
