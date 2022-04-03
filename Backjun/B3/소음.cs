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

            string left = sr.ReadLine();
            string ope = sr.ReadLine();
            string right = sr.ReadLine();

            string result = null;

            if (left.Length < right.Length)
            {
                var temp = left;
                left = right;
                right = temp;
            }

            if (ope == "+")
            {
                if (left.Length == right.Length)
                {
                    result = $"2{string.Concat(Enumerable.Repeat("0", left.Length - 1))}";
                }
                else
                {
                    result = $"1{string.Concat(Enumerable.Repeat("0", left.Length - right.Length - 1))}{right}";
                }
            }
            else
            {
                result = $"1{string.Concat(Enumerable.Repeat("0", left.Length + right.Length - 2))}";
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
