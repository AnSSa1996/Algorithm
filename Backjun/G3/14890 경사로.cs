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
            int N = inputs[0]; int L = inputs[1];
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < N; i++) board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());

            int count = 0;

            for (int y = 0; y < N; y++)
            {
                bool[] slopes = new bool[N];
                int current = board[y][0];

                for (int x = 1; x < N; x++)
                {
                    if (current == board[y][x])
                    {
                        continue;
                    }
                    // 높이가 2 이상 차이나면, 실패
                    if (Math.Abs(current - board[y][x]) >= 2) { goto end; break; }

                    if (current > board[y][x])
                    {
                        current = board[y][x];
                        if (x + L > N) { goto end; break; }
                        for (int currentX = x; currentX < x + L; currentX++)
                        {
                            if (current != board[y][currentX]) { goto end; break; }
                            if (slopes[currentX] == true) { goto end; break; }

                            slopes[currentX] = true;
                        }
                    }
                    else
                    {
                        if (x - L < 0) { goto end; break; }
                        for (int currentX = x - L; currentX < x; currentX++)
                        {
                            if (current != board[y][currentX]) { goto end; break; }
                            if (slopes[currentX] == true) { goto end; break; }

                            slopes[currentX] = true;
                        }
                    }
                    current = board[y][x];
                }
                count++;
            end:;
            }


            for (int x = 0; x < N; x++)
            {
                bool[] slopes = new bool[N];
                int current = board[0][x];

                for (int y = 1; y < N; y++)
                {
                    if (current == board[y][x])
                    {
                        continue;
                    }
                    // 높이가 2 이상 차이나면, 실패
                    if (Math.Abs(current - board[y][x]) >= 2) { goto end2; break; }

                    if (current > board[y][x])
                    {
                        current = board[y][x];
                        if (y + L > N) { goto end2; break; }
                        for (int currentY = y; currentY < y + L; currentY++)
                        {
                            if (current != board[currentY][x]) { goto end2; break; }
                            if (slopes[currentY] == true) { goto end2; break; }

                            slopes[currentY] = true;
                        }
                    }
                    else
                    {
                        if (y - L < 0) { goto end2; break; }
                        for (int currentY = y - L; currentY < y; currentY++)
                        {
                            if (current != board[currentY][x]) { goto end2; break; }
                            if (slopes[currentY] == true) { goto end2; break; }

                            slopes[currentY] = true;
                        }
                    }

                    current = board[y][x];
                }

                count++;
            end2:;
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}