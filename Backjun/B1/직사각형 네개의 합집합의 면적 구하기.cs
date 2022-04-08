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

            int[,] board = new int[101, 101];

            for (int i = 0; i < 4; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int startX = inputs[0];
                int startY = inputs[1];
                int endX = inputs[2];
                int endY = inputs[3];

                for (int y = startY; y < endY; y++)
                {
                    for (int x = startX; x < endX; x++)
                    {
                        board[y, x] = 1;
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