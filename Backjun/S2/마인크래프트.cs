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
            int H = inputs[0]; int W = inputs[1]; int invertory = inputs[2];

            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < H; i++) board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());

            long answerTime = long.MaxValue;
            long answer = 0;
            for (int i = 0; i <= 256; i++)
            {
                long remove = 0; long stack = 0;
                long time = 0;
                for (int y = 0; y < H; y++)
                {
                    for (int x = 0; x < W; x++)
                    {
                        if (board[y][x] > i) { remove += board[y][x] - i; }
                        else if (board[y][x] < i) { stack += i - board[y][x]; }
                    }
                }

                long tempInven = invertory + remove;
                time = remove * 2 + stack;
                if (stack > tempInven) continue;

                if (answerTime >= time)
                {
                    answerTime = time; answer = i;
                }
            }

            sw.WriteLine($"{answerTime} {answer}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}