using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
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
                string[] strs = sr.ReadLine().Split();
                int index = int.Parse(strs[0]) - 1;
                List<char> charArray = strs[1].ToList();
                charArray.RemoveAt(index);

                sw.WriteLine(new string(charArray.ToArray()));
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
