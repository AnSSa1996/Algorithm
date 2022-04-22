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
            Stack<int> stack = new Stack<int>();

            int total = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(') stack.Push(1);
                else
                {
                    stack.Pop();
                    if (str[i - 1] == '(')
                        total += stack.Count();
                    else total++;
                }
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}