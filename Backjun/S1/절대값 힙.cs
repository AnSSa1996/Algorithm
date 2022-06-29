using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJun
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            PriorityQ q = new PriorityQ();
            int repeat = int.Parse(sr.ReadLine());

            for (int i = 0; i < repeat; i++)
            {
                int num = int.Parse(sr.ReadLine());
                if (num == 0)
                {
                    sw.WriteLine(q.Pop());
                    continue;
                }
                q.Push(num);
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class PriorityQ
    {
        public List<int> _heap = new List<int>();

        public void Push(int data)
        {
            _heap.Add(data);

            int now = _heap.Count - 1;
            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (Math.Abs(_heap[now]).CompareTo(Math.Abs(_heap[next])) > 0 || (Math.Abs(_heap[now]) == Math.Abs(_heap[next]) && _heap[now] > _heap[next])) break;

                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }
        }

        // O(logN)
        public int Pop()
        {
            if (_heap.Count == 0) return 0;
            int ret = _heap[0];

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
                if (left <= lastIndex && (Math.Abs(_heap[next]).CompareTo(Math.Abs(_heap[left])) > 0 ||
                    (Math.Abs(_heap[next]) == Math.Abs(_heap[left]) && _heap[next] > _heap[left])))
                    next = left;

                if (right <= lastIndex && (Math.Abs(_heap[next]).CompareTo(Math.Abs(_heap[right])) > 0 ||
                    (Math.Abs(_heap[next]) == Math.Abs(_heap[right]) && _heap[next] > _heap[right])))
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

        public int Count()
        {
            return _heap.Count;
        }
    }
}
