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

            Queue<int> q = new Queue<int>();

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

                if (strs[0] == "push") q.Enqueue(int.Parse(strs[1]));
                else if (strs[0] == "pop")
                {
                    if (q.Count == 0) sw.WriteLine(-1);
                    else sw.WriteLine(q.Dequeue());
                }
                else if (strs[0] == "size") sw.WriteLine(q.Count());
                else if (strs[0] == "empty")
                {
                    if (q.Count() == 0) sw.WriteLine(1);
                    else sw.WriteLine(0);
                }
                else if (strs[0] == "front")
                {
                    if (q.Count == 0) sw.WriteLine(-1);
                    else sw.WriteLine(q.Peek());
                }
                else if (strs[0] == "back")
                {
                    if (q.Count == 0) sw.WriteLine(-1);
                    else sw.WriteLine(q.Last());
                }
            }
        }
    }
}
