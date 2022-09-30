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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] result = new int[N];
            Stack<(int NUM, int INDEX)> stack = new Stack<(int NUM, int INDEX)>();

            for (int index = 0; index < N; index++)
            {
                int num = nums[index];
                while (stack.Count > 0)
                {
                    if (stack.Peek().NUM >= num)
                    {
                        result[index] = stack.Peek().INDEX;
                        stack.Push((num, index + 1));
                        break;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                if (stack.Count == 0)
                {
                    stack.Push((num, index + 1));
                    result[index] = 0;
                    continue;
                }
            }

            sw.WriteLine(string.Join(' ', result));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}