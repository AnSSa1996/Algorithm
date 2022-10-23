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

            Stack<int> stack = new Stack<int>();
            int result = 0;
            for (int i = 0; i < N; i++)
            {
                int height = int.Parse(sr.ReadLine());
                while (stack.Count() >= 1 && stack.Peek() <= height)
                {
                    stack.Pop();
                }
                stack.Push(height);

                result += stack.Count() - 1;
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
