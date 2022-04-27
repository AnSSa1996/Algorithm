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

            string str = sr.ReadLine();
            Stack<char> stack = new Stack<char>();

            int temp = 1;
            bool answer = true;
            int total = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (answer) check(str[i], i);
                else break;
            }
            void check(char c, int index)
            {
                if (c == '(') { temp *= 2; stack.Push(c); }
                else if (c == '[') { temp *= 3; stack.Push(c); }
                else if (c == ')')
                {
                    if (stack.Count < 1) { answer = false; return; }
                    if (stack.Pop() != '(') { answer = false; return; }
                    if (str[index - 1] == '(') total += temp;
                    temp /= 2;
                }
                else
                {
                    if (stack.Count < 1) { answer = false; return; }
                    if (stack.Pop() != '[') { answer = false; return; }
                    if (str[index - 1] == '[') total += temp;
                    temp /= 3;
                }
            }

            if (stack.Count > 1) answer = false;
            if (answer) sw.WriteLine(total);
            else sw.WriteLine(0);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}