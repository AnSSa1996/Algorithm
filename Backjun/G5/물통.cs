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
            int A = inputs[0]; int B = inputs[1]; int C = inputs[2];
            bool[,] visited = new bool[A + 1, B + 1];

            List<int> answer = new List<int>();
            BFS();

            void BFS()
            {
                Queue<(int A, int B, int C)> q = new Queue<(int A, int B, int C)>();
                q.Enqueue((0, 0, C));

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var a = current.A;
                    var b = current.B;
                    var c = current.C;
                    if (visited[a, b] == false)
                    {
                        visited[a, b] = true;
                    }
                    else
                    {
                        continue;
                    }
                    if (a == 0) { answer.Add(c); }

                    int water = 0;
                    //A->B
                    water = Math.Min(a, B - b);
                    q.Enqueue((a - water, b + water, c));
                    //A->C
                    water = Math.Min(a, C - c);
                    q.Enqueue((a - water, b, c + water));
                    //B->A
                    water = Math.Min(b, A - a);
                    q.Enqueue((a + water, b - water, c));
                    //B->C
                    water = Math.Min(b, C - c);
                    q.Enqueue((a, b - water, c + water));
                    //C->A
                    water = Math.Min(A - a, c);
                    q.Enqueue((a + water, b, c - water));
                    //C->B
                    water = Math.Min(B - b, c);
                    q.Enqueue((a, b + water, c - water));
                }
            }

            answer.Sort();
            sw.WriteLine(string.Join(' ', answer));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}