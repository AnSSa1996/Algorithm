using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int V = inputs[0]; int E = inputs[1];

            List<List<(int S, int D)>> lst = new List<List<(int S, int D)>>();
            for (int i = 0; i <= V; i++) lst.Add(new List<(int S, int D)>());
            for (int i = 0; i < E; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                lst.Add((inputs[0], inputs[1], inputs[2]));
                lst.Add((inputs[1], inputs[0], inputs[2]));
            }

            PriorityQueue<Line> pq = new PriorityQueue<Line>();
            Line firstLine = new Line();
            firstLine.Current = lst[1].A;
            firstLine.Next = lst[1].B;
            firstLine.Distance = lst[1].C;

            pq.Push(firstLine);
            bool[] visited = new bool[V + 1];

            long answer = 0;
            int count = 0;

            while (pq.Count() > 0)
            {
                if (count == V) break;
                var current = pq.Pop();

                if (!visited[current.Next])
                {
                    visited[current.Next] = true;
                    answer += current.Distance;
                    count++;

                    foreach (var next in lst[current.Next])
                    {
                        pq.Push(next);
                    }
                }
            }

            sw.WriteLine(answer);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    class Line : IComparable<Line>
    {
        public int Current;
        public int Next;
        public int Distance;

        public int CompareTo([AllowNull] Line other)
        {
            if (Distance == other.Distance)
                return 0;
            return Distance > other.Distance ? 1 : -1;
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public void Push(T data)
        {
            _heap.Add(data);

            int now = _heap.Count - 1;
            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                now = next;
            }
        }

        public T Pop()
        {
            T ret = _heap[0];

            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;
                if (next == now)
                    break;

                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }
}