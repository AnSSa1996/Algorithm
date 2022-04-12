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

            List<string> answerLst = new List<string>();
            string result = null;
            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                if (str == new string(str.Reverse().ToArray()))
                {
                    result = str;
                    break;
                }
                else if (answerLst.Contains(str))
                {
                    result = str;
                    break;
                }

                answerLst.Add(new string(str.Reverse().ToArray()));
            }

            sw.WriteLine($"{result.Length} {result[result.Length / 2]}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}