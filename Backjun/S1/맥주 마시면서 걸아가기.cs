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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());

                int startX = 0; int startY = 0;
                int endX = 0; int endY = 0;
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                Dictionary<Tuple<int, int>, bool> visited = new Dictionary<Tuple<int, int>, bool>();
                startX = inputs[0]; startY = inputs[1];
                List<Tuple<int, int>> board = new List<Tuple<int, int>>();
                visited.Add(new Tuple<int, int>(startX, startY), true);
                board.Add(new Tuple<int, int>(startX, startY));
                for (int a = 0; a < N; a++)
                {
                    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    board.Add(new Tuple<int, int>(inputs[0], inputs[1]));
                    visited.Add(new Tuple<int, int>(inputs[0], inputs[1]), false);
                }
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                endX = inputs[0]; endY = inputs[1];
                visited.Add(new Tuple<int, int>(endX, endY), false);
                board.Add(new Tuple<int, int>(endX, endY));

                var check = StartBFS(visited, board, startX, startY, endX, endY);
                if (check) sw.WriteLine("happy");
                else sw.WriteLine("sad");
            }



            sw.Flush();
            sw.Close();
            sr.Close();
        }

        static bool StartBFS(Dictionary<Tuple<int, int>, bool> visited, List<Tuple<int, int>> board, int startX, int StartY, int endX, int endY)
        {
            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(startX, StartY));
            bool check = false;
            while (q.Count > 0)
            {
                Pos currentPos = q.Dequeue();
                int X = currentPos.X;
                int Y = currentPos.Y;

                if (X == endX && Y == endY) { check = true; break; }
                var nexts = visited.Where(x => x.Value == false && Math.Abs(x.Key.Item1 - X) + Math.Abs(x.Key.Item2 - Y) <= 1000)
                    .Select(x => (X: x.Key.Item1, Y: x.Key.Item2)).ToList();

                foreach (var next in nexts)
                {
                    q.Enqueue(new Pos(next.X, next.Y));
                    visited[new Tuple<int, int>(next.X, next.Y)] = true;
                }
            }

            return check;
        }
    }

    public class Pos
    {
        public int X = 0;
        public int Y = 0;
        public Pos(int x, int y) { X = x; Y = y; }
    }
}