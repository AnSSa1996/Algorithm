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

            for (int i = 0; i < N; i++)
            {
                Stack<int> stack = new Stack<int>();
                string str = sr.ReadLine();
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '(') stack.Push(1);
                    else
                    {
                        if (stack.Count() == 0)
                        {
                            sw.WriteLine("NO");
                            goto end;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                }

                if (stack.Count == 0) sw.WriteLine("YES");
                else sw.WriteLine("NO");
                end:;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
