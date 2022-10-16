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
            int INF = 10000000;
            int N = int.Parse(sr.ReadLine());
            int[,] board = new int[N + 1, N + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    board[i, j] = INF;
                }
            }
            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (inputs[0] == -1 && inputs[1] == -1) break;
                board[inputs[0], inputs[1]] = 1;
                board[inputs[1], inputs[0]] = 1;
            }

            for (int i = 1; i <= N; i++) board[i, i] = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    for (int k = 1; k <= N; k++)
                    {
                        if (j == k) continue;
                        if (board[j, i] == INF || board[i, k] == INF) continue;
                        if (board[j, k] > board[j, i] + board[i, k])
                            board[j, k] = board[j, i] + board[i, k];
                    }
                }
            }

            List<(int player, int score)> lst = new List<(int player, int score)>();
            for (int i = 1; i <= N; i++)
            {
                int result = 0;
                for (int j = 1; j <= N; j++)
                {
                    if (result < board[i, j])
                        result = board[i, j];
                }
                lst.Add((i, result));
            }

            int min = lst.Min(x => x.score);
            var ResultPlayers = lst.Where(x => x.score == min);

            sw.WriteLine($"{min} {ResultPlayers.Count()}");
            sw.WriteLine($"{string.Join(' ', ResultPlayers.Select(x => x.player))}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
