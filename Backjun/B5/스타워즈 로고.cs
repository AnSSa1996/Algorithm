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

            sw.WriteLine("    8888888888  888    88888");
            sw.WriteLine("   88     88   88 88   88  88");
            sw.WriteLine("    8888  88  88   88  88888");
            sw.WriteLine("       88 88 888888888 88   88");
            sw.WriteLine("88888888  88 88     88 88    888888");
            sw.WriteLine();
            sw.WriteLine("88  88  88   888    88888    888888");
            sw.WriteLine("88  88  88  88 88   88  88  88");
            sw.WriteLine("88 8888 88 88   88  88888    8888");
            sw.WriteLine(" 888  888 888888888 88  88      88");
            sw.WriteLine("  88  88  88     88 88   88888888");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
