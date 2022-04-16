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

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                if (num == 0) stack.Pop();
                else stack.Push(num);
            }

            sw.WriteLine(stack.Sum());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
