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

            int N = int.Parse(sr.ReadLine());

            List<string> board = new List<string>();
            for (int i = 0; i < N; i++) board.Add(sr.ReadLine());

            int[,] friends = new int[N, N];
            for (int a = 0; a < N; a++)
            {
                for (int b = 0; b < N; b++)
                {
                    for (int c = 0; c < N; c++)
                    {
                        if (b == c) continue;
                        if (board[b][c] == 'Y' || (board[b][a] == 'Y' && board[a][c] == 'Y'))
                        {
                            friends[b, c] = 1;
                        }
                    }
                }
            }

            int result = -1;
            for (int i = 0; i < N; i++)
            {
                int sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += friends[i, j];
                }
                result = Math.Max(result, sum);
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}