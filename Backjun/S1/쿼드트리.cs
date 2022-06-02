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
            StringBuilder sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());
            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < N; i++) { board.Add(sr.ReadLine().ToList()); }


            recursive(0, 0, N);

            void recursive(int startY, int startX, int n)
            {
                char current = board[startY][startX];
                if (n == 1) { sb.Append(current); return; }

                bool check = true;
                for (int y = startY; y < startY + n; y++)
                {
                    for (int x = startX; x < startX + n; x++)
                    {
                        if (current != board[y][x])
                        {
                            check = false;
                        }
                    }
                }

                if (check == false)
                {
                    sb.Append('(');
                    recursive(startY, startX, n / 2);
                    recursive(startY, startX + n / 2, n / 2);
                    recursive(startY + n / 2, startX, n / 2);
                    recursive(startY + n / 2, startX + n / 2, n / 2);
                    sb.Append(')');
                    return;
                }
                sb.Append(current);
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
