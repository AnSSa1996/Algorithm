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
            int N = int.Parse(sr.ReadLine());
            char[,] charArray = new char[N, N];
            for (int i = 0; i < N; i++) for (int j = 0; j < N; j++) charArray[i, j] = ' ';

            SanghunSolution(N, 0, 0);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sb.Append(charArray[i, j]);
                }
                sb.AppendLine();
            }

            sw.Write(sb);

            void SanghunSolution(int n, int y, int x)
            {
                if (n == 1) { charArray[y, x] = '*'; return; }
                n /= 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == 1 && j == 1) continue;
                        SanghunSolution(n, y + n * i, x + n * j);
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
