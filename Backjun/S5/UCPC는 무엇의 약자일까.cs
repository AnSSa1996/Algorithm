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
            char[] answer = new char[4] { 'U', 'C', 'P', 'C' };

            int index = 0;
            foreach (char c in charArray)
            {
                if (c == answer[index]) index++;
                if (index == 4) break;
            }

            if (index == 4) sw.WriteLine("I love UCPC");
            else sw.WriteLine("I hate UCPC");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
