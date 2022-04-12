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

            Queue<int> bit = new Queue<int>();

            while (true)
            {
                if (N == 0) break;
                bit.Enqueue(N % 2);
                N /= 2;
            }


            long result = 0;
            for (int i = bit.Count() - 1; i >= 0; i--)
            {
                int multiply = (int)Math.Pow(2, i);
                result += bit.Dequeue() * multiply;
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}