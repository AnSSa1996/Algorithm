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
            int cnt = 0;
            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                Stack<char> stack = new Stack<char>();
                for (int j = 0; j < str.Length; j++)
                {
                    char c = str[j];
                    if (stack.Count == 0) stack.Push(c);
                    else if (stack.Peek() == c) stack.Pop();
                    else stack.Push(c);
                }

                if (stack.Count() == 0) cnt++;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
