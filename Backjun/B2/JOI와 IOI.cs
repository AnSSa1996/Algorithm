using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string str = sr.ReadLine();

            int JOI_Count = 0;
            int IOI_Count = 0;
            for (int i = 0; i < str.Length - 2; i++)
            {
                string tempStr = str.Substring(i, 3);
                if (tempStr == "JOI") JOI_Count++;
                else if (tempStr == "IOI") IOI_Count++;
            }

            sw.WriteLine(JOI_Count);
            sw.WriteLine(IOI_Count);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
