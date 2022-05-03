using System;
using System.Collections.Generic;
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

            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < 19; i++)
            {
                List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                board.Add(lst);
            }

            int answer = 0;
            int answerY = -1;
            int answerX = -1;

            int[] dx = new int[8] { 1, 0, -1, 1, -1, 0, 1, -1 };
            int[] dy = new int[8] { 0, 1, 1, 1, 0, -1, -1, -1 };

            int cnt = 1;

            for (int x = 0; x < 19; x++)
            {
                for (int y = 0; y < 19; y++)
                {
                    if (board[y][x] != 0)
                    {
                        int temp = board[y][x];
                        for (int d = 0; d < 4; d++)
                        {
                            cnt = 1;

                            DFS(temp, y, x, d);
                            DFS(temp, y, x, d + 4);
                            if (cnt == 5)
                            {
                                answer = temp;
                                answerY = y;
                                answerX = x;
                                goto end;
                            }
                        }
                    }
                }
            }

        end:
            if (cnt == 5)
            {
                sw.WriteLine(answer);
                sw.WriteLine($"{answerY + 1} {answerX + 1}");
            }
            else { sw.WriteLine(0); }

            void DFS(int piece, int startY, int startX, int direction)
            {
                int nextY = startY + dy[direction];
                int nextX = startX + dx[direction];

                if (nextY < 0 || nextY >= 19 || nextX < 0 || nextX >= 19) return;
                if (board[nextY][nextX] == piece)
                {
                    DFS(piece, nextY, nextX, direction); cnt++;
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}