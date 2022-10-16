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
            List<(int X, int Y)> board = new List<(int X, int Y)>();
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                board.Add((inputs[0], inputs[1]));
            }

            board.Sort((a, b) => a.X.CompareTo(b.X));

            int Start = board[0].X;
            int End = board[0].Y;
            int length = End - Start;
            for (int i = 1; i < N; i++)
            {
                var current = board[i];
                int X = current.X;
                int Y = current.Y;

                if (End > Y) continue;

                if (X <= End)
                {
                    if (Y < End) continue;
                    length += Y - End;
                    End = Y;
                    continue;
                }

                if (X > End)
                {
                    Start = X;
                    End = Y;
                    length += Y - X;
                    continue;
                }
            }

            sw.WriteLine(length);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
