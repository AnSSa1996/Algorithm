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

            while (true)
            {
                string str = sr.ReadLine();
                if (str == "0") break;
                int total = 0;
                for (int i = str.Length; i > 0; i--)
                {
                    int num = str[str.Length - i] - '0';
                    int temp = i;
                    int multiply = 1;
                    while (temp > 0)
                    {
                        multiply *= temp--;
                    }

                    total += num * multiply;
                }
                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
