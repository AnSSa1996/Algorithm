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
            int N = inputs[0]; int M = inputs[1];

            bool[] visited = new bool[1000001];

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(N, 0));

            int result = 0;
            visited[N] = true;
            while (q.Count > 0)
            {
                Pos curPos = q.Dequeue();
                int curN = curPos.P;
                int curDepth = curPos.Depth;
                if (curN == M) { result = curDepth; break; }
                if (curN < 0) continue;
                if (curN > 500000) continue;

                visited[curN] = true;
                if (curN - 1 >= 0 && visited[curN - 1] != true)
                    q.Enqueue(new Pos(curN - 1, curDepth + 1));
                if (visited[curN + 1] != true)
                    q.Enqueue(new Pos(curN + 1, curDepth + 1));
                if (visited[curN * 2] != true)
                    q.Enqueue(new Pos(curN * 2, curDepth + 1));
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class Pos
    {
        public int P;
        public int Depth;
        public Pos(int p, int depth) { P = p; Depth = depth; }
    }
}
