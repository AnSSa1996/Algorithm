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
            int Y = inputs[0];
            int X = inputs[1];
            List<char[]> lst = new List<char[]>();

            for (int i = 0; i < Y; i++) lst.Add(sr.ReadLine().ToArray());

            for (int x = X - 1; x >= 0; x--)
            {
                StringBuilder tempSb = new StringBuilder();
                for (int y = 0; y < Y; y++)
                {
                    char c = changeChar(lst[y][x]);
                    tempSb.Append(c);
                }
                sw.WriteLine(tempSb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static char changeChar(char c)
        {
            if (c == '.') return '.';
            else if (c == 'O') return 'O';
            else if (c == '-') return '|';
            else if (c == '|') return '-';
            else if (c == '/') return '\\';
            else if (c == '\\') return '/';
            else if (c == '^') return '<';
            else if (c == '<') return 'v';
            else if (c == 'v') return '>';
            else return '^';

        }
    }
}