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

            Stack<int> stack = new Stack<int>();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                process(str);
            }

            sw.Flush();
            sw.Close();
            sr.Close();

            void process(string str)
            {
                string[] strs = str.Split();

                if (strs[0] == "push") stack.Push(int.Parse(strs[1]));
                else if (strs[0] == "pop")
                {
                    if (stack.Count() == 0) sw.WriteLine(-1);
                    else sw.WriteLine(stack.Pop());
                }
                else if (strs[0] == "size") sw.WriteLine(stack.Count());
                else if (strs[0] == "empty")
                {
                    if (stack.Count() == 0) sw.WriteLine(1);
                    else sw.WriteLine(0);
                }
                else
                {
                    if (stack.Count() == 0) sw.WriteLine(-1);
                    else sw.WriteLine(stack.Peek());
                }
            }
        }
    }
}
