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

            string right = str.Substring(0, str.Length / 2);
            string left = str.Substring(str.Length / 2);

            int rightSum = right.ToArray().Sum(x => x - '0');
            int leftSum = left.ToArray().Sum(x => x - '0');

            if (rightSum == leftSum) sw.WriteLine("LUCKY");
            else sw.WriteLine("READY");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
