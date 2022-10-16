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

            int N = int.Parse(sr.ReadLine());
            int[,] board = new int[N, N];

            int[] dx = new int[4] { 0, 0, 1, -1 };
            int[] dy = new int[4] { 1, -1, 0, 0 };

            Dictionary<int, List<int>> LikeStudentDict = new Dictionary<int, List<int>>();
            for (int i = 0; i < N * N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int currentStudent = inputs[0];
                LikeStudentDict.Add(currentStudent, inputs[1..].ToList());

                List<(int Like, int Blank, int H, int W)> lst = new List<(int Like, int Blank, int H, int W)>();

                for (int y = 0; y < N; y++)
                {
                    for (int x = 0; x < N; x++)
                    {
                        int like = 0;
                        int blank = 0;
                        if (board[y, x] != 0) continue;
                        for (int d = 0; d < 4; d++)
                        {
                            int nextY = y + dy[d];
                            int nextX = x + dx[d];

                            if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= N) continue;
                            if (board[nextY, nextX] == 0)
                            {
                                blank += 1;
                            }
                            if (LikeStudentDict[currentStudent].Contains(board[nextY, nextX]))
                            {
                                like += 1;
                            }
                            lst.Add((like, blank, y, x));
                        }
                    }
                }

                var current = lst.OrderByDescending(a => a.Like).ThenByDescending(b => b.Blank).ThenBy(c => c.H).ThenBy(d => d.W).First();
                board[current.H, current.W] = currentStudent;
            }

            int result = 0;

            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    int current = board[y, x];
                    int likeCount = 0;
                    for (int d = 0; d < 4; d++)
                    {
                        int nextY = y + dy[d];
                        int nextX = x + dx[d];
                        if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= N) continue;
                        if (LikeStudentDict[current].Contains(board[nextY, nextX]))
                        {
                            likeCount += 1;
                            continue;
                        }
                    }
                    if (likeCount >= 1) result += (int)Math.Pow(10, likeCount - 1);
                }
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
