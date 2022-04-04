using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int[] alphabets = Enumerable.Repeat(-1, 26).ToArray();
            var str = sr.ReadLine();

            for (int i = 0; i < str.Length; i++)
            {
                if (alphabets[str[i] - 'a'] != -1) continue;
                alphabets[str[i] - 'a'] = i;
            }

            string result = string.Join(" ", alphabets);
            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
