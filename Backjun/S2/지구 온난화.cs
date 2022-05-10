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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int Y = inputs[0]; int X = inputs[1];
            List<List<char>> board = new List<List<char>>();
            List<List<char>> changeBoard = new List<List<char>>();
            for (int i = 0; i < Y; i++)
            {
                List<char> lst = sr.ReadLine().ToList();
                board.Add(lst);
                changeBoard.Add(lst.ToList());
            }


            int[] dx = new int[4] { -1, 1, 0, 0 };
            int[] dy = new int[4] { 0, 0, -1, 1 };

            int minY = int.MaxValue; int maxY = -1;
            int minX = int.MaxValue; int maxX = -1;
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y][x] == '.') continue;

                    int cnt = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        int nextY = y + dy[i];
                        int nextX = x + dx[i];

                        if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
                        if (board[nextY][nextX] == 'X') cnt++;
                    }
                    if (cnt < 2) changeBoard[y][x] = '.';
                    else
                    {
                        minY = Math.Min(minY, y); maxY = Math.Max(maxY, y);
                        minX = Math.Min(minX, x); maxX = Math.Max(maxX, x);
                    }
                }
            }

            for (int y = minY; y <= maxY; y++)
            {
                StringBuilder sb = new StringBuilder();
                for (int x = minX; x <= maxX; x++)
                {
                    sb.Append(changeBoard[y][x]);
                }
                sw.WriteLine(sb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
