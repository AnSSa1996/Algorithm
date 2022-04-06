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

            while (true)
            {
                string str = sr.ReadLine();
                if (str == "#") break;
                char alpha = str[0];
                string sentence = str.Substring(1).ToLower();

                int count = sentence.Count(x => x == alpha);
                sw.WriteLine($"{alpha} {count}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}