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

            int result = 0;

            if (str[1] == 'x')
            {
                string sub = str.Substring(2);
                result = Convert.ToInt32(sub, 16);
            }
            else if (str[0] == '0')
            {
                string sub = str.Substring(1);
                result = Convert.ToInt32(sub, 8);
            }
            else
            {
                result = int.Parse(str);
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}