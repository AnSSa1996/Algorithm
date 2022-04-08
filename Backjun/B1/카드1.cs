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
            Queue<int> q = new Queue<int>(Enumerable.Range(1, N).ToArray());
            List<int> result = new List<int>();

            while (true)
            {
                result.Add(q.Dequeue());
                if (q.Count == 0) break;
                q.Enqueue(q.Dequeue());
            }

            sw.WriteLine(string.Join(" ", result));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}