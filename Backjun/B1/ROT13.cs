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
            StringBuilder sb = new StringBuilder();

            char[] charArray = sr.ReadLine().ToArray();

            foreach (char c in charArray) sb.Append(Encryption(c));

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static char Encryption(char c)
        {
            if (c == ' ' || (c >= '0' && c <= '9')) return c;
            else if (c >= 'A' && c <= 'Z')
            {
                char newChar = c + 13 <= 'Z' ? (char)(c + 13) : (char)(c - 13);
                return newChar;
            }
            else
            {
                char newChar = c + 13 <= 'z' ? (char)(c + 13) : (char)(c - 13);
                return newChar;
            }
        }
    }
}