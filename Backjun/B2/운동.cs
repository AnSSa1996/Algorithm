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
            int N = inputs[0];
            int m = inputs[1];
            int M = inputs[2];
            int T = inputs[3];
            int R = inputs[4];

            int count = 0;
            int temp = m;
            if (m + T > M)
            {
                count = -1;
                goto end;
            }
            while (N > 0)
            {
                if (m + T <= M)
                {
                    m += T;
                    count++;
                    N--;
                }
                else
                {
                    m = m - R < temp ? temp : m - R;
                    count++;
                }
            }
        end:
            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}