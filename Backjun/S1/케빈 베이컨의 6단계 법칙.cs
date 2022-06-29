using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJun
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int users = inputs[0]; int repeat = inputs[1];

            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < users; i++) { board.Add(Enumerable.Repeat(1000000, users).ToList()); }

            for (int i = 0; i < repeat; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int start = inputs[0] - 1; int end = inputs[1] - 1;

                board[start][end] = 1;
                board[end][start] = 1;
            }

            for (int pass = 0; pass < users; pass++)
            {
                for (int start = 0; start < users; start++)
                {
                    for (int end = 0; end < users; end++)
                    {
                        if (start == end)
                        {
                            board[start][end] = 0;
                            continue;
                        }
                        if (board[start][pass] + board[pass][end] < board[start][end])
                        {
                            board[start][end] = board[start][pass] + board[pass][end];
                        }
                    }
                }
            }
            var result = board.Select((item, index) => new { item, index }).OrderBy(a => a.item.Sum()).Select(a => a.index);
            sw.WriteLine(result.First() + 1);


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
