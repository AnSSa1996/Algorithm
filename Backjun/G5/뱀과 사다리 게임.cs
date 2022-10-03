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

            int L = inputs[0] + inputs[1];

            List<List<int>> lines = new List<List<int>>();
            for (int i = 0; i <= 100; i++) lines.Add(new List<int>());
            for (int i = 0; i < L; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                lines[inputs[0]].Add(inputs[1]);
            }

            BFS();

            void BFS()
            {
                Queue<(int pos, int depth)> q = new Queue<(int pos, int depth)>();
                q.Enqueue((1, 0));
                bool[] visited = new bool[101];
                visited[1] = true;
                int result = 0;
                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var pos = current.pos;
                    var depth = current.depth;
                    if (pos == 100)
                    {
                        result = depth;
                        break;
                    }

                    for (int dice = 1; dice <= 6; dice++)
                    {
                        var next = pos + dice;
                        if (next > 100) continue;
                        if (visited[next]) continue;
                        if (lines[next].Count > 0)
                        {
                            q.Enqueue((lines[next][0], depth + 1));
                            visited[lines[next][0]] = true;
                            continue;
                        }

                        visited[next] = true;
                        q.Enqueue((next, depth + 1));
                    }
                }

                sw.WriteLine(result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}