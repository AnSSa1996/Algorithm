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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int rows = inputs[0]; int columns = inputs[1];

            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < rows; i++) { board.Add(sr.ReadLine().ToList()); }

            bool check = true;


            int[] dx = new int[4] { 1, 0, -1, 0 };
            int[] dy = new int[4] { 0, -1, 0, 1 };
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (board[y][x] == 'W')
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            int nextY = y + dy[i];
                            int nextX = x + dx[i];

                            if (nextY < 0 || nextY >= rows || nextX < 0 || nextX >= columns) continue;
                            else if (board[nextY][nextX] == 'S')
                            {
                                check = false;
                                goto end;
                            }
                        }
                    }
                    if (board[y][x] == '.') board[y][x] = 'D';
                }
            }

        end:

            if (check)
            {
                sw.WriteLine(1);
                foreach (var lst in board) sw.WriteLine(string.Join("", lst));
            }
            else { sw.WriteLine(0); }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
