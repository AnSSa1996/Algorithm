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
            char[] temp = new char[charArray.Length];
            Array.Copy(charArray, temp, charArray.Length);
            int N = charArray.Length;

            List<string> lst = new List<string>();

            for (int a = 1; a <= N - 2; a++)
            {
                for (int b = 1; b <= N - a - 1; b++)
                {
                    Array.Reverse(temp, 0, a);
                    Array.Reverse(temp, a, b);
                    Array.Reverse(temp, a + b, N - a - b);
                    lst.Add(new string(temp));
                    Array.Copy(charArray, temp, charArray.Length);
                }
            }

            lst.Sort();
            sw.WriteLine(lst.First());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
