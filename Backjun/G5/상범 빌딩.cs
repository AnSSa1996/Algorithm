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

            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int X = inputs[0]; int Y = inputs[1]; int Z = inputs[2];
                if (X == 0 && Y == 0 && Z == 0) break;

                char[,,] board = new char[X, Y, Z];

                List<(int X, int Y, int Z)> startPos = new List<(int X, int Y, int Z)>();
                List<(int X, int Y, int Z)> targetPos = new List<(int X, int Y, int Z)>();

                for (int x = 0; x < X; x++)
                {
                    for (int y = 0; y < Y; y++)
                    {
                        string str = sr.ReadLine();
                        for (int z = 0; z < Z; z++)
                        {
                            if (str[z] == 'S') startPos.Add((x, y, z));
                            if (str[z] == 'E') targetPos.Add((x, y, z));
                            board[x, y, z] = str[z];
                        }
                    }
                    sr.ReadLine();
                }

                bool[,,] visited = new bool[X, Y, Z];
                int result = 0;

                int[] dx = new int[6] { 1, -1, 0, 0, 0, 0 };
                int[] dy = new int[6] { 0, 0, 1, -1, 0, 0 };
                int[] dz = new int[6] { 0, 0, 0, 0, 1, -1 };

                void BFS()
                {
                    Queue<(int X, int Y, int Z, int Depth)> q = new Queue<(int X, int Y, int Z, int Depth)>();
                    q.Enqueue((startPos[0].X, startPos[0].Y, startPos[0].Z, 0));
                    visited[startPos[0].X, startPos[0].Y, startPos[0].Z] = true;

                    while (q.Count > 0)
                    {
                        var current = q.Dequeue();
                        var CX = current.X;
                        var CY = current.Y;
                        var CZ = current.Z;
                        var Depth = current.Depth;

                        if (CX == targetPos[0].X && CY == targetPos[0].Y && CZ == targetPos[0].Z)
                        {
                            result = Depth;
                            break;
                        }

                        for (int d = 0; d < 6; d++)
                        {
                            var nextX = CX + dx[d];
                            var nextY = CY + dy[d];
                            var nextZ = CZ + dz[d];

                            if (nextX < 0 || nextX >= X || nextY < 0 || nextY >= Y || nextZ < 0 || nextZ >= Z) continue;
                            if (visited[nextX, nextY, nextZ]) continue;
                            if (board[nextX, nextY, nextZ] == '#') continue;
                            q.Enqueue((nextX, nextY, nextZ, Depth + 1));
                            visited[nextX, nextY, nextZ] = true;
                        }
                    }
                }

                BFS();

                if (result == 0) sw.WriteLine($"Trapped!");
                else sw.WriteLine($"Escaped in {result} minute(s).");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}