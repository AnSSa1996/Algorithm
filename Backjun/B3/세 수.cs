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

            int f = inputs[0];
            int s = inputs[1];
            int t = inputs[2];

            if (f + s == t) sw.WriteLine($"{f}+{s}={t}");
            else if (f - s == t) sw.WriteLine($"{f}-{s}={t}");
            else if (f * s == t) sw.WriteLine($"{f}*{s}={t}");
            else if (f / s == t) sw.WriteLine($"{f}/{s}={t}");
            else if (f == s + t) sw.WriteLine($"{f}={s}+{t}");
            else if (f == s - t) sw.WriteLine($"{f}={s}-{t}");
            else if (f == s * t) sw.WriteLine($"{f}={s}*{t}");
            else if (f == s / t) sw.WriteLine($"{f}={s}/{t}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
