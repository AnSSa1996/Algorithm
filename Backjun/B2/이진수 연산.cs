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


            string A = sr.ReadLine();
            string B = sr.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < A.Length; i++) sb.Append((A[i] - '0') & (B[i] - '0'));
            sw.WriteLine(sb);
            sb.Clear();

            for (int i = 0; i < A.Length; i++) sb.Append((A[i] - '0') | (B[i] - '0'));
            sw.WriteLine(sb);
            sb.Clear();

            for (int i = 0; i < A.Length; i++) sb.Append((A[i] - '0') ^ (B[i] - '0'));
            sw.WriteLine(sb);
            sb.Clear();

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '0') sb.Append(1);
                else sb.Append(0);
            }
            sw.WriteLine(sb);
            sb.Clear();

            for (int i = 0; i < A.Length; i++)
            {
                if (B[i] == '0') sb.Append(1);
                else sb.Append(0);
            }
            sw.WriteLine(sb);
            sb.Clear();

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}