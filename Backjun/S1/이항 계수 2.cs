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
            int N = inputs[0]; int K = inputs[1];
            List<List<int>> board = new List<List<int>>();

            for (int i = 1; i <= (N + 1); i++)
            {
                List<int> lst = Enumerable.Repeat(1, i).ToList();
                board.Add(lst);
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0) board[i][j] = 1;
                    else if (j == i) board[i][j] = 1;
                    else
                    {
                        board[i][j] = board[i - 1][j - 1] % 10007 + board[i - 1][j] % 10007;
                    }
                }
            }

            sw.WriteLine(board[N][K] % 10007);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
