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

            int dasom = int.Parse(sr.ReadLine());
            PriorityQueue q = new PriorityQueue();

            for (int i = 1; i < N; i++) q.Push(int.Parse(sr.ReadLine()));

            int cnt = 0;
            while (q.Count() > 0)
            {
                int pop = q.Pop();
                if (dasom > pop) break;
                else
                {
                    cnt++;
                    dasom++;
                    q.Push(pop - 1);
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class PriorityQueue
    {
        List<int> heap = new List<int>();

        public void Push(int data)
        {
            heap.Add(data);

            int now = heap.Count - 1;

            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (heap[now] < heap[next]) break;

                int temp = heap[now];
                heap[now] = heap[next];
                heap[next] = temp;

                now = next;
            }
        }

        public int Pop()
        {
            int ret = heap[0];

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

                if (left <= lastIndex && heap[next] < heap[left])
                    next = left;
                if (right <= lastIndex && heap[next] < heap[right])
                    next = right;

                if (next == now) break;

                int temp = heap[now];
                heap[now] = heap[next];
                heap[next] = temp;

                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return heap.Count;
        }
    }
}
