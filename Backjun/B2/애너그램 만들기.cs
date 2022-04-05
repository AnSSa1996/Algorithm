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

            List<char> firstStr = sr.ReadLine().ToList();
            List<char> secondStr = sr.ReadLine().ToList();

            int count = 0;

            for (int i = 0; i < firstStr.Count(); i++)
            {
                char c = firstStr[i];
                if (secondStr.Contains(c))
                {
                    secondStr.Remove(c);
                    firstStr.Remove(c);
                    i--;
                }
            }

            sw.WriteLine(firstStr.Count() + secondStr.Count());

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
