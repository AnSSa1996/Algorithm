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

            int Y = inputs[0];
            int X = inputs[1];

            List<string> board = new List<string>();
            for (int i = 0; i < Y; i++) board.Add(sr.ReadLine());

            int W_cnt_Min = int.MaxValue;
            int B_cnt_Min = int.MaxValue;
            for (int startY = 0; startY < Y - 7; startY++)
            {
                for (int startX = 0; startX < X - 7; startX++)
                {
                    int W_cnt = 0;
                    int B_cnt = 0;
                    for (int y = startY; y < startY + 8; y++)
                    {
                        for (int x = startX; x < startX + 8; x++)
                        {
                            if ((y + x) % 2 == 0)
                            {
                                if (board[y][x] == 'W') W_cnt++;
                                if (board[y][x] == 'B') B_cnt++;
                            }
                            else
                            {
                                if (board[y][x] == 'B') W_cnt++;
                                if (board[y][x] == 'W') B_cnt++;
                            }
                        }
                    }
                    W_cnt_Min = Math.Min(W_cnt_Min, W_cnt);
                    B_cnt_Min = Math.Min(B_cnt_Min, B_cnt);
                }
            }

            sw.WriteLine(Math.Min(W_cnt_Min, B_cnt_Min));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
