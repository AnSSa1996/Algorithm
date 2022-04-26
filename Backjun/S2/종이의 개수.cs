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
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(-1, 0); dict.Add(0, 0); dict.Add(1, 0);
            List<int[]> board = new List<int[]>();
            for (int i = 0; i < N; i++) { board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse)); }

            recursive(0, 0, N);

            for (int i = -1; i < 2; i++) { sw.WriteLine(dict[i]); }

            void recursive(int startY, int startX, int n)
            {
                int current = board[startY][startX];
                if (n == 1) { dict[current]++; return; }
                for (int y = startY; y < (startY + n); y++)
                {
                    for (int x = startX; x < (startX + n); x++)
                    {
                        if (current != board[y][x]) goto end;
                    }
                }
                dict[current]++; return;

            end:
                int nextN = n / 3;
                recursive(startY, startX, nextN);
                recursive(startY + nextN, startX, nextN);
                recursive(startY + nextN * 2, startX, nextN);
                recursive(startY, startX + nextN, nextN);
                recursive(startY, startX + nextN * 2, nextN);
                recursive(startY + nextN, startX + nextN, nextN);
                recursive(startY + nextN, startX + nextN * 2, nextN);
                recursive(startY + nextN * 2, startX + nextN, nextN);
                recursive(startY + nextN * 2, startX + nextN * 2, nextN);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}