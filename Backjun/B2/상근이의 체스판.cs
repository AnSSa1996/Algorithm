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

            int[] RC = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] AB = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int R = RC[0];
            int C = RC[1];
            int A = AB[0];
            int B = AB[1];

            string X = string.Concat(Enumerable.Repeat("X", B));
            string P = string.Concat(Enumerable.Repeat(".", B));

            int count = 1;
            int colum = 0;
            while (true)
            {
                if (colum == R * A) break;
                for (int a = 1; a <= A; a++)
                {
                    for (int b = 1; b <= C; b++)
                    {
                        if ((b + count) % 2 == 0) sb.Append(X);
                        else sb.Append(P);
                    }
                    sb.AppendLine();
                    colum++;
                    if (colum == R * A) break;
                }
                count = (count + 1) % 2;
            }

            sw.Write(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}