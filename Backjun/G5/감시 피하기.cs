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

            char[,] board = new char[N, N];
            List<(int Y, int X)> T_List = new List<(int Y, int X)>();
            bool check = false;
            for (int y = 0; y < N; y++)
            {
                char[] inputs = Array.ConvertAll(sr.ReadLine().Split(), char.Parse);
                for (int x = 0; x < N; x++)
                {
                    board[y, x] = inputs[x];
                    if (inputs[x] == 'T')
                    {
                        T_List.Add((y, x));
                    }
                }
            }

            DFS(0);

            void DFS(int count)
            {
                if (check) return;

                if (count == 3)
                {
                    check = Check();
                    return;
                }

                for (int y = 0; y < N; y++)
                {
                    for (int x = 0; x < N; x++)
                    {
                        if (board[y, x] == 'X')
                        {
                            board[y, x] = 'O';
                            DFS(count + 1);
                            board[y, x] = 'X';
                        }
                    }
                }
            }

            bool Check()
            {
                int[] dx = new int[4] { 1, -1, 0, 0 };
                int[] dy = new int[4] { 0, 0, 1, -1 };

                foreach (var T in T_List)
                {
                    int y = T.Y;
                    int x = T.X;

                    var nextY = y;
                    var nextX = x;
                    // 오른쪽 검사
                    while (true)
                    {
                        nextX = nextX + dx[0];
                        nextY = nextY + dy[0];
                        if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) break;
                        if (board[nextY, nextX] == 'T') break;
                        if (board[nextY, nextX] == 'O') break;
                        if (board[nextY, nextX] == 'S') return false;
                    }

                    nextY = y;
                    nextX = x;
                    // 왼쪽 검사
                    while (true)
                    {
                        nextX = nextX + dx[1];
                        nextY = nextY + dy[1];
                        if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) break;
                        if (board[nextY, nextX] == 'T') break;
                        if (board[nextY, nextX] == 'O') break;
                        if (board[nextY, nextX] == 'S') return false;
                    }

                    nextY = y;
                    nextX = x;
                    // 위쪽 검사
                    while (true)
                    {
                        nextX = nextX + dx[2];
                        nextY = nextY + dy[2];
                        if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) break;
                        if (board[nextY, nextX] == 'T') break;
                        if (board[nextY, nextX] == 'O') break;
                        if (board[nextY, nextX] == 'S') return false;
                    }

                    nextY = y;
                    nextX = x;
                    // 아래쪽 검사
                    while (true)
                    {
                        nextX = nextX + dx[3];
                        nextY = nextY + dy[3];
                        if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) break;
                        if (board[nextY, nextX] == 'T') break;
                        if (board[nextY, nextX] == 'O') break;
                        if (board[nextY, nextX] == 'S') return false;
                    }
                }
                return true;
            }

            if (check) sw.WriteLine("YES");
            else sw.WriteLine("NO");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
