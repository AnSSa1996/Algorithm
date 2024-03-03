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
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < N; i++) board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());

            int max = 0;

            int[] dy = new int[4] { 1, -1, 0, 0 };
            int[] dx = new int[4] { 0, 0, -1, 1 };

            Recursive(0);

            sw.WriteLine(max);
            void Recursive(int count)
            {
                if (count == 5)
                {
                    max = Math.Max(max, MAX(board));
                    return;
                }
                var lst = Create(board);
                for (int direction = 0; direction < 4; direction++)
                {
                    Get(board, direction);
                    Recursive(count + 1);
                    board = Create(lst);
                }
            }

            void Get(List<List<int>> lst, int d)
            {
                // 하
                bool[,] check = new bool[N, N];
                if (d == 0)
                {
                    for (int x = 0; x < N; x++)
                    {
                        int count = 0;
                        for (int y = N - 2; y >= 0; y--)
                        {
                            if (lst[y][x] == 0) continue;
                            {
                                count = Move(lst, y, x, d, lst[y][x], N - y - 1, count);
                            }
                        }
                    }
                }
                // 상
                else if (d == 1)
                {
                    for (int x = 0; x < N; x++)
                    {
                        int count = 0;
                        for (int y = 1; y < N; y++)
                        {
                            if (lst[y][x] == 0) continue;
                            {
                                count = Move(lst, y, x, d, lst[y][x], y, count);
                            }
                        }
                    }
                }
                // 좌
                else if (d == 2)
                {
                    for (int y = 0; y < N; y++)
                    {
                        int count = 0;
                        for (int x = 1; x < N; x++)
                        {
                            if (lst[y][x] == 0) continue;
                            {
                                count = Move(lst, y, x, d, lst[y][x], x, count);
                            }
                        }
                    }
                }
                // 우
                else
                {
                    for (int y = 0; y < N; y++)
                    {
                        int count = 0;
                        for (int x = N - 2; x >= 0; x--)
                        {
                            if (lst[y][x] == 0) continue;
                            {
                                count = Move(lst, y, x, d, lst[y][x], N - x - 1, count);
                            }
                        }
                    }
                }
            }

            int Move(List<List<int>> lst, int y, int x, int direction, int current, int first, int last)
            {
                int result = last;
                for (int repeat = 0; repeat < first - last; repeat++)
                {
                    y += dy[direction];
                    x += dx[direction];
                    if (lst[y][x] == 0)
                    {
                        lst[y - dy[direction]][x - dx[direction]] = 0; lst[y][x] = current; continue;
                    }
                    if (lst[y][x] != current)
                    {
                        if (direction == 0) { result = N - y; }
                        else if (direction == 1) { result = y + 1; }
                        else if (direction == 2) { result = x + 1; }
                        else if (direction == 3) { result = N - x; }
                        break;
                    }
                    if (lst[y][x] == current)
                    {
                        lst[y][x] *= 2; lst[y - dy[direction]][x - dx[direction]] = 0;
                        if (direction == 0) { result = N - y; }
                        else if (direction == 1) { result = y + 1; }
                        else if (direction == 2) { result = x + 1; }
                        else if (direction == 3) { result = N - x; }
                        break;
                    }
                }

                return result;
            }

            int MAX(List<List<int>> lst)
            {
                int result = 0;
                for (int y = 0; y < N; y++)
                {
                    for (int x = 0; x < N; x++)
                    {
                        if (lst[y][x] > result) result = lst[y][x];
                    }
                }

                return result;
            }

            List<List<int>> Create(List<List<int>> lst)
            {
                List<List<int>> resultLst = new List<List<int>>();
                for (int i = 0; i < N; i++)
                {
                    resultLst.Add(lst[i].ToList());
                }

                return resultLst;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}