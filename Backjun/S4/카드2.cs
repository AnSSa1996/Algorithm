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
            List<int> nums = Enumerable.Range(1, N).ToList();
            Queue<int> q = new Queue<int>();
            nums.ForEach(x => q.Enqueue(x));

            while (true)
            {
                if (q.Count == 1) break;
                q.Dequeue();
                q.Enqueue(q.Dequeue());
            }

            sw.WriteLine(q.First());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
