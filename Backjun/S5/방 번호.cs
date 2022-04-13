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

            int[] numsArray = new int[10];
            char[] charArray = sr.ReadLine().ToArray();

            foreach (char c in charArray)
            {
                if (c == '9') numsArray[6]++;
                else numsArray[c - '0']++;
            }

            numsArray[6] = (numsArray[6] + 1) / 2;

            sw.WriteLine(numsArray.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
