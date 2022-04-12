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

            str = str.Replace("c=", "a");
            str = str.Replace("c-", "a");
            str = str.Replace("dz=", "a");
            str = str.Replace("d-", "a");
            str = str.Replace("lj", "a");
            str = str.Replace("nj", "a");
            str = str.Replace("s=", "a");
            str = str.Replace("z=", "a");

            sw.WriteLine(str.Length);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}