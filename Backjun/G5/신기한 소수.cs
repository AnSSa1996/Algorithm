using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            DFS(0, 0);
            void DFS(int num, int length)
            {
                if (length == N)
                {
                    sw.WriteLine(num);
                    return;
                }

                for (int i = 1; i <= 9; i++)
                {
                    int current = num * 10 + i;
                    if (CheckPrime(current))
                    {
                        DFS(current, length + 1);
                    }
                }
            }

            bool CheckPrime(int X)
            {
                if (X == 0 || X == 1) return false;
                if (X == 2 || X == 3 || X == 5 || X == 7) return true;
                for (int i = 2; i <= (int)Math.Pow(X, 0.5) + 1; i++)
                    if (X % i == 0) return false;
                return true;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
