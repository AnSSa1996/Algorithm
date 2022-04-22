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

            int A = inputs[1]; int B = inputs[2];
            int cnt = 0;

            while (A != B)
            {
                A -= A / 2;
                B -= B / 2;
                cnt++;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}