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

            int N = int.Parse(sr.ReadLine());
            while (true)
            {
                string ope = sr.ReadLine();
                if (ope == "=") break;
                int nextN = int.Parse(sr.ReadLine());

                if (ope == "+") N += nextN;
                else if (ope == "-") N -= nextN;
                else if (ope == "*") N *= nextN;
                else if (ope == "/") N /= nextN;
            }

            sw.WriteLine(N);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
