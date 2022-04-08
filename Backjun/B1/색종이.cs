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
                int startX = inputs[0];
                int startY = inputs[1];

                for (int x = startX; x < startX + 10; x++)
                {
                    for (int y = startY; y < startY + 10; y++)
                    {
                        board[x, y] = 1;
                    }
                }
            }

            sw.WriteLine(board.Cast<int>().Sum());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}