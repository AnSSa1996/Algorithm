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

            char[] charArray = sr.ReadLine().ToArray();

            int zero = 0;
            int one = 0;

            if (charArray[0] == '0') one++;
            else zero++;

            char currentChar = charArray[0];
            for (int i = 1; i < charArray.Length; i++)
            {
                if (currentChar != charArray[i])
                {
                    if (charArray[i] == '0') one++;
                    else zero++;
                    currentChar = charArray[i];
                }
            }

            sw.WriteLine(Math.Min(zero, one));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
