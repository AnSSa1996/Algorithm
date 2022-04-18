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
            int answer = int.Parse(sr.ReadLine());
            int X = inputs[0];
            int Y = inputs[1];

            int tempX = X;
            int tempY = Y;

            int[] dx = new int[4] { 0, 1, 0, -1 };
            int[] dy = new int[4] { 1, 0, -1, 0 };

            int[,] board = new int[Y, X];
            int dCnt = 0;
            int cnt = 1;
            int y = -1; int x = 0;
            while (true)
            {
                if (Y == 0 || X == 0) break;

                for (int i = 0; i < Y; i++)
                {
                    y = y + dy[dCnt];
                    x = x + dx[dCnt];
                    board[y, x] = cnt++;
                }
                dCnt++;
                if (dCnt % 4 == 0) dCnt = 0;
                Y--;

                X--;
                for (int i = 0; i < X; i++)
                {
                    y = y + dy[dCnt];
                    x = x + dx[dCnt];
                    board[y, x] = cnt++;
                }
                dCnt++;
                if (dCnt % 4 == 0) dCnt = 0;
            }

            int ay = -1; int ax = -1;

            for (int py = 0; py < tempY; py++)
            {
                for (int px = 0; px < tempX; px++)
                {
                    if (board[py, px] == answer) { ay = py; ax = px; break; }
                }
            }

            if (ay == -1 && ax == -1) sw.WriteLine(0);
            else sw.WriteLine($"{ax + 1} {ay + 1}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
