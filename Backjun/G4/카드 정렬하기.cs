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
            PriorityQueue q = new PriorityQueue();
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                q.Enqueue(num);
            }

            int result = 0;
            for (int i = 1; i < N; i++)
            {
                int num = q.Dequeue() + q.Dequeue();
                result += num;
                q.Enqueue(num);
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class PriorityQueue
    {
        List<int> _heap = new List<int>();

        public void Enqueue(int num)
        {
            _heap.Add(num);
            int myIndex = _heap.Count() - 1;

            while (true)
            {
                int parentIndex = (myIndex - 1) / 2;
                if (_heap[myIndex].CompareTo(_heap[parentIndex]) < 0)
                {
                    var temp = _heap[myIndex];
                    _heap[myIndex] = _heap[parentIndex];
                    _heap[parentIndex] = temp;
                    myIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }


        public int Dequeue()
        {
            int lastIndex = _heap.Count() - 1;
            int last = _heap[lastIndex];

            var temp = _heap[0];
            _heap[0] = _heap[lastIndex];
            _heap[lastIndex] = temp;

            _heap.RemoveAt(lastIndex--);
            int myIndex = 0;

            while (true)
            {
                var tempIndex = myIndex;
                int left = 2 * myIndex + 1;
                int right = 2 * myIndex + 2;

                if (left <= lastIndex && _heap[myIndex].CompareTo(_heap[left]) > 0)
                {
                    myIndex = left;
                }
                if (right <= lastIndex && _heap[myIndex].CompareTo(_heap[right]) > 0)
                {
                    myIndex = right;
                }

                if (tempIndex == myIndex) break;

                var tempNum = _heap[tempIndex];
                _heap[tempIndex] = _heap[myIndex];
                _heap[myIndex] = tempNum;
            }

            return temp;
        }

        public int Count()
        {
            return _heap.Count();
        }
    }
}