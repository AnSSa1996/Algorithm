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
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StreamReader sr = new StreamReader(Console.OpenStandardInput());

            while (true)
            {
                Stack<char> stack = new Stack<char>();

                string str = sr.ReadLine();
                bool isCheck = true;

                if (str == ".") break;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '(') stack.Push('(');
                    else if (str[i] == '[') stack.Push('[');
                    else if (str[i] == ')')
                    {
                        if (stack.Count == 0) { isCheck = false; break; }
                        else if (stack.Pop() != '(') { isCheck = false; break; }
                    }
                    else if (str[i] == ']')
                    {
                        if (stack.Count == 0) { isCheck = false; break; }
                        else if (stack.Pop() != '[') { isCheck = false; break; }
                    }
                }

                if (stack.Count != 0) isCheck = false;

                if (isCheck) sw.WriteLine("yes");
                else sw.WriteLine("no");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
