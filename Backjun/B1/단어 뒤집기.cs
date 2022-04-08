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

            for (int i = 0; i < N; i++)
            {
                StringBuilder sb = new StringBuilder();
                string[] str = sr.ReadLine().Split();

                for (int j = 0; j < str.Length; j++)
                {
                    string newStr = new string(str[j].Reverse().ToArray());
                    if (j != (str.Length - 1)) sb.Append($"{newStr} ");
                    else sb.Append($"{newStr}");
                }
                sw.WriteLine(sb);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}