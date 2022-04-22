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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                StringBuilder sb = new StringBuilder();
                Stack<char> left = new Stack<char>();
                Stack<char> right = new Stack<char>();

                string str = sr.ReadLine();

                foreach (var c in str)
                {
                    if (c == '<' && left.Count() >= 1) { right.Push(left.Pop()); }
                    else if (c == '>' && right.Count() >= 1) { left.Push(right.Pop()); }
                    else if (c == '-' && left.Count() >= 1) { left.Pop(); }
                    else if (c != '<' && c != '>' && c != '-') left.Push(c);
                }

                while (left.Count > 0) right.Push(left.Pop());
                while (right.Count > 0) sb.Append(right.Pop());

                sw.WriteLine(sb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}