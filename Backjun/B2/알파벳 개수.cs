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

            int[] alphabets = Enumerable.Repeat(0, 26).ToArray();

            var str = sr.ReadLine();

            for (int i = 0; i < str.Length; i++)
            {
                alphabets[str[i] - 'a']++;
            }

            string result = string.Join(" ", alphabets);
            sw.WriteLine(result);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
