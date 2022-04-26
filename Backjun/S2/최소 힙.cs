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

            int N = int.Parse(sr.ReadLine());

            PriorityQ q = new PriorityQ();
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());

                if (num == 0) sw.WriteLine(q.Dequene());
                else q.Enqueue(num);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class PriorityQ
    {
        List<int> heap = new List<int>();

        public void Enqueue(int n)
        {
            heap.Add(n);
            int current = heap.Count() - 1;

            while (current > 0)
            {
                int next = (current - 1) / 2;
                if (heap[current].CompareTo(heap[next]) > 0) break;

                int temp = heap[current];
                heap[current] = heap[next];
                heap[next] = temp;

                current = next;
            }
        }

        public int Dequene()
        {
            if (heap.Count == 0) return 0;
            int ret = heap[0];
            int lastIndex = heap.Count - 1;
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;

            while (true)
            {
                int left = now * 2 + 1;
                int right = now * 2 + 2;

                int next = now;
                // 왼쪽값이 현재값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && heap[next].CompareTo(heap[left]) > 0)
                    next = left;
                // 오른값이 현재값(왼쪽 이동 포함)보다 크면, 오른쪽으로 이동
                if (right <= lastIndex && heap[next].CompareTo(heap[right]) > 0)
                    next = right;

                // 왼쪽/오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값을 교체한다
                int temp = heap[now];
                heap[now] = heap[next];
                heap[next] = temp;
                // 검사 위치를 이동한다
                now = next;
            }

            return ret;
        }
    }
}