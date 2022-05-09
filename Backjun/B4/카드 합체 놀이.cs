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
            int N = inputs[0]; int T = inputs[1];
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            PriorityQueue q = new PriorityQueue();
            for (int i = 0; i < N; i++) q.Push(nums[i]);

            for (int i = 0; i < T; i++)
            {
                long first = q.Pop(); long second = q.Pop();
                long sum = first + second;
                q.Push(sum); q.Push(sum);
            }

            sw.WriteLine(q.Sum());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    class PriorityQueue
    {
        List<long> _heap = new List<long>();

        public void Push(long data)
        {
            _heap.Add(data);

            int now = _heap.Count - 1;
            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) > 0)
                    break;

                long temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }
        }
        public long Pop()
        {
            long ret = _heap[0];

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
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) > 0)
                    next = left;
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) > 0)
                    next = right;
                if (next == now)
                    break;

                long temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }

            return ret;
        }

        public long Sum()
        {
            long sum = _heap.Sum();
            return sum;
        }
    }
}
