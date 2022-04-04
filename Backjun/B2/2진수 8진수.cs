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
            StringBuilder sb = new StringBuilder();
            string bit = sr.ReadLine();

            int index = bit.Length;
            while (true)
            {
                if (index - 3 < 0)
                {
                    string str = bit.Substring(0, index);
                    if (str == "") break;
                    int num = Convert.ToInt32(str, 2);
                    sb.Append(num);
                    break;
                }
                else
                {
                    index -= 3;
                    string str = bit.Substring(index, 3);
                    int num = Convert.ToInt32(str, 2);
                    sb.Append(num);
                }
            }

            sw.WriteLine(new string(sb.ToString().Reverse().ToArray()));

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
