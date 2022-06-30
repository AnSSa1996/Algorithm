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

            int T = int.Parse(sr.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());
                List<Tuple<int, int>> board = new List<Tuple<int, int>>();
                for (int a = 0; a < N; a++)
                {
                    int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    board.Add(new Tuple<int, int>(inputs[0], inputs[1]));
                }

                board.Sort((a, b) => a.Item1.CompareTo(b.Item1));

                int count = 1;
                int max = board[0].Item2;

                for (int index = 1; index < N; index++)
                {
                    if (board[index].Item2 < max)
                    {
                        max = board[index].Item2;
                        count++;
                    }
                    if (max == 1) break;
                }

                sw.WriteLine(count);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
