using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());

            int count = 0;
            while (true)
            {
                if (3 * count * count + 3 * count + 1 >= N) break;
                count++;
            }

            sw.WriteLine(count+1);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
