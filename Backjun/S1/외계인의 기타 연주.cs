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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int Y = inputs[0]; int X = inputs[1];
            List<Stack<int>> stack = new List<Stack<int>>();
            for (int i = 0; i < 7; i++) stack.Add(new Stack<int>());

            int count = 0;
            for (int i = 0; i < Y; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int a = inputs[0]; int b = inputs[1];
                while (true)
                {
                    if (stack[a].Count == 0) { count++; stack[a].Push(b); break; }
                    if (stack[a].Peek() == b) { break; }
                    if (stack[a].Peek() < b) { count++; stack[a].Push(b); continue; }
                    stack[a].Pop(); count++;
                }
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}