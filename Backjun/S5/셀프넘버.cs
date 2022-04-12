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

            List<int> result = Enumerable.Range(1, 9999).ToList();

            for (int i = 1; i < 10000; i++)
            {
                int selfNum = i;
                string selfString = selfNum.ToString();
                for (int j = 0; j < selfString.Length; j++) selfNum += selfString[j] - '0';
                result.Remove(selfNum);
            }

            sw.WriteLine(string.Join("\n", result));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}