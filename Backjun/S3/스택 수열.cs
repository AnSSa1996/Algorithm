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

            int N = int.Parse(sr.ReadLine());

            Stack<int> stack = new Stack<int>();
            int cnt = 1;

            StringBuilder sb = new StringBuilder();

            bool isCan = true;
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                while (true)
                {
                    if (stack.Count() == 0) { stack.Push(cnt++); sb.AppendLine("+"); continue; }
                    if (stack.Peek() < num) { stack.Push(cnt++); sb.AppendLine("+"); continue; }
                    else if (stack.Peek() == num) { stack.Pop(); sb.AppendLine("-"); break; }
                    else { isCan = false; break; }
                }
                if (isCan == false) break;
            }

            if (isCan == false) sw.WriteLine("NO");
            else sw.Write(sb);

            sw.Flush();
            sw.Close();
            
            sr.Close();
        }
    }
}