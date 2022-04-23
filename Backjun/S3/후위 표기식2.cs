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
            string str = sr.ReadLine();

            List<int> num = new List<int>();
            for (int i = 0; i < N; i++) num.Add(int.Parse(sr.ReadLine()));


            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (c >= 'A' && c <= 'Z') stack.Push(num[c - 'A']);
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    if (c == '*') stack.Push(a * b);
                    else if (c == '/') stack.Push(a / b);
                    else if (c == '+') stack.Push(a + b);
                    else stack.Push(a - b);
                }
            }

            sw.WriteLine($"{stack.Pop():f2}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}