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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int K = inputs[1];

            int[,] board = new int[N, N];

            List<(int num, int y, int x)> lst = new List<(int num, int y, int x)>();
            for (int y = 0; y < N; y++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int x = 0; x < N; x++)
                {
                    board[y, x] = inputs[x];
                    if (inputs[x] != 0) lst.Add((inputs[x], y, x));
                }
            }
            lst.Sort((a, b) => a.num - b.num);

            inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int second = inputs[0]; int targetY = inputs[1]; int targetX = inputs[2];
            Queue<(int num, int y, int x)> q = new Queue<(int num, int y, int x)>(lst);

            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };
            for (int i = 0; i < second; i++)
            {
                List<(int num, int y, int x)> nextQ = new List<(int num, int y, int x)>();
                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var num = current.num;
                    var y = current.y;
                    var x = current.x;
                    for (int d = 0; d < 4; d++)
                    {
                        var nextY = y + dy[d];
                        var nextX = x + dx[d];

                        if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) continue;
                        if (board[nextY, nextX] != 0) continue;

                        board[nextY, nextX] = num;
                        nextQ.Add((num, nextY, nextX));
                    }
                }
                q = new Queue<(int num, int y, int x)>(nextQ);
            }

            sw.WriteLine(board[targetY - 1, targetX - 1]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
