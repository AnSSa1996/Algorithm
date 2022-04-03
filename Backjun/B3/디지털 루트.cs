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
                if (str == "0") break;
                while (str.Length > 1)
                {
                    int sum = 0;
                    foreach (var s in str)
                    {
                        sum += s - '0';
                    }
                    str = sum.ToString();
                }
                sw.WriteLine(str);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
