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

            int N = int.Parse(sr.ReadLine());

            List<(int start, int end)> lst = new List<(int start, int end)>();
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                lst.Add((inputs[0], inputs[1]));
            }
            lst.Sort((a, b) => a.start.CompareTo(b.start));


            PriorityQueue q = new PriorityQueue();
            q.Push(lst[0].end);
            for (int i = 1; i < N; i++)
            {
                if (lst[i].start < q.Peek())
                {
                    q.Push(lst[i].end);
                }
                else
                {
                    q.Pop();
                    q.Push(lst[i].end);
                }
            }

            sw.WriteLine(q.Count());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    class PriorityQueue
    {
        List<int> _heap = new List<int>();

        public int Count() { return _heap.Count(); }

        public void Push(int num)
        {
            _heap.Add(num);
            int now = _heap.Count - 1;
            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) > 0)
                    break;

                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }
        }

        public int Pop()
        {
            int ret = _heap[0];
            int lastIndex = _heap.Count() - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) > 0)
                    next = left;
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) > 0)
                    next = right;
                if (next == now)
                    break;
                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                now = next;
            }
            return ret;
        }

        public int Peek()
        {
            return _heap[0];
        }
    }
}