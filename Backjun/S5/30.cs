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

            charArray = charArray.OrderByDescending(x => x).ToArray();
            int sum = charArray.Sum(x => x - '0');

            if (charArray[charArray.Length - 1] == '0' && sum % 3 == 0)
            {
                sw.WriteLine(new string(charArray));
            }
            else sw.WriteLine(-1);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
