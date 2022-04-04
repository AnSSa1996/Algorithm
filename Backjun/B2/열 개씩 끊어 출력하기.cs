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

            string str = sr.ReadLine();

            int index = 0;
            int length = str.Length - 1;
            while (true)
            {
                int currentLength = (index + 10) > length ? length - index + 1 : 10;
                sw.WriteLine(str.Substring(index, currentLength));
                if (currentLength < 10) break;
                index += 10;
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
