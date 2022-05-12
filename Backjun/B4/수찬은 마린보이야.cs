using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            if (sr.ReadLine() == "0") sw.WriteLine("divide by zero");
            else sw.WriteLine("1.00");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
