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

            int num = int.Parse(sr.ReadLine());
            int result = num;

            if(result == 0)
            {
                result = 1;
                num = 1;
            }
            while (true)
            {
                num--;
                if (num == 0) break;
                result *= num;
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
