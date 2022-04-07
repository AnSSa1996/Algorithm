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

            int caseCount = 1;
            while (true)
            {
                string[] str = sr.ReadLine().Split();
                string op = str[1];
                if (op == "E") break;
                int A = int.Parse(str[0]);
                int B = int.Parse(str[2]);

                if (check(A, B, op)) sw.WriteLine($"Case {caseCount}: true");
                else sw.WriteLine($"Case {caseCount}: false");
                caseCount++;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static bool check(int left, int right, string op)
        {
            if (op == ">") return left > right;
            else if (op == ">=") return left >= right;
            else if (op == "<") return left < right;
            else if (op == "<=") return left <= right;
            else if (op == "==") return left == right;
            else return left != right;
        }
    }
}