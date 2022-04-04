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

            string str = sr.ReadLine();

            char current = str[0];
            int height = 10;

            for (int i = 1; i < str.Length; i++)
            {
                if (current == str[i]) height += 5;
                else
                {
                    current = str[i];
                    height += 10;
                }
            }

            sw.WriteLine(height);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
