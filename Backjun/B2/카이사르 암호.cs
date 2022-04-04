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
            var newStr = str.ToArray().Select(x => x - 3 >= 'A' ? (char)(x - 3) : (char)(x + 23)).ToArray();

            sw.WriteLine(new string(newStr));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
