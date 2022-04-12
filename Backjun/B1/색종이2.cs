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

            int N = int.Parse(sr.ReadLine());
            int[,] board = new int[1001, 1001];

            for (int i = 1; i <= N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int X = inputs[0];
                int Y = inputs[1];
                int W = inputs[2];
                int H = inputs[3];

                for (int y = Y; y < Y + H; y++)
                {
                    for (int x = X; x < X + W; x++)
                    {
                        board[y, x] = i;
                    }
                }
            }

            int[] flatBoard = new int[board.Length];
            Buffer.BlockCopy(board, 0, flatBoard, 0, board.Length);
            for (int i = 1; i <= N; i++)
            {
                int count = flatBoard.Count(x => x == i);
                sw.WriteLine(count);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}