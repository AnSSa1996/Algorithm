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

            List<char> charArray = sr.ReadLine().ToList();
            char[] vows = new char[5] { 'a', 'e', 'i', 'o', 'u' };

            for (int index = 0; index < charArray.Count; index++)
            {
                if (vows.Contains(charArray[index]))
                {
                    charArray.RemoveRange(index + 1, 2);
                }
            }

            sw.WriteLine(new string(charArray.ToArray()));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}