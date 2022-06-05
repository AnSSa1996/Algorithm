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
            for (int i = 0; i < N; i++)
            {
                List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                board.Add(lst);
            }

            for (int a = 0; a < N; a++)
            {
                for (int b = 0; b < N; b++)
                {
                    for (int c = 0; c < N; c++)
                    {
                        if (board[b][a] == 1 && board[a][c] == 1) board[b][c] = 1;
                    }
                }
            }

            for (int i = 0; i < N; i++) { sw.WriteLine(string.Join(" ", board[i])); }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
