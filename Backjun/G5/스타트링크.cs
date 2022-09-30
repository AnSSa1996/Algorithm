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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int F = inputs[0]; int S = inputs[1]; int G = inputs[2]; int U = inputs[3]; int D = inputs[4];
            bool[] visited = new bool[F + 1];

            int result = -1;
            BFS();
            void BFS()
            {
                Queue<(int pos, int depth)> q = new Queue<(int pos, int depth)>();
                visited[S] = true;
                q.Enqueue((S, 0));

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var pos = current.pos;
                    var depth = current.depth;
                    if (pos == G)
                    {
                        result = depth;
                        break;
                    }

                    var nextUP = pos + U;
                    if (nextUP <= F && visited[nextUP] == false)
                    {
                        visited[nextUP] = true;
                        q.Enqueue((nextUP, depth + 1));
                    }

                    var nextDOWN = pos - D;
                    if (nextDOWN >= 1 && visited[nextDOWN] == false)
                    {
                        visited[nextDOWN] = true;
                        q.Enqueue((nextDOWN, depth + 1));
                    }
                }
            }

            if (result == -1)
            {
                sw.WriteLine("use the stairs");
            }
            else
            {
                sw.WriteLine(result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}