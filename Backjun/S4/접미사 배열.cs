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

            string str = sr.ReadLine();
            List<string> lst = new List<string>();

            for (int i = 0; i < str.Length; i++) lst.Add(str.Substring(i, str.Length - i));

            lst.Sort();

            sw.WriteLine(string.Join("\n", lst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
