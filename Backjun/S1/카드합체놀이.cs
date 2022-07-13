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
            long[] nums = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            PriorityQue q = new PriorityQue();

            for (int i = 0; i < N; i++) q.Push(nums[i]);

            for (int i = 0; i < T; i++)
            {
                long sum = q.Pop() + q.Pop();
                q.Push(sum); q.Push(sum);
            }

            sw.WriteLine(q.Sum());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    class PriorityQue
    {
        List<long> heap = new List<long>();

        public void Push(long num)
        {
            heap.Add(num);

            int now = heap.Count - 1;

            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (heap[now].CompareTo(heap[next]) > 0) break;

                long temp = heap[now];
                heap[now] = heap[next];
                heap[next] = temp;

                now = next;
            }
        }

        public long Pop()
        {
            long ret = heap[0];

            int lastIndex = heap.Count - 1;
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;

            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;

                if (left <= lastIndex && heap[next].CompareTo(heap[left]) > 0)
                    next = left;
                if (right <= lastIndex && heap[next].CompareTo(heap[right]) > 0)
                    next = right;

                if (next == now) break;

                long temp = heap[now];
                heap[now] = heap[next];
                heap[next] = temp;

                now = next;
            }

            return ret;
        }

        public long Sum()
        {
            return heap.Sum();
        }
    }
}