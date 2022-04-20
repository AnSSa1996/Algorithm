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


            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            Stack<int> stack = new Stack<int>();

            int start = 1;
            for (int i = 0; i < N; i++)
            {
                while (true)
                {
                    if (stack.Count == 0) break;
                    if (stack.Peek() == start) { stack.Pop(); start++; }
                    else break;
                }
                int num = inputs[i];
                if (num == start) { start++; continue; }
                else stack.Push(num);
            }

            while (true)
            {
                if (stack.Count == 0) break;
                if (stack.Peek() == start) { stack.Pop(); start++; }
                else break;
            }

            if (stack.Count > 0) sw.WriteLine("Sad");
            else sw.WriteLine("Nice");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
