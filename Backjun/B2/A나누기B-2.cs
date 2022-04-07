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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int A = inputs[0];
            int B = inputs[1];

            sb.Append(A / B);
            A %= B;
            if (A != 0)
            {
                sb.Append(".");
                for (int i = 0; i < 1001; i++)
                {
                    if (A == 0) break;
                    while (A < B) A *= 10;
                    int quo = A / B;
                    A %= B;
                    sb.Append(quo);
                }
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}