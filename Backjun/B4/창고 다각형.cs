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
            List<Tuple<int, int>> board = new List<Tuple<int, int>>();
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int pos = inputs[0]; int height = inputs[1];
                board.Add(new Tuple<int, int>(pos, height));
                board.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            }

            int maxIndex = board.FindIndex(x => x.Item2 == board.Max(a => a.Item2));

            int area = 0;
            int current = board[0].Item1;
            int h = board[0].Item2;
            for (int i = 1; i <= maxIndex; i++)
            {
                if (h <= board[i].Item2)
                {
                    area += (board[i].Item1 - current) * h;
                    current = board[i].Item1;
                    h = board[i].Item2;
                }
            }

            current = board[maxIndex].Item1;
            h = board[maxIndex].Item2;

            for (int i = maxIndex; i < N; i++)
            {
                if (h == board[i].Item2)
                {
                    area += (board[i].Item1 - current) * h;
                    current = board[i].Item1;
                }
            }

            area += h;

            current = board[N - 1].Item1 + 1;
            h = board[N - 1].Item2;
            for (int i = N - 1; i >= maxIndex; i--)
            {
                if (h < board[i].Item2)
                {
                    area += (current - board[i].Item1 - 1) * h;
                    current = board[i].Item1 + 1;
                    h = board[i].Item2;
                }
            }

            sw.WriteLine(area);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
