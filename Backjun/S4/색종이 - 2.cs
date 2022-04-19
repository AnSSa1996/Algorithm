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

            int[,] board = new int[101, 101];

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int X = inputs[0];
                int Y = inputs[1];

                for (int y = Y; y < Y + 10; y++)
                {
                    for (int x = X; x < X + 10; x++)
                    {
                        board[y, x] = 1;
                    }
                }
            }

            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            int Sum = 0;
            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    if (board[i, j] == 1)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            int y = i + dy[k];
                            int x = j + dx[k];
                            if (board[y, x] == 0) Sum++;
                        }
                    }
                }
            }
            sw.WriteLine(Sum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

