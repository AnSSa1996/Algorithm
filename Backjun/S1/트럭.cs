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

            int N = inputs[0]; int L = inputs[1]; int W = inputs[2];

            int currentW = 0;

            inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Queue<int> trucks = new Queue<int>(inputs);
            Queue<int> q = new Queue<int>();

            int count = 1;
            while (true)
            {
                count++;
                if (trucks.Count() >= 1 && currentW + trucks.Peek() <= W)
                {
                    var w = trucks.Dequeue();
                    q.Enqueue(w);
                    currentW += w;
                }
                else
                {
                    q.Enqueue(0);
                }

                if (q.Count == L)
                {
                    var w = q.Dequeue();
                    currentW -= w;
                }

                if (trucks.Count == 0 && currentW == 0) break;
            }

            sw.WriteLine(count);
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}