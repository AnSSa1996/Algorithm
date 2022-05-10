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

            int T = int.Parse(sr.ReadLine());

            int[] dx = new int[4] { 0, -1, 0, 1 };
            int[] dy = new int[4] { 1, 0, -1, 0 };
            // 왼쪽이면 +1 오른쪽 -1

            for (int i = 0; i < T; i++)
            {
                string str = sr.ReadLine();
                List<Tuple<int, int>> board = new List<Tuple<int, int>>();
                int X = 0;
                int Y = 0;
                int d = 0;
                board.Add(new Tuple<int, int>(Y, X));
                for (int j = 0; j < str.Length; j++)
                {
                    char c = str[j];
                    if (c == 'B')
                    {
                        int td = (d + 2) % 4;
                        Y += dy[td]; X += dx[td];
                        board.Add(new Tuple<int, int>(Y, X));
                    }
                    else if (c == 'F')
                    {
                        Y += dy[d]; X += dx[d];
                        board.Add(new Tuple<int, int>(Y, X));
                    }
                    else if (c == 'L') { d = (d + 1) % 4; }
                    else if (c == 'R') { d = (d - 1) < 0 ? 3 : d - 1; }

                }

                var ySort = board.OrderBy(x => x.Item1);
                int yLength = ySort.Last().Item1 - ySort.First().Item1;

                var xSort = board.OrderBy(x => x.Item2);
                int xLength = xSort.Last().Item2 - xSort.First().Item2;

                sw.WriteLine(yLength * xLength);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
