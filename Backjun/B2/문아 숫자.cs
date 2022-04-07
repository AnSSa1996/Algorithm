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

            while (true)
            {
                string str = sr.ReadLine();
                if (str == "#") break;
                int total = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    int multiply = (int)Math.Pow(8, str.Length - i - 1);
                    int num = isCheck(str[i]);
                    total += num * multiply;
                }
                sw.WriteLine(total);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int isCheck(char c)
        {
            switch (c)
            {
                case '-':
                    return 0;
                case '\\':
                    return 1;
                case '(':
                    return 2;
                case '@':
                    return 3;
                case '?':
                    return 4;
                case '>':
                    return 5;
                case '&':
                    return 6;
                case '%':
                    return 7;
                default:
                    return -1;
            }
        }
    }
}